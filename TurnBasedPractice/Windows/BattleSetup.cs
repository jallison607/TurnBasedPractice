using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.EntityClasses;
using TurnBasedPractice.ItemClasses;
using TurnBasedPractice.GameClasses;

namespace TurnBasedPractice.Windows
{
    public partial class BattleSetup : Form
    {
        private EntityWrapper _entityBossWrapper;
        private EntityWrapper _entityTemplateWrapper;
        private ItemWrapper _potionWrapper;
        private ItemWrapper _weaponWrapper;
        private Party _playerParty;
        private Party _foeParty;
        private int foePartySize;
        private int minLevel;
        private int maxLevel;
        private int playerPartySize = 1;

        public BattleSetup()
        {
            InitializeComponent();
            foePartySize = (int)this.nNumFoes.Value;
            this._entityBossWrapper = new EntityWrapper("Entity");
            this._entityTemplateWrapper = new EntityWrapper("Entity Template");
            this._potionWrapper = new ItemWrapper("Potion");
            this._weaponWrapper = new ItemWrapper("Weapon");
            populateDataGrid();
        }


        //Events
        private void cBosses_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.minLevel = (int)this.nMinLevel.Value;
            this.maxLevel = (int)this.nMaxLevel.Value;
            bool playerGeneration = generatePlayers();
            bool foeGeneration = generateFoes();

            if (playerGeneration && foeGeneration)
            {
                new BattleTest2(new BattleV2(this._playerParty, this._foeParty)).Show();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cRandItem_CheckedChanged(object sender, EventArgs e)
        {
            if (cRandItem.Checked)
            {
                this.nRandItems.Enabled = true;
            }
            else
            {
                this.nRandItems.Enabled = false;
            }
        }

        //Data population
        private void populateDataGrid()
        {
            List<EntityAbstract> entityList = new List<EntityAbstract>();
            entityList = this._entityBossWrapper.getEntities();

            this.dgvEntities.Rows.Clear();

            foreach (EntityAbstract tmpEntityEntry in entityList)
            {
                Entity tmpEntity = (Entity)tmpEntityEntry;
                int tmpKey = 0;
                int tmpID = tmpEntity.getID();
                string tmpName = tmpEntity.name;
                string tmpMaxHP = tmpEntity.getMaxHP().ToString();
                string tmpLevel = tmpEntity.getLevel().ToString();
                Weapon tmpWeapon = tmpEntity.getEquipedWeapon();
                string tmpWeaponName = tmpWeapon.itemName;
                this.dgvEntities.Rows.Insert(tmpKey, tmpID, tmpName, tmpMaxHP, tmpLevel, tmpWeaponName);
            }

            this.dgvEntities.ClearSelection();
        }

        //Batte Generation
        private void generatePlayerInventory()
        {
            if (this.nRandItems.Enabled)
            {
                int numToGen =(int)this.nRandItems.Value;
               
                while (numToGen > 0)
                {
                    List<Item> abstractItems = this._potionWrapper.getItems();

                    int selectedItem = TurnBasedPractice.RandomInt.r.Next(0,abstractItems.Count);
                    int selectedQty = TurnBasedPractice.RandomInt.r.Next(1,numToGen);

                    Item tmpNewItem = abstractItems[selectedItem];

                    this._playerParty.addItemToInventory(tmpNewItem, selectedQty);
                    numToGen -= selectedQty;
                }


            }
        }

        private bool generatePlayers()
        {
            bool generated = true;
            if (this.dgvEntities.SelectedRows.Count == 0)
            {
                generated = false;
                MessageBox.Show("Please Select your player");
            }
            else
            {
                int tmpID = Int32.Parse(this.dgvEntities.SelectedRows[0].Cells[0].Value.ToString());
                Entity selectedEntity = (Entity)this._entityBossWrapper.getEntity(tmpID);
                List<Entity> playerPartyList = new List<Entity>();
                playerPartyList.Add(selectedEntity);
                this._playerParty = new Party(playerPartyList, this.playerPartySize);
            }
            return generated;
        }

        /*private bool generatePlayers()
        {
            bool generated = true;
            List<Entity> player = new List<Entity>();
            int i = 0;
            while (i < this.playerPartySize)
            {
                List<EntityAbstract> entityAbstracts = this._entityBossWrapper.getEntities();
                List<Entity> potentialEntities = new List<Entity>();
                foreach (EntityAbstract tmpEntity in entityAbstracts)
                {
                    if (((Entity)tmpEntity).getLevel() >= this.minLevel)
                    {
                        potentialEntities.Add((Entity)tmpEntity);
                    }
                }

                if (potentialEntities.Count > 0)
                {
                    int selected = TurnBasedPractice.RandomInt.r.Next(0, potentialEntities.Count);
                    Entity newEntity = potentialEntities[selected];
                    player.Add(newEntity);
                }
                else
                {
                    MessageBox.Show("Not enough potential Player Characters");
                    generated = false;
                }

                i++;
            }

            if (generated)
            {

                this._playerParty = new Party(player, this.playerPartySize);

                generatePlayerInventory();
            }

            return generated;
        }*/

        private bool generateFoes()
        {
            bool generated = true;
            List<Entity> foes = new List<Entity>();
            if (this.cBosses.Checked)
            {
                List<EntityAbstract> entityAbstracts = this._entityBossWrapper.getEntities();
                List<Entity> potentialEntities = new List<Entity>();
                foreach (EntityAbstract tmpEntity in entityAbstracts)
                {
                    if (((Entity)tmpEntity).getLevel() > this.minLevel)
                    {
                        potentialEntities.Add((Entity)tmpEntity);
                    }
                }

                if (potentialEntities.Count > 0)
                {

                    int selected = TurnBasedPractice.RandomInt.r.Next(0, potentialEntities.Count);
                    Entity newEntity = potentialEntities[selected];
                    foes.Add(newEntity);
                }
                else
                {
                    MessageBox.Show("Not enough Potential Bosses");
                    generated = false;
                }


            }

            List<EntityAbstract> entityAbstractsTemplates = this._entityTemplateWrapper.getEntities();
            List<EntityTemplate> potentialEntityTemplate = new List<EntityTemplate>();
            foreach (EntityAbstract tmpEntity in entityAbstractsTemplates)
            {
                EntityTemplate tmpTemplate = (EntityTemplate)tmpEntity;
                if (tmpTemplate.getMinLevel() <= this.minLevel)
                {
                    potentialEntityTemplate.Add((EntityTemplate)tmpEntity);
                }
            }

            if (potentialEntityTemplate.Count > 0 && foes.Count != foePartySize)
            {

                int i = foes.Count();
                while (i < foePartySize)
                {
                    int selected = TurnBasedPractice.RandomInt.r.Next(0, potentialEntityTemplate.Count);
                    int level = TurnBasedPractice.RandomInt.r.Next(this.minLevel, this.maxLevel);
                    Entity tmpNewEntity = new Entity(potentialEntityTemplate[selected], level);
                    foes.Add(tmpNewEntity);
                    i++;
                }

                this._foeParty = new Party(foes, this.foePartySize);
            }
            else
            {
                generated = false;
            }

            return generated;
            
        }

        private void nMinLevel_ValueChanged(object sender, EventArgs e)
        {
            this.nMaxLevel.Minimum = this.nMinLevel.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.foePartySize = (int) this.nNumFoes.Value;
        }



    }
}
