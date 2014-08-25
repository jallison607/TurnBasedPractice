namespace TurnBasedPractice.Windows
{
    partial class NewItem
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
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rPotion = new System.Windows.Forms.RadioButton();
            this.rWeapon = new System.Windows.Forms.RadioButton();
            this.lblEffect = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.nEffect = new System.Windows.Forms.NumericUpDown();
            this.nValue = new System.Windows.Forms.NumericUpDown();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAddEdit = new System.Windows.Forms.Button();
            this.lblAttackRollBonus = new System.Windows.Forms.Label();
            this.nAttackRollBonus = new System.Windows.Forms.NumericUpDown();
            this.btnExit = new System.Windows.Forms.Button();
            this.nIDForce = new System.Windows.Forms.NumericUpDown();
            this.cIDOverride = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttackRollBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nEffect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAttackRollBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIDForce)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.Value,
            this.Potency,
            this.Damage,
            this.AttackRollBonus});
            this.dgvItems.Location = new System.Drawing.Point(12, 253);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(396, 198);
            this.dgvItems.TabIndex = 13;
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(252, 212);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 49);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(42, 52);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rPotion);
            this.groupBox1.Controls.Add(this.rWeapon);
            this.groupBox1.Location = new System.Drawing.Point(233, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // rPotion
            // 
            this.rPotion.AutoSize = true;
            this.rPotion.Location = new System.Drawing.Point(17, 60);
            this.rPotion.Name = "rPotion";
            this.rPotion.Size = new System.Drawing.Size(55, 17);
            this.rPotion.TabIndex = 1;
            this.rPotion.TabStop = true;
            this.rPotion.Text = "Potion";
            this.rPotion.UseVisualStyleBackColor = true;
            this.rPotion.CheckedChanged += new System.EventHandler(this.rPotion_CheckedChanged);
            // 
            // rWeapon
            // 
            this.rWeapon.AutoSize = true;
            this.rWeapon.Checked = true;
            this.rWeapon.Location = new System.Drawing.Point(17, 23);
            this.rWeapon.Name = "rWeapon";
            this.rWeapon.Size = new System.Drawing.Size(66, 17);
            this.rWeapon.TabIndex = 0;
            this.rWeapon.TabStop = true;
            this.rWeapon.Text = "Weapon";
            this.rWeapon.UseVisualStyleBackColor = true;
            this.rWeapon.CheckedChanged += new System.EventHandler(this.rWeapon_CheckedChanged);
            // 
            // lblEffect
            // 
            this.lblEffect.Location = new System.Drawing.Point(14, 85);
            this.lblEffect.Name = "lblEffect";
            this.lblEffect.Size = new System.Drawing.Size(67, 20);
            this.lblEffect.TabIndex = 10;
            this.lblEffect.Text = "Damage:";
            this.lblEffect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(30, 137);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(52, 20);
            this.lblValue.TabIndex = 12;
            this.lblValue.Text = "Value:";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nEffect
            // 
            this.nEffect.Location = new System.Drawing.Point(87, 85);
            this.nEffect.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nEffect.Name = "nEffect";
            this.nEffect.Size = new System.Drawing.Size(99, 20);
            this.nEffect.TabIndex = 1;
            // 
            // nValue
            // 
            this.nValue.Location = new System.Drawing.Point(88, 137);
            this.nValue.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nValue.Name = "nValue";
            this.nValue.Size = new System.Drawing.Size(99, 20);
            this.nValue.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 212);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAddEdit
            // 
            this.btnAddEdit.Location = new System.Drawing.Point(93, 212);
            this.btnAddEdit.Name = "btnAddEdit";
            this.btnAddEdit.Size = new System.Drawing.Size(75, 23);
            this.btnAddEdit.TabIndex = 5;
            this.btnAddEdit.Text = "Add/Edit";
            this.btnAddEdit.UseVisualStyleBackColor = true;
            this.btnAddEdit.Click += new System.EventHandler(this.btnAddEdit_Click);
            // 
            // lblAttackRollBonus
            // 
            this.lblAttackRollBonus.Location = new System.Drawing.Point(27, 111);
            this.lblAttackRollBonus.Name = "lblAttackRollBonus";
            this.lblAttackRollBonus.Size = new System.Drawing.Size(55, 23);
            this.lblAttackRollBonus.TabIndex = 11;
            this.lblAttackRollBonus.Text = "AttackRollBonus:";
            this.lblAttackRollBonus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nAttackRollBonus
            // 
            this.nAttackRollBonus.Location = new System.Drawing.Point(87, 111);
            this.nAttackRollBonus.Name = "nAttackRollBonus";
            this.nAttackRollBonus.Size = new System.Drawing.Size(100, 20);
            this.nAttackRollBonus.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(333, 212);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // nIDForce
            // 
            this.nIDForce.Enabled = false;
            this.nIDForce.Location = new System.Drawing.Point(357, 146);
            this.nIDForce.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nIDForce.Name = "nIDForce";
            this.nIDForce.Size = new System.Drawing.Size(34, 20);
            this.nIDForce.TabIndex = 14;
            // 
            // cIDOverride
            // 
            this.cIDOverride.AutoSize = true;
            this.cIDOverride.Location = new System.Drawing.Point(284, 147);
            this.cIDOverride.Name = "cIDOverride";
            this.cIDOverride.Size = new System.Drawing.Size(67, 17);
            this.cIDOverride.TabIndex = 15;
            this.cIDOverride.Text = "Force ID";
            this.cIDOverride.UseVisualStyleBackColor = true;
            this.cIDOverride.CheckedChanged += new System.EventHandler(this.cIDOverride_CheckedChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(173, 212);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // ItemID
            // 
            this.ItemID.FillWeight = 30F;
            this.ItemID.HeaderText = "ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.Width = 30;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Potency
            // 
            this.Potency.HeaderText = "Potency";
            this.Potency.Name = "Potency";
            this.Potency.ReadOnly = true;
            // 
            // Damage
            // 
            this.Damage.HeaderText = "Damage";
            this.Damage.Name = "Damage";
            this.Damage.ReadOnly = true;
            // 
            // AttackRollBonus
            // 
            this.AttackRollBonus.HeaderText = "AttackRollBonus";
            this.AttackRollBonus.Name = "AttackRollBonus";
            this.AttackRollBonus.ReadOnly = true;
            // 
            // NewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 463);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.cIDOverride);
            this.Controls.Add(this.nIDForce);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.nAttackRollBonus);
            this.Controls.Add(this.lblAttackRollBonus);
            this.Controls.Add(this.btnAddEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.nValue);
            this.Controls.Add(this.nEffect);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblEffect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvItems);
            this.Name = "NewItem";
            this.Text = "New Items";
            this.Load += new System.EventHandler(this.NewItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nEffect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAttackRollBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIDForce)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rPotion;
        private System.Windows.Forms.RadioButton rWeapon;
        private System.Windows.Forms.Label lblEffect;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.NumericUpDown nEffect;
        private System.Windows.Forms.NumericUpDown nValue;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAddEdit;
        private System.Windows.Forms.Label lblAttackRollBonus;
        private System.Windows.Forms.NumericUpDown nAttackRollBonus;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NumericUpDown nIDForce;
        private System.Windows.Forms.CheckBox cIDOverride;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttackRollBonus;
    }
}