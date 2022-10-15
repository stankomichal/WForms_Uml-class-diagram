using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class DiagramSettings {
        public Font ClassFont { get; set; } = new Font(FontFamily.GenericSansSerif, 12); // Font for class
        public Font AbstractClassFont { get; set; } = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic); // Font of abstract class
        public Brush FontColor { get; set; } = Brushes.DarkSlateGray; // Color of the class font
        public Brush ClassColor { get; set; } = Brushes.LightBlue; // Color of class background
        public Brush SelectClassColor { get; set; } = Brushes.LightCoral; // Color of selected class background
        public Color RelationColor { get; set; } = Color.Black; // Color of the relation line
        public Color RelationColorSelected { get; set; } = Color.Brown; // Color of the selected relation line
        public List<string> ReturnTypes { get; set; } = new List<string> {"string", "bool", "char", "int", "long", "double", "float" };

        private static DiagramSettings _instance; // Static instance, so we have only one
        // Getter of that instance, if we have none, create one
        public static DiagramSettings GetInstance() {
            if (_instance == null) {
                _instance = new DiagramSettings();
                return _instance;
            }
            return _instance;
        }
        // Private contructor so we cannot create another instance of this anywhere else
        private DiagramSettings() { }

        public string GetCardinalityType(CardinalityType type) {
            switch (type) {
                case CardinalityType.ZEROorONE:
                    return "0..1";
                case CardinalityType.ONE:
                    return "1";
                case CardinalityType.ZEROPLUS:
                    return "0..*";
                case CardinalityType.ONEPLUS:
                    return "1..*";
                case CardinalityType.NONE:
                default:
                    return "";
            }
        }
    }



}
