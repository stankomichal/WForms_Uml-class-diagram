using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes.ExportModels {
    public abstract class ExportModel {
        public abstract void Export(Diagram diagram, int width, int height);
    }
}
