namespace TurnBasedPractice.Windows
{
    partial class BattleTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleTest));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CommandPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAttack = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnItems = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnRun = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EnemyNamePlates = new System.Windows.Forms.GroupBox();
            this.PlayerNamePlates = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.CommandPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CommandPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 497);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CommandPanel
            // 
            this.CommandPanel.Controls.Add(this.toolStrip1);
            this.CommandPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandPanel.Location = new System.Drawing.Point(3, 358);
            this.CommandPanel.Name = "CommandPanel";
            this.CommandPanel.Size = new System.Drawing.Size(504, 136);
            this.CommandPanel.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAttack,
            this.btnItems,
            this.btnRun});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(46, 136);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAttack
            // 
            this.btnAttack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAttack.Image = ((System.Drawing.Image)(resources.GetObject("btnAttack.Image")));
            this.btnAttack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.ShowDropDownArrow = false;
            this.btnAttack.Size = new System.Drawing.Size(43, 19);
            this.btnAttack.Text = "Attack";
            // 
            // btnItems
            // 
            this.btnItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnItems.Image = ((System.Drawing.Image)(resources.GetObject("btnItems.Image")));
            this.btnItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItems.Name = "btnItems";
            this.btnItems.ShowDropDownArrow = false;
            this.btnItems.Size = new System.Drawing.Size(43, 19);
            this.btnItems.Text = "Items";
            // 
            // btnRun
            // 
            this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(43, 19);
            this.btnRun.Text = "Run";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.EnemyNamePlates);
            this.panel2.Controls.Add(this.PlayerNamePlates);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 349);
            this.panel2.TabIndex = 1;
            // 
            // EnemyNamePlates
            // 
            this.EnemyNamePlates.Dock = System.Windows.Forms.DockStyle.Right;
            this.EnemyNamePlates.Location = new System.Drawing.Point(304, 0);
            this.EnemyNamePlates.Name = "EnemyNamePlates";
            this.EnemyNamePlates.Size = new System.Drawing.Size(200, 290);
            this.EnemyNamePlates.TabIndex = 1;
            this.EnemyNamePlates.TabStop = false;
            // 
            // PlayerNamePlates
            // 
            this.PlayerNamePlates.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlayerNamePlates.Location = new System.Drawing.Point(0, 0);
            this.PlayerNamePlates.Name = "PlayerNamePlates";
            this.PlayerNamePlates.Size = new System.Drawing.Size(200, 290);
            this.PlayerNamePlates.TabIndex = 0;
            this.PlayerNamePlates.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(0, 290);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(504, 59);
            this.textBox1.TabIndex = 0;
            // 
            // BattleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 497);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(526, 535);
            this.Name = "BattleTest";
            this.Text = "BattleTest";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.CommandPanel.ResumeLayout(false);
            this.CommandPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel CommandPanel;
        private System.Windows.Forms.GroupBox PlayerNamePlates;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox EnemyNamePlates;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRun;
        private System.Windows.Forms.ToolStripDropDownButton btnAttack;
        private System.Windows.Forms.ToolStripDropDownButton btnItems;
    }
}