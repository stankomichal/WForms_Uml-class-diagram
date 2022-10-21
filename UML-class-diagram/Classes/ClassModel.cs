using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UML_class_diagram.Classes.RelationLines;

namespace UML_class_diagram.Classes {
    public class ClassModel : SelectItem {
        /// <summary>
        /// Name of the class
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// List of all Properties
        /// </summary>
        public List<Property> Properties { get; set; }
        /// <summary>
        /// List of all Functions
        /// </summary>
        public List<Function> Functions { get; set; }
        /// <summary>
        /// Is class abstract
        /// </summary>
        public bool IsAbstract { get; set; }

        /// <summary>
        /// Left top point for draw
        /// </summary>
        public Point LeftTop;
        /// <summary>
        /// Right bottom point for draw
        /// </summary>
        public Point RightBottom => new Point(LeftTop.X + width, LeftTop.Y + height);
        /// <summary>
        /// Width of class container - counted when redraw
        /// </summary>
        private int width;
        /// <summary>
        /// Getter for width
        /// </summary>
        public int Width => width;
        /// <summary>
        /// Height of class container - counted when redraw
        /// </summary>
        private int height;
        /// <summary>
        /// Getter for height
        /// </summary>
        public int Height => height;
        /// <summary>
        /// Is class selected
        /// </summary>
        public override bool Selected { get; set; }
        /// <summary>
        /// Diagram settings for colors and fonts
        /// </summary>
        private DiagramSettings diagramSettings = DiagramSettings.GetInstance();

        #region Images
        private readonly Image imageTrash = UML_class_diagram.Properties.Resources.trash;
        private readonly Image imageUp = UML_class_diagram.Properties.Resources.up_arrow;
        private readonly Image imageDown = UML_class_diagram.Properties.Resources.down_arrow;
        private readonly Image imageLeft = UML_class_diagram.Properties.Resources.left_arrow;
        private readonly Image imageRight = UML_class_diagram.Properties.Resources.right_arrow;
        #endregion

