using static UML_class_diagram.Form1;
using UML_class_diagram.Classes.ExportModels;

namespace UML_class_diagram.Classes {
    public class ExportManager {
        private Dictionary<ExportTypes, ExportModel> exporters = new Dictionary<ExportTypes, ExportModel>();
        public ExportManager() {
            exporters.Add(ExportTypes.JSON, new ExportJSON());
            exporters.Add(ExportTypes.JPG, new ExportJPG());
            exporters.Add(ExportTypes.CS, new ExportCS());
        }


        /// <summary>
        /// Exports diagram to selected export Type
        /// </summary>
        /// <param name="exportTypes">Selected export type</param>
        /// <param name="diagram">Diagram to find all classes and relations</param>
        /// <param name="width">Width of the picture box</param>
        /// <param name="height">Height of the picture box</param>
        public void Export(ExportTypes exportTypes, Diagram diagram, int width, int height) {
            if (diagram.CurrentlySelectedItem is not null) {
                diagram.CurrentlySelectedItem.Selected = false;
                diagram.CurrentlySelectedItem = null;
                diagram.deselectAction?.Invoke();
            }
            exporters[exportTypes].Export(diagram, width, height);
        }
    }
}
