namespace TurnBasedPractice.Windows
{
    partial class NewEntityTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblMaxHP = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.nBaseHP = new System.Windows.Forms.NumericUpDown();
            this.nLevel = new System.Windows.Forms.NumericUpDown();
            this.lblWeapon = new System.Windows.Forms.Label();
            this.dgvEntities = new System.Windows.Forms.DataGridView();
            this.TemplateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntityTemplateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weapon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWeapon = new System.Windows.Forms.TextBox();
            this.btnWepChange = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAddEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nSpeed = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nBaseHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(5, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaxHP
            // 
            this.lblMaxHP.Location = new System.Drawing.Point(8, 60);
            this.lblMaxHP.Name = "lblMaxHP";
            this.lblMaxHP.Size = new System.Drawing.Size(61, 27);
            this.lblMaxHP.TabIndex = 2;
            this.lblMaxHP.Text = "Base HP:";
            this.lblMaxHP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLevel
            // 
            this.lblLevel.Location = new System.Drawing.Point(8, 87);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(61, 30);
            this.lblLevel.TabIndex = 3;
            this.lblLevel.Text = "Min Level:";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 4;
            // 
            // nBaseHP
            // 
            this.nBaseHP.Location = new System.Drawing.Point(75, 65);
            this.nBaseHP.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nBaseHP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nBaseHP.Name = "nBaseHP";
            this.nBaseHP.Size = new System.Drawing.Size(100, 20);
            this.nBaseHP.TabIndex = 5;
            this.nBaseHP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nLevel
            // 
            this.nLevel.Location = new System.Drawing.Point(75, 94);
            this.nLevel.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nLevel.Name = "nLevel";
            this.nLevel.Size = new System.Drawing.Size(100, 20);
            this.nLevel.TabIndex = 6;
            this.nLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblWeapon
            // 
            this.lblWeapon.AutoSize = true;
            this.lblWeapon.Location = new System.Drawing.Point(175, 34);
            this.lblWeapon.Name = "lblWeapon";
            this.lblWeapon.Size = new System.Drawing.Size(51, 13);
            this.lblWeapon.TabIndex = 7;
            this.lblWeapon.Text = "Weapon:";
            // 
            // dgvEntities
            // 
            this.dgvEntities.AllowUserToAddRows = false;
            this.dgvEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TemplateID,
            this.EntityTemplateName,
            this.BaseHP,
            this.MinLevel,
            this.Weapon,
            this.Speed});
            this.dgvEntities.Location = new System.Drawing.Point(8, 224);
            this.dgvEntities.Name = "dgvEntities";
            this.dgvEntities.ReadOnly = true;
            this.dgvEntities.RowHeadersVisible = false;
            this.dgvEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntities.Size = new System.Drawing.Size(386, 150);
            this.dgvEntities.TabIndex = 8;
            this.dgvEntities.SelectionChanged += new System.EventHandler(this.dgvEntities_SelectionChanged);
            // 
            // TemplateID
            // 
            this.TemplateID.HeaderText = "TemplateID";
            this.TemplateID.Name = "TemplateID";
            this.TemplateID.ReadOnly = true;
            this.TemplateID.Visible = false;
            // 
            // EntityTemplateName
            // 
            this.EntityTemplateName.HeaderText = "Template Name";
            this.EntityTemplateName.Name = "EntityTemplateName";
            this.EntityTemplateName.ReadOnly = true;
            // 
            // BaseHP
            // 
            this.BaseHP.FillWeight = 75F;
            this.BaseHP.HeaderText = "Base HP";
            this.BaseHP.Name = "BaseHP";
            this.BaseHP.ReadOnly = true;
            this.BaseHP.Width = 75;
            // 
            // MinLevel
            // 
            this.MinLevel.FillWeight = 50F;
            this.MinLevel.HeaderText = "Minimum Level";
            this.MinLevel.Name = "MinLevel";
            this.MinLevel.ReadOnly = true;
            this.MinLevel.Width = 50;
            // 
            // Weapon
            // 
            this.Weapon.HeaderText = "Weapon";
            this.Weapon.Name = "Weapon";
            this.Weapon.ReadOnly = true;
            // 
            // Speed
            // 
            this.Speed.FillWeight = 50F;
            this.Speed.HeaderText = "Speed";
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            this.Speed.Width = 50;
            // 
            // txtWeapon
            // 
            this.txtWeapon.Location = new System.Drawing.Point(228, 31);
            this.txtWeapon.Name = "txtWeapon";
            this.txtWeapon.ReadOnly = true;
            this.txtWeapon.Size = new System.Drawing.Size(100, 20);
            this.txtWeapon.TabIndex = 9;
            // 
            // btnWepChange
            // 
            this.btnWepChange.Location = new System.Drawing.Point(334, 29);
            this.btnWepChange.Name = "btnWepChange";
            this.btnWepChange.Size = new System.Drawing.Size(60, 23);
            this.btnWepChange.TabIndex = 10;
            this.btnWepChange.Text = "Change";
            this.btnWepChange.UseVisualStyleBackColor = true;
            this.btnWepChange.Click += new System.EventHandler(this.btnWepChange_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(7, 195);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAddEdit
            // 
            this.btnAddEdit.Location = new System.Drawing.Point(85, 195);
            this.btnAddEdit.Name = "btnAddEdit";
            this.btnAddEdit.Size = new System.Drawing.Size(75, 23);
            this.btnAddEdit.TabIndex = 12;
            this.btnAddEdit.Text = "Add/Edit";
            this.btnAddEdit.UseVisualStyleBackColor = true;
            this.btnAddEdit.Click += new System.EventHandler(this.btnAddEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(241, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(319, 195);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(164, 195);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Speed:";
            // 
            // nSpeed
            // 
            this.nSpeed.Location = new System.Drawing.Point(75, 120);
            this.nSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nSpeed.Name = "nSpeed";
            this.nSpeed.Size = new System.Drawing.Size(120, 20);
            this.nSpeed.TabIndex = 7;
            this.nSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NewEntityTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 386);
            this.Controls.Add(this.nSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnWepChange);
            this.Controls.Add(this.txtWeapon);
            this.Controls.Add(this.dgvEntities);
            this.Controls.Add(this.lblWeapon);
            this.Controls.Add(this.nLevel);
            this.Controls.Add(this.nBaseHP);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblMaxHP);
            this.Controls.Add(this.lblName);
            this.Name = "NewEntityTemplate";
            this.Text = "New Entity Template";
            this.Load += new System.EventHandler(this.NewEntityTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nBaseHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMaxHP;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown nBaseHP;
        private System.Windows.Forms.NumericUpDown nLevel;
        private System.Windows.Forms.Label lblWeapon;
        private System.Windows.Forms.DataGridView dgvEntities;
        private System.Windows.Forms.TextBox txtWeapon;
        private System.Windows.Forms.Button btnWepChange;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAddEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityTemplateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weapon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
    }
}