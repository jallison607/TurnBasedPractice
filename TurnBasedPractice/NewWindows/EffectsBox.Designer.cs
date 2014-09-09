namespace TurnBasedPractice.Windows
{
    partial class EffectsBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.subBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEffectDuration = new System.Windows.Forms.TextBox();
            this.txtSpecialEffectName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEditEffects = new System.Windows.Forms.Button();
            this.txtEffectAmount = new System.Windows.Forms.TextBox();
            this.txtStatChanged = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtElement = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lstEffects = new System.Windows.Forms.ListBox();
            this.cmbEffects = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.subBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // subBox
            // 
            this.subBox.Controls.Add(this.label8);
            this.subBox.Controls.Add(this.txtEffectDuration);
            this.subBox.Controls.Add(this.txtSpecialEffectName);
            this.subBox.Controls.Add(this.label6);
            this.subBox.Controls.Add(this.btnEditEffects);
            this.subBox.Controls.Add(this.txtEffectAmount);
            this.subBox.Controls.Add(this.txtStatChanged);
            this.subBox.Controls.Add(this.txtType);
            this.subBox.Controls.Add(this.txtElement);
            this.subBox.Controls.Add(this.btnRemove);
            this.subBox.Controls.Add(this.label5);
            this.subBox.Controls.Add(this.lstEffects);
            this.subBox.Controls.Add(this.cmbEffects);
            this.subBox.Controls.Add(this.btnAdd);
            this.subBox.Controls.Add(this.txtName);
            this.subBox.Controls.Add(this.label2);
            this.subBox.Controls.Add(this.label4);
            this.subBox.Controls.Add(this.label3);
            this.subBox.Location = new System.Drawing.Point(5, 2);
            this.subBox.Name = "subBox";
            this.subBox.Size = new System.Drawing.Size(360, 232);
            this.subBox.TabIndex = 2;
            this.subBox.TabStop = false;
            this.subBox.Text = "Effects";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Duration:";
            // 
            // txtEffectDuration
            // 
            this.txtEffectDuration.Location = new System.Drawing.Point(70, 204);
            this.txtEffectDuration.Name = "txtEffectDuration";
            this.txtEffectDuration.ReadOnly = true;
            this.txtEffectDuration.Size = new System.Drawing.Size(100, 20);
            this.txtEffectDuration.TabIndex = 23;
            // 
            // txtSpecialEffectName
            // 
            this.txtSpecialEffectName.Location = new System.Drawing.Point(224, 204);
            this.txtSpecialEffectName.Name = "txtSpecialEffectName";
            this.txtSpecialEffectName.ReadOnly = true;
            this.txtSpecialEffectName.Size = new System.Drawing.Size(100, 20);
            this.txtSpecialEffectName.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Special:";
            // 
            // btnEditEffects
            // 
            this.btnEditEffects.Location = new System.Drawing.Point(181, 106);
            this.btnEditEffects.Name = "btnEditEffects";
            this.btnEditEffects.Size = new System.Drawing.Size(138, 23);
            this.btnEditEffects.TabIndex = 20;
            this.btnEditEffects.Text = "Edit Effects List";
            this.btnEditEffects.UseVisualStyleBackColor = true;
            this.btnEditEffects.Click += new System.EventHandler(this.btnEditEffects_Click);
            // 
            // txtEffectAmount
            // 
            this.txtEffectAmount.Location = new System.Drawing.Point(251, 173);
            this.txtEffectAmount.Name = "txtEffectAmount";
            this.txtEffectAmount.ReadOnly = true;
            this.txtEffectAmount.Size = new System.Drawing.Size(68, 20);
            this.txtEffectAmount.TabIndex = 19;
            // 
            // txtStatChanged
            // 
            this.txtStatChanged.Location = new System.Drawing.Point(119, 174);
            this.txtStatChanged.Name = "txtStatChanged";
            this.txtStatChanged.ReadOnly = true;
            this.txtStatChanged.Size = new System.Drawing.Size(100, 20);
            this.txtStatChanged.TabIndex = 18;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(12, 174);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(100, 20);
            this.txtType.TabIndex = 17;
            // 
            // txtElement
            // 
            this.txtElement.Location = new System.Drawing.Point(226, 141);
            this.txtElement.Name = "txtElement";
            this.txtElement.ReadOnly = true;
            this.txtElement.Size = new System.Drawing.Size(100, 20);
            this.txtElement.TabIndex = 16;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(256, 20);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(63, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Effect:";
            // 
            // lstEffects
            // 
            this.lstEffects.BackColor = System.Drawing.SystemColors.Control;
            this.lstEffects.FormattingEnabled = true;
            this.lstEffects.Location = new System.Drawing.Point(7, 20);
            this.lstEffects.Name = "lstEffects";
            this.lstEffects.Size = new System.Drawing.Size(244, 69);
            this.lstEffects.TabIndex = 0;
            // 
            // cmbEffects
            // 
            this.cmbEffects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEffects.FormattingEnabled = true;
            this.cmbEffects.Location = new System.Drawing.Point(54, 108);
            this.cmbEffects.Name = "cmbEffects";
            this.cmbEffects.Size = new System.Drawing.Size(121, 21);
            this.cmbEffects.TabIndex = 14;
            this.cmbEffects.SelectedIndexChanged += new System.EventHandler(this.cmbEffects_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(257, 49);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(54, 144);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(106, 20);
            this.txtName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "By";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Element:";
            // 
            // EffectsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.subBox);
            this.Name = "EffectsBox";
            this.Size = new System.Drawing.Size(374, 243);
            this.subBox.ResumeLayout(false);
            this.subBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox subBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEffectDuration;
        private System.Windows.Forms.TextBox txtSpecialEffectName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEditEffects;
        private System.Windows.Forms.TextBox txtEffectAmount;
        private System.Windows.Forms.TextBox txtStatChanged;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtElement;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstEffects;
        private System.Windows.Forms.ComboBox cmbEffects;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;

    }
}
