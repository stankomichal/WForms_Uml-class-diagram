using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_class_diagram {
    public partial class PropertyForm : Form {
        public string Property { get; set; }

        public PropertyForm(string property) {
            InitializeComponent();
            this.Property = property;

            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PUBLIC);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PRIVATE);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PROTECTED);


            this.comboBox_AccessModifiers.SelectedIndex = 0;
            if (property != "") {
                switch (property[0]) {

                    case '-':
                        this.comboBox_AccessModifiers.SelectedIndex = 1;
                        break;
                    case '#':
                        this.comboBox_AccessModifiers.SelectedIndex = 2;
                        break;
                }
                property = property[1..];
                string[] parts = property.Split(':');
                this.textBox_PropertyName.Text = parts[0].Trim();
                this.textBox_Type.Text = parts[1].Trim();
            }
        }

        private void button_OK_Click(object sender, EventArgs e) {
            if (!this.ValidateChildren())
                return;

            string property = "";

            switch ((AccessModifier)this.comboBox_AccessModifiers.SelectedItem) {
                case AccessModifier.PUBLIC:
                    property = "+";
                    break;
                case AccessModifier.PRIVATE:
                    property = "-";
                    break;
                case AccessModifier.PROTECTED:
                    property = "#";
                    break;
            }

            property += this.textBox_PropertyName.Text.Trim();
            if (!string.IsNullOrEmpty(this.textBox_Type.Text)) {
                property += " : ";
                property += this.textBox_Type.Text.Trim();
            }

            this.Property = property;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
    public enum AccessModifier {
        PUBLIC,
        PRIVATE,
        PROTECTED
    }
}
