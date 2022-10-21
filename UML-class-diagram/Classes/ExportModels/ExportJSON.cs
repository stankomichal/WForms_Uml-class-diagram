using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes.ExportModels {
    public class ExportJSON : ExportModel {
        public override void Export(Diagram diagram, int width, int height) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json (*.json)|*.json";
            saveFileDialog.Title = "Export to JSON";
            saveFileDialog.FileName = "Diagram.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {

                JsonSerializerSettings SerializerSettings = new JsonSerializerSettings();
                SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
                SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(JsonConvert.SerializeObject(diagram, Formatting.Indented, SerializerSettings));
                sw.Close();
                MessageBox.Show("Exported successfully!");
            }
        }
    }
}
