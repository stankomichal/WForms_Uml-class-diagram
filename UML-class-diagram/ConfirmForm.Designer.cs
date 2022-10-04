namespace UML_class_diagram {
    partial class ConfirmForm {
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
            this.button_Confirm = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Question = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Confirm
            // 
            this.button_Confirm.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Confirm.Location = new System.Drawing.Point(98, 120);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(102, 41);
            this.button_Confirm.TabIndex = 0;
            this.button_Confirm.Text = "YES";
            this.button_Confirm.UseVisualStyleBackColor = true;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Cancel.Location = new System.Drawing.Point(258, 120);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(102, 41);
            this.button_Cancel.TabIndex = 0;
            this.button_Cancel.Text = "NO";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label_Question
            // 
            this.label_Question.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Question.Location = new System.Drawing.Point(12, 9);
            this.label_Question.Name = "label_Question";
            this.label_Question.Size = new System.Drawing.Size(410, 98);
            this.label_Question.TabIndex = 1;
            this.label_Question.Text = "PLACEHOLDER";
            this.label_Question.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 185);
            this.Controls.Add(this.label_Question);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Confirm);
            this.Name = "ConfirmForm";
            this.Text = "ConfirmForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_Confirm;
        private Button button_Cancel;
        private Label label_Question;
    }
}