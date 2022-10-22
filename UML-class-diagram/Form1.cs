using Newtonsoft.Json;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UML_class_diagram.Classes;
using UML_class_diagram.Classes.RelationLines;

namespace UML_class_diagram {
    public partial class Form1 : Form {
        /// <summary>
        /// Instance if diagram
        /// </summary>
        public Diagram Diagram { get; set; }

        /// <summary>
        /// X position of mouse when we clicked and moved
        /// </summary>
        private int mouseX;
        /// <summary>
        /// Y position of mouse when we clicked and moved
        /// </summary>
        private int mouseY;

        /// <summary>
        /// Is user dragging class
        /// </summary>
        private bool isDragging;
        /// <summary>
        /// Is user moving diagram
        /// </summary>
        private bool isMoving;

        /// <summary>
        /// Is user dragging class
        /// </summary>
        private bool isCreatingRelation;
        /// <summary>
        /// If user changed anything in sidebar
        /// </summary>
        private bool isChanged;
        /// <summary>
        /// Instance of an export manager
        /// </summary>
        private ExportManager exportManager = new();
        public Form1() {
            InitializeComponent();
            // Create diagram
            this.Diagram = new();
            // Correct panels positions
            this.panel_DiagramProperties.Left = this.panel_ClassProperties.Left;
            this.panel_DiagramProperties.Top = this.panel_ClassProperties.Top;
            this.panel_RelationProperties.Left = this.panel_ClassProperties.Left;
            this.panel_RelationProperties.Top = this.panel_ClassProperties.Top;

            // Set sidebar visibility to false when event is emited
            this.Diagram.deselectAction += () => {
                this.panel_ClassProperties.Visible = false;
                this.panel_RelationProperties.Visible = false;
                this.panel_DiagramProperties.Visible = true;
            };
            // Set visibility of sidebar to false
            this.panel_ClassProperties.Visible = false;

            // Setup events for changes
            this.textBox_ClassName.TextChanged += (x, e) => this.isChanged = true;
            this.checkBox_Abstract.CheckedChanged += (x, e) => this.isChanged = true;
            this.comboBox_RelationType.SelectedIndexChanged += (x, e) => this.isChanged = true;
            this.comboBox_RelationType.SelectedIndexChanged += (x, e) => this.isChanged = true;

            this.comboBox_RelationType.Items.Add(RelationType.ASSOCIATION);
            this.comboBox_RelationType.Items.Add(RelationType.INHERITANCE);
            this.comboBox_RelationType.Items.Add(RelationType.IMPLEMENTATION);
            this.comboBox_RelationType.Items.Add(RelationType.DEPENDENCY);
            this.comboBox_RelationType.Items.Add(RelationType.AGGREGATION);
            this.comboBox_RelationType.Items.Add(RelationType.COMPOSITION);

            this.contextMenuStrip1.Items.Add(ExportTypes.JSON.ToString());
            this.contextMenuStrip1.Items.Add(ExportTypes.JPG.ToString());
            this.contextMenuStrip1.Items.Add(ExportTypes.CS.ToString());
            this.contextMenuStrip1.ItemClicked += ContextMenuStrip1_ItemClicked;

            foreach (string item in DiagramSettings.GetInstance().ReturnTypes) {
                this.dataGridView_ReturnTypeList.Rows.Add(item);
            }
            foreach (string item in DiagramSettings.GetInstance().CardinalityTypes) {
                this.dataGridView_CardinalityList.Rows.Add(item);
            }
            SetPositionLabels();
            this.FillCardinality();
        }

