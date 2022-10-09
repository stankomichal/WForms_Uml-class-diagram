using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class Diagram {
        public List<ClassModel> ClassList { get; set; } // List of all classes
        public List<RelationModel> RelationList { get; set; } // List of all relations
        public SelectItem CurrentlySelectedItem { get; set; } // Reference to selected class
        public event Action deselectAction; // Action to invoke deselect in form

        private int classCount = 1; // Count for naming new classes
        public Diagram() {
            // Setup lists
            this.ClassList = new();
            this.RelationList = new();
        }
        // Add class to class list and make it selected
        public void AddClass() {
            ClassModel classModel = new ClassModel("Class" + classCount);
            classCount++;
            this.ClassList.Add(classModel);
            this.CurrentlySelectedItem = classModel;
        }
        public void RemoveClass() {
            ConfirmForm form = new ConfirmForm("Are you sure you want to remove this class?");

            if (form.ShowDialog() == DialogResult.OK) {
                this.ClassList.Remove(this.CurrentlySelectedItem as ClassModel);
                this.CurrentlySelectedItem = null;
                deselectAction?.Invoke();
            }
        }
        // Draw all classes and relations
        public void Draw(Graphics g) {
            foreach (var classModel in this.ClassList) {
                classModel.Draw(g);
            }
        }
        // MouseHandler
        public bool MouseHandler(int x, int y) {
            // If we have alredy something selected
            if (this.CurrentlySelectedItem as ClassModel != null) {
                switch (this.CurrentlySelectedItem.ClickOnMe(x, y)) {
                    case ClickType.MOVE:
                        return true;
                    case ClickType.RELATION:
                        return false;
                    case ClickType.DELETE:
                        RemoveClass();
                        return false;
                    case ClickType.NONE:
                    default:
                        this.CurrentlySelectedItem.Selected = false;
                        this.CurrentlySelectedItem = null;
                        break;
                }
            }
            // Find if we clicked on something else
            for (int i = this.ClassList.Count - 1; i >= 0; i--) {
                if (this.ClassList[i].ClickOnMe(x, y) == ClickType.MOVE) {
                    // If yes - make it top layer and make it selected
                    this.ClassList.Add(this.ClassList[i]);

                    this.CurrentlySelectedItem = this.ClassList[i];
                    this.CurrentlySelectedItem.Selected = true;

                    this.ClassList.RemoveAt(i);
                    return true;
                }
            }

            // Invoke delesect Action to inform form that we want it to deselect - make sidebar invisible
            deselectAction?.Invoke();
            return false;
        }
    }
}
