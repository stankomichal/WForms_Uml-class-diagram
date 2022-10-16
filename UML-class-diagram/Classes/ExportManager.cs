using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static UML_class_diagram.Form1;
using System.Security.Cryptography.X509Certificates;

namespace UML_class_diagram.Classes {
    public class ExportManager {
        public void Export(ExportTypes exportTypes, Diagram diagram, int width, int height) {
            if (diagram.CurrentlySelectedItem is not null) {
                diagram.CurrentlySelectedItem.Selected = false;
                diagram.CurrentlySelectedItem = null;
                diagram.deselectAction?.Invoke();
            }
            switch (exportTypes) {
                case ExportTypes.JSON:
                    ExportToJson(diagram);
                    break;
                case ExportTypes.JPG:
                    ExportToJpg(diagram, width, height);
                    break;
                case ExportTypes.CS:
                    ExportToCs(diagram);
                    break;
            }
        }

        private void ExportToJson(Diagram diagram) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {

                JsonSerializerSettings SerializerSettings = new JsonSerializerSettings();
                SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
                SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(JsonConvert.SerializeObject(diagram, Formatting.Indented, SerializerSettings));
                sw.Close();
            }
        }
        private void ExportToJpg(Diagram diagram, int width, int height) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG (*.png)|*.png";
            saveFileDialog.Title = "Export to JPG";
            saveFileDialog.FileName = "Diagram.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                Image image = new Bitmap(width, height);

                Graphics g = Graphics.FromImage(image);
                g.Clear(Color.White);
                diagram.Draw(g);

                image.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }
        private void ExportToCs(Diagram diagram) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            DirectoryInfo df = new DirectoryInfo(dialog.SelectedPath);
            if (!df.Exists)
                df.Create();

            foreach (var classModel in diagram.ClassList) {
                List<ClassModel> implementClass = diagram.RelationList.Where(x => x.ToClass == classModel && (x.LineType.Index == 1 || x.LineType.Index == 2)).Select(x => x.FromClass).ToList();
                string implementation = "";

                if (implementClass.Count != 0) {
                    implementation += " : ";

                    for (int i = 0; i < implementClass.Count; i++) {
                        implementation += implementClass[i].ClassName;
                        if (i != implementClass.Count - 1)
                            implementation += ", ";
                    }
                }
                StreamWriter sw = new StreamWriter(dialog.SelectedPath + "\\" + classModel.ClassName + ".cs");
                sw.WriteLine("public " + (classModel.IsAbstract ? "abstract " : "") + "class " + classModel.ClassName + implementation);
                sw.WriteLine('{');
                foreach (var property in classModel.Properties) {
                    sw.WriteLine($"    {property.AccessMod.ToString().ToLower()} {property.Data.Type} {property.Data.Name} {{get; set; }}");
                }
                foreach (var function in classModel.Functions) {
                    sw.WriteLine($"    {function.AccessMod.ToString().ToLower()} {function.Data.Type} {function.Data.Name} ({String.Join(", ", function.Arguments.Select(x => $"{x.Type} {x.Name}"))})");
                    sw.WriteLine("    {");
                    sw.WriteLine();
                    sw.WriteLine("    }");

                }
                sw.WriteLine('}');


                sw.Close();
            }
        }
    }
}
