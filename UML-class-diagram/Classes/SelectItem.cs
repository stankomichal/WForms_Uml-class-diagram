using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace UML_class_diagram.Classes {
    public abstract class SelectItem {
        public abstract bool Selected { get; set; }// Is this item selected
        public abstract ClickType ClickOnMe(int x, int y);
        public abstract bool Move(int x, int y, int width, int height);
        public abstract void FillSidebar(Form1 form);
    }
}
