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

namespace UML_class_diagram {
    public partial class FunctionForm : Form {
        public string Function { get; set; } // Function so we can access it from Form1
        public FunctionForm(string function) {
            InitializeComponent();

            // Add dropdown items for access modifiers
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PUBLIC);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PRIVATE);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PROTECTED);

            // Select first access modifier
            this.comboBox_AccessModifiers.SelectedIndex = 0;

            // If function is empty - no need to fill
            if (function == "")
                return;

            // Set Access Modifier from string index [0]
            switch (function[0]) {
                case '-':
                    this.comboBox_AccessModifiers.SelectedIndex = 1;
                    break;
                case '#':
                    this.comboBox_AccessModifiers.SelectedIndex = 2;
                    break;
            }

            // Get function return type
            // If return type is void then set empty string
            string funcType = function.Substring(function.LastIndexOf(':') + 1).Trim();
            this.textBox_Type.Text = funcType == "void" ? "" : funcType;


            // Find index of left / right bracket 
            int leftBracketIndex = function.IndexOf('(');
            int rightBracketIndex = function.IndexOf(')');

            // Get all arguments inside indexes, replace "," with \r\n
            string arguments = function.Substring(leftBracketIndex + 1, rightBracketIndex - leftBracketIndex - 1);
            this.textBox_Argument.Text = arguments.Replace(", ", "\r\n");

            // Set function name from second letter to left bracket
            this.textBox_FunctionName.Text = function[1..(leftBracketIndex)];
        }

        private void button_OK_Click(object sender, EventArgs e) {
            if (!this.ValidateChildren())
                return;

            // Variable for whole function
            string function = "";

            // Set char of access modifier
            AccessModifier modifier = (AccessModifier)this.comboBox_AccessModifiers.SelectedItem;
            function += (char)modifier;

            // Add function name add trim it 
            function += this.textBox_FunctionName.Text.Trim();
            // Add function arguments, trim it and replace "\r\n" with ", "
            function += $"({this.textBox_Argument.Text.Trim().Replace("\r\n", ", ")})";

            // Add divider
            function += " : ";

            // If return type not empty set to return type else set it to void
            if (!string.IsNullOrEmpty(this.textBox_Type.Text))
                function += this.textBox_Type.Text.Trim();
            else
                function += "void";

            // Set property function
            this.Function = function;

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
