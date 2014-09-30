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

namespace TurnBasedPractice.Windows
{
    public partial class BattleSetupV2 : Form
    {
        private EntityWrapper playerWrapper;
        private EntityWrapper generatedFoeWrapper;
        private EntityTemplateWrapper templateWrapper;
        private EffectWrapper effectWrapper = new EffectWrapper();
        private AbilityWrapper abilityWrapper = new AbilityWrapper();
        private SpellWrapper spellWrapper = new SpellWrapper();
        private ItemWrapper weaponWrapper = new ItemWrapper("Weapon");
        private CharacterClassWrapper characterClassWrapper = new CharacterClassWrapper();
        private Party pParty = new Party(new List<Entity>(), 3);
        private Entity selectedPartyMember;
        private Entity selectedFoePartyMember;
        private Party fParty = new Party(new List<Entity>(), 3);
        private List<Entity> pEntList = new List<Entity>();
        private List<Entity> gEntList = new List<Entity>();
        private List<EntityTemplate> tEntList = new List<EntityTemplate>();
        private List<Weapon> WepList = new List<Weapon>();
        private NameRandomiser nameRandomizer = new NameRandomiser();
        private ItemWrapper wepWrapper;
        private Entity newEntity;
        private Weapon unarmedWeapon = new Weapon(0, "Unarmed", 0, 0, true, new List<int>(), new List<int>());
        private Random r = new Random();
        private bool loadingFoe = false;
        //private bool loadingAlly = false;

        public BattleSetupV2()
        {
            InitializeComponent();
            wepWrapper = new ItemWrapper("Weapon");
            Weapon tmpWep = unarmedWeapon;
            wepWrapper.AddItem(tmpWep);
            updateLocalWeaponList();
            playerWrapper = new EntityWrapper("Player Entity", WepList);
            generatedFoeWrapper = new EntityWrapper("Generated Entity", WepList);
            templateWrapper = new EntityTemplateWrapper("Entity Template");
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

            if (rGenerated.Checked)
            {
                foreach (Entity tmpEnt in gEntList)
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
                cmbFoeParty.Items.Add("Level :" + tmpEnt.getLevel() + " " + tmpEnt.name);
            }

            cmbPWeapon.Items.Clear();
            foreach (Weapon tmpWep in WepList)
            {
                cmbPWeapon.Items.Add(tmpWep.ItemName);
            }

            
            cmbPlayerParty.SelectedIndex = cmbPlayerParty.Items.Count - 1;
            cmbFoeParty.SelectedIndex = cmbFoeParty.Items.Count - 1;

        }

        private void loadCharacterClasses()
        {
            characterClassBindingSource.Clear();
            foreach (CharacterClass tmpClass in characterClassWrapper.getClassList())
            {
                characterClassBindingSource.Add(tmpClass);
            }
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
                txtFoeName.Text = "";
            }
            else
            {
                btnDeleteFoe.Enabled = true;
            }

            if (cmbPlayerParty.SelectedIndex >= 0)
            {
                selectedPartyMember = (Entity)pParty.getEntities()[cmbPlayerParty.SelectedIndex].Clone();
                updateSelectedPlayerInfo();
                grpCharInfo.Enabled = true;
            }
            else
            {
                txtAllyName.Text = "";
                cmbPlayerParty.SelectedText = "";
                nudpCon.Value = 1;
                nudpDex.Value = 1;
                nudpMag.Value = 1;
                nudpStr.Value = 1;
                grpCharInfo.Enabled = false;
            }

            if (cmbFoeParty.SelectedIndex >= 0)
            {
                selectedFoePartyMember = (Entity)fParty.getEntities()[cmbFoeParty.SelectedIndex].Clone();
                updateSelectedFoeInfo();
                txtFoeName.Text = selectedFoePartyMember.name;
                nudFoeLevel.Value = selectedFoePartyMember.getLevel();
                grpFoeInfo.Enabled = true;
            }
            else
            {
                txtFoeName.Text = "";
                cmbFoeParty.SelectedText = "";
                nudfCon.Value = 1;
                nudfDex.Value = 1;
                nudfMag.Value = 1;
                nudfStr.Value = 1;
                grpFoeInfo.Enabled = false;
            }

            if (cmbPlayerParty.Items.Count > 0)
            {
                cmbPlayerParty.Enabled = true;
            }
            else
            {
                cmbPlayerParty.Enabled = false;
            }

            if (cmbFoeParty.Items.Count > 0)
            {
                cmbFoeParty.Enabled = true;
            }
            else
            {
                cmbFoeParty.Enabled = false;
            }


            if (cmbPlayerParty.Items.Count > 0 && cmbFoeParty.Items.Count > 0)
            {
                btnFight.Enabled = true;
            }
            else
            {
                btnFight.Enabled = false;
            }

        }

