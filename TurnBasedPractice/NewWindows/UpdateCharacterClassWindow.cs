using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.GameClasses;
using GameTools.Basic;

namespace TurnBasedPractice.Windows
{
    public partial class UpdateCharacterClassWindow : Form
    {
        private CharacterClassWrapper _classWrapper = new CharacterClassWrapper();
        private ElementWrapper _elementWrapper = new ElementWrapper();
        private AbilityWrapper _abilityWrapper = new AbilityWrapper();
        private CharacterClass newCharacterClass = new CharacterClass(-1, "New Class", 0, 0, 0, 0, 0, 0, new List<int>(), new Dictionary<int, int>());
        private CharacterClass selectedCharacterClass = new CharacterClass(-1, "New Class", 0, 0, 0, 0, 0, 0, new List<int>(), new Dictionary<int, int>());
        private bool changesSaved = true;

        

        public UpdateCharacterClassWindow()
        {
            InitializeComponent();
            loadPreExsistingCharacterClasses();
            cmbCurrent.SelectedIndex = 0;
            updateCmbInfo();
            configureGui();
        }

        //Functional Methods
        private void loadPreExsistingCharacterClasses()
        {
            characterClassBindingSource.Clear();
            characterClassBindingSource.Add(newCharacterClass);

            foreach (CharacterClass tmpClass in _classWrapper.getClassList())
            {
                characterClassBindingSource.Add(tmpClass);
            }
        }

        private void updateCmbInfo()
        {
            if (cmbCurrent.SelectedValue != null)
            {
                if (((int)cmbCurrent.SelectedValue) == -1)
                {
                    selectedCharacterClass = newCharacterClass.Clone(-1);
                }
                else
                {
                    selectedCharacterClass = _classWrapper.getClass((int)cmbCurrent.SelectedValue);
                }
                
                updateSelectedClassInfo();
            }
        }

        private void updateSelectedClassInfo()
        {
            txtName.Text = selectedCharacterClass.ClassName;
            nudConBonus.Value = selectedCharacterClass.constitutionBonus;
            nudMagiBonus.Value = selectedCharacterClass.magiBonus;
            nudDexBonus.Value = selectedCharacterClass.dexterityBonus;
            nudStrBonus.Value = selectedCharacterClass.strengthBonus;
            nudSpiritBonus.Value = selectedCharacterClass.spiritBonus;
            nudSpeedBonus.Value = selectedCharacterClass.speedBonus;

            clElements.Items.Clear();
            foreach (MagiElement tmpElement in _elementWrapper.getElementList())
            {
                clElements.Items.Add(tmpElement.ElementName, selectedCharacterClass.magiElementsCanUse.Contains(tmpElement.ElementID));
            }

            listedAbilityBindingSource.Clear();
            foreach (KeyValuePair<int, int> tmpAbilityID in selectedCharacterClass.abilitiesLearnedByLevel)
            {
                ListedAbility tmpEntry = new ListedAbility(tmpAbilityID.Key,"Unlocked at level " + ParseItems.convertToLength(tmpAbilityID.Value,2) + ":  " + _abilityWrapper.getAbility(tmpAbilityID.Key).name, tmpAbilityID.Value);
                listedAbilityBindingSource.Add(tmpEntry);
            }
        }

        private void configureGui()
        {
            if (changesSaved)
            {
                btnCommit.Enabled = false;
            }
            else
            {
                btnCommit.Enabled = true;
            }
        }

        //########Events##############

        //General Character Class Info

        private void cmbCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCmbInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tmpClassName = txtName.Text;
            if (tmpClassName != string.Empty)
            {
                int tmpID;
                if (selectedCharacterClass.ClassID == -1)
                {
                    tmpID = _classWrapper.NextID();
                }
                else
                {
                    tmpID = selectedCharacterClass.ClassID;
                }


                //I dont like this matching by Name when there is a perfectly good ID available but im not sure how to do it differently.....for now
                List<int> tmpSelectedMagiElements = new List<int>();
                foreach (string tmpString in clElements.CheckedItems)
                {
                    foreach (MagiElement tmpMagiElement in _elementWrapper.getElementList())
                    {
                        if (tmpMagiElement.ElementName == tmpString)
                        {
                            tmpSelectedMagiElements.Add(tmpMagiElement.ElementID);
                        }
                    }
                }

                Dictionary<int, int> selectedAbilities = new Dictionary<int, int>();
                foreach (ListedAbility tmpListed in listedAbilityBindingSource)
                {
                    selectedAbilities.Add(tmpListed.AbilityID, tmpListed.LevelLearned);
                }

                selectedCharacterClass = new CharacterClass(tmpID, tmpClassName, (int)nudConBonus.Value, (int)nudMagiBonus.Value, (int)nudDexBonus.Value, (int)nudStrBonus.Value, (int)nudSpiritBonus.Value, (int)nudSpeedBonus.Value, tmpSelectedMagiElements, selectedAbilities);
                _classWrapper.addClassToTempCache(selectedCharacterClass);
                loadPreExsistingCharacterClasses();
                cmbCurrent.SelectedIndex = 0;
                selectedCharacterClass = newCharacterClass.Clone(-1);
                changesSaved = false;
                configureGui();
                updateSelectedClassInfo();
            }
            else
            {
                MessageBox.Show("Please Enter a Class Name");
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            _classWrapper.saveCacheChanges();
            changesSaved = true;
            configureGui();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!changesSaved)
            {
                DialogResult ds = MessageBox.Show("Commit Changes?", "Save", MessageBoxButtons.YesNoCancel);

                if (ds == DialogResult.Yes)
                {
                    _classWrapper.saveCacheChanges();
                    this.Close();
                }
                else if (ds == DialogResult.No)
                {
                    this.Dispose();
                    this.Close();
                }
            }
            else
            {
                this.Dispose();
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbCurrent.SelectedIndex > 0)
            {
                CharacterClass tmpToRemove = _classWrapper.getClassList()[cmbCurrent.SelectedIndex - 1];
                _classWrapper.removeClassFromTempCache(tmpToRemove);
                loadPreExsistingCharacterClasses();
                cmbCurrent.SelectedIndex = 0;
                changesSaved = false;
                configureGui();
            }
        }

        //Class Ability Info

        private void cmbAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

    }

    public class ListedAbility
    {
        private int id;
        private string text;
        private int level;
        public int AbilityID
        {
            get { return id; }
        }
        public string ListText
        {
            get { return text; }
        }
        public int LevelLearned
        {
            get { return level; }
        }
        public ListedAbility(int tmpID, string tmpText, int tmpLevel)
        {
            this.id = tmpID;
            this.text = tmpText;
            this.level = tmpLevel;
        }
    }

}
