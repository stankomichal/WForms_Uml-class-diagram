using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class NameDataTypePair {
        public string Name { get; set; }
        public string Type { get; set; }
        public NameDataTypePair(string name, string type) {
            this.Name = name;
            this.Type = type;
        }
        public override string ToString() {
            return $"{this.Name} : {this.Type}";
        }
    }
}