        // Button to add class
        private void button_Add_Click(object sender, EventArgs e) {
            // If we have changed anything - form to inform user about it
            if (isChanged) {
                ConfirmForm form = new ConfirmForm("You have unsaved changes.\r\nDo you want to continue?");
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                else
                    isChanged = false;
            }

            // If we have anything selected - deselect
            if (this.Diagram.CurrentlySelectedItem != null)
                this.Diagram.CurrentlySelectedItem.Selected = false;
            // Call add class method
            this.Diagram.AddClass();

            // Fill sidebar with data
            this.Diagram.CurrentlySelectedItem.FillSidebar(this);
            //FillPanel();
            // Invalidate picturebox to redraw it
            this.pictureBox_Editor.Invalidate();
            // Set isChanged to false bcs of filling sidebar - changing values
            isChanged = false;
        }
        // Button to import
        private void button_Import_Click(object sender, EventArgs e) {
            if (isChanged) {
                ConfirmForm form = new ConfirmForm("You have unsaved changes.\r\nDo you want to continue?");
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                else {
                    isChanged = false;
                    this.errorProvider1.Clear();
                }
            }


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Json (*.json)|*.json";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            StreamReader sr = new StreamReader(dialog.FileName);
            string str = sr.ReadToEnd();

            JsonSerializerSettings SerializerSettings = new JsonSerializerSettings();
            SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;

            try {
                Diagram diagram = JsonConvert.DeserializeObject<Diagram>(str, SerializerSettings);
                this.Diagram = diagram;
                this.Diagram.deselectAction += () => {
                    this.panel_ClassProperties.Visible = false;
                    this.panel_RelationProperties.Visible = false;
                    this.panel_DiagramProperties.Visible = true;
                };
                this.panel_ClassProperties.Visible = false;
                this.panel_RelationProperties.Visible = false;
                this.panel_DiagramProperties.Visible = true;
                this.Diagram.offset = new();
                this.SetPositionLabels();

            } catch (Exception) {

                MessageBox.Show("This is not valid import file.", "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sr.Close();
            this.pictureBox_Editor.Invalidate();
        }
        // Button to export
        private void button_Export_Click(object sender, EventArgs e) {
            this.contextMenuStrip1.Show(this.button_Export, 0, this.button_Export.Height);
        }

        private void ContextMenuStrip1_ItemClicked(object? sender, ToolStripItemClickedEventArgs e) {
            if (e.ClickedItem.Text == "JSON") {
                exportManager.Export(ExportTypes.JSON, this.Diagram, this.pictureBox_Editor.Width, this.pictureBox_Editor.Height);
            }
            else if (e.ClickedItem.Text == "JPG") {
                exportManager.Export(ExportTypes.JPG, this.Diagram, this.pictureBox_Editor.Width, this.pictureBox_Editor.Height);
            }
            else {
                exportManager.Export(ExportTypes.CS, this.Diagram, this.pictureBox_Editor.Width, this.pictureBox_Editor.Height);
            }
            this.pictureBox_Editor.Invalidate();
        }



        #region MouseHandle
        // Called first frame when user clicked inside of the paintbox
        private void pictureBox_Editor_MouseDown(object sender, MouseEventArgs e) {
            // If clicked button is not left - return
            if (e.Button != MouseButtons.Left)
                return;
            // If we changed anything - form to inform user about it
            if (isChanged) {
                ConfirmForm form = new ConfirmForm("You have unsaved changes.\r\nDo you want to continue?");
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                else {
                    isChanged = false;
                    this.errorProvider1.Clear();
                }
            }
            switch (this.Diagram.MouseHandler(e.X, e.Y)) {
                case ClickType.MOVE:
                    // Set mouse positions for later use in moveMouse
                    mouseX = e.X;
                    mouseY = e.Y;
                    // Set dragging to true
                    this.isDragging = true;

                    // Fill sidebar with informations of selected item
                    if (this.Diagram.CurrentlySelectedItem is not null)
                        this.Diagram.CurrentlySelectedItem.FillSidebar(this);
                    // Set isChanged to false bcs of filling sidebar - changing values
                    isChanged = false;
                    break;
                case ClickType.RELATION:
                    this.Diagram.AddRelation();
                    this.Diagram.RelationList.Last().Move(e.X, e.Y, 1, 1);
                    this.isCreatingRelation = true;
                    break;
                case ClickType.DELETE:
                    this.Diagram.RemoveClass();
                    break;
                case ClickType.NONE:
                    this.panel_ClassProperties.Visible = false;
                    this.panel_RelationProperties.Visible = false;
                    this.panel_DiagramProperties.Visible = true;
                    mouseX = e.X;
                    mouseY = e.Y;
                    this.isMoving = true;
                    break;
            }

            // Redraw picturebox
            this.pictureBox_Editor.Invalidate();
        }
        // Called everytime user moved cursor inside of the paintbox
        private void pictureBox_Editor_MouseMove(object sender, MouseEventArgs e) {
            // If we just moved without clicking anything and we have something selected
            if (e.Button == MouseButtons.None && this.Diagram.CurrentlySelectedItem is not null) {
                // Call click on me method on selected class
                switch (this.Diagram.CurrentlySelectedItem.ClickOnMe(e.X, e.Y)) {
                    // If we have cursor on relation arrow or on delete icon - change cursor
                    case ClickType.RELATION:
                    case ClickType.DELETE:
                        Cursor.Current = Cursors.Hand;
                        break;
                }
            }
            // If clicked button is not left - return
            // If user is not dragging - return
            // If user is not creating relation - return
            if (e.Button != MouseButtons.Left )
                return;
            if (!this.isMoving && !this.isDragging && !this.isCreatingRelation)
                return;
            if (this.isCreatingRelation) {
                this.Diagram.RelationList.Last().Move(e.X, e.Y, 1, 1);
            }
            else {
                // Get offset of cursor movement
                int offsetX = e.X - mouseX;
                int offsetY = e.Y - mouseY;
                if (isDragging)
                    this.Diagram.CurrentlySelectedItem.Move(offsetX, offsetY, this.pictureBox_Editor.Width, this.pictureBox_Editor.Height);
                else {
                    this.Diagram.offset.Width += offsetX;
                    this.Diagram.offset.Height += offsetY;
                    Cursor.Current = Cursors.Hand;
                    SetPositionLabels();
                }

                // Set cursor positions
                mouseX += offsetX;
                mouseY += offsetY;
            }

            // Redraw
            this.pictureBox_Editor.Invalidate();
        }
        // Called first frame when user release mouse
        private void pictureBox_Editor_MouseUp(object sender, MouseEventArgs e) {
            // If clicked button is not left - return
            // If user is not dragging - return
            if (e.Button != MouseButtons.Left)
                return;
            if (this.isDragging)
                this.isDragging = false;
            else if (this.isCreatingRelation) {
                RelationModel relationModel = this.Diagram.RelationList.Last();

                if (this.Diagram.MouseHandler(e.X, e.Y) == ClickType.MOVE) {
                    ClassModel classModel = this.Diagram.CurrentlySelectedItem as ClassModel;
                    if (classModel is null) {
                        this.isCreatingRelation = false;
                        this.Diagram.RelationList.Remove(relationModel);
                        this.Diagram.CurrentlySelectedItem = null;
                        this.pictureBox_Editor.Invalidate();
                    }
                    if (relationModel.FromClass == classModel || this.Diagram.RelationList.Where(x => x.FromClass == relationModel.FromClass && x.ToClass == classModel).Count() != 0) {
                        this.isCreatingRelation = false;
                        this.Diagram.RelationList.Remove(relationModel);
                        classModel.Selected = false;
                        this.Diagram.CurrentlySelectedItem = null;
                        this.pictureBox_Editor.Invalidate();
                        return;
                    }
                    classModel.Selected = false;
                    relationModel.ToClass = classModel;
                    this.Diagram.CurrentlySelectedItem = relationModel;
                    this.isCreatingRelation = false;
                    relationModel.FillSidebar(this);
                    relationModel.Selected = true;
                    this.isChanged = false;
                }
                else {
                    this.isCreatingRelation = false;
                    this.Diagram.RelationList.Remove(relationModel);
                }
                this.pictureBox_Editor.Invalidate();
            }

            // Set dragging to false
            this.isDragging = false;
            this.isMoving = false;
        }
        #endregion
        // Called when picture box is needed to be repainted
        private void pictureBox_Editor_Paint(object sender, PaintEventArgs e) {
            // Redraw
            this.Diagram.Draw(e.Graphics);
        }
        #region Properties
        // Add new property to list
        private void button_AddProperty_Click(object sender, EventArgs e) {
            // Create new PropertyForm with empty string
            PropertyForm form = new PropertyForm(null);
            if (form.ShowDialog() == DialogResult.OK) {
                // Set is Changed to true, bcs we changed that list
                this.isChanged = true;
                // Add our property from PropertyForm to our listbox of properties
                this.listBox_Props.Items.Add(form.Property);
            }
        }
        // Edit selected property
        private void button_EditProperty_Click(object sender, EventArgs e) {
            // If we dont have anything selected - return
            if (this.listBox_Props.SelectedIndex == -1)
                return;

            // Create new PropertyForm with selected property
            PropertyForm form = new PropertyForm(this.listBox_Props.SelectedItem as Property);
            if (form.ShowDialog() == DialogResult.OK) {
                // Set is Changed to true, bcs we changed that list
                this.isChanged = true;
                // Change our property to new edited property from PropertyForm
                this.listBox_Props.Items[this.listBox_Props.SelectedIndex] = form.Property;
            }
        }
        // Delete selected property
        private void button_DeleteProperty_Click(object sender, EventArgs e) {
            // If we dont have anything selected - return
            if (this.listBox_Props.SelectedIndex == -1)
                return;

            // Remove selected property
            this.listBox_Props.Items.RemoveAt(this.listBox_Props.SelectedIndex);
            // Set is Changed to true, bcs we changed that list
            isChanged = true;
        }
        #endregion

        #region Functions
        // Add new function to list
        private void button_AddFunc_Click(object sender, EventArgs e) {
            // Create new FunctionForm with empty string
            FunctionForm form = new FunctionForm(null);
            if (form.ShowDialog() == DialogResult.OK) {
                // Set is Changed to true, bcs we changed that list
                this.isChanged = true;
                // Add our function from FunctionForm to our listbox of functions
                this.listBox_Funcs.Items.Add(form.Function);
            }
        }
        // Edit selected property
        private void button_EditFunc_Click(object sender, EventArgs e) {
            // If we dont have anything selected - return
            if (this.listBox_Funcs.SelectedIndex == -1)
                return;

            // Create new FunctionForm with selected function
            FunctionForm form = new FunctionForm(this.listBox_Funcs.SelectedItem as Function);
            if (form.ShowDialog() == DialogResult.OK) {
                // Set is Changed to true, bcs we changed that list
                this.isChanged = true;
                // Change our function to new edited function from FunctionForm
                this.listBox_Funcs.Items[this.listBox_Funcs.SelectedIndex] = form.Function;
            }
        }
        // Delete selected property
        private void button_DeleteFunc_Click(object sender, EventArgs e) {
            // If we dont have anything selected - return
            if (this.listBox_Funcs.SelectedIndex == -1)
                return;
            // Remove selected function
            this.listBox_Funcs.Items.RemoveAt(this.listBox_Funcs.SelectedIndex);
            // Set is Changed to true, bcs we changed that list
            isChanged = true;
        }
        #endregion
        // Save information from sidebar to selected class
        private void button_SaveClass_Click(object sender, EventArgs e) {
            // If we didnt changed anything or we have error in our sidebar - return
            if (!isChanged || !this.ValidateChildren())
                return;
            ClassModel selectedClass = this.Diagram.CurrentlySelectedItem as ClassModel;
            if (selectedClass == null)
                return;
            // Set name of the selected class to text in class name textbox 
            selectedClass.ClassName = textBox_ClassName.Text;
            // Set list of properties of the selected class to list from sidebar - cast it to List<string>
            selectedClass.Properties = new List<Property>(this.listBox_Props.Items.Cast<Property>().ToList());
            // Set list of functions of the selected class to list from sidebar - cast it to List<string>
            selectedClass.Functions = new List<Function>(this.listBox_Funcs.Items.Cast<Function>().ToList());
            // Set isAbstract of the selected class to bool from checkbox
            selectedClass.IsAbstract = this.checkBox_Abstract.Checked;
            // Set isChanged to false, bcs we saved all our changes
            this.isChanged = false;

            // Redraw
            this.pictureBox_Editor.Invalidate();
        }

        // Validating class name textbox
        private void textBox_ClassName_Validating(object sender, CancelEventArgs e) {
            // Cast sender to Texbox
            TextBox tb = sender as TextBox;
            // If our cast results in null - return
            if (tb is null)
                return;
            this.errorProvider1.SetError(tb, null);
            ClassModel selectedClass = this.Diagram.CurrentlySelectedItem as ClassModel;
            if (tb.Text != selectedClass.ClassName) {
                if (this.Diagram.ClassList.Count(x => x.ClassName == tb.Text) != 0) {
                    e.Cancel = true;
                    this.errorProvider1.SetError(tb, "Class name has to be unique for every class.");
                }
            }

            // Class can only containt lowercase / uppercase letters, numbers and underscore
            if (!Regex.IsMatch(tb.Text, @"^[a-zA-Z0-9_]+$")) {
                e.Cancel = true;
                this.errorProvider1.SetError(tb, "Only lowercase, uppercase letters or numbers or underscore.");
            }
        }

        private void button_Relation_Save_Click(object sender, EventArgs e) {
            RelationModel relModel = this.Diagram.CurrentlySelectedItem as RelationModel;
            if (relModel is null)
                return;
            relModel.LineType = Line.GetLine((RelationType)this.comboBox_RelationType.SelectedItem);
            relModel.CardinalityFrom = this.comboBox_Relation_Card_From.Text;
            relModel.CardinalityTo = this.comboBox_Relation_Card_To.Text;
            this.isChanged = false;
            this.pictureBox_Editor.Invalidate();
        }

        private void button_Relation_Delete_Click(object sender, EventArgs e) {
            this.Diagram.RemoveRelation();
            this.pictureBox_Editor.Invalidate();
        }


        private void button_SettingsSave_Click(object sender, EventArgs e) {
            List<string> returnTypes = new();
            List<string> cardinalityList = new();
            this.dataGridView_ReturnTypeList.CommitEdit(DataGridViewDataErrorContexts.Display);
            dataGridView_CardinalityList.CommitEdit(DataGridViewDataErrorContexts.Display);
            foreach (DataGridViewRow returnType in this.dataGridView_ReturnTypeList.Rows) {
                if (returnType.IsNewRow) continue;
                string temp = returnType.Cells[0].Value.ToString();
                if (returnTypes.Contains(temp)) {
                    MessageBox.Show("All return types have to be unique!");
                    return;
                }
                returnTypes.Add(temp);
            }
            foreach (DataGridViewRow cardinalityType in this.dataGridView_CardinalityList.Rows) {
                if (cardinalityType.IsNewRow) continue;
                string temp = cardinalityType.Cells[0].Value.ToString();
                if (cardinalityList.Contains(temp)) {
                    MessageBox.Show("All return types have to be unique!");
                    return;
                }
                cardinalityList.Add(temp);
            }
            if (returnTypes.Contains("")) {
                MessageBox.Show("Return type cant be empty!");
                return;
            }
            DiagramSettings.GetInstance().ReturnTypes = returnTypes;
            DiagramSettings.GetInstance().CardinalityTypes = cardinalityList;
            DiagramSettings.GetInstance().SaveSettings();
            MessageBox.Show("Settings saved successfully!");
            this.FillCardinality();
        }

        private void FillCardinality() {
            this.comboBox_Relation_Card_From.Items.Clear();
            this.comboBox_Relation_Card_To.Items.Clear();
            foreach (var item in DiagramSettings.GetInstance().CardinalityTypes) {
                this.comboBox_Relation_Card_From.Items.Add(item);
            }
            foreach (var item in DiagramSettings.GetInstance().CardinalityTypes) {
                this.comboBox_Relation_Card_To.Items.Add(item);
            }
        }

        private void button_Reset_Click(object sender, EventArgs e) {
            this.Diagram.offset = new Size();
            SetPositionLabels();
            this.pictureBox_Editor.Invalidate();
        }
        private void SetPositionLabels() {
            this.label_PosX.Text = "x: " + this.Diagram.offset.Width * -1;
            this.label_PosY.Text = "y: " + this.Diagram.offset.Height * -1;
        }
    }
    public enum ExportTypes {
        JSON,
        JPG,
        CS
    }
}