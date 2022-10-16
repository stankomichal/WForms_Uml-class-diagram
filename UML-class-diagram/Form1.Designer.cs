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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button_Add = new System.Windows.Forms.Button();
            this.panel_ClassProperties = new System.Windows.Forms.Panel();
            this.checkBox_Abstract = new System.Windows.Forms.CheckBox();
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
            this.panel_DiagramProperties = new System.Windows.Forms.Panel();
            this.pictureBox_Editor = new System.Windows.Forms.PictureBox();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel_RelationProperties = new System.Windows.Forms.Panel();
            this.comboBox_Relation_Card_To = new System.Windows.Forms.ComboBox();
            this.comboBox_Relation_Card_From = new System.Windows.Forms.ComboBox();
            this.comboBox_RelationType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Relation_Delete = new System.Windows.Forms.Button();
            this.button_Relation_Save = new System.Windows.Forms.Button();
            this.panel_ClassProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Editor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel_RelationProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Import
            // 
            this.button_Import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Import.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Import.Location = new System.Drawing.Point(993, 7);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(85, 30);
            this.button_Import.TabIndex = 1;
            this.button_Import.Text = "Import";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // button_Export
            // 
            this.button_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Export.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Export.Location = new System.Drawing.Point(1087, 7);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(85, 30);
            this.button_Export.TabIndex = 1;
            this.button_Export.Text = "Export";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(36, 4);
            // 
            // button_Add
            // 
            this.button_Add.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Add.Location = new System.Drawing.Point(39, 6);
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
            this.panel_ClassProperties.Controls.Add(this.checkBox_Abstract);
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
            this.panel_ClassProperties.Location = new System.Drawing.Point(5, 43);
            this.panel_ClassProperties.Name = "panel_ClassProperties";
            this.panel_ClassProperties.Size = new System.Drawing.Size(185, 606);
            this.panel_ClassProperties.TabIndex = 3;
            // 
            // checkBox_Abstract
            // 
            this.checkBox_Abstract.AutoSize = true;
            this.checkBox_Abstract.Location = new System.Drawing.Point(10, 30);
            this.checkBox_Abstract.Name = "checkBox_Abstract";
            this.checkBox_Abstract.Size = new System.Drawing.Size(70, 19);
            this.checkBox_Abstract.TabIndex = 7;
            this.checkBox_Abstract.Text = "Abstract";
            this.checkBox_Abstract.UseVisualStyleBackColor = true;
            // 
            // listBox_Props
            // 
            this.listBox_Props.FormattingEnabled = true;
            this.listBox_Props.ItemHeight = 15;
            this.listBox_Props.Location = new System.Drawing.Point(3, 70);
            this.listBox_Props.Name = "listBox_Props";
            this.listBox_Props.Size = new System.Drawing.Size(177, 184);
            this.listBox_Props.TabIndex = 4;
            this.toolTip1.SetToolTip(this.listBox_Props, "List of properties");
            // 
            // listBox_Funcs
            // 
            this.listBox_Funcs.FormattingEnabled = true;
            this.listBox_Funcs.ItemHeight = 15;
            this.listBox_Funcs.Location = new System.Drawing.Point(3, 316);
            this.listBox_Funcs.Name = "listBox_Funcs";
            this.listBox_Funcs.Size = new System.Drawing.Size(177, 184);
            this.listBox_Funcs.TabIndex = 4;
            this.toolTip1.SetToolTip(this.listBox_Funcs, "List of all functions");
            // 
            // button_DeleteFunc
            // 
            this.button_DeleteFunc.Location = new System.Drawing.Point(122, 506);
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
            this.button_EditFunc.Location = new System.Drawing.Point(66, 506);
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
            this.button_DeleteProperty.Location = new System.Drawing.Point(122, 262);
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
            this.button_AddFunc.Location = new System.Drawing.Point(10, 506);
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
            this.button_EditProperty.Location = new System.Drawing.Point(66, 262);
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
            this.button_AddProperty.Location = new System.Drawing.Point(10, 262);
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
            this.button_SaveClass.Location = new System.Drawing.Point(55, 555);
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
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class name:";
            // 
            // textBox_ClassName
            // 
            this.textBox_ClassName.Location = new System.Drawing.Point(75, 5);
            this.textBox_ClassName.Name = "textBox_ClassName";
            this.textBox_ClassName.Size = new System.Drawing.Size(73, 23);
            this.textBox_ClassName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox_ClassName, "Input for class name");
            this.textBox_ClassName.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_ClassName_Validating);
            // 
            // panel_DiagramProperties
            // 
            this.panel_DiagramProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_DiagramProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_DiagramProperties.Location = new System.Drawing.Point(632, 43);
            this.panel_DiagramProperties.Name = "panel_DiagramProperties";
            this.panel_DiagramProperties.Size = new System.Drawing.Size(185, 606);
            this.panel_DiagramProperties.TabIndex = 8;
            // 
            // pictureBox_Editor
            // 
            this.pictureBox_Editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Editor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Editor.Location = new System.Drawing.Point(196, 43);
            this.pictureBox_Editor.Name = "pictureBox_Editor";
            this.pictureBox_Editor.Size = new System.Drawing.Size(976, 606);
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
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // panel_RelationProperties
            // 
            this.panel_RelationProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_RelationProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_RelationProperties.Controls.Add(this.comboBox_Relation_Card_To);
            this.panel_RelationProperties.Controls.Add(this.comboBox_Relation_Card_From);
            this.panel_RelationProperties.Controls.Add(this.comboBox_RelationType);
            this.panel_RelationProperties.Controls.Add(this.label6);
            this.panel_RelationProperties.Controls.Add(this.label4);
            this.panel_RelationProperties.Controls.Add(this.label3);
            this.panel_RelationProperties.Controls.Add(this.button_Relation_Delete);
            this.panel_RelationProperties.Controls.Add(this.button_Relation_Save);
            this.panel_RelationProperties.Location = new System.Drawing.Point(297, 43);
            this.panel_RelationProperties.Name = "panel_RelationProperties";
            this.panel_RelationProperties.Size = new System.Drawing.Size(185, 606);
            this.panel_RelationProperties.TabIndex = 8;
            this.panel_RelationProperties.Visible = false;
            // 
            // comboBox_Relation_Card_To
            // 
            this.comboBox_Relation_Card_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Relation_Card_To.FormattingEnabled = true;
            this.comboBox_Relation_Card_To.Location = new System.Drawing.Point(26, 280);
            this.comboBox_Relation_Card_To.Name = "comboBox_Relation_Card_To";
            this.comboBox_Relation_Card_To.Size = new System.Drawing.Size(136, 23);
            this.comboBox_Relation_Card_To.TabIndex = 0;
            // 
            // comboBox_Relation_Card_From
            // 
            this.comboBox_Relation_Card_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Relation_Card_From.FormattingEnabled = true;
            this.comboBox_Relation_Card_From.Location = new System.Drawing.Point(26, 161);
            this.comboBox_Relation_Card_From.Name = "comboBox_Relation_Card_From";
            this.comboBox_Relation_Card_From.Size = new System.Drawing.Size(136, 23);
            this.comboBox_Relation_Card_From.TabIndex = 0;
            // 
            // comboBox_RelationType
            // 
            this.comboBox_RelationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RelationType.FormattingEnabled = true;
            this.comboBox_RelationType.Location = new System.Drawing.Point(26, 31);
            this.comboBox_RelationType.Name = "comboBox_RelationType";
            this.comboBox_RelationType.Size = new System.Drawing.Size(136, 23);
            this.comboBox_RelationType.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cardinality to:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cardinality from:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Relation type:";
            // 
            // button_Relation_Delete
            // 
            this.button_Relation_Delete.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Relation_Delete.Location = new System.Drawing.Point(105, 555);
            this.button_Relation_Delete.Name = "button_Relation_Delete";
            this.button_Relation_Delete.Size = new System.Drawing.Size(75, 29);
            this.button_Relation_Delete.TabIndex = 4;
            this.button_Relation_Delete.Text = "Delete";
            this.button_Relation_Delete.UseVisualStyleBackColor = true;
            this.button_Relation_Delete.Click += new System.EventHandler(this.button_Relation_Delete_Click);
            // 
            // button_Relation_Save
            // 
            this.button_Relation_Save.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Relation_Save.Location = new System.Drawing.Point(3, 555);
            this.button_Relation_Save.Name = "button_Relation_Save";
            this.button_Relation_Save.Size = new System.Drawing.Size(75, 29);
            this.button_Relation_Save.TabIndex = 4;
            this.button_Relation_Save.Text = "Save";
            this.button_Relation_Save.UseVisualStyleBackColor = true;
            this.button_Relation_Save.Click += new System.EventHandler(this.button_Relation_Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel_DiagramProperties);
            this.Controls.Add(this.panel_RelationProperties);
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel_RelationProperties.ResumeLayout(false);
            this.panel_RelationProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button button_Import;
        private Button button_Export;
        private Button button_Add;
        public Panel panel_ClassProperties;
        public PictureBox pictureBox_Editor;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        public Button button_AddProperty;
        private Label label5;
        private Label label2;
        private Label label1;
        public TextBox textBox_ClassName;
        public ListBox listBox_Funcs;
        public ListBox listBox_Props;
        public Button button_DeleteProperty;
        public Button button_EditProperty;
        public Button button_DeleteFunc;
        public Button button_EditFunc;
        public Button button_AddFunc;
        public Button button_SaveClass;
        private ToolTip toolTip1;
        private ErrorProvider errorProvider1;
        public CheckBox checkBox_Abstract;
        public Panel panel_DiagramProperties;
        public Panel panel_RelationProperties;
        public ComboBox comboBox_Relation_Card_To;
        public ComboBox comboBox_Relation_Card_From;
        public ComboBox comboBox_RelationType;
        private Label label6;
        private Label label4;
        private Label label3;
        public Button button_Relation_Save;
        public Button button_Relation_Delete;
        private ContextMenuStrip contextMenuStrip1;
    }
}