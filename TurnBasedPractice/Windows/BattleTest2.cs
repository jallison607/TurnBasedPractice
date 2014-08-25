using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.GameClasses;
using TurnBasedPractice.GuiClasses;
using TurnBasedPractice.EntityClasses;
using System.Threading;

namespace TurnBasedPractice.Windows
{
    public partial class BattleTest2 : Form
    {
        private BattleV2 _currentBattle;
        private bool _baseMenu = true;
        private bool _playerTurn = true;
        private bool _updateInfo = false;
        private bool _updatingInfo = false;
        private bool _inPlace = true;
        private Point ActiveLocation = new Point(0, 0);
        private Point InactiveLocation1 = new Point(-91, 0);
        private Point InactiveLocation2 = new Point(91, 0);
        private Point _baseMenuLocation = new Point(0, 0);
        private Point _subMenuLocation = new Point(91, 0);
        private int _MenuMoveSpeed = 5;
        private Thread t;
        private Dictionary<int, NamePlate> NamePlateDictionary = new Dictionary<int, NamePlate>();


        //Threading Batons
        private object BatonCommandMove = new object();
        private object BatonUpdateInfo = new object();
        public object BatonAttack = new object();


        public BattleTest2(BattleV2 tmpBattle)
        {
            InitializeComponent();
            this._currentBattle = tmpBattle;
            this.panelSubCommands.Location = InactiveLocation2;
            this.ActiveLocation = this.panelBaseCommands.Location;
            GenerateNameplates();
            updatePlayerInfo();
            if (!this._currentBattle.playerTurn)
            {
                this.AITurn();
            }
            t = new Thread(updateForm);
            t.IsBackground = true;
            t.Start();
        }

        private void GenerateNameplates()
        {
            int i = 0;
            int k = 0;
            int incrementor = this.panelGraphics.Width / 3;
            int padding = (incrementor - 100) / 2;
            int y = 0;
            foreach (KeyValuePair<int, Entity> tmpFoe in this._currentBattle.foes)
            {
                Label tmplblFoeHP = new Label();
                ProgressBar tmppFoeHP = new ProgressBar();
                Label tmplblFoeName = new Label();
                // 
                // lblFoeName
                // 
                tmplblFoeName.AutoSize = true;
                tmplblFoeName.Location = new System.Drawing.Point(0, 0);
                tmplblFoeName.Name = "lblFoeName";
                tmplblFoeName.Size = new System.Drawing.Size(35, 15);
                tmplblFoeName.TabIndex = 0;
                tmplblFoeName.Text = tmpFoe.Value.name;
                tmplblFoeName.Visible = true;
                tmplblFoeName.Enabled = true;
                
                // 
                // tmppFoeHP
                // 
                tmppFoeHP.Location = new System.Drawing.Point(0, 15);
                tmppFoeHP.Name = "pFoeHP";
                tmppFoeHP.Size = new System.Drawing.Size(100, 25);
                tmppFoeHP.Maximum = tmpFoe.Value.getMaxHP();
                tmppFoeHP.TabIndex = 1;
                tmppFoeHP.Visible = true;
                tmppFoeHP.Enabled = true;
                // 
                // tmplblFoeHP
                // 
                tmplblFoeHP.AutoSize = true;
                tmplblFoeHP.Location = new System.Drawing.Point(0, 40);
                tmplblFoeHP.Name = "lblFoeHP";
                tmplblFoeHP.Size = new System.Drawing.Size(35, 15);
                tmplblFoeHP.TabIndex = 2;
                tmplblFoeHP.Text = "DynamicHPText";
                tmplblFoeHP.Visible = true;
                tmplblFoeHP.Enabled = true;

                if (i == 3)
                {
                    k++;
                    i = 0;
                    y = this.panelGraphics.Height / 2;
                }
                NamePlateDictionary.Add(tmpFoe.Key, new NamePlate(tmpFoe.Key, tmplblFoeName , tmppFoeHP, tmplblFoeHP));
                NamePlateDictionary[tmpFoe.Key].Location = new Point(padding + (incrementor * i), y);
                this.panelGraphics.Controls.Add(NamePlateDictionary[tmpFoe.Key]);

                i++;
            }
        }

