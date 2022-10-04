using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes {
    public class DiagramSettings {

        public Font ClassFont { get; set; } = new Font(FontFamily.GenericSansSerif, 12);
        public Brush FontColor { get; set; } = Brushes.DarkSlateGray;
        public Brush ClassColor { get; set; } = Brushes.LightBlue;
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
