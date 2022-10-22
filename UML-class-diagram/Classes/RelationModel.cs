using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_class_diagram.Classes.RelationLines;

namespace UML_class_diagram.Classes {
    public class RelationModel : SelectItem {
        public override bool Selected { get; set; }
        private DiagramSettings diagramSettings = DiagramSettings.GetInstance(); // Diagram settings for colors and fonts
        public ClassModel FromClass { get; set; }
        public ClassModel ToClass { get; set; }
        public string CardinalityFrom { get; set; } = "";
        public string CardinalityTo { get; set; } = "";
        public Line LineType { get; set; }

        private Point Start;
        private Point End;
        private Point? Break;
        private const int offset = 5;
        public RelationModel(ClassModel fromClass) {
            this.FromClass = fromClass;
            this.Selected = true;
        }

        public override ClickType ClickOnMe(int x, int y) {
            if (this.Selected || this.ToClass is null)
                return ClickType.NONE;
            Point leftTop = new();
            Point rightBottom = new();
            if (this.Break is null) {
                if (this.Start.X == this.End.X) {
                    if (this.Start.Y > this.End.Y) {
                        leftTop = this.End;
                        leftTop.X -= offset;
                        rightBottom = this.Start;
                        rightBottom.X += offset;
                    }
                    else {
                        leftTop = this.Start;
                        leftTop.X -= offset;
                        rightBottom = this.End;
                        rightBottom.X += offset;
                    }
                }
                else {
                    if (this.Start.X > this.End.X) {
                        leftTop = this.End;
                        leftTop.Y -= offset;
                        rightBottom = this.Start;
                        rightBottom.Y += offset;
                    }
                    else {
                        leftTop = this.Start;
                        leftTop.Y -= offset;
                        rightBottom = this.End;
                        rightBottom.Y += offset;
                    }
                }
                if (x >= leftTop.X && x <= rightBottom.X)
                    if (y >= leftTop.Y && y <= rightBottom.Y)
                        return ClickType.MOVE;
            }
            else {
                Point breakRight = (Point)this.Break;
                Point breakLeft = (Point)this.Break;
                if (this.Start.Y > breakRight.Y) {
                    leftTop = (Point)this.Break;
                    leftTop.X -= offset;
                    leftTop.Y -= offset;
                    breakRight = this.Start;
                    breakRight.X += offset;
                }
                else {
                    leftTop = this.Start;
                    leftTop.X -= offset;
                    breakRight.X += offset;
                    breakRight.Y += offset;
                }

                if (this.End.X > breakLeft.X) {

                    rightBottom = this.End;
                    rightBottom.Y += offset;
                    breakLeft.X -= offset;
                    breakLeft.Y -= offset;

                }
                else {
                    breakLeft = this.End;
                    breakLeft.Y -= offset;
                    rightBottom = (Point)this.Break;
                    rightBottom.X += offset;
                    rightBottom.Y += offset;
                }

                if (x >= leftTop.X && x <= breakRight.X)
                    if (y >= leftTop.Y && y <= breakRight.Y)
                        return ClickType.MOVE;
                if (x >= breakLeft.X && x <= rightBottom.X)
                    if (y >= breakLeft.Y && y <= rightBottom.Y)
                        return ClickType.MOVE;
            }

            return ClickType.NONE;
        }

        public override void FillSidebar(Form1 form) {
            if (this.LineType is null)
                this.LineType = new AssociationLine();

            // Make sidebar visible
            form.panel_ClassProperties.Visible = false;
            form.panel_DiagramProperties.Visible = false;
            form.panel_RelationProperties.Visible = true;

            form.comboBox_RelationType.SelectedIndex = this.LineType.Index;

            form.comboBox_Relation_Card_From.Text = this.CardinalityFrom;
            form.comboBox_Relation_Card_To.Text = this.CardinalityTo;
        }

        public override bool Move(int x, int y, int width, int height) {
            this.End = new(x, y);
            return true;
        }
        #region Draw
        public void Draw(Graphics g) {
            if (this.ToClass is null)
                this.DrawUnfinished(g);
            else
                this.DrawFinished(g);
        }