        private void updateSelectedPlayerInfo()
        {
            //loadingAlly = true;
            txtAllyName.Text = selectedPartyMember.name;
            nudAllyLevel.Value = selectedPartyMember.getLevel();
            int wepIndex = -1;
            int unarmedIndex = -1;
            foreach (Weapon tmpWep in WepList)
            {
                if (tmpWep.ItemID == selectedPartyMember.getEquipedWeapon().ItemID)
                {
                    wepIndex = WepList.IndexOf(tmpWep);
                }

                if (tmpWep.ItemName == "Unarmed")
                {
                    unarmedIndex = WepList.IndexOf(tmpWep);
                }
            }

            if (wepIndex == -1)
            {
                wepIndex = unarmedIndex;
            }

            cmbPWeapon.SelectedIndex = wepIndex;

            nudpCon.Value = selectedPartyMember.constitution;
            nudpMag.Value = selectedPartyMember.magi;
            nudpDex.Value = selectedPartyMember.dexterity;
            nudpStr.Value = selectedPartyMember.strength;
            //loadingAlly = false;
        }

        private void updateSelectedFoeInfo()
        {
            loadingFoe = true;
            txtFoeName.Text = selectedFoePartyMember.name;
            nudFoeLevel.Value = selectedFoePartyMember.getLevel();
            nudfCon.Value = selectedFoePartyMember.constitution;
            nudfMag.Value = selectedFoePartyMember.magi;
            nudfDex.Value = selectedFoePartyMember.dexterity;
            nudfStr.Value = selectedFoePartyMember.strength;
            loadingFoe = false;
        }

        private void removePreMadePlayer()
        {
            if (cmbEntityAllies.SelectedIndex > 0)
            {
                playerWrapper.removeEntity(pEntList[cmbEntityAllies.SelectedIndex - 1]);
                updateLocalLists();
                loadEntities();
                updateControlsData();
            }
        }

        private void removePreMadeFoe()
        {
            if (rGenerated.Checked)
            {
                generatedFoeWrapper.removeEntity(gEntList[cmbEntityFoes.SelectedIndex - 1]);
            }else{
                templateWrapper.removeEntity(tEntList[cmbEntityFoes.SelectedIndex - 1]);
            }
            updateLocalLists();
            loadEntities();
            updateControlsData();
        }


        private void addToPreMadePlayer()
        {
            
            Entity tmpEnt = pParty.getEntities()[cmbPlayerParty.SelectedIndex];
            if (playerWrapper.getEntity(tmpEnt.id) != null)
            {
                DialogResult dialogResult = MessageBox.Show("ID in use, save as new?", "New Player Character", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    tmpEnt.id = playerWrapper.getNextID();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Player not added");
                }

            }
            playerWrapper.AddEntity(tmpEnt);
            updateLocalLists();
            loadEntities();
            updateControlsData();
        }

        private void addToPreMadeFoe()
        {
            Entity tmpEnt = fParty.getEntities()[cmbFoeParty.SelectedIndex];
            generatedFoeWrapper.AddEntity(tmpEnt);
            updateLocalLists();
            loadEntities();
            updateControlsData();
        }

        private void updateLocalLists()
        {
            pEntList.Clear();
            gEntList.Clear();
            tEntList.Clear();

            foreach (EntityAbstract tmpEnt in playerWrapper.getEntities())
            {
                pEntList.Add((Entity)tmpEnt);
            }
            foreach (EntityAbstract tmpEnt in generatedFoeWrapper.getEntities())
            {
                gEntList.Add((Entity)tmpEnt);
            }
            foreach (EntityTemplate tmpEnt in templateWrapper.getEntities())
            {
                tEntList.Add(tmpEnt);
            }

            updateLocalWeaponList();
            loadCharacterClasses();

            int[] tmpStats = new int[5]{1,1,1,1,1};

            newEntity = new Entity(0, "", tmpStats ,WepList[0]);
        }

        private void updateLocalWeaponList()
        {
            WepList.Clear();
            foreach (Item tmpWep in wepWrapper.getItems())
            {
                WepList.Add((Weapon)tmpWep);
            }
        }

        //########Events
        //Open New Windows

        private void ltsmEffect_Click(object sender, EventArgs e)
        {
            new UpdateEffectList().ShowDialog();
            effectWrapper.reload();
        }

        private void ltsmAbilities_Click(object sender, EventArgs e)
        {
            new UpdateAbilityWindow().ShowDialog();
            effectWrapper.reload();
            abilityWrapper.reload();
        }


        private void ltsmSpells_Click(object sender, EventArgs e)
        {
            new UpdateMagicWindow().Show();
            effectWrapper.reload();
            spellWrapper.reload();
        }

