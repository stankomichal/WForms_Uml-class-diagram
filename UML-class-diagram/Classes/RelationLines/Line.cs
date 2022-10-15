using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes.RelationLines {
    public abstract class Line {
        public DiagramSettings diagramSettings = DiagramSettings.GetInstance();
        public abstract int Index { get; set; }
        public abstract void DrawLine(Graphics g, bool selected, Point startPoint, Point endPoint, Point? breakPoint = null);

        public static Line GetLine(RelationType type) {
            switch (type) {
                case RelationType.ASSOCIATION:
                    return new AssociationLine();
                case RelationType.INHERITANCE:
                    return new InheritanceLine();
                case RelationType.IMPLEMENTATION:
                    return new ImplementationLine();
                case RelationType.DEPENDENCY:
                    return new DependencyLine();
                case RelationType.AGGREGATION:
                    return new AggregationLine();
                case RelationType.COMPOSITION:
                default:
                    return new CompositionLine();
            }
        }

    }
    public enum RelationType {
        ASSOCIATION,
        INHERITANCE,
        IMPLEMENTATION,
        DEPENDENCY,
        AGGREGATION,
        COMPOSITION
    }

}
