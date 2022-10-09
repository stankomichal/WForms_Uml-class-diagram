using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class RelationModel : SelectItem {
        public override bool Selected { get; set; }

        public override ClickType ClickOnMe(int x, int y) {
            throw new NotImplementedException();
        }

        public override bool Move(int x, int y, int width, int height) {
            throw new NotImplementedException();
        }
    }
}
