namespace TurnBasedPractice.Windows
{
    partial class UpdateWeaponsWindow
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
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.clbCanUseClasses = new System.Windows.Forms.GroupBox();
            this.cAvailInShops = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.effectsBox1 = new TurnBasedPractice.Windows.EffectsBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudPower = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudValue = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clClasses = new System.Windows.Forms.CheckedListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.clbCanUseClasses.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCurrent
            // 
            this.cmbCurrent.DataSource = this.itemBindingSource;
            this.cmbCurrent.DisplayMember = "ItemName";
            this.cmbCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrent.FormattingEnabled = true;
            this.cmbCurrent.Location = new System.Drawing.Point(13, 13);
            this.cmbCurrent.Name = "cmbCurrent";
            this.cmbCurrent.Size = new System.Drawing.Size(279, 21);
            this.cmbCurrent.TabIndex = 0;
            this.cmbCurrent.ValueMember = "ItemID";
            this.cmbCurrent.SelectedIndexChanged += new System.EventHandler(this.cmbCurrent_SelectedIndexChanged);
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(TurnBasedPractice.ItemClasses.Item);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(308, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // clbCanUseClasses
            // 
            this.clbCanUseClasses.Controls.Add(this.cAvailInShops);
            this.clbCanUseClasses.Controls.Add(this.btnExit);
            this.clbCanUseClasses.Controls.Add(this.btnCommit);
            this.clbCanUseClasses.Controls.Add(this.effectsBox1);
            this.clbCanUseClasses.Controls.Add(this.btnSave);
            this.clbCanUseClasses.Controls.Add(this.groupBox3);
            this.clbCanUseClasses.Controls.Add(this.groupBox2);
            this.clbCanUseClasses.Controls.Add(this.txtName);
            this.clbCanUseClasses.Controls.Add(this.label1);
            this.clbCanUseClasses.Location = new System.Drawing.Point(13, 51);
            this.clbCanUseClasses.Name = "clbCanUseClasses";
            this.clbCanUseClasses.Size = new System.Drawing.Size(388, 473);
            this.clbCanUseClasses.TabIndex = 2;
            this.clbCanUseClasses.TabStop = false;
            this.clbCanUseClasses.Text = "Weapon Info";
            // 
            // cAvailInShops
            // 
            this.cAvailInShops.AutoSize = true;
            this.cAvailInShops.Location = new System.Drawing.Point(242, 22);
            this.cAvailInShops.Name = "cAvailInShops";
            this.cAvailInShops.Size = new System.Drawing.Size(113, 17);
            this.cAvailInShops.TabIndex = 10;
            this.cAvailInShops.Text = "Available in Shops";
            this.cAvailInShops.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(263, 418);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(156, 418);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(100, 23);
            this.btnCommit.TabIndex = 8;
            this.btnCommit.Text = "Commit Cache";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // effectsBox1
            // 
            this.effectsBox1.Location = new System.Drawing.Point(10, 153);
            this.effectsBox1.Name = "effectsBox1";
            this.effectsBox1.Size = new System.Drawing.Size(374, 243);
            this.effectsBox1.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(52, 418);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save In Cache";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudPower);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nudValue);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(242, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(129, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stats";
            // 
            // nudPower
            // 
            this.nudPower.Location = new System.Drawing.Point(73, 58);
            this.nudPower.Name = "nudPower";
            this.nudPower.Size = new System.Drawing.Size(44, 20);
            this.nudPower.TabIndex = 6;
            this.nudPower.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Power:";
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(73, 31);
            this.nudValue.Name = "nudValue";
            this.nudValue.Size = new System.Drawing.Size(44, 20);
            this.nudValue.TabIndex = 4;
            this.nudValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Value:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clClasses);
            this.groupBox2.Location = new System.Drawing.Point(10, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Classes";
            // 
            // clClasses
            // 
            this.clClasses.FormattingEnabled = true;
            this.clClasses.Location = new System.Drawing.Point(6, 16);
            this.clClasses.MultiColumn = true;
            this.clClasses.Name = "clClasses";
            this.clClasses.Size = new System.Drawing.Size(209, 79);
            this.clClasses.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(52, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // UpdateWeaponsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 536);
            this.Controls.Add(this.clbCanUseClasses);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbCurrent);
            this.Name = "UpdateWeaponsWindow";
            this.Text = "Modify Weapon List";
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.clbCanUseClasses.ResumeLayout(false);
            this.clbCanUseClasses.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCurrent;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox clbCanUseClasses;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudPower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCommit;
        private EffectsBox effectsBox1;
        private System.Windows.Forms.CheckedListBox clClasses;
        private System.Windows.Forms.CheckBox cAvailInShops;
        private System.Windows.Forms.BindingSource itemBindingSource;
    }
}