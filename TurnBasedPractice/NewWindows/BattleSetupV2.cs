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
using NameMaker;

namespace TurnBasedPractice.NewWindows
{
    public partial class BattleSetupV2 : Form
    {
        private EntityWrapper playerWrapper;
        private EntityWrapper bossWrapper;
        private EntityWrapper templateWrapper;
        private Party pParty = new Party(new List<Entity>(), 3);
        private Entity selectedPartyMember;
        private Party fParty = new Party(new List<Entity>(), 3);
        private List<Entity> pEntList = new List<Entity>();
        private List<Entity> bEntList = new List<Entity>();
        private List<EntityTemplate> tEntList = new List<EntityTemplate>();
        private List<Weapon> WepList = new List<Weapon>();
        private NameRandomiser nameRandomizer = new NameRandomiser();
        private ItemWrapper wepWrapper;
        private Entity newEntity;
        private Random r = new Random();

        public BattleSetupV2()
        {
            InitializeComponent();
            playerWrapper = new EntityWrapper("Player Entity");
            bossWrapper = new EntityWrapper("Boss Entity");
            templateWrapper = new EntityWrapper("Entity Template");
            wepWrapper = new ItemWrapper("Weapon");
            
            updateLocalLists();
            
            
            loadEntities();
            updateControlsData();
        }
        //Functonal Methods
        private void loadEntities()
        {
            cmbEntityAllies.Items.Clear();
            cmbEntityFoes.Items.Clear();
            cmbEntityAllies.Items.Add("New");
            cmbEntityFoes.Items.Add("New");
            
            foreach (Entity tmpEnt in pEntList)
            {
                cmbEntityAllies.Items.Add("Level: " + tmpEnt.getLevel() + " " + tmpEnt.name);
            }

            if (rBosses.Checked)
            {
                foreach (Entity tmpEnt in bEntList)
                {
                    cmbEntityFoes.Items.Add("Level: " + tmpEnt.getLevel() + " " + tmpEnt.name);
                }
            }
            else
            {
                foreach (EntityTemplate tmpEnt in tEntList)
                {
                    cmbEntityFoes.Items.Add("Min Level: " + tmpEnt.getMinLevel() + " " + tmpEnt.name);
                }
            }

            cmbEntityAllies.SelectedIndex = 0;
            cmbEntityFoes.SelectedIndex = 0;

            cmbPlayerParty.Items.Clear();
            cmbFoeParty.Items.Clear();
            foreach (Entity tmpEnt in pParty.getEntities())
            {
                cmbPlayerParty.Items.Add("Level :" + tmpEnt.getLevel() + " " +tmpEnt.name);
            }

            foreach (Entity tmpEnt in fParty.getEntities())
            {
                cmbPlayerParty.Items.Add("Level :" + tmpEnt.getLevel() + " " + tmpEnt.name);
            }

            cmbPlayerParty.SelectedIndex = cmbPlayerParty.Items.Count - 1;
            cmbFoeParty.SelectedIndex = cmbFoeParty.Items.Count - 1;

        }

        private void updateControlsData()
        {
            if (cmbEntityAllies.SelectedIndex == -1)
            {
                btnDeleteAlly.Enabled = false;
                txtAllyName.Text = "";
            }
            else
            {
                btnDeleteAlly.Enabled = true;
            }

            if (cmbEntityFoes.SelectedIndex == -1)
            {
                btnDeleteFoe.Enabled = false;
                btnGenerateTemplateFoe.Enabled = false;
                txtFoeName.Text = "";
            }
            else
            {
                btnDeleteFoe.Enabled = true;
                if (rBosses.Checked)
                {
                    btnGenerateTemplateFoe.Enabled = true;
                }
                else
                {
                    btnGenerateTemplateFoe.Enabled = false;
                }
            }

            if (cmbPlayerParty.SelectedIndex >= 0)
            {
                txtAllyName.Text = pParty.getEntities()[cmbPlayerParty.SelectedIndex].name;
                nudAllyLevel.Value = pParty.getEntities()[cmbPlayerParty.SelectedIndex].getLevel();
                btnRemoveAlly.Enabled = true;
                btnSavePreMadeA.Enabled = true;
            }
            else
            {
                cmbPlayerParty.SelectedText = "";
                btnRemoveAlly.Enabled = false;
                btnSavePreMadeA.Enabled = false;
            }

            if (cmbFoeParty.SelectedIndex >= 0)
            {
                txtFoeName.Text = fParty.getEntities()[cmbFoeParty.SelectedIndex].name;
                nudFoeLevel.Value = fParty.getEntities()[cmbFoeParty.SelectedIndex].getLevel();
                btnRemoveFoe.Enabled = true;
                btnSavePreMadeF.Enabled = true;
            }
            else
            {
                cmbFoeParty.SelectedText = "";
                btnRemoveFoe.Enabled = false;
                btnSavePreMadeF.Enabled = false;
            }

        }