        private void updateForm()
        {
            while (true)
            {
                lock (this.BatonCommandMove)
                {
                    //If base Menu Is Active
                    if (_baseMenu)
                    {
                        if (_subMenuLocation != moveXToward(_subMenuLocation, this.InactiveLocation2) || _baseMenuLocation != moveXToward(_baseMenuLocation, this.ActiveLocation))
                        {
                            this._inPlace = false;
                        }
                        _subMenuLocation = moveXToward(_subMenuLocation, this.InactiveLocation2);
                        _baseMenuLocation = moveXToward(_baseMenuLocation, this.ActiveLocation);
                    }
                    //If base Menu is not Active
                    else
                    {
                        if (_subMenuLocation != moveXToward(_subMenuLocation, this.ActiveLocation) || _baseMenuLocation != moveXToward(_baseMenuLocation, this.InactiveLocation1))
                        {
                            this._inPlace = false;
                        }
                        _baseMenuLocation = moveXToward(_baseMenuLocation, this.InactiveLocation1);
                        _subMenuLocation = moveXToward(_subMenuLocation, this.ActiveLocation);
                    }
                }

                if (!_inPlace)
                {
                    this.panelCommands.Invalidate();
                }

                Thread.Sleep(20);
            }
        }

        private void AITurn()
        {
            this._currentBattle.AIGo();
            this.updatePlayerInfo();

            if(this._currentBattle.foes.ContainsKey(this._currentBattle.CurrentID())){
                AITurn();
            }

        }

        private void updatePlayerInfo()
        {
            this.pPlayerHP.Maximum = this._currentBattle.friend.getMaxHP();
            this.pPlayerHP.Value =this._currentBattle.friend.currentHP();
            this.lblCurrentHP.Text = this._currentBattle.friend.currentHP() + "/" + this._currentBattle.friend.getMaxHP();
            this.lblPlayer.Text = this._currentBattle.friend.name;

            if (lblBattleInfo.Text != string.Empty)
            {
                this.lblBattleInfo.Text += this._currentBattle.dataOut;
            }
            else
            {
                this.lblBattleInfo.Text += this._currentBattle.dataOut;
            }

           // this.panelGraphics.Controls.Clear();
            foreach (KeyValuePair<int, NamePlate> tmpNamePlate in this.NamePlateDictionary)
            {
                Entity tmpFoe = this._currentBattle.foes[tmpNamePlate.Key];
                tmpNamePlate.Value.updateHP(tmpFoe.currentHP());
            }

            /* this.pFoeHP.Maximum = this._currentBattle.foe.getMaxHP();
            this.pFoeHP.Value =this._currentBattle.foe.currentHP();
            this.lblFoeHP.Text = this._currentBattle.foe.currentHP() + "/" + this._currentBattle.foe.getMaxHP();
            this.lblFoeName.Text = this._currentBattle.foe.name;
            this.lblBattleInfo.Text += this._currentBattle.dataOut;*/
        }

        private Point moveXToward(Point tmpOrg, Point tmpDest)
        {
            //if Not already there
            if (tmpOrg != tmpDest)
            {
                //Moving Right
                if (tmpDest.X > tmpOrg.X)
                {
                    if ((tmpOrg.X + this._MenuMoveSpeed) > tmpDest.X)
                    {
                        tmpOrg = tmpDest;
                    }
                    else
                    {
                        tmpOrg.X = tmpOrg.X + this._MenuMoveSpeed;
                    }
                }
                //Moving Left
                else if (tmpDest.X < tmpOrg.X)
                {
                    if ((tmpOrg.X - this._MenuMoveSpeed) < tmpDest.X)
                    {
                        tmpOrg = tmpDest;
                    }
                    else
                    {
                        tmpOrg.X = tmpOrg.X - _MenuMoveSpeed;
                    }
                }
            }

            return tmpOrg;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            this.panelSubCommands.Controls.Clear();
            List<ButtonWithID> targets = new List<ButtonWithID>();
            int i = 0;
            foreach (KeyValuePair<int, Entity> tmpFoe in this._currentBattle.foes)
            {

                if (tmpFoe.Value.isAlive())
                {

                    ButtonWithID foe = new ButtonWithID(tmpFoe.Key);
                    foe.Width = btnAttack.Width - 10;
                    foe.Height = btnAttack.Height - 5;
                    foe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    foe.Location = new Point(this.btnAttack.Location.X, btnAttack.Location.Y + (((5) + foe.Height) * i));
                    foe.Name = "btnFoe" + tmpFoe.Key;
                    foe.TabIndex = 0;
                    foe.Font = new Font(FontFamily.GenericSansSerif, 6F);
                    foe.Text = tmpFoe.Value.name;
                    foe.UseVisualStyleBackColor = true;
                    foe.Click += new System.EventHandler(this.FoeClicked);
                    foe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyInput);
                    foe.Visible = true;
                    targets.Add(foe);
                }
                    
                i++;
            }
            foreach (ButtonWithID tmpButton in targets)
            {
                tmpButton.Parent = this.panelSubCommands;
                this.panelSubCommands.Controls.Add(tmpButton);
            }

