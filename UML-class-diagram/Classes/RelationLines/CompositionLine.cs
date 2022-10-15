using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes.RelationLines {
    public class CompositionLine : Line {
        public override int Index { get; set; } = 5;
        public override void DrawLine(Graphics g, bool selected, Point startPoint, Point endPoint, Point? breakPoint = null) {
            GraphicsPath hPath = new();
            hPath.AddLine(new Point(0, 0), new Point(4, -8));
            hPath.AddLine(new Point(4, -8), new Point(0, -16));
            hPath.AddLine(new Point(0, -16), new Point(-4, -8));
            hPath.AddLine(new Point(-4, -8), new Point(0, 0));

            CustomLineCap HookCap = new CustomLineCap(hPath, null);
            HookCap.SetStrokeCaps(LineCap.Flat, LineCap.Flat);
            Pen pen = new Pen(selected ? this.diagramSettings.RelationColorSelected : this.diagramSettings.RelationColor, 2);
            HookCap.BaseInset = 15;
            pen.CustomEndCap = HookCap;

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
