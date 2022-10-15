using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class Function {
        public AccessModifier AccessMod { get; set; } // Acccess modifier of the function
        public NameDataTypePair Data { get; set; } // Function name and return data type
        public List<NameDataTypePair> Arguments { get; set; } // List of arguments of the function

        public Function() {
            this.Data = new NameDataTypePair("PLACEHOLDER", "PLACEHOLDER");
            this.Arguments = new();

        }
        public Function(AccessModifier accessMod, NameDataTypePair data, List<NameDataTypePair> arguments) {
            this.Data = data;
            this.AccessMod = accessMod;
            this.Arguments = arguments;
        }

        public override string ToString() {
            string result = (char)AccessMod + " ";

            result += this.Data.Name;
            result += $"({String.Join(", ", this.Arguments)})";
            result += $" : {this.Data.Type}";
            return result;
        }
    }
}
