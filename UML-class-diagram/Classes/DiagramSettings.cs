using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class DiagramSettings {

        // Font for class
        public Font ClassFont { get; set; } = new Font(FontFamily.GenericSansSerif, 12);
        // Font of abstract class
        public Font AbstractClassFont { get; set; } = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic);
        // Color of the class font
        public Brush FontColor { get; set; } = Brushes.DarkSlateGray;
        // Color of class background
        public Brush ClassColor { get; set; } = Brushes.LightBlue;
        // Color of selected class background
        public Brush SelectClassColor { get; set; } = Brushes.LightCoral;

        private static DiagramSettings _instance;
        public static DiagramSettings GetInstance() {
            if (_instance == null) {
                _instance = new DiagramSettings();
                return _instance;
            }
            return _instance;
        }
    }
}
