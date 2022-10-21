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
using UML_class_diagram.Classes;

namespace UML_class_diagram {
    public partial class PropertyForm : Form {
        /// <summary>
        /// Property so we can access it from Form1
        /// </summary>
        public Property Property { get; set; }
        public PropertyForm(Property property) {
            InitializeComponent();
            this.Property = property;

            // Add dropdown items for access modifiers
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PUBLIC);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PRIVATE);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PROTECTED);

            // Select first access modifier
            this.comboBox_AccessModifiers.SelectedIndex = 0;

            // If property is empty - no need to fill
            if (property == null) {
                this.Property = new();
                return;
            }
            this.Property = property;

            // Set Access Modifier from string index [0]
            switch (this.Property.AccessMod) {
                case AccessModifier.PRIVATE:
                    this.comboBox_AccessModifiers.SelectedIndex = 1;
                    break;
                case AccessModifier.PROTECTED:
                    this.comboBox_AccessModifiers.SelectedIndex = 2;
                    break;
                case AccessModifier.PUBLIC:
                default:
                    this.comboBox_AccessModifiers.SelectedIndex = 0;
                    break;
            }
            foreach (var item in DiagramSettings.GetInstance().ReturnTypes) {
                this.comboBox_type.Items.Add(item);
            }

            this.comboBox_type.Text = this.Property.Data.Type;
            this.textBox_PropertyName.Text = this.Property.Data.Name;
        }

        private void button_OK_Click(object sender, EventArgs e) {
            if (!this.ValidateChildren())
                return;

            this.Property = new();

            // Set char of access modifier
            this.Property.AccessMod = (AccessModifier)this.comboBox_AccessModifiers.SelectedItem;

            // Set property name and trim it
            this.Property.Data.Name = this.textBox_PropertyName.Text.Trim();

            // Set property return type
            this.Property.Data.Type = this.comboBox_type.Text.Trim();

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

            if (!Regex.IsMatch(tb.Text.Trim(), @"^[a-zA-Z0-9_]+$")) {
                e.Cancel = true;
                this.errorProvider1.SetError(tb, "Only lowercase, uppercase letters or numbers or underscore.");
            }
        }

        private void textBox_Type_Validating(object sender, CancelEventArgs e) {
            ComboBox tb = sender as ComboBox;
            if (tb is null)
                return;
            this.errorProvider1.SetError(tb, null);

            if (!Regex.IsMatch(tb.Text.Trim(), @"^[a-zA-Z]+$")) {
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
