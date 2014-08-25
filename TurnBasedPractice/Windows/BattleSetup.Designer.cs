namespace TurnBasedPractice.Windows
{
    partial class BattleSetup
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
            this.btnStart = new System.Windows.Forms.Button();
            this.grpBattleSettings = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvEntities = new System.Windows.Forms.DataGridView();
            this.EntityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weapon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nRandItems = new System.Windows.Forms.NumericUpDown();
            this.cRandItem = new System.Windows.Forms.CheckBox();
            this.nMaxLevel = new System.Windows.Forms.NumericUpDown();
            this.nMinLevel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBosses = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nNumFoes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.grpBattleSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRandItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumFoes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(94, 290);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // grpBattleSettings
            // 
            this.grpBattleSettings.Controls.Add(this.label4);
            this.grpBattleSettings.Controls.Add(this.nNumFoes);
            this.grpBattleSettings.Controls.Add(this.label3);
            this.grpBattleSettings.Controls.Add(this.dgvEntities);
            this.grpBattleSettings.Controls.Add(this.nRandItems);
            this.grpBattleSettings.Controls.Add(this.cRandItem);
            this.grpBattleSettings.Controls.Add(this.nMaxLevel);
            this.grpBattleSettings.Controls.Add(this.nMinLevel);
            this.grpBattleSettings.Controls.Add(this.label2);
            this.grpBattleSettings.Controls.Add(this.label1);
            this.grpBattleSettings.Controls.Add(this.cBosses);
            this.grpBattleSettings.Location = new System.Drawing.Point(13, 13);
            this.grpBattleSettings.Name = "grpBattleSettings";
            this.grpBattleSettings.Size = new System.Drawing.Size(435, 271);
            this.grpBattleSettings.TabIndex = 5;
            this.grpBattleSettings.TabStop = false;
            this.grpBattleSettings.Text = "Battle Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Player Character Selection:";
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
            this.Weapon});
            this.dgvEntities.Location = new System.Drawing.Point(6, 132);
            this.dgvEntities.Name = "dgvEntities";
            this.dgvEntities.RowHeadersVisible = false;
            this.dgvEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntities.Size = new System.Drawing.Size(405, 133);
            this.dgvEntities.TabIndex = 7;
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
            this.MaxHP.HeaderText = "MaxHP";
            this.MaxHP.Name = "MaxHP";
            this.MaxHP.ReadOnly = true;
            // 
            // Level
            // 
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            // 
            // Weapon
            // 
            this.Weapon.HeaderText = "Weapon";
            this.Weapon.Name = "Weapon";
            this.Weapon.ReadOnly = true;
            // 
            // nRandItems
            // 
            this.nRandItems.Enabled = false;
            this.nRandItems.Location = new System.Drawing.Point(30, 74);
            this.nRandItems.Name = "nRandItems";
            this.nRandItems.Size = new System.Drawing.Size(46, 20);
            this.nRandItems.TabIndex = 6;
            // 
            // cRandItem
            // 
            this.cRandItem.AutoSize = true;
            this.cRandItem.Location = new System.Drawing.Point(82, 77);
            this.cRandItem.Name = "cRandItem";
            this.cRandItem.Size = new System.Drawing.Size(94, 17);
            this.cRandItem.TabIndex = 5;
            this.cRandItem.Text = "Random Items";
            this.cRandItem.UseVisualStyleBackColor = true;
            this.cRandItem.CheckedChanged += new System.EventHandler(this.cRandItem_CheckedChanged);
            // 
            // nMaxLevel
            // 
            this.nMaxLevel.Location = new System.Drawing.Point(102, 43);
            this.nMaxLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxLevel.Name = "nMaxLevel";
            this.nMaxLevel.Size = new System.Drawing.Size(41, 20);
            this.nMaxLevel.TabIndex = 4;
            this.nMaxLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nMinLevel
            // 
            this.nMinLevel.Location = new System.Drawing.Point(102, 20);
            this.nMinLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMinLevel.Name = "nMinLevel";
            this.nMinLevel.Size = new System.Drawing.Size(41, 20);
            this.nMinLevel.TabIndex = 3;
            this.nMinLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMinLevel.ValueChanged += new System.EventHandler(this.nMinLevel_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum Level:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minimum Level:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cBosses
            // 
            this.cBosses.AutoSize = true;
            this.cBosses.Location = new System.Drawing.Point(330, 52);
            this.cBosses.Name = "cBosses";
            this.cBosses.Size = new System.Drawing.Size(60, 17);
            this.cBosses.TabIndex = 0;
            this.cBosses.Text = "Bosses";
            this.cBosses.UseVisualStyleBackColor = true;
            this.cBosses.CheckedChanged += new System.EventHandler(this.cBosses_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nNumFoes
            // 
            this.nNumFoes.Location = new System.Drawing.Point(238, 19);
            this.nNumFoes.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nNumFoes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nNumFoes.Name = "nNumFoes";
            this.nNumFoes.Size = new System.Drawing.Size(60, 20);
            this.nNumFoes.TabIndex = 9;
            this.nNumFoes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nNumFoes.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "# of Foes:";
            // 
            // BattleSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 325);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpBattleSettings);
            this.Controls.Add(this.btnStart);
            this.Name = "BattleSetup";
            this.Text = "BattleSetup";
            this.grpBattleSettings.ResumeLayout(false);
            this.grpBattleSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRandItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumFoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox grpBattleSettings;
        private System.Windows.Forms.CheckBox cBosses;
        private System.Windows.Forms.NumericUpDown nMaxLevel;
        private System.Windows.Forms.NumericUpDown nMinLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nRandItems;
        private System.Windows.Forms.CheckBox cRandItem;
        private System.Windows.Forms.DataGridView dgvEntities;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weapon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nNumFoes;
    }
}