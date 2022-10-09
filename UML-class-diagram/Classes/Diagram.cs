using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class Diagram {
        // List of all classes
        public List<ClassModel> ClassList { get; set; }
        // List of all relations
        public List<RelationModel> RelationList { get; set; }
        // Reference to selected class
        public ClassModel CurrentlySelectedClass { get; set; }

        public Diagram() {
            this.ClassList = new();
            this.RelationList = new();
        }
        // Add class to class list and make it selected
        public void AddClass() {
            ClassModel classModel = new ClassModel("Class" + (this.ClassList.Count + 1));
            this.ClassList.Add(classModel);
            this.CurrentlySelectedClass = classModel;
        }
        public void RemoveClass() {

        }
        // Draw all classes and relations
        public void Draw(Graphics g) {
            foreach (var classModel in this.ClassList) {
                classModel.Draw(g);
            }
        }
        // Check if there is anything under cursor
        // If yes, make it on top layer
        public bool CheckSelect(int x, int y) {
            this.CurrentlySelectedClass = null;

            for (int i = this.ClassList.Count - 1; i >= 0; i--) {
                if (this.ClassList[i].SelectMe(x, y)) {
                    this.ClassList.Add(this.ClassList[i]);

                    this.CurrentlySelectedClass = this.ClassList[i];
                    this.CurrentlySelectedClass.selected = true;

                    this.ClassList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
