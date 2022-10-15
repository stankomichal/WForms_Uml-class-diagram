using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes.RelationLines {
    public class ImplementationLine : Line {
        public override int Index { get; set; } = 2;
        public override void DrawLine(Graphics g, bool selected, Point startPoint, Point endPoint, Point? breakPoint = null) {
            GraphicsPath hPath = new();
            hPath.AddLine(new Point(0, 0), new Point(4, -8));
            hPath.AddLine(new Point(4, -8), new Point(-4, -8));
            hPath.AddLine(new Point(-4, -8), new Point(0, 0));
            CustomLineCap HookCap = new CustomLineCap(null, hPath);
            HookCap.SetStrokeCaps(LineCap.Flat, LineCap.Flat);
            Pen pen = new Pen(selected ? this.diagramSettings.RelationColorSelected : this.diagramSettings.RelationColor, 2);
            HookCap.BaseInset = 8;
            pen.CustomEndCap = HookCap;
            pen.DashPattern = new float[] { 10, 10 };

            if (breakPoint is null) {
                g.DrawLine(pen, startPoint, endPoint);
            }
            else {
                Pen firstPen = new Pen(selected ? this.diagramSettings.RelationColorSelected : this.diagramSettings.RelationColor, 2);
                firstPen.DashPattern = new float[] { 10, 10 };
                g.DrawLine(firstPen, startPoint, (Point)breakPoint);
                g.DrawLine(pen, (Point)breakPoint, endPoint);
            }
        }
    }
}
