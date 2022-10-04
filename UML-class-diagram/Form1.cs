using System.ComponentModel;
using UML_class_diagram.Classes;

namespace UML_class_diagram {
    public partial class Form1 : Form {
        public Diagram Diagram { get; set; }

        private int mouseX;
        private int mouseY;

        private bool isDraging;
        private bool isChanged;
        public Form1() {
            InitializeComponent();
            this.Diagram = new(this.pictureBox_Editor.CreateGraphics(), this.pictureBox_Editor.Width, this.pictureBox_Editor.Height);
            this.panel_ClassProperties.Visible = false;

            this.textBox_ClassName.TextChanged += (x, e) => this.isChanged = true;
        }

        private void button_Add_Click(object sender, EventArgs e) {
            if (this.Diagram.CurrentlySelectedClass != null) {
                this.Diagram.CurrentlySelectedClass.selected = false;
                this.Diagram.CurrentlySelectedClass = null;
                this.pictureBox_Editor.Invalidate();
            }
            this.Diagram.AddClass();
            this.pictureBox_Editor.Invalidate();
            this.panel_ClassProperties.Visible = true;
            FillPanel();
            isChanged = false;
        }

        private void button_Import_Click(object sender, EventArgs e) {
            this.pictureBox_Editor.Refresh();
        }

        private void button_Export_Click(object sender, EventArgs e) {

        }
        #region MouseHandle
        private void pictureBox_Editor_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left)
                return;
            if (isChanged) {
                ConfirmForm form = new ConfirmForm("You have unsaved changes.\r\nDo you want to continue?");
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                else
                    isChanged = false;
            }

            if (this.Diagram.CurrentlySelectedClass != null) {
                this.Diagram.CurrentlySelectedClass.selected = false;
                this.Diagram.CurrentlySelectedClass = null;
                this.pictureBox_Editor.Invalidate();
                this.panel_ClassProperties.Visible = false;
            }
            if (this.Diagram.CheckSelect(e.X, e.Y)) {
                mouseX = e.X;
                mouseY = e.Y;
                this.pictureBox_Editor.Invalidate();
                isDraging = true;
                this.panel_ClassProperties.Visible = true;
                FillPanel();
                isChanged = false;
            }

        }
        private void pictureBox_Editor_MouseMove(object sender, MouseEventArgs e) {
            if (!isDraging || e.Button != MouseButtons.Left)
                return;

            int offsetX = e.X - mouseX;
            int offsetY = e.Y - mouseY;

            if(!this.Diagram.CurrentlySelectedClass.ChangeStartPoint(offsetX,offsetY, this.pictureBox_Editor.Width, this.pictureBox_Editor.Height)) {

                //Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);
                //return;
            }

            mouseX += offsetX;
            mouseY += offsetY;
            this.pictureBox_Editor.Invalidate();
        }

        private void pictureBox_Editor_MouseUp(object sender, MouseEventArgs e) {
            if (!isDraging || e.Button != MouseButtons.Left)
                return;
            isDraging = false;
        }
        #endregion
        private void pictureBox_Editor_Paint(object sender, PaintEventArgs e) {
            this.Diagram.Draw(e.Graphics);
        }

        private void FillPanel() {


            if (this.Diagram.CurrentlySelectedClass == null)
                return;

            this.textBox_ClassName.Text = this.Diagram.CurrentlySelectedClass.ClassName;

            this.listBox_Props.Items.Clear();
            this.listBox_Funcs.Items.Clear();
            foreach (var item in this.Diagram.CurrentlySelectedClass.Properties) {
                this.listBox_Props.Items.Add(item);
            }
            foreach (var item in this.Diagram.CurrentlySelectedClass.Methods) {
                this.listBox_Funcs.Items.Add(item);
            }
        }

        #region Properties
        private void button_AddProperty_Click(object sender, EventArgs e) {
            PropertyForm form = new PropertyForm("");
            if (form.ShowDialog() == DialogResult.OK) {
                this.isChanged = true;
                this.listBox_Props.Items.Add(form.Property);
            }
        }
        private void button_EditProperty_Click(object sender, EventArgs e) {
            if (this.listBox_Props.SelectedIndex == -1)
                return;

            PropertyForm form = new PropertyForm(this.listBox_Props.SelectedItem.ToString());
            if (form.ShowDialog() == DialogResult.OK) {
                this.isChanged = true;
                this.listBox_Props.Items[this.listBox_Props.SelectedIndex] = form.Property;
            }
        }
        private void button_DeleteProperty_Click(object sender, EventArgs e) {
            if (this.listBox_Props.SelectedIndex == -1)
                return;

            this.listBox_Props.Items.RemoveAt(this.listBox_Props.SelectedIndex);
            isChanged = true;
        }
        #endregion

        #region Functions
        private void button_AddFunc_Click(object sender, EventArgs e) {
            FunctionForm form = new FunctionForm("");
            if (form.ShowDialog() == DialogResult.OK) {
                this.isChanged = true;
                this.listBox_Funcs.Items.Add(form.Function);
            }
        }

        private void button_EditFunc_Click(object sender, EventArgs e) {
            if (this.listBox_Funcs.SelectedIndex == -1)
                return;

            FunctionForm form = new FunctionForm(this.listBox_Funcs.SelectedItem.ToString());
            if (form.ShowDialog() == DialogResult.OK) {
                this.isChanged = true;
                this.listBox_Funcs.Items[this.listBox_Funcs.SelectedIndex] = form.Function;
            }
        }
        private void button_DeleteFunc_Click(object sender, EventArgs e) {
            if (this.listBox_Funcs.SelectedIndex == -1)
                return;

            this.listBox_Funcs.Items.RemoveAt(this.listBox_Funcs.SelectedIndex);
            isChanged = true;
        }
        #endregion

        private void button_SaveClass_Click(object sender, EventArgs e) {
            this.Diagram.CurrentlySelectedClass.ClassName = textBox_ClassName.Text;
            this.Diagram.CurrentlySelectedClass.Properties = new BindingList<string>(this.listBox_Props.Items.Cast<string>().ToList());
            this.Diagram.CurrentlySelectedClass.Methods = new BindingList<string>(this.listBox_Funcs.Items.Cast<string>().ToList());
            this.pictureBox_Editor.Invalidate();
            this.isChanged = false;
        }

    }
}