        private void removePreMadePlayer()
        {
            playerWrapper.removeEntity(pEntList[cmbEntityAllies.SelectedIndex - 1]);
            updateLocalLists();
            loadEntities();
            updateControlsData();
        }

        private void addToPreMadePlayer()
        {
            Entity tmpEnt = pParty.getEntities()[cmbPlayerParty.SelectedIndex];
            playerWrapper.AddEntity(tmpEnt);
            updateLocalLists();
            loadEntities();
            updateControlsData();
        }

        private void updateLocalLists()
        {
            pEntList.Clear();
            bEntList.Clear();
            tEntList.Clear();
            WepList.Clear();

            foreach (EntityAbstract tmpEnt in playerWrapper.getEntities())
            {
                pEntList.Add((Entity)tmpEnt);
            }
            foreach (EntityAbstract tmpEnt in bossWrapper.getEntities())
            {
                bEntList.Add((Entity)tmpEnt);
            }
            foreach (EntityAbstract tmpEnt in templateWrapper.getEntities())
            {
                tEntList.Add((EntityTemplate)tmpEnt);
            }

            foreach (Item tmpWep in wepWrapper.getItems())
            {
                WepList.Add((Weapon)tmpWep);
            }

            newEntity = new Entity(playerWrapper.getNextID(), "", 1, WepList[0]);
        }

        //Events
        private void btnUpdateAbilityList_Click(object sender, EventArgs e)
        {
            new UpdateAbilityWindow().Show();

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateWeaponList_Click(object sender, EventArgs e)
        {
            new UpdateWeaponsWindow().Show();
        }

        private void btnUpdateRaceList_Click(object sender, EventArgs e)
        {
            new UpdateRaceWindow().Show();
        }

        private void btnUpdateTypeList_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAlly_Click(object sender, EventArgs e)
        {
            if (cmbEntityAllies.SelectedIndex > 0)
            {
                pParty.addEntity(pEntList[cmbEntityAllies.SelectedIndex - 1]);
            }
            else
            {
                Entity tmpEnt = (Entity)newEntity.Clone();
                tmpEnt.id = playerWrapper.getNextID();
                tmpEnt.name = nameRandomizer.randomFirstName()[0];
                pParty.addEntity(tmpEnt);
            }

            loadEntities();
            updateControlsData();
        }

        private void btnRemoveAlly_Click(object sender, EventArgs e)
        {
            if (cmbPlayerParty.SelectedIndex >= 0)
            {
                pParty.removeEntity(pParty.getEntities()[cmbPlayerParty.SelectedIndex]);
            }

            loadEntities();
            updateControlsData();
        }

        private void rBosses_CheckedChanged(object sender, EventArgs e)
        {
            loadEntities();
            updateControlsData();
        }

        private void cmbEntityFoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateControlsData();
        }

        private void cmbEntityAllies_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateControlsData();
        }

        private void btnDeleteAlly_Click(object sender, EventArgs e)
        {
            removePreMadePlayer();
        }

        private void btnSavePreMadeA_Click(object sender, EventArgs e)
        {
            addToPreMadePlayer();
        }

        private void cmbPlayerParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlayerParty.SelectedIndex >= 0)
            {
                selectedPartyMember = (Entity) pParty.getEntities()[cmbPlayerParty.SelectedIndex].Clone();
            }
        }

        private void txtAllyName_TextChanged(object sender, EventArgs e)
        {
            selectedPartyMember.name = txtAllyName.Text;
        }

        private void nudAllyLevel_ValueChanged(object sender, EventArgs e)
        {
            selectedPartyMember.setLevel((int)nudAllyLevel.Value);
        }

        private void btnASaveChanges_Click(object sender, EventArgs e)
        {
            if (cmbPlayerParty.SelectedIndex >= 0)
            {
                pParty.updateEntity(selectedPartyMember);
                loadEntities();
                updateControlsData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerWrapper.saveEntities();
        }

    }
}
