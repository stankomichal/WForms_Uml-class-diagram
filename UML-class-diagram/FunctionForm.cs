using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_class_diagram {
    public partial class FunctionForm : Form {
        public string Function { get; set; }
        public FunctionForm(string function) {
            InitializeComponent();
            this.Function = function;

            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PUBLIC);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PRIVATE);
            this.comboBox_AccessModifiers.Items.Add(AccessModifier.PROTECTED);


            this.comboBox_AccessModifiers.SelectedIndex = 0;
            if (function != "") {
                switch (function[0]) {

                    case '-':
                        this.comboBox_AccessModifiers.SelectedIndex = 1;
                        break;
                    case '#':
                        this.comboBox_AccessModifiers.SelectedIndex = 2;
                        break;
                }
                function = function[1..];
                string[] parts = function.Split(':');
                string[] bracketParts = parts[0].Trim().Split('(');
                this.textBox_FunctionName.Text = bracketParts[0].Trim();

                bracketParts[1] = bracketParts[1][..(bracketParts[1].Length - 1)];

                this.textBox_Argument.Text = bracketParts[1].Replace(", ", "\r\n");

                if (parts.Length != 1)
                    this.textBox_Type.Text = parts[1].Trim();
            }
        }

        private void button_OK_Click(object sender, EventArgs e) {
            if (!this.ValidateChildren())
                return;

            string function = "";

            switch ((AccessModifier)this.comboBox_AccessModifiers.SelectedItem) {
                case AccessModifier.PUBLIC:
                    function = "+";
                    break;
                case AccessModifier.PRIVATE:
                    function = "-";
                    break;
                case AccessModifier.PROTECTED:
                    function = "#";
                    break;
            }

            function += this.textBox_FunctionName.Text.Trim();
            function += "(";
            function += this.textBox_Argument.Text.Trim().Replace("\r\n", ", ");
            function += ")";

            if (!string.IsNullOrEmpty(this.textBox_Type.Text)) {
                function += " : ";
                function += this.textBox_Type.Text.Trim();
            }

            this.Function = function;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