        private void ltsmClasses_Click(object sender, EventArgs e)
        {
            new UpdateCharacterClassWindow().ShowDialog();
            characterClassWrapper.reload();
            loadCharacterClasses();
            abilityWrapper.reload();
            effectWrapper.reload();
        }


        private void ltsmWeapons_Click(object sender, EventArgs e)
        {
            new UpdateWeaponsWindow().ShowDialog();
            weaponWrapper.reload();
        }


        private void btnUpdateRaceList_Click(object sender, EventArgs e)
        {
            new UpdateRaceWindow().Show();
        }

        //Exit
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Foe Only Events
        private void rBosses_CheckedChanged(object sender, EventArgs e)
        {
            loadEntities();
            updateControlsData();
        }

        //Ally Only Events

        //Similar events on either side
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

        private void btnAddFoe_Click(object sender, EventArgs e)
        {
            if (cmbEntityFoes.SelectedIndex > 0)
            {
                if (rGenerated.Checked)
                {
                    fParty.addEntity(gEntList[cmbEntityFoes.SelectedIndex - 1]);
                }
                else
                {
                    fParty.addEntity(tEntList[cmbEntityFoes.SelectedIndex - 1].generateAnEntity(generatedFoeWrapper.getNextID(),nameRandomizer.randomFirstName()[0], WepList));
                }
            }
            else
            {
                Entity tmpEnt = (Entity)newEntity.Clone();
                tmpEnt.id = generatedFoeWrapper.getNextID();
                tmpEnt.name = nameRandomizer.randomFirstName()[0];
                fParty.addEntity(tmpEnt);
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

        private void btnRemoveFoe_Click(object sender, EventArgs e)
        {
            if (cmbFoeParty.SelectedIndex >= 0)
            {
                fParty.removeEntity(fParty.getEntities()[cmbFoeParty.SelectedIndex]);
            }

            loadEntities();
            updateControlsData();
        }

        private void btnASaveChanges_Click(object sender, EventArgs e)
        {
            if (cmbPlayerParty.SelectedIndex >= 0)
            {
                selectedPartyMember.name = txtAllyName.Text;
                selectedPartyMember.setLevel((int)nudAllyLevel.Value);
                selectedPartyMember.constitution = (int)nudpCon.Value;
                selectedPartyMember.magi = (int)nudpMag.Value;
                selectedPartyMember.dexterity = (int)nudpDex.Value;
                selectedPartyMember.strength = (int)nudpStr.Value;
                selectedPartyMember.equipWeapon(WepList[cmbPWeapon.SelectedIndex]);
                pParty.updateEntity(selectedPartyMember);
                loadEntities();
                updateControlsData();
            }
        }

        private void btnFSaveChanges_Click(object sender, EventArgs e)
        {
            if (cmbFoeParty.SelectedIndex >= 0)
            {
                selectedFoePartyMember.name = txtFoeName.Text;
                selectedFoePartyMember.setLevel((int)nudFoeLevel.Value);
                if (!loadingFoe)
                {
                    selectedFoePartyMember.constitution = (int)nudfCon.Value;
                    selectedFoePartyMember.magi = (int)nudfMag.Value;
                    selectedFoePartyMember.dexterity = (int)nudfDex.Value;
                    selectedFoePartyMember.strength = (int)nudfStr.Value;
                }
                fParty.updateEntity(selectedFoePartyMember);
                loadEntities();
                updateControlsData();
            }
        }

        private void btnDeleteAlly_Click(object sender, EventArgs e)
        {
            removePreMadePlayer();
        }

        private void btnDeleteFoe_Click(object sender, EventArgs e)
        {
            if (cmbEntityFoes.SelectedIndex > 0)
            {
                removePreMadeFoe();
            }
        }

        private void btnSavePreMadeA_Click(object sender, EventArgs e)
        {
            addToPreMadePlayer();
        }

        private void btnSavePreMadeF_Click(object sender, EventArgs e)
        {
            addToPreMadeFoe();
        }

        private void cmbPlayerParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlayerParty.SelectedIndex >= 0)
            {
                selectedPartyMember = (Entity) pParty.getEntities()[cmbPlayerParty.SelectedIndex].Clone();
                updateSelectedPlayerInfo();
            }
        }

        private void cmbFoeParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFoeParty.SelectedIndex >= 0)
            {
                selectedFoePartyMember = (Entity)fParty.getEntities()[cmbFoeParty.SelectedIndex].Clone();
                updateSelectedFoeInfo();
            }
        }

        private void btnPCommit_Click(object sender, EventArgs e)
        {
            playerWrapper.saveEntities();
        }

        private void btnFCommit_Click(object sender, EventArgs e)
        {
            if (rGenerated.Checked)
            {
                generatedFoeWrapper.saveEntities();
            }
            else
            {
                templateWrapper.saveEntities();
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
