using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class Function {
        /// <summary>
        /// Acccess modifier of the function
        /// </summary>
        public AccessModifier AccessMod { get; set; }
        /// <summary>
        /// Function name and return data type
        /// </summary>
        public NameDataTypePair Data { get; set; }
        /// <summary>
        /// List of arguments of the function
        /// </summary>
        public List<NameDataTypePair> Arguments { get; set; }

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
