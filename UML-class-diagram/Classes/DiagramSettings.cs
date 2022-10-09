using System;
using System.Collections.Generic;
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
    }
}
