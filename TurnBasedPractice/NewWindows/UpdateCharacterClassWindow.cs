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
        private EffectWrapper _effectWrapper = new EffectWrapper();
        private CharacterClass newCharacterClass = new CharacterClass(-1, "New Class", new Dictionary<string, int>(), new List<int>(), new Dictionary<int, int>(), new Dictionary<string, int>(), new Dictionary<int, int>());
        private CharacterClass selectedCharacterClass = new CharacterClass(-1, "New Class", new Dictionary<string, int>(), new List<int>(), new Dictionary<int, int>(), new Dictionary<string, int>(), new Dictionary<int, int>());
        private CharacterClass selectedPreReqClass = null;
        private Ability selectedAbility = null;
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
        /// <summary>
        /// Loads all Character Classes into the class drop down lists
        /// </summary>
        private void loadPreExsistingCharacterClasses()
        {
            updating = true;
            characterClassBindingSource.Clear();
            prereqCharacterClassBindingSource.Clear();
            characterClassBindingSource.Add(newCharacterClass);
            foreach (CharacterClass tmpClass in _classWrapper.getClassList())
            {
                characterClassBindingSource.Add(tmpClass);
                prereqCharacterClassBindingSource.Add(tmpClass);
            }

            if (prereqCharacterClassBindingSource.Count > 0)
            {
                selectedPreReqClass = (CharacterClass)prereqCharacterClassBindingSource[0];
            }

            updateAbilityOptions();
            updating = false;
        }

        /// <summary>
        /// Loads all Abilities into the ability drop down list
        /// </summary>
        private void updateAbilityOptions()
        {
            abilityBindingSource.Clear();
            foreach (Ability tmpAbility in _abilityWrapper.getAbilityList())
            {
                abilityBindingSource.Add(tmpAbility);
            }

            if (abilityBindingSource.List.Count > 0)
            {
                selectedAbility = (Ability)abilityBindingSource.List[0];
            }
        }

        /// <summary>
        /// Updates selected character class to whatever was selected in the character class drop down list
        /// </summary>
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

        /// <summary>
        /// Loads the character class information of the selected character class
        /// </summary>
        private void updateSelectedClassInfo()
        {
            txtName.Text = selectedCharacterClass.ClassName;
            
            //Stats
            nudConBonus.Value = selectedCharacterClass.constitutionBonus;
            nudMagiBonus.Value = selectedCharacterClass.magiBonus;
            nudDexBonus.Value = selectedCharacterClass.dexterityBonus;
            nudStrBonus.Value = selectedCharacterClass.strengthBonus;
            nudSpiritBonus.Value = selectedCharacterClass.spiritBonus;
            nudSpeedBonus.Value = selectedCharacterClass.speedBonus;

            //PreReqStats
            nudConPre.Value = selectedCharacterClass.constitutionPrereq;
            nudMagPre.Value = selectedCharacterClass.magiPrereq;
            nudDexPre.Value = selectedCharacterClass.dexterityPrereq;
            nudStrPre.Value = selectedCharacterClass.strengthPrereq;
            nudSprPre.Value = selectedCharacterClass.spiritPrereq;
            nudSpdPre.Value = selectedCharacterClass.speedPrereq;

            //Elements-AKA Branches of Magi they can use
            clElements.Items.Clear();
            foreach (MagiElement tmpElement in _elementWrapper.getElementList())
            {
                clElements.Items.Add(tmpElement.ElementName, selectedCharacterClass.magiElementsCanUse.Contains(tmpElement.ElementID));
            }

            updateClassAbilityList();
            updateClassPreqClassList();
            updateSelectedPreReqInfo();
            updateSelectedAbilityInfo();
            
        }

        /// <summary>
        /// Loads/Reloads the list of pre req classes for the selected character class
        /// </summary>
        private void updateClassPreqClassList()
        {
            listedClassPreReqBindingSource.Clear();
            foreach (KeyValuePair<int, int> tmpPreReq in selectedCharacterClass.preReqClasses)
            {
                ListedClassPreReq tmpClass = new ListedClassPreReq(tmpPreReq.Key, "Level " + tmpPreReq.Value + " " + _classWrapper.getClass(tmpPreReq.Key).ClassName, tmpPreReq.Value);
                listedClassPreReqBindingSource.Add(tmpClass);
            }
        }


        /// <summary>
        /// loads/reloads the list of abilities for the selected character class
        /// </summary>
        private void updateClassAbilityList()
        {
            //Abilities learned by level
            listedAbilityBindingSource.Clear();
            foreach (KeyValuePair<int, int> tmpAbilityID in selectedCharacterClass.abilitiesLearnedByLevel)
            {
                ListedAbility tmpEntry = new ListedAbility(tmpAbilityID.Key, "Unlocked at level " + ParseItems.convertToLength(tmpAbilityID.Value, 2) + ":  " + _abilityWrapper.getAbility(tmpAbilityID.Key).AbilityName, tmpAbilityID.Value);
                listedAbilityBindingSource.Add(tmpEntry);
            }
        }

        /// <summary>
        /// enables/disables the commit button depending on wheater or not there are unsaved changes
        /// </summary>
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

                selectedCharacterClass = new CharacterClass(tmpID, tmpClassName, getStatsFromNuds(), tmpSelectedMagiElements, selectedAbilities, getPreReqStatsFromNuds(), getPreReqClassIDs());
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

        /// <summary>
        /// Gets the dictionary<class id, level> of pre req classes listed in the pre req list box
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, int> getPreReqClassIDs()
        {
            Dictionary<int, int> preReqClassIDs = new Dictionary<int, int>();

            foreach (ListedClassPreReq tmpPreReqClass in listedClassPreReqBindingSource)
            {
                preReqClassIDs.Add(tmpPreReqClass.PreReqID, tmpPreReqClass.PreReqLevel);
            }

            return preReqClassIDs;
        }

        /// <summary>
        /// Gets the dictionary<Stat name, stat> of stat bonuses specified in the numeric up downs for bonuses
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int> getStatsFromNuds()
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();
            stats.Add("Con", (int)nudConBonus.Value);
            stats.Add("Mag", (int)nudMagiBonus.Value);
            stats.Add("Str", (int)nudStrBonus.Value);
            stats.Add("Dex", (int)nudDexBonus.Value);
            stats.Add("Spr", (int)nudSpiritBonus.Value);
            stats.Add("Spd", (int)nudSpeedBonus.Value);
            return stats;
        }

        /// <summary>
        /// Gets the dictionary<stat name, stat> of the pre-req stats specified in the numeric up downs for pre-reqs
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int> getPreReqStatsFromNuds()
        {
            Dictionary<string, int> preReqStats = new Dictionary<string,int>();
            preReqStats.Add("Con", (int)nudConPre.Value);
            preReqStats.Add("Mag", (int)nudMagPre.Value);
            preReqStats.Add("Str", (int)nudStrPre.Value);
            preReqStats.Add("Dex", (int)nudDexPre.Value);
            preReqStats.Add("Spr", (int)nudSprPre.Value);
            preReqStats.Add("Spd", (int)nudSpdPre.Value);

            return preReqStats;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            _classWrapper.saveCacheChanges();
            changesSaved = true;
            configureGui();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            updating = true;
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
            updating = false;
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
        //Functional Methods
        private bool updating = false;
        /// <summary>
        /// syncronizes the ability list box selection and the ability drop down list selection, updates the level numeric up down associated with the ability
        /// </summary>
        private void updateSelectedAbilityInfo()
        {
                //Set CMB selection to the selected Ability
                cmbAbilities.SelectedValue = selectedAbility.AbilityID;
                cmbAbilities.SelectedIndex = abilityBindingSource.IndexOf(selectedAbility);

                //If selected ability ID is in listed abilities then set listed abilities selection & level nud
                ListedAbility tmpListed = listedAbilityFromDataSourceValueMember(selectedAbility.AbilityID);
                if (tmpListed.AbilityID != -1)
                {
                    lstAbilities.SelectedValue = tmpListed.AbilityID;
                    nudLevel.Value = tmpListed.LevelLearned;
                }
                else
                {
                    lstAbilities.ClearSelected();
                    nudLevel.Value = 0;
                }
        }

        /// <summary>
        /// returns the ability with the specified ID from the ability data source attached to the ability drop down list
        /// </summary>
        /// <param name="tmpAbilityID"></param>
        /// <returns></returns>
        private Ability abilityFromDataSourceValueMember(int tmpAbilityID)
        {
            foreach(object tmpObject in abilityBindingSource)
            {
                Ability tmpAbility = (Ability)tmpObject;
                if (tmpAbility.AbilityID == tmpAbilityID)
                {
                    return tmpAbility;
                }
            }
            return new Ability(-1,"",new List<int>());
        }


        /// <summary>
        /// returns the ability with the specified ID from the listed ability data source attached to the ability list box
        /// </summary>
        /// <param name="tmpAbilityID"></param>
        /// <returns></returns>
        private ListedAbility listedAbilityFromDataSourceValueMember(int tmpAbilityID)
        {
            foreach (object tmpObject in listedAbilityBindingSource)
            {
                ListedAbility tmpListedAbility = (ListedAbility)tmpObject;
                if (tmpListedAbility.AbilityID == tmpAbilityID)
                {
                    return tmpListedAbility;
                }
            }
            return new ListedAbility(-1, "", -1); ;
        }

        //Events
        private void cmbAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                selectedAbility = abilityFromDataSourceValueMember((int)cmbAbilities.SelectedValue);
                updating = true;
                updateSelectedAbilityInfo();
                updating = false;
            }
        }

        private void lstAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                if (lstAbilities.SelectedValue != null)
                {
                    updating = true;
                    selectedAbility = abilityFromDataSourceValueMember((int)lstAbilities.SelectedValue);
                    updateSelectedAbilityInfo();
                    updating = false;
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            string selectedAbilityInfo = string.Empty;
            selectedAbilityInfo += selectedAbility.AbilityName + " Info";
            selectedAbilityInfo += "\r\n\r\nEffects:";
            foreach (int tmpEffectID in selectedAbility.effects)
            {
                Effect tmpEffect = _effectWrapper.getEffect(tmpEffectID);
                if (tmpEffect != null)
                {
                    selectedAbilityInfo += "\r\n   " + tmpEffect.name;
                }
            }
            MessageBox.Show(selectedAbilityInfo);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            updating = true;
            new UpdateAbilityWindow().ShowDialog();
            _abilityWrapper.reload();
            updateAbilityOptions();
            updating = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedAbility != null)
            {
                if (selectedCharacterClass.abilitiesLearnedByLevel.ContainsKey(selectedAbility.AbilityID))
                {
                    selectedCharacterClass.abilitiesLearnedByLevel[selectedAbility.AbilityID] = (int)nudLevel.Value;
                }
                else
                {
                    selectedCharacterClass.abilitiesLearnedByLevel.Add(selectedAbility.AbilityID, (int)nudLevel.Value);
                }
                updateClassAbilityList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstAbilities.SelectedValue != null)
            {
                updating = true;
                selectedCharacterClass.abilitiesLearnedByLevel.Remove((int)lstAbilities.SelectedValue);
                updateClassAbilityList();
                updating = false;
            }
        }


        //////////////////Pre Req Classes Information
        //Functional Methods
        /// <summary>
        /// Syncronizes the selected value of the pre req class drop down list with the selected entry of the pre req class list box
        /// </summary>
        private void updateSelectedPreReqInfo()
        {
            //Set CMB selection to the selected Ability
            this.cmbPreReqClasses.SelectedValue = selectedPreReqClass.ClassID;
            cmbPreReqClasses.SelectedIndex = prereqCharacterClassBindingSource.IndexOf(selectedPreReqClass);

            //If selected ability ID is in listed abilities then set listed abilities selection & level nud
            ListedClassPreReq tmpPreReq = listedPreReqFromDataSourceValueMember(selectedPreReqClass.ClassID);
            if (tmpPreReq.PreReqID != -1)
            {
                lstClassClassPreReq.SelectedValue = tmpPreReq.PreReqID;
                nudPreReqLevel.Value = tmpPreReq.PreReqLevel;
            }
            else
            {
                lstClassClassPreReq.ClearSelected();
                nudPreReqLevel.Value = 0;
            }
        }

        /// <summary>
        /// Returns the listed class from the data source attached to the pre req class list box by class id.
        /// </summary>
        /// <param name="tmpClassID"></param>
        /// <returns></returns>
        private ListedClassPreReq listedPreReqFromDataSourceValueMember(int tmpClassID)
        {
            foreach (object tmpObject in listedClassPreReqBindingSource)
            {
                ListedClassPreReq tmpListedClass = (ListedClassPreReq)tmpObject;
                if (tmpListedClass.PreReqID == tmpClassID)
                {
                    return tmpListedClass;
                }
            }
            return new ListedClassPreReq(-1, "", -1);
        }

        /// <summary>
        /// Returns the character class from the data source attached to the pre req combo drop down list by class id.
        /// </summary>
        /// <param name="tmpClassID"></param>
        /// <returns></returns>
        private CharacterClass characterClassFromDataSourceValueMember(int tmpClassID)
        {
            foreach (object tmpObject in prereqCharacterClassBindingSource)
            {
                CharacterClass tmpClass = (CharacterClass)tmpObject;
                if (tmpClass.ClassID == tmpClassID)
                {
                    return tmpClass;
                }
            }
            return newCharacterClass.Clone(-1);
        }

        //Events
        private void cmbPreReqClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                updating = true;
                selectedPreReqClass = characterClassFromDataSourceValueMember((int)cmbPreReqClasses.SelectedValue);
                updateSelectedPreReqInfo();
                updating = false;
            }
        }

        private void lstClassClassPreReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                if (lstClassClassPreReq.SelectedValue != null)
                {
                    updating = true;
                    selectedPreReqClass = characterClassFromDataSourceValueMember((int)lstClassClassPreReq.SelectedValue);
                    updateSelectedPreReqInfo();
                    updating = false;
                }
            }
        }

        private void btnAddPreReq_Click(object sender, EventArgs e)
        {
            if (selectedPreReqClass != null)
            {
                if(selectedCharacterClass.preReqClasses.ContainsKey(selectedPreReqClass.ClassID))
                {
                    selectedCharacterClass.preReqClasses[selectedPreReqClass.ClassID] = (int)nudPreReqLevel.Value;
                }else
                {
                    selectedCharacterClass.preReqClasses.Add(selectedPreReqClass.ClassID, (int)nudPreReqLevel.Value);
                }
                updateClassPreqClassList();
            }
        }
        
        private void btnPreReqRemove_Click(object sender, EventArgs e)
        {
            if (lstClassClassPreReq.SelectedValue != null)
            {
                selectedCharacterClass.preReqClasses.Remove((int)lstClassClassPreReq.SelectedValue);
                updating = true;
                updateClassPreqClassList();
                updating = false;
            }
        }



    }
}
