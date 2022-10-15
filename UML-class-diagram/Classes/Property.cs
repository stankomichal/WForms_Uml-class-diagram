using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class Property {
        public AccessModifier AccessMod { get; set; }
        public NameDataTypePair Data { get; set; }
        public Property() {
            this.Data = new NameDataTypePair("PLACEHOLDER", "PLACEHOLDER");
        }
        public Property(AccessModifier access, NameDataTypePair data) {
            this.AccessMod = access;
            this.Data = data;
        }
        public override string ToString() {
            return $"{(char)this.AccessMod} {this.Data.Name} : {this.Data.Type}";
        }
    }
}
