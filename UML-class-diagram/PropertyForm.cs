using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_class_diagram {
    public partial class PropertyForm : Form {
        public string Property { get; set; }

        public PropertyForm(string property) {
            InitializeComponent();
            this.Property = property;

            // Add dropdown items for access modifiers
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PUBLIC);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PRIVATE);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PROTECTED);

            // Select first access modifier
            this.comboBox_AccessModifiers.SelectedIndex = 0;

            // If property is empty - no need to fill
            if (property == "")
                return;

            // Set Access Modifier from string index [0]
            switch (property[0]) {
                case '-':
                    this.comboBox_AccessModifiers.SelectedIndex = 1;
                    break;
                case '#':
                    this.comboBox_AccessModifiers.SelectedIndex = 2;
                    break;
            }
            // Get property without first char
            property = property[1..];
            // Split by ":"
            string[] parts = property.Split(':');
            // Set property name and trim it
            this.textBox_PropertyName.Text = parts[0].Trim();
            // Set property type and trim it
            this.textBox_Type.Text = parts[1].Trim();
        }

        private void button_OK_Click(object sender, EventArgs e) {
            if (!this.ValidateChildren())
                return;

            string property = "";


            // Set char of access modifier
            AccessModifier modifier = (AccessModifier)this.comboBox_AccessModifiers.SelectedItem;
            property += (char)modifier;

            // Add property name and trim it
            property += this.textBox_PropertyName.Text.Trim();

            // Add divider and add property data type
            property += " : " + this.textBox_Type.Text.Trim();

            // Set property "property"
            this.Property = property;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_PropertyName_Validating(object sender, CancelEventArgs e) {
            TextBox tb = sender as TextBox;
            if (tb is null)
                return;
            this.errorProvider1.SetError(tb, null);

            if (!Regex.IsMatch(tb.Text, @"^[a-zA-Z0-9_]+$")) {
                e.Cancel = true;
                this.errorProvider1.SetError(tb, "Only lowercase, uppercase letters or numbers or underscore.");
            }
        }

        private void textBox_Type_Validating(object sender, CancelEventArgs e) {
            TextBox tb = sender as TextBox;
            if (tb is null)
                return;
            this.errorProvider1.SetError(tb, null);

            if (!Regex.IsMatch(tb.Text, @"^[a-zA-Z]+$")) {
                e.Cancel = true;
                this.errorProvider1.SetError(tb, "Only lowercase or uppercase letters.");
            }
        }
    }
    public enum AccessModifier {
        PUBLIC = '+',
        PRIVATE = '-',
        PROTECTED = '#',
    }
}
