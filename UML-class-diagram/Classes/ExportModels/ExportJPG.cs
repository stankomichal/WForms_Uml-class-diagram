using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_class_diagram.Classes.ExportModels {
    public class ExportJPG : ExportModel {
        public override void Export(Diagram diagram, int width, int height) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPG (*.jpg)|*.jpg";
            saveFileDialog.Title = "Export to JPG";
            saveFileDialog.FileName = "Diagram.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                Image image = new Bitmap(width, height);

                Graphics g = Graphics.FromImage(image);
                g.Clear(Color.White);
                diagram.Draw(g);

                image.Save(saveFileDialog.FileName, ImageFormat.Png);
                MessageBox.Show("Exported successfully!");
            }
        }
    }
}
