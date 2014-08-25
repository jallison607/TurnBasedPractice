namespace TurnBasedPractice.Windows
{
    partial class NewEntity
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
            this.nMaxHP = new System.Windows.Forms.NumericUpDown();
            this.nLevel = new System.Windows.Forms.NumericUpDown();
            this.lblWeapon = new System.Windows.Forms.Label();
            this.dgvEntities = new System.Windows.Forms.DataGridView();
            this.EntityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxHP)).BeginInit();
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
            this.lblMaxHP.Size = new System.Drawing.Size(48, 27);
            this.lblMaxHP.TabIndex = 2;
            this.lblMaxHP.Text = "Max HP:";
            this.lblMaxHP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLevel
            // 
            this.lblLevel.Location = new System.Drawing.Point(8, 87);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(48, 23);
            this.lblLevel.TabIndex = 3;
            this.lblLevel.Text = "Level:";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 4;
            // 
            // nMaxHP
            // 
            this.nMaxHP.Location = new System.Drawing.Point(63, 66);
            this.nMaxHP.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nMaxHP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxHP.Name = "nMaxHP";
            this.nMaxHP.Size = new System.Drawing.Size(100, 20);
            this.nMaxHP.TabIndex = 5;
            this.nMaxHP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nLevel
            // 
            this.nLevel.Location = new System.Drawing.Point(63, 89);
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
            this.EntityID,
            this.EntityName,
            this.MaxHP,
            this.Level,
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
            // EntityID
            // 
            this.EntityID.HeaderText = "EntityID";
            this.EntityID.Name = "EntityID";
            this.EntityID.ReadOnly = true;
            this.EntityID.Visible = false;
            // 
            // EntityName
            // 
            this.EntityName.HeaderText = "Name";
            this.EntityName.Name = "EntityName";
            this.EntityName.ReadOnly = true;
            // 
            // MaxHP
            // 
            this.MaxHP.FillWeight = 75F;
            this.MaxHP.HeaderText = "Max HP";
            this.MaxHP.Name = "MaxHP";
            this.MaxHP.ReadOnly = true;
            this.MaxHP.Width = 75;
            // 
            // Level
            // 
            this.Level.FillWeight = 50F;
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            this.Level.Width = 50;
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
            this.label1.Location = new System.Drawing.Point(18, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Speed:";
            // 
            // nSpeed
            // 
            this.nSpeed.Location = new System.Drawing.Point(63, 113);
            this.nSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nSpeed.Name = "nSpeed";
            this.nSpeed.Size = new System.Drawing.Size(100, 20);
            this.nSpeed.TabIndex = 17;
            this.nSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(241, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 19;
            // 
            // NewEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 386);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
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
            this.Controls.Add(this.nMaxHP);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblMaxHP);
            this.Controls.Add(this.lblName);
            this.Name = "NewEntity";
            this.Text = "New Entity";
            this.Load += new System.EventHandler(this.NewEntity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nMaxHP)).EndInit();
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
        private System.Windows.Forms.NumericUpDown nMaxHP;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weapon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}