        private void DrawFinished(Graphics g) {
            ClassModel biggerClass;
            ClassModel smallerClass;

            // Find smaller and bigger class
            if (this.FromClass.Height > this.ToClass.Height) {
                biggerClass = this.FromClass;
                smallerClass = this.ToClass;
            }
            else {
                biggerClass = this.ToClass;
                smallerClass = this.FromClass;
            }

            if (smallerClass.RightBottomWithOffset.X >= biggerClass.LeftTopWithOffset.X && smallerClass.LeftTopWithOffset.X <= biggerClass.RightBottomWithOffset.X)
                if (smallerClass.RightBottomWithOffset.Y >= biggerClass.LeftTopWithOffset.Y && smallerClass.LeftTopWithOffset.Y <= biggerClass.RightBottomWithOffset.Y)
                    return;

            if (CalculateLeftRight(biggerClass, smallerClass, out int positionY) == true) {
                if (this.FromClass.LeftTopWithOffset.X > this.ToClass.RightBottomWithOffset.X) {
                    this.Start = new(this.FromClass.LeftTopWithOffset.X, positionY);
                    this.End = new(this.ToClass.RightBottomWithOffset.X, positionY);
                    this.Break = null;
                    if (this.Start.X - this.End.X > 80) {
                        g.DrawString(this.CardinalityFrom, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X - 30, positionY - 30);
                        g.DrawString(this.CardinalityTo, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X + 10, positionY - 30);
                    }
                }
                else if (this.FromClass.RightBottomWithOffset.X < this.ToClass.LeftTopWithOffset.X) {
                    this.Start = new(this.FromClass.RightBottomWithOffset.X, positionY);
                    this.End = new(this.ToClass.LeftTopWithOffset.X, positionY);
                    this.Break = null;
                    if (this.End.X - this.Start.X > 80) {
                        g.DrawString(this.CardinalityFrom, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, positionY - 30);
                        g.DrawString(this.CardinalityTo, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X - 30, positionY - 30);
                    }
                }
            }
            else if (CalculateTopBottom(biggerClass, smallerClass, out int positionX) == true) {
                if (this.FromClass.LeftTopWithOffset.Y > this.ToClass.RightBottomWithOffset.Y) {
                    this.Start = new(positionX, this.FromClass.LeftTopWithOffset.Y);
                    this.End = new(positionX, this.ToClass.RightBottomWithOffset.Y + 3);
                    this.Break = null;
                    if (this.Start.Y - this.End.Y > 60) {
                        g.DrawString(this.CardinalityFrom, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, this.Start.Y - 30);
                        g.DrawString(this.CardinalityTo, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X + 10, this.End.Y + 10);
                    }
                }
                else if (this.FromClass.RightBottomWithOffset.Y < this.ToClass.LeftTopWithOffset.Y) {
                    this.Start = new(positionX, this.FromClass.RightBottomWithOffset.Y + 3);
                    this.End = new(positionX, this.ToClass.LeftTopWithOffset.Y);
                    this.Break = null;
                    if (this.End.Y - this.Start.Y > 60) {
                        g.DrawString(this.CardinalityFrom, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, this.Start.Y + 10);
                        g.DrawString(this.CardinalityTo, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X + 10, this.End.Y - 30);
                    }
                }
            }
            else {
                if (this.FromClass.RightBottomWithOffset.X < this.ToClass.LeftTopWithOffset.X)
                    this.End = new(this.ToClass.LeftTopWithOffset.X, this.ToClass.RightBottomWithOffset.Y - (this.ToClass.Height / 2));
                else
                    this.End = new(this.ToClass.RightBottomWithOffset.X, this.ToClass.RightBottomWithOffset.Y - (this.ToClass.Height / 2));

                if (this.FromClass.RightBottomWithOffset.Y < this.ToClass.LeftTopWithOffset.Y)
                    this.Start = new(this.FromClass.RightBottomWithOffset.X - (this.FromClass.Width / 2), this.FromClass.RightBottomWithOffset.Y + 2);
                else
                    this.Start = new(this.FromClass.RightBottomWithOffset.X - (this.FromClass.Width / 2), this.FromClass.LeftTopWithOffset.Y);
                this.Break = new(this.FromClass.RightBottomWithOffset.X - (this.FromClass.Width / 2), this.ToClass.RightBottomWithOffset.Y - (this.ToClass.Height / 2));

                if (this.Start.Y > ((Point)this.Break).Y)
                    g.DrawString(this.CardinalityFrom, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, this.Start.Y - 30);
                else
                    g.DrawString(this.CardinalityFrom, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, this.Start.Y + 10);

                if (this.End.X > ((Point)this.Break).X)
                    g.DrawString(this.CardinalityTo, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X - 35, this.End.Y - 30);
                else
                    g.DrawString(this.CardinalityTo, this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X + 10, this.End.Y - 30);

            }

            this.LineType.DrawLine(g, this.Selected, this.Start, this.End, this.Break);
        }
        private void DrawUnfinished(Graphics g) {
            if (this.FromClass.LeftTopWithOffset.Y <= this.End.Y && this.FromClass.RightBottomWithOffset.Y >= this.End.Y) {
                if (this.FromClass.LeftTopWithOffset.X > this.End.X) {
                    g.DrawLine(new Pen(Color.Black, 3), this.FromClass.LeftTopWithOffset.X, this.End.Y, this.End.X, this.End.Y);
                }
                else {
                    g.DrawLine(new Pen(Color.Black, 3), this.FromClass.RightBottomWithOffset.X, this.End.Y, this.End.X, this.End.Y);
                }
            }
            else if (this.FromClass.LeftTopWithOffset.X <= this.End.X && this.FromClass.RightBottomWithOffset.X >= this.End.X) {
                if (this.FromClass.LeftTopWithOffset.Y > this.End.Y) {
                    g.DrawLine(new Pen(Color.Black, 3), this.End.X, this.FromClass.LeftTopWithOffset.Y, this.End.X, this.End.Y);
                }
                else {
                    g.DrawLine(new Pen(Color.Black, 3), this.End.X, this.FromClass.RightBottomWithOffset.Y, this.End.X, this.End.Y);
                }
            }
            else {
                if (this.FromClass.RightBottomWithOffset.Y < this.End.Y)
                    this.Start = new(this.FromClass.RightBottomWithOffset.X - (this.FromClass.Width / 2), this.FromClass.RightBottomWithOffset.Y);
                else
                    this.Start = new(this.FromClass.RightBottomWithOffset.X - (this.FromClass.Width / 2), this.FromClass.LeftTopWithOffset.Y);

                this.Break = new(this.FromClass.RightBottomWithOffset.X - (this.FromClass.Width / 2), this.End.Y);

                g.DrawLines(new Pen(Color.Black, 3), new PointF[] { this.Start, (Point)this.Break, this.End });
            }

        }
        public bool CalculateLeftRight(ClassModel big, ClassModel small, out int positionY) {
            int topOffset = small.RightBottomWithOffset.Y - big.LeftTopWithOffset.Y;
            int botOffset = big.RightBottomWithOffset.Y - small.LeftTopWithOffset.Y;

            if (topOffset >= 0 && botOffset >= 0) {
                if (topOffset < botOffset) {
                    positionY = small.RightBottomWithOffset.Y - (topOffset / 2);
                    return true;

                }
                else {
                    positionY = big.RightBottomWithOffset.Y - (botOffset / 2);
                    return true;
                }

            }
            positionY = -1;
            return false;
        }
        public bool CalculateTopBottom(ClassModel big, ClassModel small, out int positionX) {
            int leftOffset = small.RightBottomWithOffset.X - big.LeftTopWithOffset.X;
            int rightOffset = big.RightBottomWithOffset.X - small.LeftTopWithOffset.X;

            if (leftOffset >= 0 && rightOffset >= 0) {
                if (leftOffset < rightOffset) {
                    positionX = small.RightBottomWithOffset.X - (leftOffset / 2);
                    return true;

                }
                else {
                    positionX = big.RightBottomWithOffset.X - (rightOffset / 2);
                    return true;
                }

            }
            positionX = -1;
            return false;
        }
        #endregion

    }
}
