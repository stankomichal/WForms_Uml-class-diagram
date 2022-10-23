using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes.ExportModels {
    public class ExportCS : ExportModel {
        public override void Export(Diagram diagram, int width, int height) {
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
                    sw.WriteLine("        throw new NotImplementedException();");
                    sw.WriteLine("    }");

                }
                sw.WriteLine('}');

                sw.Close();
                MessageBox.Show("Exported successfully!");
            }
        }
    }
}
