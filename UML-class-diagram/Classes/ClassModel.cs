using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UML_class_diagram.Classes {
    public class ClassModel {
        public string ClassName { get; set; }
        public BindingList<string> Properties { get; set; }
        public BindingList<string> Methods { get; set; }

        public Point LeftTop;
        public Point RightBottom => new(LeftTop.X + width, LeftTop.Y + height);
        private int width;
        private int height => offset.Height * (1 + this.Properties.Count + this.Methods.Count);
        private DiagramSettings diagramSettigns = DiagramSettings.GetInstance();
        public bool selected = true;
        private Size offset;



        public ClassModel(string className, int x, int y) {
            this.ClassName = className;
            this.Properties = new();
            this.Methods = new();

            this.Properties.Add("+ asd : string");
            this.Properties.Add("- asd: string");
            this.Properties.Add("+ asd:string");
            this.Properties.Add("# asd :int");

            this.Methods.Add("+ asd()");
            this.Methods.Add("-asdasd(int)");
            this.Methods.Add("-asdasd(int, bool, array):bool");

            LeftTop = new Point(x - (width / 2), y - 10);
        }
        public void Draw(Graphics g) {
            width = LongestWorldSize(g);
            offset = g.MeasureString(this.ClassName, diagramSettigns.ClassFont).ToSize();

            Point tempPoint = LeftTop;
            int nameX = (tempPoint.X + (width / 2)) - (g.MeasureString(this.ClassName, diagramSettigns.ClassFont).ToSize().Width / 2);
            int nameY = tempPoint.Y;

            g.FillRectangle(selected ? diagramSettigns.SelectClassColor : diagramSettigns.ClassColor, tempPoint.X, tempPoint.Y, width, height + 2);
            g.DrawString(this.ClassName, diagramSettigns.ClassFont, diagramSettigns.FontColor, nameX, nameY);
            if (selected)
                g.DrawRectangle(Pens.DarkViolet, tempPoint.X, tempPoint.Y, width, height + 2);






            if (this.Properties.Count != 0) {
                g.DrawLine(Pens.Gray, tempPoint.X, tempPoint.Y + offset.Height, tempPoint.X + width - 1, tempPoint.Y + offset.Height);

                foreach (string item in this.Properties) {
                    tempPoint.Y += this.offset.Height;
                    g.DrawString(item, diagramSettigns.ClassFont, diagramSettigns.FontColor, tempPoint);
                }
            }

            if (this.Methods.Count != 0) {
                g.DrawLine(Pens.Gray, tempPoint.X, tempPoint.Y + offset.Height, tempPoint.X + width - 1, tempPoint.Y + offset.Height);

                foreach (string item in this.Methods) {
                    tempPoint.Y += this.offset.Height;
                    g.DrawString(item, diagramSettigns.ClassFont, diagramSettigns.FontColor, tempPoint);
                }
            }
        }
        public bool SelectMe(int x, int y) => (x >= LeftTop.X && x <= LeftTop.X + width) && (y >= LeftTop.Y && y <= LeftTop.Y + height);
        private int LongestWorldSize(Graphics g) {
            int size = g.MeasureString(this.ClassName, diagramSettigns.ClassFont).ToSize().Width;

            foreach (string prop in this.Properties) {
                int temp = g.MeasureString(prop, diagramSettigns.ClassFont).ToSize().Width;
                if (temp > size)
                    size = temp;
            }
            foreach (string method in this.Methods) {
                int temp = g.MeasureString(method, diagramSettigns.ClassFont).ToSize().Width;
                if (temp > size)
                    size = temp;
            }
            return size;
        }

        public bool ChangeStartPoint(int x, int y, int width, int height) {
            if ((this.LeftTop.X + x) < 0)
                return false;
            if ((this.LeftTop.Y + y) < 0)
                return false;
            if ((this.RightBottom.X + x) > width - 3)
                return false;
            if ((this.RightBottom.Y + y) > height - 5)
                return false;


            this.LeftTop.X += x;
            this.LeftTop.Y += y;
            return true;
        }
    }
}
