using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class Diagram {
        public List<ClassModel> ClassList { get; set; }
        public List<RelationModel> RelationList { get; set; }

        public ClassModel CurrentlySelectedClass { get; set; }

        private Graphics _graphics;
        private int _width;
        private int _height;

        public Diagram(Graphics graphics, int width, int height) {
            this.ClassList = new();
            this.RelationList = new();
            this._graphics = graphics;
            this._width = width;
            this._height = height;
        }
        public void AddClass() {
            ClassModel classModel = new ClassModel("Class" + (this.ClassList.Count + 1), _width / 2, _height / 2);
            this.ClassList.Add(classModel);
            this.CurrentlySelectedClass = classModel;
        }

        public void Draw(Graphics g) {
            foreach (var classModel in this.ClassList) {
                classModel.Draw(g);
            }
        }
        public bool CheckSelect(int x, int y) {
            this.CurrentlySelectedClass = null;

            for (int i = this.ClassList.Count - 1; i >= 0; i--) {
                if (this.ClassList[i].SelectMe(x, y)) {
                    this.CurrentlySelectedClass = this.ClassList[i];
                    this.CurrentlySelectedClass.selected = true;
                    return true;
                }
            }
            return false;
        }
    }
}