        public ClassModel(string className) {
            // Set properties
            this.ClassName = className;
            this.Properties = new();
            this.Functions = new();
            this.IsAbstract = false;
            this.Selected = true;

            // Testing
            this.Properties.Add(new Property(AccessModifier.PUBLIC, new NameDataTypePair("asd", "string")));
            this.Properties.Add(new Property(AccessModifier.PRIVATE, new NameDataTypePair("asd", "string")));
            this.Properties.Add(new Property(AccessModifier.PUBLIC, new NameDataTypePair("asdddddasd", "string")));
            this.Properties.Add(new Property(AccessModifier.PROTECTED, new NameDataTypePair("asd", "yxcyc")));
            this.Properties.Add(new Property(AccessModifier.PUBLIC, new NameDataTypePair("asd", "int")));

            this.Functions.Add(
                new Function(AccessModifier.PUBLIC,
                new NameDataTypePair("func1", "void"),
                new List<NameDataTypePair>()));
            this.Functions.Add(
                new Function(AccessModifier.PUBLIC,
                new NameDataTypePair("func2", "void"),
                new List<NameDataTypePair>() { new("arg", "string"), new("arg1", "int") }));
            // /Testing

            // Starting position of the class container
            this.LeftTop = new Point(30, 30);
            // Get instance of diagram settings
            this.diagramSettings = DiagramSettings.GetInstance();
        }
        /// <summary>
        /// Draw class to picture box
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="xOffset">X offset of the diagram to move starting positions</param>
        /// <param name="yOffset">Y offset of the diagram to move starting positions</param>
        public void Draw(Graphics g) {
            // Measure height of the font
            int fontHeight = g.MeasureString(this.ClassName, diagramSettings.ClassFont).ToSize().Height;
            // Measure width of the longest string
            int tempWidth = LongestWordSize(g);
            width = tempWidth < 120 ? 120 : tempWidth;
            // Measure height with font Height and number of lines
            height = fontHeight * (1 + this.Properties.Count + this.Functions.Count);
            // Temporary point to have point where to draw
            Point tempPoint = LeftTop;
            // Find position X to middle class name
            int nameX = (tempPoint.X + (width / 2)) - (g.MeasureString(this.ClassName, diagramSettings.ClassFont).ToSize().Width / 2);

            // Draw rectangle for class and set background color according to selected
            g.FillRectangle(this.Selected ? diagramSettings.SelectClassColor : diagramSettings.ClassColor, tempPoint.X, tempPoint.Y, width, height + 2);
            // Draw border around rectangle
            g.DrawRectangle(Pens.DarkViolet, tempPoint.X, tempPoint.Y, width, height + 2);
            // Draw class name
            g.DrawString(this.ClassName, IsAbstract ? diagramSettings.AbstractClassFont : diagramSettings.ClassFont, diagramSettings.FontColor, nameX, tempPoint.Y);

            // If there are any properties
            if (this.Properties.Count != 0) {
                // Draw divider 
                g.DrawLine(Pens.Gray, tempPoint.X, tempPoint.Y + fontHeight, tempPoint.X + width - 1, tempPoint.Y + fontHeight);

                // Draw all properties
                foreach (var item in this.Properties) {
                    tempPoint.Y += fontHeight;
                    g.DrawString(item.ToString(), diagramSettings.ClassFont, diagramSettings.FontColor, tempPoint);
                }
            }
            // If there are any functions
            if (this.Functions.Count != 0) {
                // Draw divider 
                g.DrawLine(Pens.Gray, tempPoint.X, tempPoint.Y + fontHeight, tempPoint.X + width - 1, tempPoint.Y + fontHeight);

                // Draw all functions
                foreach (var item in this.Functions) {
                    tempPoint.Y += fontHeight;
                    g.DrawString(item.ToString(), diagramSettings.ClassFont, diagramSettings.FontColor, tempPoint);
                }
            }

            // If class is selected, draw trash and arrows
            if (this.Selected) {
                g.DrawImage(imageTrash, LeftTop.X + width - 20, LeftTop.Y - 25, 20, 20);
                g.DrawImage(imageUp, LeftTop.X + (width / 2 - 10), LeftTop.Y - 25, 20, 20);
                g.DrawImage(imageDown, LeftTop.X + (width / 2 - 10), LeftTop.Y + height + 8, 20, 20);
                g.DrawImage(imageLeft, LeftTop.X - 25, LeftTop.Y + (height / 2 - 10), 20, 20);
                g.DrawImage(imageRight, LeftTop.X + width + 5, LeftTop.Y + (height / 2 - 10), 20, 20);
            }
        }
        /// <summary>
        /// Get type of click on given positions
        /// </summary>
        /// <param name="x">X position of the class</param>
        /// <param name="y">Y position of the class</param>
        /// <returns></returns>
        public override ClickType ClickOnMe(int x, int y) {
            // If clicked inside of the container - MOVE
            if ((x >= LeftTop.X && x <= LeftTop.X + width) && (y >= LeftTop.Y && y <= LeftTop.Y + height))
                return ClickType.MOVE;

            // If the class is selected - another conditions for icons
            if (this.Selected) {
                // If we clicked on trash icon - DELETE
                if ((x >= LeftTop.X + width - 20 && x <= LeftTop.X + width) && (y >= LeftTop.Y - 25 && y <= LeftTop.Y - 5))
                    return ClickType.DELETE;

                // If we clicked on TOP ARROW - RELATION
                if ((x >= LeftTop.X + (width / 2 - 5) && x <= LeftTop.X + (width / 2 + 15)) && (y >= LeftTop.Y - 25 && y <= LeftTop.Y - 5))
                    return ClickType.RELATION;

                // If we clicked on BOTTOM ARROW - RELATION
                if ((x >= LeftTop.X + (width / 2 - 5) && x <= LeftTop.X + (width / 2 + 15)) && (y >= LeftTop.Y + height + 8 && y <= LeftTop.Y + height + 28))
                    return ClickType.RELATION;

                // If we clicked on LEFT ARROW - RELATION
                if ((x >= LeftTop.X - 25 && x <= LeftTop.X - 5) && (y >= LeftTop.Y + (height / 2 - 10) && y <= LeftTop.Y + (height / 2 + 10)))
                    return ClickType.RELATION;

                // If we clicked on RIGHT ARROW - RELATION
                if ((x >= LeftTop.X + width + 5 && x <= LeftTop.X + width + 25) && (y >= LeftTop.Y + (height / 2 - 10) && y <= LeftTop.Y + (height / 2 + 10)))
                    return ClickType.RELATION;
            }

            // Else - NONE
            return ClickType.NONE;
        }
        /// <summary>
        /// Returns length of the longest word
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <returns>Length of the longest word</returns>
        private int LongestWordSize(Graphics g) {
            int size = g.MeasureString(this.ClassName, diagramSettings.ClassFont).ToSize().Width;

            // Find longest size from all properties
            foreach (var prop in this.Properties) {
                int temp = g.MeasureString(prop.ToString(), diagramSettings.ClassFont).ToSize().Width;
                if (temp > size)
                    size = temp;
            }
            // Find longest size from all functions
            foreach (var func in this.Functions) {
                int temp = g.MeasureString(func.ToString(), diagramSettings.ClassFont).ToSize().Width;
                if (temp > size)
                    size = temp;
            }
            return size;
        }

        /// <summary>
        /// Method to move LeftTop point by "x" and "y" offset and return if we can move or not
        /// </summary>
        /// <param name="x">X position of the cursor</param>
        /// <param name="y">Y position of the cursor</param>
        /// <param name="width">Width of the picture box</param>
        /// <param name="height">Width of the picture box</param>
        /// <returns>Return if we can move or not</returns>
        public override bool Move(int x, int y, int width, int height) {
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

        /// <summary>
        /// Set sidebar of the form with class
        /// </summary>
        /// <param name="form">Form to be filled</param>
        public override void FillSidebar(Form1 form) {
            // Make sidebar visible
            form.panel_ClassProperties.Visible = true;
            form.panel_DiagramProperties.Visible = false;
            form.panel_RelationProperties.Visible = false;

            // Set class name textbox to selected class name
            form.textBox_ClassName.Text = this.ClassName;

            // Clear lists so we have empty lists that we use will fill
            form.listBox_Props.Items.Clear();
            form.listBox_Funcs.Items.Clear();

            // If class is abstract - check checkbox
            form.checkBox_Abstract.Checked = this.IsAbstract;
            // Fill Properties list with items in selected class properties
            foreach (var item in this.Properties)
                form.listBox_Props.Items.Add(item);
            // Fill Functions list with items in selected class functions
            foreach (var item in this.Functions)
                form.listBox_Funcs.Items.Add(item);

            // This is not reference, we fill both lists so our changes are not immediately written to our selected class
        }
    }
    public enum ClickType {
        NONE,
        MOVE,
        RELATION,
        DELETE
    }

}
