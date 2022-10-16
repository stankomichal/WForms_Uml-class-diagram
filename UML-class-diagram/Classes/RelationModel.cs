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
        public CardinalityType CardinalityFrom { get; set; } = CardinalityType.ZEROPLUS;
        public CardinalityType CardinalityTo { get; set; } = CardinalityType.ZEROorONE;
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

            form.comboBox_Relation_Card_From.SelectedIndex = (int)this.CardinalityFrom;
            form.comboBox_Relation_Card_To.SelectedIndex = (int)this.CardinalityTo;
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

            if (smallerClass.RightBottom.X >= biggerClass.LeftTop.X && smallerClass.LeftTop.X <= biggerClass.RightBottom.X)
                if (smallerClass.RightBottom.Y >= biggerClass.LeftTop.Y && smallerClass.LeftTop.Y <= biggerClass.RightBottom.Y)
                    return;

            if (CalculateLeftRight(biggerClass, smallerClass, out int positionY) == true) {
                if (this.FromClass.LeftTop.X > this.ToClass.RightBottom.X) {
                    this.Start = new(this.FromClass.LeftTop.X, positionY);
                    this.End = new(this.ToClass.RightBottom.X, positionY);
                    this.Break = null;
                    if (this.Start.X - this.End.X > 80) {
                        g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityFrom), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X - 30, positionY - 30);
                        g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityTo), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X + 10, positionY - 30);
                    }
                }
                else if (this.FromClass.RightBottom.X < this.ToClass.LeftTop.X) {
                    this.Start = new(this.FromClass.RightBottom.X, positionY);
                    this.End = new(this.ToClass.LeftTop.X, positionY);
                    this.Break = null;
                    if (this.End.X - this.Start.X > 80) {
                        g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityFrom), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, positionY - 30);
                        g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityTo), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X - 30, positionY - 30);
                    }
                }
            }
            else if (CalculateTopBottom(biggerClass, smallerClass, out int positionX) == true) {
                if (this.FromClass.LeftTop.Y > this.ToClass.RightBottom.Y) {
                    this.Start = new(positionX, this.FromClass.LeftTop.Y);
                    this.End = new(positionX, this.ToClass.RightBottom.Y + 3);
                    this.Break = null;
                    if (this.Start.Y - this.End.Y > 60) {
                        g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityFrom), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, this.Start.Y - 30);
                        g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityTo), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X + 10, this.End.Y + 10);
                    }
                }
                else if (this.FromClass.RightBottom.Y < this.ToClass.LeftTop.Y) {
                    this.Start = new(positionX, this.FromClass.RightBottom.Y + 3);
                    this.End = new(positionX, this.ToClass.LeftTop.Y);
                    this.Break = null;
                    if (this.End.Y - this.Start.Y > 60) {
                        g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityFrom), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, this.Start.Y + 10);
                        g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityTo), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X + 10, this.End.Y - 30);
                    }
                }
            }
            else {
                if (this.FromClass.RightBottom.X < this.ToClass.LeftTop.X)
                    this.End = new(this.ToClass.LeftTop.X, this.ToClass.RightBottom.Y - (this.ToClass.Height / 2));
                else
                    this.End = new(this.ToClass.RightBottom.X, this.ToClass.RightBottom.Y - (this.ToClass.Height / 2));

                if (this.FromClass.RightBottom.Y < this.ToClass.LeftTop.Y)
                    this.Start = new(this.FromClass.RightBottom.X - (this.FromClass.Width / 2), this.FromClass.RightBottom.Y + 2);
                else
                    this.Start = new(this.FromClass.RightBottom.X - (this.FromClass.Width / 2), this.FromClass.LeftTop.Y);
                this.Break = new(this.FromClass.RightBottom.X - (this.FromClass.Width / 2), this.ToClass.RightBottom.Y - (this.ToClass.Height / 2));

                if (this.Start.Y > ((Point)this.Break).Y)
                    g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityFrom), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, this.Start.Y - 30);
                else
                    g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityFrom), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.Start.X + 10, this.Start.Y + 10);

                if (this.End.X > ((Point)this.Break).X)
                    g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityTo), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X - 35, this.End.Y - 30);
                else
                    g.DrawString(diagramSettings.GetCardinalityType(this.CardinalityTo), this.diagramSettings.ClassFont, this.diagramSettings.FontColor, this.End.X + 10, this.End.Y - 30);

            }

            this.LineType.DrawLine(g, this.Selected, this.Start, this.End, this.Break);
        }
        private void DrawUnfinished(Graphics g) {
            if (this.FromClass.LeftTop.Y <= this.End.Y && this.FromClass.RightBottom.Y >= this.End.Y) {
                if (this.FromClass.LeftTop.X > this.End.X) {
                    g.DrawLine(new Pen(Color.Black, 3), this.FromClass.LeftTop.X, this.End.Y, this.End.X, this.End.Y);
                }
                else {
                    g.DrawLine(new Pen(Color.Black, 3), this.FromClass.RightBottom.X, this.End.Y, this.End.X, this.End.Y);
                }
            }
            else if (this.FromClass.LeftTop.X <= this.End.X && this.FromClass.RightBottom.X >= this.End.X) {
                if (this.FromClass.LeftTop.Y > this.End.Y) {
                    g.DrawLine(new Pen(Color.Black, 3), this.End.X, this.FromClass.LeftTop.Y, this.End.X, this.End.Y);
                }
                else {
                    g.DrawLine(new Pen(Color.Black, 3), this.End.X, this.FromClass.RightBottom.Y, this.End.X, this.End.Y);
                }
            }
            else {
                if (this.FromClass.RightBottom.Y < this.End.Y)
                    this.Start = new(this.FromClass.RightBottom.X - (this.FromClass.Width / 2), this.FromClass.RightBottom.Y);
                else
                    this.Start = new(this.FromClass.RightBottom.X - (this.FromClass.Width / 2), this.FromClass.LeftTop.Y);

                this.Break = new(this.FromClass.RightBottom.X - (this.FromClass.Width / 2), this.End.Y);

                g.DrawLines(new Pen(Color.Black, 3), new PointF[] { this.Start, (Point)this.Break, this.End });
            }

        }
        public bool CalculateLeftRight(ClassModel big, ClassModel small, out int positionY) {
            int topOffset = small.RightBottom.Y - big.LeftTop.Y;
            int botOffset = big.RightBottom.Y - small.LeftTop.Y;

            if (topOffset >= 0 && botOffset >= 0) {
                //int middle = small.RightBottom.Y - small.Height / 2;
                //if (middle > big.LeftTop.Y && middle < big.RightBottom.Y) {
                //    positionY = middle;
                //    return true;
                //}
                if (topOffset < botOffset) {
                    positionY = small.RightBottom.Y - (topOffset / 2);
                    return true;

                }
                else {
                    positionY = big.RightBottom.Y - (botOffset / 2);
                    return true;
                }

            }
            positionY = -1;
            return false;
        }
        public bool CalculateTopBottom(ClassModel big, ClassModel small, out int positionX) {
            int leftOffset = small.RightBottom.X - big.LeftTop.X;
            int rightOffset = big.RightBottom.X - small.LeftTop.X;

            if (leftOffset >= 0 && rightOffset >= 0) {
                //int middle = small.RightBottom.X - small.Width / 2;
                //if (middle > big.LeftTop.X && middle < big.RightBottom.X) {
                //    positionX = middle;
                //    return true;
                //}
                if (leftOffset < rightOffset) {
                    positionX = small.RightBottom.X - (leftOffset / 2);
                    return true;

                }
                else {
                    positionX = big.RightBottom.X - (rightOffset / 2);
                    return true;
                }

            }
            positionX = -1;
            return false;
        }
        #endregion

    }
    public enum CardinalityType {
        NONE,
        ZEROorONE,
        ONE,
        ZEROPLUS,
        ONEPLUS
    }
}
