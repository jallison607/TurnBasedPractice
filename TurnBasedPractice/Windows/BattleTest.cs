using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.GameClasses;
using TurnBasedPractice.EntityClasses;
using TurnBasedPractice.ItemClasses;

namespace TurnBasedPractice.Windows
{
    public partial class BattleTest : Form
    {

        private Battle _currentBattle;
        private Dictionary<Item, string> playerInventory = new Dictionary<Item,string>();
        private List<Item> _ItemsInInventory = new List<Item>();
        private List<int> _players = new List<int>();
        private int selectedItem;

        public BattleTest(Battle tmpBattle)
        {
            InitializeComponent();
            this._currentBattle = tmpBattle;
            getFoeNamePlates();
            getPlayerInventory();
        }

        private void getPlayerInventory()
        {
            List<string> playerMenuOptions = new List<string>();
            foreach(Entity tmpPlayer in this._currentBattle.getPlayerParty().getActiveParty()){
                
            }

            foreach (KeyValuePair<Item, int> tmpItem in _currentBattle.getPlayerParty().getInventory())
            {
                string menuString = tmpItem.Value + " " + tmpItem.Key.itemName;
                this._ItemsInInventory.Add(tmpItem.Key);
                this.btnItems.DropDownItems.Add(menuString);
                this.btnItems.DropDownItems[this.btnItems.DropDownItems.Count - 1].Click += new EventHandler(ClickedItem);
            }
        }

        private void ClickedItem(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedEntry = (ToolStripMenuItem)sender;
            int index = this.btnItems.DropDownItems.IndexOf(selectedEntry);
            this.selectedItem = index;
            //this._currentBattle.useItemOn(targetInstanceID, this._ItemsInInventory[index]);
            
            //Unable to cast object of type 'System.Windows.Forms.ToolStripMenuItem' to type 'System.Windows.Forms.Button
        }

        private void getFoeNamePlates()
        {
            List<string> namePlates = new List<string>();
            foreach (Entity tmpEntity in _currentBattle.orderedParticipents)
            {
                if(_currentBattle.getFoeIDs().Contains(tmpEntity.getInstanceID())){
                    string tmpNamePlate = string.Empty;
                    tmpNamePlate += tmpEntity.name + " HP: " + tmpEntity.currentHP();
                    namePlates.Add(tmpNamePlate);
                }
            }

            this.btnAttack.DropDownItems.Clear();

            foreach (string tmpNamePlate in namePlates)
            {
                this.btnAttack.DropDownItems.Add(tmpNamePlate);
            }

        }
    }
}
