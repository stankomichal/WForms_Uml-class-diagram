using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_class_diagram.Classes;

namespace UML_class_diagram {
    public partial class FunctionForm : Form {
        public Function Function { get; set; } // Function so we can access it from Form1
        public FunctionForm(Function function) {
            InitializeComponent();

            // Add dropdown items for access modifiers
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PUBLIC);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PRIVATE);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PROTECTED);

            // Select first access modifier
            this.comboBox_AccessModifiers.SelectedIndex = 0;

            // If function is empty - no need to fill
            if (function == null) {
                this.Function = new();
                return;
            }

            this.Function = function;
            switch (this.Function.AccessMod) {
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
            this.textBox_Type.Text = this.Function.Data.Type;
            this.textBox_FunctionName.Text = this.Function.Data.Name;
            this.textBox_Argument.Text = String.Join("\r\n", this.Function.Arguments);
        }

        private void button_OK_Click(object sender, EventArgs e) {
            if (!this.ValidateChildren())
                return;
            this.Function = new();
            this.Function.AccessMod = (AccessModifier)this.comboBox_AccessModifiers.SelectedItem;
            this.Function.Data.Name = this.textBox_FunctionName.Text.Trim();
            if (!string.IsNullOrEmpty(this.textBox_Type.Text))
                this.Function.Data.Type = this.textBox_Type.Text.Trim();
            else
                this.Function.Data.Type = "void";
            foreach (var item in this.textBox_Argument.Text.Trim().Trim('\r', '\n').Split("\r\n")) {
                string[] parts = item.Split(" : ");
                this.Function.Arguments.Add(new(parts[0], parts[1]));
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_FunctionName_Validating(object sender, CancelEventArgs e) {
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
            TextBox tb = sender as TextBox;
            if (tb is null)
                return;
            this.errorProvider1.SetError(tb, null);

            // If return type is empty, its ok bcs its void :)
            if (tb.Text.Trim() == "")
                return;

            if (!Regex.IsMatch(tb.Text.Trim(), @"^[a-zA-Z]+$")) {
                e.Cancel = true;
                this.errorProvider1.SetError(tb, "Only lowercase or uppercase letters.");
            }

        }
        private void textBox_Argument_Validating(object sender, CancelEventArgs e) {
            TextBox tb = sender as TextBox;
            if (tb is null)
                return;
            this.errorProvider1.SetError(tb, null);

            // If text is empty
            if (tb.Text.Trim() == "" || tb.Text.Trim().Replace("\r\n", "") == "")
                return;

            // Split all arguments by "\r\n"
            string[] parts = tb.Text.Trim().Split("\r\n");


            // For all items in parts match regex and find errors
            foreach (string item in parts) {
                if (!Regex.IsMatch(item, @"^[a-zA-Z0-9_]+ : [a-zA-Z]+$")) {
                    e.Cancel = true;
                    this.errorProvider1.SetError(tb, "'ArgName : ArgType' Only lowercase or uppercase letters. Space around colon is required");
                }
            }
        }
    }
}
