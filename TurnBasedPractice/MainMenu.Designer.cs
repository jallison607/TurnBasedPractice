namespace TurnBasedPractice
{
    partial class MainMenu
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
            this.btnNewItem = new System.Windows.Forms.Button();
            this.btnNewEntity = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnBattle = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewItem
            // 
            this.btnNewItem.Location = new System.Drawing.Point(68, 231);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(75, 23);
            this.btnNewItem.TabIndex = 0;
            this.btnNewItem.Text = "New Items";
            this.btnNewItem.UseVisualStyleBackColor = true;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // btnNewEntity
            // 
            this.btnNewEntity.Location = new System.Drawing.Point(147, 231);
            this.btnNewEntity.Name = "btnNewEntity";
            this.btnNewEntity.Size = new System.Drawing.Size(75, 23);
            this.btnNewEntity.TabIndex = 1;
            this.btnNewEntity.Text = "New Entity";
            this.btnNewEntity.UseVisualStyleBackColor = true;
            this.btnNewEntity.Click += new System.EventHandler(this.btnNewEntity_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Location = new System.Drawing.Point(86, 202);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(114, 23);
            this.btnTemplate.TabIndex = 2;
            this.btnTemplate.Text = "New Entity Template";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(107, 173);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnBattle
            // 
            this.btnBattle.Location = new System.Drawing.Point(107, 144);
            this.btnBattle.Name = "btnBattle";
            this.btnBattle.Size = new System.Drawing.Size(75, 23);
            this.btnBattle.TabIndex = 4;
            this.btnBattle.Text = "Battle";
            this.btnBattle.UseVisualStyleBackColor = true;
            this.btnBattle.Click += new System.EventHandler(this.btnBattle_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(107, 115);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(75, 23);
            this.btnSetup.TabIndex = 5;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnBattle);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.btnNewEntity);
            this.Controls.Add(this.btnNewItem);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewItem;
        private System.Windows.Forms.Button btnNewEntity;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnBattle;
        private System.Windows.Forms.Button btnSetup;
    }
}

