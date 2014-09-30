using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.GameClasses;
using TurnBasedPractice.ItemClasses;
using TurnBasedPractice.GuiClasses;

namespace TurnBasedPractice.Windows
{
    public partial class UpdateWeaponsWindow : Form
    {
        private ItemWrapper weaponWrapper = new ItemWrapper("Weapon");
        private CharacterClassWrapper characterClassWrapper = new CharacterClassWrapper();
        private Weapon newWeapon = new Weapon(-1,"New Weapon", 0, 0, 0,false,new List<int>(),new List<int>());
        private Weapon selectedWeapon = new Weapon(-1, "New Weapon", 0, 0, 0,false, new List<int>(), new List<int>());
        private bool changesSaved = true;

        public UpdateWeaponsWindow()
        {
            InitializeComponent();
            clClasses.DataSource = listedClassesForWeaponBindingSource;
            clClasses.DisplayMember = "ClassName";
            clClasses.ValueMember = "ClassID";
            effectsBox1._effectWrapper = new EffectWrapper();
            effectsBox1.updateData();
            loadPreExsistingWeapons();
            cmbCurrent.SelectedIndex = 0;
            updateCmbInfo();
            configureGui();
        }

        private void loadPreExsistingWeapons()
        {
            itemBindingSource.Clear();
            itemBindingSource.Add(newWeapon);

            foreach (Item tmpItem in weaponWrapper.getItems())
            {
                itemBindingSource.Add((Weapon)tmpItem);
            }

        }
        private void updateCmbInfo()
        {
            if (cmbCurrent.SelectedValue != null)
            {
                if (((int)cmbCurrent.SelectedValue) == -1)
                {
                    selectedWeapon = (Weapon)newWeapon.Clone(-1);
                }
                else
                {
                    selectedWeapon = (Weapon)weaponWrapper.getItem((int)cmbCurrent.SelectedValue);
                }

                updateSelectedItemsInfo();
            }
        }

        private void updateSelectedItemsInfo()
        {
            txtName.Text = selectedWeapon.ItemName;
            effectsBox1.setList(selectedWeapon.getMagicalEffects());
            cAvailInShops.Checked = selectedWeapon.canBuy;
            nudValue.Value = selectedWeapon.value;
            nudPower.Value = selectedWeapon.getPower();
            nudMagiPower.Value = selectedWeapon.getMagiPower();

            listedClassesForWeaponBindingSource.Clear();

            foreach(CharacterClass tmpClass in characterClassWrapper.getClassList())
            {
                ListedClassesForWeapon listedWeapon = new ListedClassesForWeapon(tmpClass.ClassID, tmpClass.ClassName, selectedWeapon.ValidClasses.Contains(tmpClass.ClassID));
                listedClassesForWeaponBindingSource.Add(listedWeapon); 
            }

            for (int i = 0; i < clClasses.Items.Count; i++)
            {
                bool isChecked = ((ListedClassesForWeapon)listedClassesForWeaponBindingSource[i]).IsPermited;
                clClasses.SetItemChecked(i, isChecked);
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

        private List<int> getListOfClasses()
        {
            List<int> tmpAllowedClasses = new List<int>();
            for (int i = 0; i < clClasses.Items.Count; i++)
            {
                ListedClassesForWeapon tmpWeapon = (ListedClassesForWeapon)listedClassesForWeaponBindingSource[i];
                tmpWeapon.IsPermited = clClasses.GetItemChecked(i);
                listedClassesForWeaponBindingSource[i] = tmpWeapon;
            }

            foreach (ListedClassesForWeapon tmpListed in listedClassesForWeaponBindingSource)
            {
                if (tmpListed.IsPermited)
                {
                    tmpAllowedClasses.Add(tmpListed.ClassID);
                }
            }
            return tmpAllowedClasses;
        }

        private void saveChanges()
        {
            if (cmbCurrent.SelectedIndex > 0)
            {
                selectedWeapon.ItemName = txtName.Text;
                if (selectedWeapon.ItemName != string.Empty)
                {
                    if (selectedWeapon.ItemID == -1)
                    {
                        selectedWeapon.ItemID = weaponWrapper.NextID();
                    }
                    selectedWeapon = new Weapon(selectedWeapon.ItemID, selectedWeapon.ItemName, (int)nudValue.Value, (int)nudPower.Value, (int)nudMagiPower.Value, cAvailInShops.Checked, effectsBox1.getList(), getListOfClasses());
                    weaponWrapper.AddItem(selectedWeapon);
                    loadPreExsistingWeapons();
                    cmbCurrent.SelectedIndex = 0;
                    updateCmbInfo();
                    configureGui();
                }
                else
                {
                    MessageBox.Show("Please Enter a Spell Name");
                }
            }
        }

        private void cmbCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCmbInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!changesSaved)
            {
                DialogResult ds = MessageBox.Show("Commit Changes?", "Save", MessageBoxButtons.YesNoCancel);

                if (ds == DialogResult.Yes)
                {
                    weaponWrapper.saveCacheChanges();
                    this.Close();
                }
                else if (ds == DialogResult.No)
                {
                    this.weaponWrapper.reload();
                    this.Close();
                }
            }
            else
            {
                this.Dispose();
                this.Close();
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            weaponWrapper.saveCacheChanges();
            changesSaved = true;
            configureGui();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
            changesSaved = false;
            configureGui();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbCurrent.SelectedIndex > 0)
            {
                Item tmpToRemove = weaponWrapper.getItems()[cmbCurrent.SelectedIndex - 1];
                weaponWrapper.removeItem(tmpToRemove);
                loadPreExsistingWeapons();
                cmbCurrent.SelectedIndex = 0;
                updateCmbInfo();
                changesSaved = false;
                configureGui();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(selectedWeapon.ItemName);
        }

        private void btnAllClasses_Click(object sender, EventArgs e)
        {
            if (clClasses.CheckedIndices.Count == clClasses.Items.Count)
            {
                for (int i = 0; i < clClasses.Items.Count; i++)
                {
                    clClasses.SetItemChecked(i, false);
                }
            }
            else
            {
                for (int i = 0; i < clClasses.Items.Count; i++)
                {
                    clClasses.SetItemChecked(i, true);
                }
            }
        }



    }
}
