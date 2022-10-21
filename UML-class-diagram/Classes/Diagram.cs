using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class Diagram {
        /// <summary>
        /// List of all classes
        /// </summary>
        public List<ClassModel> ClassList { get; set; }
        /// <summary>
        /// List of all relations
        /// </summary>
        public List<RelationModel> RelationList { get; set; }
        /// <summary>
        /// Reference to selected class
        /// </summary>
        public SelectItem CurrentlySelectedItem { get; set; }
        /// <summary>
        /// Action to invoke deselect in form
        /// </summary>
        [NonSerialized]
        public Action deselectAction;

        /// <summary>
        /// Count for naming new classes
        /// </summary>
        private int classCount = 1;


        public Diagram() {
            // Setup lists
            this.ClassList = new();
            this.RelationList = new();
            DiagramSettings.GetInstance().LoadSettings();
        }

        /// <summary>
        /// Add class to class list and make it selected
        /// </summary>
        public void AddClass() {
            ClassModel classModel = new ClassModel("Class" + classCount);
            classCount++;
            this.ClassList.Add(classModel);
            this.CurrentlySelectedItem = classModel;
        }
        /// <summary>
        /// Add relation to relation list and make it selected
        /// </summary>
        public void AddRelation() {
            RelationModel relation = new(this.CurrentlySelectedItem as ClassModel);
            this.RelationList.Add(relation);
            //this.CurrentlySelectedItem = relation;
        }
        /// <summary>
        /// Remove selected class from class list
        /// </summary>
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
        /// <summary>
        /// Remove selected relation from relation list
        /// </summary>
        public void RemoveRelation() {
            ConfirmForm form = new ConfirmForm("Are you sure you want to remove this relation?");

            if (form.ShowDialog() == DialogResult.OK) {
                this.RelationList.Remove(this.CurrentlySelectedItem as RelationModel);

                this.CurrentlySelectedItem = null;
                deselectAction?.Invoke();
            }
        }
        /// <summary>
        /// Draw all classes and relations
        /// </summary>
        /// <param name="g">Graphics</param>
        public void Draw(Graphics g) {
            foreach (var classModel in this.ClassList) {
                classModel.Draw(g);
            }
            foreach (var relationModel in this.RelationList) {
                relationModel.Draw(g);
            }
        }
        /// <summary>
        /// MouseHandler
        /// </summary>
        /// <param name="x">X position of the cursor</param>
        /// <param name="y">Y position of the cursor</param>
        /// <returns>Returns click type</returns>
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
                if (this.RelationList[i].ClickOnMe(x, y) == ClickType.MOVE) {

                    this.CurrentlySelectedItem = this.RelationList[i];
                    this.CurrentlySelectedItem.Selected = true;

                    return ClickType.MOVE;
                }
            }


            // Invoke delesect Action to inform form that we want it to deselect - make sidebar invisible
            return ClickType.NONE;
        }
    }
}
