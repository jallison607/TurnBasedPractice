namespace TurnBasedPractice.Windows
{
    partial class UpdateEffectList
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
            this.cmbCurrent = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblElement = new System.Windows.Forms.Label();
            this.cmbElement = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudEffect = new System.Windows.Forms.NumericUpDown();
            this.cmbSpecial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pSpecial = new System.Windows.Forms.Panel();
            this.pStandard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudEffect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.panel1.SuspendLayout();
            this.pSpecial.SuspendLayout();
            this.pStandard.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCurrent
            // 
            this.cmbCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrent.FormattingEnabled = true;
            this.cmbCurrent.Location = new System.Drawing.Point(60, 15);
            this.cmbCurrent.Name = "cmbCurrent";
            this.cmbCurrent.Size = new System.Drawing.Size(121, 21);
            this.cmbCurrent.TabIndex = 0;
            this.cmbCurrent.SelectedIndexChanged += new System.EventHandler(this.cmbCurrent_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(187, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(52, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblElement
            // 
            this.lblElement.AutoSize = true;
            this.lblElement.Location = new System.Drawing.Point(158, 11);
            this.lblElement.Name = "lblElement";
            this.lblElement.Size = new System.Drawing.Size(48, 13);
            this.lblElement.TabIndex = 4;
            this.lblElement.Text = "Element:";
            // 
            // cmbElement
            // 
            this.cmbElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElement.FormattingEnabled = true;
            this.cmbElement.Items.AddRange(new object[] {
            "Normal",
            "Fire",
            "Water",
            "Air",
            "Earth",
            "Poison",
            "Holy",
            "Time"});
            this.cmbElement.Location = new System.Drawing.Point(213, 8);
            this.cmbElement.Name = "cmbElement";
            this.cmbElement.Size = new System.Drawing.Size(96, 21);
            this.cmbElement.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Type:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Decrease",
            "Increase"});
            this.cmbType.Location = new System.Drawing.Point(58, 44);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(79, 21);
            this.cmbType.TabIndex = 7;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Stat:";
            // 
            // cmbStat
            // 
            this.cmbStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStat.FormattingEnabled = true;
            this.cmbStat.Items.AddRange(new object[] {
            "Hit Points",
            "Magi Points",
            "Strength",
            "Dexterity",
            "Speed"});
            this.cmbStat.Location = new System.Drawing.Point(53, 9);
            this.cmbStat.Name = "cmbStat";
            this.cmbStat.Size = new System.Drawing.Size(96, 21);
            this.cmbStat.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Amount:";
            // 
            // nudEffect
            // 
            this.nudEffect.Location = new System.Drawing.Point(54, 38);
            this.nudEffect.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudEffect.Name = "nudEffect";
            this.nudEffect.Size = new System.Drawing.Size(95, 20);
            this.nudEffect.TabIndex = 11;
            // 
            // cmbSpecial
            // 
            this.cmbSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecial.FormattingEnabled = true;
            this.cmbSpecial.Location = new System.Drawing.Point(56, 24);
            this.cmbSpecial.Name = "cmbSpecial";
            this.cmbSpecial.Size = new System.Drawing.Size(100, 21);
            this.cmbSpecial.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Special:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Duration:";
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(58, 80);
            this.nudDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(79, 20);
            this.nudDuration.TabIndex = 15;
            this.nudDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pSpecial);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.pStandard);
            this.panel1.Controls.Add(this.nudDuration);
            this.panel1.Controls.Add(this.cmbElement);
            this.panel1.Controls.Add(this.lblElement);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Location = new System.Drawing.Point(5, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 119);
            this.panel1.TabIndex = 16;
            // 
            // pSpecial
            // 
            this.pSpecial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSpecial.Controls.Add(this.cmbSpecial);
            this.pSpecial.Controls.Add(this.label4);
            this.pSpecial.Enabled = false;
            this.pSpecial.Location = new System.Drawing.Point(143, 35);
            this.pSpecial.Name = "pSpecial";
            this.pSpecial.Size = new System.Drawing.Size(166, 66);
            this.pSpecial.TabIndex = 21;
            this.pSpecial.Visible = false;
            // 
            // pStandard
            // 
            this.pStandard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pStandard.Controls.Add(this.cmbStat);
            this.pStandard.Controls.Add(this.nudEffect);
            this.pStandard.Controls.Add(this.label2);
            this.pStandard.Controls.Add(this.label3);
            this.pStandard.Location = new System.Drawing.Point(143, 35);
            this.pStandard.Name = "pStandard";
            this.pStandard.Size = new System.Drawing.Size(166, 66);
            this.pStandard.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(5, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 59);
            this.panel2.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(39, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(203, 247);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(282, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Duration indicates over how long the effect takes to apply.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(284, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ex: An effect of 4 with duration of 4 will apply 1 each round";
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(122, 247);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 20;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // UpdateEffectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 278);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbCurrent);
            this.Name = "UpdateEffectList";
            this.Text = "Update Effects List";
            this.Load += new System.EventHandler(this.UpdateEffectList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudEffect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pSpecial.ResumeLayout(false);
            this.pSpecial.PerformLayout();
            this.pStandard.ResumeLayout(false);
            this.pStandard.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCurrent;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblElement;
        private System.Windows.Forms.ComboBox cmbElement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudEffect;
        private System.Windows.Forms.ComboBox cmbSpecial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pStandard;
        private System.Windows.Forms.Panel pSpecial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCommit;
    }
}