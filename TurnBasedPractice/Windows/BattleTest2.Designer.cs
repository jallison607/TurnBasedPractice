namespace TurnBasedPractice.Windows
{
    partial class BattleTest2
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
            this.CompleteBattle = new System.Windows.Forms.TableLayoutPanel();
            this.panelGraphics = new System.Windows.Forms.Panel();
            this.PanelDialog = new System.Windows.Forms.Panel();
            this.panelParty = new System.Windows.Forms.Panel();
            this.lblCurrentHP = new System.Windows.Forms.Label();
            this.pPlayerHP = new System.Windows.Forms.ProgressBar();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.panelOut = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblBattleInfo = new System.Windows.Forms.Label();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.panelBaseCommands = new System.Windows.Forms.Panel();
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnFlee = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.panelSubCommands = new System.Windows.Forms.Panel();
            this.CompleteBattle.SuspendLayout();
            this.PanelDialog.SuspendLayout();
            this.panelParty.SuspendLayout();
            this.panelOut.SuspendLayout();
            this.panelCommands.SuspendLayout();
            this.panelBaseCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompleteBattle
            // 
            this.CompleteBattle.ColumnCount = 1;
            this.CompleteBattle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CompleteBattle.Controls.Add(this.panelGraphics, 0, 0);
            this.CompleteBattle.Controls.Add(this.PanelDialog, 0, 1);
            this.CompleteBattle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompleteBattle.Location = new System.Drawing.Point(0, 0);
            this.CompleteBattle.Name = "CompleteBattle";
            this.CompleteBattle.RowCount = 2;
            this.CompleteBattle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.CompleteBattle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.CompleteBattle.Size = new System.Drawing.Size(386, 417);
            this.CompleteBattle.TabIndex = 0;
            // 
            // panelGraphics
            // 
            this.panelGraphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraphics.Location = new System.Drawing.Point(3, 3);
            this.panelGraphics.Name = "panelGraphics";
            this.panelGraphics.Size = new System.Drawing.Size(380, 244);
            this.panelGraphics.TabIndex = 0;
            this.panelGraphics.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraphics_Paint);
            // 
            // PanelDialog
            // 
            this.PanelDialog.BackColor = System.Drawing.Color.PeachPuff;
            this.PanelDialog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelDialog.Controls.Add(this.panelParty);
            this.PanelDialog.Controls.Add(this.panelOut);
            this.PanelDialog.Controls.Add(this.panelCommands);
            this.PanelDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDialog.Location = new System.Drawing.Point(3, 253);
            this.PanelDialog.Name = "PanelDialog";
            this.PanelDialog.Size = new System.Drawing.Size(380, 161);
            this.PanelDialog.TabIndex = 1;
            // 
            // panelParty
            // 
            this.panelParty.Controls.Add(this.lblCurrentHP);
            this.panelParty.Controls.Add(this.pPlayerHP);
            this.panelParty.Controls.Add(this.lblPlayer);
            this.panelParty.Location = new System.Drawing.Point(263, 4);
            this.panelParty.Name = "panelParty";
            this.panelParty.Size = new System.Drawing.Size(114, 154);
            this.panelParty.TabIndex = 2;
            // 
            // lblCurrentHP
            // 
            this.lblCurrentHP.AutoSize = true;
            this.lblCurrentHP.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentHP.Location = new System.Drawing.Point(56, 55);
            this.lblCurrentHP.Name = "lblCurrentHP";
            this.lblCurrentHP.Size = new System.Drawing.Size(25, 9);
            this.lblCurrentHP.TabIndex = 2;
            this.lblCurrentHP.Text = "label1";
            // 
            // pPlayerHP
            // 
            this.pPlayerHP.Location = new System.Drawing.Point(35, 38);
            this.pPlayerHP.Name = "pPlayerHP";
            this.pPlayerHP.Size = new System.Drawing.Size(70, 15);
            this.pPlayerHP.TabIndex = 1;
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(14, 19);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(35, 13);
            this.lblPlayer.TabIndex = 0;
            this.lblPlayer.Text = "label1";
            // 
            // panelOut
            // 
            this.panelOut.Controls.Add(this.btnOk);
            this.panelOut.Controls.Add(this.btnExit);
            this.panelOut.Controls.Add(this.lblBattleInfo);
            this.panelOut.Location = new System.Drawing.Point(100, 4);
            this.panelOut.Name = "panelOut";
            this.panelOut.Size = new System.Drawing.Size(157, 154);
            this.panelOut.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(39, 76);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Enabled = false;
            this.btnExit.Location = new System.Drawing.Point(39, 105);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblBattleInfo
            // 
            this.lblBattleInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBattleInfo.AutoSize = true;
            this.lblBattleInfo.Location = new System.Drawing.Point(3, 28);
            this.lblBattleInfo.MaximumSize = new System.Drawing.Size(155, 200);
            this.lblBattleInfo.Name = "lblBattleInfo";
            this.lblBattleInfo.Size = new System.Drawing.Size(0, 13);
            this.lblBattleInfo.TabIndex = 0;
            // 
            // panelCommands
            // 
            this.panelCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCommands.Controls.Add(this.panelBaseCommands);
            this.panelCommands.Controls.Add(this.panelSubCommands);
            this.panelCommands.Location = new System.Drawing.Point(4, 4);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(90, 150);
            this.panelCommands.TabIndex = 0;
            this.panelCommands.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCommands_Paint);
            // 
            // panelBaseCommands
            // 
            this.panelBaseCommands.Controls.Add(this.btnAttack);
            this.panelBaseCommands.Controls.Add(this.btnFlee);
            this.panelBaseCommands.Controls.Add(this.btnItem);
            this.panelBaseCommands.Location = new System.Drawing.Point(0, 0);
            this.panelBaseCommands.Name = "panelBaseCommands";
            this.panelBaseCommands.Size = new System.Drawing.Size(85, 127);
            this.panelBaseCommands.TabIndex = 3;
            // 
            // btnAttack
            // 
            this.btnAttack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttack.Location = new System.Drawing.Point(5, 22);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(75, 23);
            this.btnAttack.TabIndex = 0;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            this.btnAttack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnAttack_KeyPress);
            // 
            // btnFlee
            // 
            this.btnFlee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlee.Location = new System.Drawing.Point(5, 80);
            this.btnFlee.Name = "btnFlee";
            this.btnFlee.Size = new System.Drawing.Size(75, 23);
            this.btnFlee.TabIndex = 2;
            this.btnFlee.Text = "Flee";
            this.btnFlee.UseVisualStyleBackColor = true;
            this.btnFlee.Click += new System.EventHandler(this.btnFlee_Click);
            // 
            // btnItem
            // 
            this.btnItem.Enabled = false;
            this.btnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItem.Location = new System.Drawing.Point(5, 51);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(75, 23);
            this.btnItem.TabIndex = 1;
            this.btnItem.Text = "Item";
            this.btnItem.UseVisualStyleBackColor = true;
            // 
            // panelSubCommands
            // 
            this.panelSubCommands.AutoScroll = true;
            this.panelSubCommands.BackColor = System.Drawing.Color.PeachPuff;
            this.panelSubCommands.Location = new System.Drawing.Point(12, 133);
            this.panelSubCommands.Name = "panelSubCommands";
            this.panelSubCommands.Size = new System.Drawing.Size(89, 127);
            this.panelSubCommands.TabIndex = 4;
            // 
            // BattleTest2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 417);
            this.Controls.Add(this.CompleteBattle);
            this.MaximumSize = new System.Drawing.Size(402, 455);
            this.MinimumSize = new System.Drawing.Size(402, 455);
            this.Name = "BattleTest2";
            this.Text = "BattleTest2";
            this.CompleteBattle.ResumeLayout(false);
            this.PanelDialog.ResumeLayout(false);
            this.panelParty.ResumeLayout(false);
            this.panelParty.PerformLayout();
            this.panelOut.ResumeLayout(false);
            this.panelOut.PerformLayout();
            this.panelCommands.ResumeLayout(false);
            this.panelBaseCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel CompleteBattle;
        private System.Windows.Forms.Panel panelGraphics;
        private System.Windows.Forms.Panel PanelDialog;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnFlee;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Panel panelParty;
        private System.Windows.Forms.Panel panelOut;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.ProgressBar pPlayerHP;
        private System.Windows.Forms.Label lblCurrentHP;
        private System.Windows.Forms.Panel panelBaseCommands;
        private System.Windows.Forms.Panel panelSubCommands;
        private System.Windows.Forms.Label lblBattleInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOk;
    }
}