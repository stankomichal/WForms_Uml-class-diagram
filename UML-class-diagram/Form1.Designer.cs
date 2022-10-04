namespace UML_class_diagram {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.button_Import = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.panel_ClassProperties = new System.Windows.Forms.Panel();
            this.listBox_Props = new System.Windows.Forms.ListBox();
            this.listBox_Funcs = new System.Windows.Forms.ListBox();
            this.button_DeleteFunc = new System.Windows.Forms.Button();
            this.button_EditFunc = new System.Windows.Forms.Button();
            this.button_DeleteProperty = new System.Windows.Forms.Button();
            this.button_AddFunc = new System.Windows.Forms.Button();
            this.button_EditProperty = new System.Windows.Forms.Button();
            this.button_AddProperty = new System.Windows.Forms.Button();
            this.button_SaveClass = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ClassName = new System.Windows.Forms.TextBox();
            this.pictureBox_Editor = new System.Windows.Forms.PictureBox();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_ClassProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Editor)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Import
            // 
            this.button_Import.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Import.Location = new System.Drawing.Point(993, 12);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(85, 30);
            this.button_Import.TabIndex = 1;
            this.button_Import.Text = "Import";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // button_Export
            // 
            this.button_Export.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Export.Location = new System.Drawing.Point(1087, 12);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(85, 30);
            this.button_Export.TabIndex = 1;
            this.button_Export.Text = "Export";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // button_Add
            // 
            this.button_Add.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Add.Location = new System.Drawing.Point(39, 11);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(125, 30);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Add Class";
            this.toolTip1.SetToolTip(this.button_Add, "Add new class to diagram");
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // panel_ClassProperties
            // 
            this.panel_ClassProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_ClassProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_ClassProperties.Controls.Add(this.listBox_Props);
            this.panel_ClassProperties.Controls.Add(this.listBox_Funcs);
            this.panel_ClassProperties.Controls.Add(this.button_DeleteFunc);
            this.panel_ClassProperties.Controls.Add(this.button_EditFunc);
            this.panel_ClassProperties.Controls.Add(this.button_DeleteProperty);
            this.panel_ClassProperties.Controls.Add(this.button_AddFunc);
            this.panel_ClassProperties.Controls.Add(this.button_EditProperty);
            this.panel_ClassProperties.Controls.Add(this.button_AddProperty);
            this.panel_ClassProperties.Controls.Add(this.button_SaveClass);
            this.panel_ClassProperties.Controls.Add(this.label5);
            this.panel_ClassProperties.Controls.Add(this.label2);
            this.panel_ClassProperties.Controls.Add(this.label1);
            this.panel_ClassProperties.Controls.Add(this.textBox_ClassName);
            this.panel_ClassProperties.Location = new System.Drawing.Point(12, 48);
            this.panel_ClassProperties.Name = "panel_ClassProperties";
            this.panel_ClassProperties.Size = new System.Drawing.Size(178, 601);
            this.panel_ClassProperties.TabIndex = 3;
            // 
            // listBox_Props
            // 
            this.listBox_Props.FormattingEnabled = true;
            this.listBox_Props.ItemHeight = 15;
            this.listBox_Props.Location = new System.Drawing.Point(3, 70);
            this.listBox_Props.Name = "listBox_Props";
            this.listBox_Props.Size = new System.Drawing.Size(170, 184);
            this.listBox_Props.TabIndex = 4;
            this.toolTip1.SetToolTip(this.listBox_Props, "List of properties");
            // 
            // listBox_Funcs
            // 
            this.listBox_Funcs.FormattingEnabled = true;
            this.listBox_Funcs.ItemHeight = 15;
            this.listBox_Funcs.Location = new System.Drawing.Point(3, 316);
            this.listBox_Funcs.Name = "listBox_Funcs";
            this.listBox_Funcs.Size = new System.Drawing.Size(170, 184);
            this.listBox_Funcs.TabIndex = 4;
            this.toolTip1.SetToolTip(this.listBox_Funcs, "List of all functions");
            // 
            // button_DeleteFunc
            // 
            this.button_DeleteFunc.Location = new System.Drawing.Point(118, 506);
            this.button_DeleteFunc.Name = "button_DeleteFunc";
            this.button_DeleteFunc.Size = new System.Drawing.Size(50, 23);
            this.button_DeleteFunc.TabIndex = 6;
            this.button_DeleteFunc.Text = "Delete";
            this.toolTip1.SetToolTip(this.button_DeleteFunc, "Delete selected function");
            this.button_DeleteFunc.UseVisualStyleBackColor = true;
            this.button_DeleteFunc.Click += new System.EventHandler(this.button_DeleteFunc_Click);
            // 
            // button_EditFunc
            // 
            this.button_EditFunc.Location = new System.Drawing.Point(62, 506);
            this.button_EditFunc.Name = "button_EditFunc";
            this.button_EditFunc.Size = new System.Drawing.Size(50, 23);
            this.button_EditFunc.TabIndex = 5;
            this.button_EditFunc.Text = "Edit";
            this.toolTip1.SetToolTip(this.button_EditFunc, "Open new form for editing selected function");
            this.button_EditFunc.UseVisualStyleBackColor = true;
            this.button_EditFunc.Click += new System.EventHandler(this.button_EditFunc_Click);
            // 
            // button_DeleteProperty
            // 
            this.button_DeleteProperty.Location = new System.Drawing.Point(118, 262);
            this.button_DeleteProperty.Name = "button_DeleteProperty";
            this.button_DeleteProperty.Size = new System.Drawing.Size(50, 23);
            this.button_DeleteProperty.TabIndex = 6;
            this.button_DeleteProperty.Text = "Delete";
            this.toolTip1.SetToolTip(this.button_DeleteProperty, "Delete selected property");
            this.button_DeleteProperty.UseVisualStyleBackColor = true;
            this.button_DeleteProperty.Click += new System.EventHandler(this.button_DeleteProperty_Click);
            // 
            // button_AddFunc
            // 
            this.button_AddFunc.Location = new System.Drawing.Point(6, 506);
            this.button_AddFunc.Name = "button_AddFunc";
            this.button_AddFunc.Size = new System.Drawing.Size(50, 23);
            this.button_AddFunc.TabIndex = 5;
            this.button_AddFunc.Text = "Add";
            this.toolTip1.SetToolTip(this.button_AddFunc, "Open form for adding new function");
            this.button_AddFunc.UseVisualStyleBackColor = true;
            this.button_AddFunc.Click += new System.EventHandler(this.button_AddFunc_Click);
            // 
            // button_EditProperty
            // 
            this.button_EditProperty.Location = new System.Drawing.Point(62, 262);
            this.button_EditProperty.Name = "button_EditProperty";
            this.button_EditProperty.Size = new System.Drawing.Size(50, 23);
            this.button_EditProperty.TabIndex = 5;
            this.button_EditProperty.Text = "Edit";
            this.toolTip1.SetToolTip(this.button_EditProperty, "Open new form for editing selected property");
            this.button_EditProperty.UseVisualStyleBackColor = true;
            this.button_EditProperty.Click += new System.EventHandler(this.button_EditProperty_Click);
            // 
            // button_AddProperty
            // 
            this.button_AddProperty.Location = new System.Drawing.Point(6, 262);
            this.button_AddProperty.Name = "button_AddProperty";
            this.button_AddProperty.Size = new System.Drawing.Size(50, 23);
            this.button_AddProperty.TabIndex = 5;
            this.button_AddProperty.Text = "Add";
            this.toolTip1.SetToolTip(this.button_AddProperty, "Open new form for adding new properties");
            this.button_AddProperty.UseVisualStyleBackColor = true;
            this.button_AddProperty.Click += new System.EventHandler(this.button_AddProperty_Click);
            // 
            // button_SaveClass
            // 
            this.button_SaveClass.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_SaveClass.Location = new System.Drawing.Point(49, 555);
            this.button_SaveClass.Name = "button_SaveClass";
            this.button_SaveClass.Size = new System.Drawing.Size(75, 29);
            this.button_SaveClass.TabIndex = 4;
            this.button_SaveClass.Text = "Save";
            this.toolTip1.SetToolTip(this.button_SaveClass, "Save class to diagram");
            this.button_SaveClass.UseVisualStyleBackColor = true;
            this.button_SaveClass.Click += new System.EventHandler(this.button_SaveClass_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Functions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Properties";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class name:";
            // 
            // textBox_ClassName
            // 
            this.textBox_ClassName.Location = new System.Drawing.Point(85, 17);
            this.textBox_ClassName.Name = "textBox_ClassName";
            this.textBox_ClassName.Size = new System.Drawing.Size(88, 23);
            this.textBox_ClassName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox_ClassName, "Input for class name");
            // 
            // pictureBox_Editor
            // 
            this.pictureBox_Editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Editor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Editor.Location = new System.Drawing.Point(196, 48);
            this.pictureBox_Editor.Name = "pictureBox_Editor";
            this.pictureBox_Editor.Size = new System.Drawing.Size(976, 601);
            this.pictureBox_Editor.TabIndex = 0;
            this.pictureBox_Editor.TabStop = false;
            this.pictureBox_Editor.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Editor_Paint);
            this.pictureBox_Editor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Editor_MouseDown);
            this.pictureBox_Editor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Editor_MouseMove);
            this.pictureBox_Editor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Editor_MouseUp);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel_ClassProperties);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.button_Export);
            this.Controls.Add(this.button_Import);
            this.Controls.Add(this.pictureBox_Editor);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Form1";
            this.Text = "UML Class Diagram Editor";
            this.panel_ClassProperties.ResumeLayout(false);
            this.panel_ClassProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Editor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button button_Import;
        private Button button_Export;
        private Button button_Add;
        private Panel panel_ClassProperties;
        private PictureBox pictureBox_Editor;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private Button button_AddProperty;
        private Label label5;
        private Label label2;
        private Label label1;
        private TextBox textBox_ClassName;
        private ListBox listBox_Funcs;
        private ListBox listBox_Props;
        private Button button_DeleteProperty;
        private Button button_EditProperty;
        private Button button_DeleteFunc;
        private Button button_EditFunc;
        private Button button_AddFunc;
        private Button button_SaveClass;
        private ToolTip toolTip1;
    }
}