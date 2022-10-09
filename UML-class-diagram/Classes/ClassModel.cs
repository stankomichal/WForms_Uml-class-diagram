using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UML_class_diagram.Classes {
    public class ClassModel {
        // Name of class
        public string ClassName { get; set; }
        // List of all Properties
        public BindingList<string> Properties { get; set; }
        // List of all Functions
        public BindingList<string> Functions { get; set; }
        // Is it abstract
        public bool IsAbstract { get; set; }

        // Left top point for draw
        public Point LeftTop;
        // Width of class container - counted when redraw
        private int width;
        private int height;
        // Diagram settings for colors and fonts
        private DiagramSettings diagramSettings = DiagramSettings.GetInstance();
        // Is this class selected - for changing background
        public bool selected = true;
        // Height of font for drawing each line
        private int fontHeight;

        public ClassModel(string className) {
            this.ClassName = className;
            this.Properties = new();
            this.Functions = new();
            this.IsAbstract = false;

            this.Properties.Add("+ asd : string");
            this.Properties.Add("- asd: string");
            this.Properties.Add("+ asd:string");
            this.Properties.Add("# asd :int");

            this.Functions.Add("+ asd() : void");
            this.Functions.Add("-asdasd(test : int) : int");
            this.Functions.Add("-asdasd(test : int, asd : bool, test : array):bool");

            LeftTop = new Point(10, 10);
        }
        public void Draw(Graphics g) {
            // Measure height of the font
            fontHeight = g.MeasureString(this.ClassName, diagramSettings.ClassFont).ToSize().Height;
            // Measure width of the longest string
            width = LongestWorldSize(g);
            // Measure height with font Height and number of lines
            height = this.fontHeight * (1 + this.Properties.Count + this.Functions.Count);
            // Temporary point to have point where to draw
            Point tempPoint = LeftTop;
            // Find position X to middle class name
            int nameX = (tempPoint.X + (width / 2)) - (g.MeasureString(this.ClassName, diagramSettings.ClassFont).ToSize().Width / 2);

            // Draw rectangle for class and set background color according to selected
            g.FillRectangle(selected ? diagramSettings.SelectClassColor : diagramSettings.ClassColor, tempPoint.X, tempPoint.Y, width, height + 2);
            // Draw border around rectangle
            g.DrawRectangle(Pens.DarkViolet, tempPoint.X, tempPoint.Y, width, height + 2);
            // Draw class name
            g.DrawString(this.ClassName, IsAbstract ? diagramSettings.AbstractClassFont : diagramSettings.ClassFont, diagramSettings.FontColor, nameX, tempPoint.Y);

            // If there are any properties
            if (this.Properties.Count != 0) {
                // Draw divider 
                g.DrawLine(Pens.Gray, tempPoint.X, tempPoint.Y + fontHeight, tempPoint.X + width - 1, tempPoint.Y + fontHeight);

                // Draw all properties
                foreach (string item in this.Properties) {
                    tempPoint.Y += this.fontHeight;
                    g.DrawString(item, diagramSettings.ClassFont, diagramSettings.FontColor, tempPoint);
                }
            }
            // If there are any functions
            if (this.Functions.Count != 0) {
                // Draw divider 
                g.DrawLine(Pens.Gray, tempPoint.X, tempPoint.Y + fontHeight, tempPoint.X + width - 1, tempPoint.Y + fontHeight);

                // Draw all functions
                foreach (string item in this.Functions) {
                    tempPoint.Y += this.fontHeight;
                    g.DrawString(item, diagramSettings.ClassFont, diagramSettings.FontColor, tempPoint);
                }
            }


        }
        // Method to find if cursor position is inside class container
        public bool SelectMe(int x, int y) => (x >= LeftTop.X && x <= LeftTop.X + width) && (y >= LeftTop.Y && y <= LeftTop.Y + height);
        private int LongestWorldSize(Graphics g) {
            int size = g.MeasureString(this.ClassName, diagramSettings.ClassFont).ToSize().Width;

            foreach (string prop in this.Properties) {
                int temp = g.MeasureString(prop, diagramSettings.ClassFont).ToSize().Width;
                if (temp > size)
                    size = temp;
            }
            foreach (string method in this.Functions) {
                int temp = g.MeasureString(method, diagramSettings.ClassFont).ToSize().Width;
                if (temp > size)
                    size = temp;
            }
            return size;
        }

        // Method to move LeftTop point by "x" and "y" offset
        public bool ChangeStartPoint(int x, int y, int width, int height) {
            if ((this.LeftTop.X + x) < 0)
                return false;
            if ((this.LeftTop.Y + y) < 0)
                return false;
            if ((this.LeftTop.X + this.width + x) > width - 3)
                return false;
            if ((this.LeftTop.Y + this.height + y) > height - 5)
                return false;

            this.LeftTop.X += x;
            this.LeftTop.Y += y;
            return true;
        }
    }
}
