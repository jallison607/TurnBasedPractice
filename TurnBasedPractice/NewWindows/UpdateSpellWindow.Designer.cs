namespace TurnBasedPractice.Windows
{
    partial class UpdateMagicWindow
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
            this.spellBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.nudMagiCost = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.effectsBox1 = new TurnBasedPractice.Windows.EffectsBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spellBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagiCost)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCurrent
            // 
            this.cmbCurrent.DataSource = this.spellBindingSource;
            this.cmbCurrent.DisplayMember = "SpellName";
            this.cmbCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrent.FormattingEnabled = true;
            this.cmbCurrent.Location = new System.Drawing.Point(13, 13);
            this.cmbCurrent.Name = "cmbCurrent";
            this.cmbCurrent.Size = new System.Drawing.Size(277, 21);
            this.cmbCurrent.TabIndex = 1;
            this.cmbCurrent.ValueMember = "SpellID";
            this.cmbCurrent.SelectedIndexChanged += new System.EventHandler(this.cmbCurrentSpells_SelectedIndexChanged);
            // 
            // spellBindingSource
            // 
            this.spellBindingSource.DataSource = typeof(TurnBasedPractice.GameClasses.Spell);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnCommit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.nudMagiCost);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.effectsBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 384);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Magic Info";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(272, 345);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(160, 345);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(106, 23);
            this.btnCommit.TabIndex = 6;
            this.btnCommit.Text = "Commit Cache";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(62, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save in Cache";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nudMagiCost
            // 
            this.nudMagiCost.Location = new System.Drawing.Point(86, 61);
            this.nudMagiCost.Name = "nudMagiCost";
            this.nudMagiCost.Size = new System.Drawing.Size(76, 20);
            this.nudMagiCost.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Magi Cost:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(167, 20);
            this.txtName.TabIndex = 1;
            // 
            // effectsBox1
            // 
            this.effectsBox1.Location = new System.Drawing.Point(14, 85);
            this.effectsBox1.Name = "effectsBox1";
            this.effectsBox1.Size = new System.Drawing.Size(374, 243);
            this.effectsBox1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(296, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // UpdateMagicWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 437);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbCurrent);
            this.Name = "UpdateMagicWindow";
            this.Text = "Modify Magic List";
            ((System.ComponentModel.ISupportInitialize)(this.spellBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagiCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.EffectsBox effectsBox1;
        private System.Windows.Forms.ComboBox cmbCurrent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown nudMagiCost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource spellBindingSource;
    }
}