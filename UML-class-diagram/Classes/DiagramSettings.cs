using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_class_diagram.Properties;

namespace UML_class_diagram.Classes {
    public class DiagramSettings {
        /// <summary>
        /// Font of class
        /// </summary>
        public Font ClassFont { get; set; }
        /// <summary>
        /// Font of abstract class
        /// </summary>
        public Font AbstractClassFont { get; set; }
        /// <summary>
        /// Color of the class font
        /// </summary>
        public Brush FontColor { get; set; }
        /// <summary>
        /// Color of class background
        /// </summary>
        public Brush ClassColor { get; set; }
        /// <summary>
        /// Color of selected class background
        /// </summary>
        public Brush SelectClassColor { get; set; }
        /// <summary>
        /// Color of the relation line
        /// </summary>
        public Color RelationColor { get; set; }
        /// <summary>
        /// // Color of the selected relation line
        /// </summary>
        public Color RelationColorSelected { get; set; }
        /// <summary>
        /// List of return types
        /// </summary>
        public List<string> ReturnTypes { get; set; }
        /// <summary>
        /// List of cardinality types
        /// </summary>
        public List<string> CardinalityTypes { get; set; }

        /// <summary>
        /// Path to diagram settings file
        /// </summary>
        [NonSerialized]
        private string settingsPath = @"../../../Resources/DiagramSettings.json";

        /// <summary>
        /// Static instance, so we have only one
        /// </summary>
        private static DiagramSettings _instance;
        /// <summary>
        /// Getter of that instance, if we have none, create one
        /// </summary>
        /// <returns>Diagram settings</returns>
        public static DiagramSettings GetInstance() {
            if (_instance == null) {
                _instance = new DiagramSettings();
                return _instance;
            }
            return _instance;
        }

        private DiagramSettings() {

        } // Private contructor so we cannot create another instance of this anywhere else

        /// <summary>
        /// Save settings to settings file
        /// </summary>
        public void SaveSettings() {
            using (var sw = new StreamWriter(this.settingsPath)) {
                JsonSerializerSettings set = new();
                set.TypeNameHandling = TypeNameHandling.Objects;
                sw.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented, set));
            }
        }
        /// <summary>
        /// Load settings from settings file
        /// </summary>
        public void LoadSettings() {
            StreamReader sr = new StreamReader(this.settingsPath);
            JsonSerializerSettings set = new();

            set.TypeNameHandling = TypeNameHandling.Objects;
            try {
                DiagramSettings dg = JsonConvert.DeserializeObject<DiagramSettings>(sr.ReadToEnd(), set);
                this.ClassFont = dg.ClassFont;
                this.AbstractClassFont = dg.AbstractClassFont;
                this.FontColor = dg.FontColor;
                this.ClassColor = dg.ClassColor;
                this.SelectClassColor = dg.SelectClassColor;
                this.RelationColor = dg.RelationColor;
                this.RelationColorSelected = dg.RelationColorSelected;
                this.ReturnTypes = dg.ReturnTypes;
                this.CardinalityTypes = dg.CardinalityTypes;
            } catch (Exception) {
                sr.Close();
                this.ClassFont = new Font(FontFamily.GenericSansSerif, 12);
                this.AbstractClassFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic);
                this.FontColor = Brushes.DarkSlateGray;
                this.ClassColor = Brushes.LightBlue;
                this.SelectClassColor = Brushes.LightCoral;
                this.RelationColor = Color.Black;
                this.RelationColorSelected = Color.Brown;
                this.ReturnTypes = new List<string> { "string", "bool", "char", "int", "long", "double", "float", "void" };
                this.CardinalityTypes = new List<string> { "0..1", "1", "0..*", "1..*" };
                this.SaveSettings();
            }
            sr.Close();
        }
    }
}