            this._baseMenu = false;
        }

        private void FoeClicked(object sender, EventArgs e)
        {
            Entity target = this._currentBattle.foes[((ButtonWithID)sender)._ID];

            this.lblBattleInfo.Text = "";
            lock (BatonUpdateInfo)
            {
                this._currentBattle.attack(target);
                this.updatePlayerInfo();
                this._currentBattle.next();
            }
            this._baseMenu = true;

            if (!this._currentBattle.playerTurn)
            {
                AITurn();
            }

            if (!this._currentBattle.isStillOn())
            {
                panelGraphics.Invalidate();
            }
        }

        private void KeyInput(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this._baseMenu = true;
            }
        }

        private void btnFlee_Click(object sender, EventArgs e)
        {
            if (this._currentBattle.attemptToFlee())
            {
                this.lblBattleInfo.Text = "You fled!";
                panelGraphics.Invalidate();
            }
            else
            {
                AITurn();
            }
        }

        //Painting
        private void btnAttack_KeyPress(object sender, KeyPressEventArgs e)
        {
            string outp = "Main location: " + this.panelBaseCommands.Location + "\r\nSub location: " + this.panelSubCommands.Location;
            foreach (Button tmpButton in this.panelSubCommands.Controls)
            {
                outp += "\r\n" + tmpButton.Text + " at " + tmpButton.Location;
            }

            foreach (Control tmpButton in this.panelBaseCommands.Controls)
            {
                outp += "\r\n" + tmpButton.Name + " at " + tmpButton.Location;
            }
            MessageBox.Show(outp);

        }

        private void panelCommands_Paint(object sender, PaintEventArgs e)
        {
            this.panelBaseCommands.Location = this._baseMenuLocation;
            this.panelSubCommands.Location = this._subMenuLocation;
            if (this._baseMenuLocation == this.ActiveLocation && _playerTurn)
            {
                this.panelBaseCommands.Enabled = true;
                this.panelBaseCommands.Controls[0].Focus();
                this._inPlace = true;
            }
            else if (this._subMenuLocation == this.ActiveLocation && _playerTurn)
            {
                this.panelSubCommands.Enabled = true;
                this._inPlace = true;
                this.panelSubCommands.Controls[0].Focus();
            }
            else
            {
                this.panelBaseCommands.Enabled = false;
                this.panelSubCommands.Enabled = false;
            }

            if (!this._currentBattle.isStillOn())
            {
                this.panelBaseCommands.Enabled = false;
                this.panelSubCommands.Enabled = false;
            }

        }

        private void panelGraphics_Paint(object sender, PaintEventArgs e)
        {
            if (this._updatingInfo)
            {
                _updatingInfo = false;
                updatePlayerInfo();
                this.panelOut.Invalidate();
                this.panelParty.Invalidate();
            }

            if (!this._currentBattle.isStillOn())
            {
                this.btnExit.Enabled = true;
                this.btnExit.Visible = true;
                this.panelBaseCommands.Enabled = false;
                this.panelSubCommands.Enabled = false;
                this.panelCommands.Invalidate();
                this._currentBattle.dataOut = "";
            }
            else
            {
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            t.Abort();
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this._currentBattle.next();
            this.btnOk.Enabled = false;
            this.btnOk.Visible = false;
        }

    }
}
