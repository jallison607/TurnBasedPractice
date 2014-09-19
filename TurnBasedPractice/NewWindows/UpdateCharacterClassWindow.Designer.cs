namespace TurnBasedPractice.Windows
{
    partial class UpdateCharacterClassWindow
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
            this.components = new System.ComponentModel.Container();
            this.cmbCurrent = new System.Windows.Forms.ComboBox();
            this.characterClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSpeedBonus = new System.Windows.Forms.NumericUpDown();
            this.nudSpiritBonus = new System.Windows.Forms.NumericUpDown();
            this.nudStrBonus = new System.Windows.Forms.NumericUpDown();
            this.nudDexBonus = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMagiBonus = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudConBonus = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clElements = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAbilities = new System.Windows.Forms.ComboBox();
            this.abilityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstAbilities = new System.Windows.Forms.ListBox();
            this.listedAbilityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.characterClassBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpiritBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDexBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagiBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConBonus)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listedAbilityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCurrent
            // 
            this.cmbCurrent.DataSource = this.characterClassBindingSource;
            this.cmbCurrent.DisplayMember = "ClassName";
            this.cmbCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrent.FormattingEnabled = true;
            this.cmbCurrent.Location = new System.Drawing.Point(39, 22);
            this.cmbCurrent.Name = "cmbCurrent";
            this.cmbCurrent.Size = new System.Drawing.Size(249, 21);
            this.cmbCurrent.TabIndex = 0;
            this.cmbCurrent.ValueMember = "ClassID";
            this.cmbCurrent.SelectedIndexChanged += new System.EventHandler(this.cmbCurrent_SelectedIndexChanged);
            // 
            // characterClassBindingSource
            // 
            this.characterClassBindingSource.DataSource = typeof(TurnBasedPractice.GameClasses.CharacterClass);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(307, 22);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete Class";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudSpeedBonus);
            this.groupBox1.Controls.Add(this.nudSpiritBonus);
            this.groupBox1.Controls.Add(this.nudStrBonus);
            this.groupBox1.Controls.Add(this.nudDexBonus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudMagiBonus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudConBonus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 113);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stat Bonuses";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(160, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Speed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Spirit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Strength:";
            // 
            // nudSpeedBonus
            // 
            this.nudSpeedBonus.Location = new System.Drawing.Point(207, 74);
            this.nudSpeedBonus.Name = "nudSpeedBonus";
            this.nudSpeedBonus.Size = new System.Drawing.Size(53, 20);
            this.nudSpeedBonus.TabIndex = 8;
            // 
            // nudSpiritBonus
            // 
            this.nudSpiritBonus.Location = new System.Drawing.Point(207, 47);
            this.nudSpiritBonus.Name = "nudSpiritBonus";
            this.nudSpiritBonus.Size = new System.Drawing.Size(53, 20);
            this.nudSpiritBonus.TabIndex = 7;
            // 
            // nudStrBonus
            // 
            this.nudStrBonus.Location = new System.Drawing.Point(207, 20);
            this.nudStrBonus.Name = "nudStrBonus";
            this.nudStrBonus.Size = new System.Drawing.Size(53, 20);
            this.nudStrBonus.TabIndex = 6;
            // 
            // nudDexBonus
            // 
            this.nudDexBonus.Location = new System.Drawing.Point(79, 74);
            this.nudDexBonus.Name = "nudDexBonus";
            this.nudDexBonus.Size = new System.Drawing.Size(53, 20);
            this.nudDexBonus.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dexterity:";
            // 
            // nudMagiBonus
            // 
            this.nudMagiBonus.Location = new System.Drawing.Point(79, 47);
            this.nudMagiBonus.Name = "nudMagiBonus";
            this.nudMagiBonus.Size = new System.Drawing.Size(53, 20);
            this.nudMagiBonus.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Magi:";
            // 
            // nudConBonus
            // 
            this.nudConBonus.Location = new System.Drawing.Point(79, 20);
            this.nudConBonus.Name = "nudConBonus";
            this.nudConBonus.Size = new System.Drawing.Size(53, 20);
            this.nudConBonus.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Constitution:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(156, 20);
            this.txtName.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clElements);
            this.groupBox2.Location = new System.Drawing.Point(294, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 113);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permitted Elements";
            // 
            // clElements
            // 
            this.clElements.CheckOnClick = true;
            this.clElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clElements.FormattingEnabled = true;
            this.clElements.Location = new System.Drawing.Point(3, 16);
            this.clElements.Name = "clElements";
            this.clElements.Size = new System.Drawing.Size(143, 94);
            this.clElements.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Controls.Add(this.btnDetails);
            this.groupBox3.Controls.Add(this.nudLevel);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmbAbilities);
            this.groupBox3.Controls.Add(this.btnRemove);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.lstAbilities);
            this.groupBox3.Location = new System.Drawing.Point(12, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 218);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Abilities";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(252, 134);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(76, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit Abilities";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(189, 134);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(57, 23);
            this.btnDetails.TabIndex = 7;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // nudLevel
            // 
            this.nudLevel.Location = new System.Drawing.Point(108, 174);
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(73, 20);
            this.nudLevel.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Learned at Level:";
            // 
            // cmbAbilities
            // 
            this.cmbAbilities.DataSource = this.abilityBindingSource;
            this.cmbAbilities.DisplayMember = "AbilityName";
            this.cmbAbilities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAbilities.FormattingEnabled = true;
            this.cmbAbilities.Location = new System.Drawing.Point(15, 134);
            this.cmbAbilities.Name = "cmbAbilities";
            this.cmbAbilities.Size = new System.Drawing.Size(167, 21);
            this.cmbAbilities.TabIndex = 3;
            this.cmbAbilities.ValueMember = "AbilityID";
            this.cmbAbilities.SelectedIndexChanged += new System.EventHandler(this.cmbAbilities_SelectedIndexChanged);
            // 
            // abilityBindingSource
            // 
            this.abilityBindingSource.DataSource = typeof(TurnBasedPractice.GameClasses.Ability);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(282, 172);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(119, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove from Class";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(188, 172);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add to Class";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstAbilities
            // 
            this.lstAbilities.DataSource = this.listedAbilityBindingSource;
            this.lstAbilities.DisplayMember = "ListText";
            this.lstAbilities.FormattingEnabled = true;
            this.lstAbilities.Location = new System.Drawing.Point(11, 19);
            this.lstAbilities.Name = "lstAbilities";
            this.lstAbilities.Size = new System.Drawing.Size(414, 95);
            this.lstAbilities.TabIndex = 0;
            this.lstAbilities.ValueMember = "AbilityID";
            this.lstAbilities.SelectedIndexChanged += new System.EventHandler(this.lstAbilities_SelectedIndexChanged);
            // 
            // listedAbilityBindingSource
            // 
            this.listedAbilityBindingSource.DataSource = typeof(TurnBasedPractice.Windows.ListedAbility);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(83, 477);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save to Cache";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(183, 477);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(89, 23);
            this.btnCommit.TabIndex = 8;
            this.btnCommit.Text = "Commit Cache";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(278, 477);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // UpdateCharacterClassWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 517);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbCurrent);
            this.MaximumSize = new System.Drawing.Size(472, 555);
            this.MinimumSize = new System.Drawing.Size(472, 555);
            this.Name = "UpdateCharacterClassWindow";
            this.Text = "Modify Character Class List";
            ((System.ComponentModel.ISupportInitialize)(this.characterClassBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpiritBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDexBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagiBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConBonus)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listedAbilityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCurrent;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudSpeedBonus;
        private System.Windows.Forms.NumericUpDown nudSpiritBonus;
        private System.Windows.Forms.NumericUpDown nudStrBonus;
        private System.Windows.Forms.NumericUpDown nudDexBonus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMagiBonus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudConBonus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clElements;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbAbilities;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstAbilities;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.BindingSource characterClassBindingSource;
        private System.Windows.Forms.BindingSource listedAbilityBindingSource;
        private System.Windows.Forms.BindingSource abilityBindingSource;
    }
}