using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes.RelationLines {
    public class InheritanceLine : Line {
        public override int Index { get; set; } = 1;

        public override void DrawLine(Graphics g, bool selected, Point startPoint, Point endPoint, Point? breakPoint = null) {
            GraphicsPath hPath = new();
            hPath.AddLine(new Point(0, 8), new Point(4, 0));
            hPath.AddLine(new Point(0, 8), new Point(-4, 0));
            hPath.AddLine(new Point(4, 0), new Point(-4, 0));
            CustomLineCap HookCap = new CustomLineCap(null, hPath);
            HookCap.SetStrokeCaps(LineCap.Flat, LineCap.Flat);
            Pen pen = new Pen(selected ? this.diagramSettings.RelationColorSelected : this.diagramSettings.RelationColor, 2);
            pen.CustomEndCap = HookCap;

            if (endPoint.X == startPoint.X) {
                if (endPoint.Y > startPoint.Y)
                    endPoint.Y -= 17;
                else
                    endPoint.Y += 17;
            }
            else {
                if (endPoint.X > startPoint.X)
                    endPoint.X -= 17;
                else
                    endPoint.X += 17;
            }
            if (breakPoint is null) {
                g.DrawLine(pen, startPoint, endPoint);
            }
            else {
                g.DrawLine(new Pen(selected ? this.diagramSettings.RelationColorSelected : this.diagramSettings.RelationColor, 2), startPoint, (Point)breakPoint);
                g.DrawLine(pen, (Point)breakPoint, endPoint);
            }
        }
    }
}
