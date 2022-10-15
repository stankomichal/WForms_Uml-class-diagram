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
            AddClass();
            AddClass();
            //AddClass();
            RelationModel rel = new RelationModel(ClassList[0]);
            RelationList.Add(rel);
            rel.ToClass = ClassList[1];
            ClassList[1].LeftTop = new Point(300, 300);
            //RelationList.Add(new RelationModel(ClassList[1]));
        }
        // Add class to class list and make it selected
        public void AddClass() {
            ClassModel classModel = new ClassModel("Class" + classCount);
            classCount++;
            this.ClassList.Add(classModel);
            this.CurrentlySelectedItem = classModel;
        }
        public void AddRelation() {
            RelationModel relation = new(this.CurrentlySelectedItem as ClassModel);
            this.RelationList.Add(relation);
            //this.CurrentlySelectedItem = relation;
        }
        public void RemoveClass() {
            ConfirmForm form = new ConfirmForm("Are you sure you want to remove this class?");

            if (form.ShowDialog() == DialogResult.OK) {
                ClassModel removeClass = this.CurrentlySelectedItem as ClassModel;
                for (int i = 0; i < this.RelationList.Count;) {
                    if (this.RelationList[i].FromClass == removeClass || this.RelationList[i].ToClass == removeClass)
                        this.RelationList.RemoveAt(i);
                    else
                        i++;
                }

                this.ClassList.Remove(removeClass);
                this.CurrentlySelectedItem = null;
                deselectAction?.Invoke();
            }
        }
        // Draw all classes and relations
        public void Draw(Graphics g) {
            foreach (var classModel in this.ClassList) {
                classModel.Draw(g);
            }
            foreach (var relationModel in this.RelationList) {
                relationModel.Draw(g);
            }
        }
        // MouseHandler
        public ClickType MouseHandler(int x, int y) {
            // If we have alredy something selected
            if (this.CurrentlySelectedItem as ClassModel != null) {
                if (this.CurrentlySelectedItem.ClickOnMe(x, y) != ClickType.NONE)
                    return this.CurrentlySelectedItem.ClickOnMe(x, y);


            }
            if (this.CurrentlySelectedItem != null) {
                this.CurrentlySelectedItem.Selected = false;
                this.CurrentlySelectedItem = null;
            }
            // Find if we clicked on something else
            for (int i = this.ClassList.Count - 1; i >= 0; i--) {
                if (this.ClassList[i].ClickOnMe(x, y) == ClickType.MOVE) {
                    // If yes - make it top layer and make it selected
                    this.ClassList.Add(this.ClassList[i]);

                    this.CurrentlySelectedItem = this.ClassList[i];
                    this.CurrentlySelectedItem.Selected = true;

                    this.ClassList.RemoveAt(i);
                    return ClickType.MOVE;
                }
            }
            for (int i = this.RelationList.Count - 1; i >= 0; i--) {
                if (this.RelationList[i].ClickOnMe(x,y) == ClickType.MOVE) {

                    this.CurrentlySelectedItem = this.RelationList[i];
                    this.CurrentlySelectedItem.Selected = true;

                    return ClickType.MOVE;
                }
            }


            // Invoke delesect Action to inform form that we want it to deselect - make sidebar invisible
            deselectAction?.Invoke();
            return ClickType.NONE;
        }

        public void RemoveRelation() {
            ConfirmForm form = new ConfirmForm("Are you sure you want to remove this relation?");

            if (form.ShowDialog() == DialogResult.OK) {
                this.RelationList.Remove(this.CurrentlySelectedItem as RelationModel);

                this.CurrentlySelectedItem = null;
                deselectAction?.Invoke();
            }
        }
    }
}
