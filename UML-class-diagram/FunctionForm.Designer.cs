namespace UML_class_diagram {
    partial class FunctionForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_FunctionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_AccessModifiers = new System.Windows.Forms.ComboBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Argument = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(19, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Return data type:";
            // 
            // textBox_FunctionName
            // 
            this.textBox_FunctionName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_FunctionName.Location = new System.Drawing.Point(145, 94);
            this.textBox_FunctionName.Name = "textBox_FunctionName";
            this.textBox_FunctionName.Size = new System.Drawing.Size(121, 27);
            this.textBox_FunctionName.TabIndex = 12;
            this.toolTip1.SetToolTip(this.textBox_FunctionName, "Input for function name");
            this.textBox_FunctionName.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_FunctionName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(19, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Function name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Access modifier:";
            // 
            // comboBox_AccessModifiers
            // 
            this.comboBox_AccessModifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AccessModifiers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox_AccessModifiers.FormattingEnabled = true;
            this.comboBox_AccessModifiers.Location = new System.Drawing.Point(145, 37);
            this.comboBox_AccessModifiers.Name = "comboBox_AccessModifiers";
            this.comboBox_AccessModifiers.Size = new System.Drawing.Size(121, 28);
            this.comboBox_AccessModifiers.TabIndex = 7;
            this.toolTip1.SetToolTip(this.comboBox_AccessModifiers, "Dropdown to select access modifier");
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Cancel.Location = new System.Drawing.Point(181, 224);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(85, 40);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.button_Cancel, "Cancel");
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_OK.Location = new System.Drawing.Point(35, 224);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(85, 40);
            this.button_OK.TabIndex = 5;
            this.button_OK.Text = "OK";
            this.toolTip1.SetToolTip(this.button_OK, "Ok");
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(378, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Arguments:";
            // 
            // textBox_Argument
            // 
            this.textBox_Argument.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_Argument.Location = new System.Drawing.Point(310, 63);
            this.textBox_Argument.Multiline = true;
            this.textBox_Argument.Name = "textBox_Argument";
            this.textBox_Argument.Size = new System.Drawing.Size(227, 178);
            this.textBox_Argument.TabIndex = 14;
            this.toolTip1.SetToolTip(this.textBox_Argument, "Input for arguments. Write each argument on new line. Syntax -> argumentName : da" +
        "taType");
            this.textBox_Argument.WordWrap = false;
            this.textBox_Argument.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Argument_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(368, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Each argument on new line";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(368, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "argumentName : dataType";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Location = new System.Drawing.Point(145, 152);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(121, 28);
            this.comboBox_Type.TabIndex = 16;
            this.comboBox_Type.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Type_Validating);
            // 
            // FunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(568, 300);
            this.Controls.Add(this.comboBox_Type);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Argument);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_FunctionName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_AccessModifiers);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Name = "FunctionForm";
            this.Text = "Function Editor";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label3;
        private TextBox textBox_FunctionName;
        private Label label2;
        private Label label1;
        private ComboBox comboBox_AccessModifiers;
        private Button button_Cancel;
        private Button button_OK;
        private Label label4;
        private TextBox textBox_Argument;
        private Label label5;
        private ToolTip toolTip1;
        private Label label6;
        private ErrorProvider errorProvider1;
        private ComboBox comboBox_Type;
    }
}