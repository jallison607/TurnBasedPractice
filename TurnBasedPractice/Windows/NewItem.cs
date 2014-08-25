using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.ItemClasses;
using GameTools.Basic;
using GameTools.Encryption;

namespace TurnBasedPractice.Windows
{
    public partial class NewItem : Form
    {
        private ItemWrapper _weaponWrapper;
        private ItemWrapper _potionWrapper;
        private bool changesSaved = true;
        private int selectedItemID;

        public NewItem()
        {
            InitializeComponent();
            _weaponWrapper = new ItemWrapper("Weapon");
            _potionWrapper = new ItemWrapper("Potion");
        }

        private void rWeapon_CheckedChanged(object sender, EventArgs e)
        {
            if (rWeapon.Checked)
            {
                this.lblEffect.Text = "Damage:";
                this.lblAttackRollBonus.Enabled = true;
                this.nAttackRollBonus.Enabled = true;
                populateDataGrid();
                //clearInfo();
            }
        }

        private void rPotion_CheckedChanged(object sender, EventArgs e)
        {
            if (rPotion.Checked)
            {
                this.lblEffect.Text = "Potency:";
                this.lblAttackRollBonus.Enabled = false;
                this.nAttackRollBonus.Enabled = false;
                populateDataGrid();
                //clearInfo();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this._weaponWrapper.saveItems();
            this._potionWrapper.saveItems();
            this.changesSaved = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "0";
            this.nEffect.Value = 0;
            this.nEffect.Value = 0;
            if (this.rWeapon.Checked)
            {
                this.nAttackRollBonus.Value = 0;
            }
            this.selectedItemID = -1;
        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            if (this.rWeapon.Checked)
            {
                int newID;
                if (this.selectedItemID > -1)
                {
                    newID = this.selectedItemID;
                }
                else if (this.cIDOverride.Checked)
                {
                    newID = (int)this.nIDForce.Value;

                }else{
                    newID = this._weaponWrapper.getNextID();
                }


                Weapon newWep = new Weapon(newID, this.txtName.Text, (int)this.nValue.Value, (int)this.nEffect.Value, (int)this.nAttackRollBonus.Value);
                this._weaponWrapper.AddItem(newWep);
            }
            else
            {
                int newID;
                if (this.selectedItemID > -1)
                {
                    newID = this.selectedItemID;
                }
                else if (this.cIDOverride.Checked)
                {
                    newID = (int)this.nIDForce.Value;
                }
                else
                {
                    newID = this._potionWrapper.getNextID();
                }


                Potion newPotion = new Potion(newID, this.txtName.Text, (int)this.nValue.Value, (int)this.nEffect.Value);
                this._potionWrapper.AddItem(newPotion);
            }

            this.populateDataGrid();
            this.changesSaved = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
         
            if (changesSaved)
            {
                this.Close();
            }
            else
            {
                
                DialogResult dialogResult = MessageBox.Show("Do you want to save your changes?", "Update Item Lists", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    this._potionWrapper.saveItems();
                    this._weaponWrapper.saveItems();
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }
        }
        private void clearInfo()
        {
            this.dgvItems.ClearSelection();
            this.txtName.Text = "";
            this.nValue.Value = 0;
            this.nAttackRollBonus.Value = 0;
            this.nEffect.Value = 0;
            this.selectedItemID = -1;
        }


        private void populateDataGrid(){
            List<Item> itemList = new List<Item>();

            this.dgvItems.Columns.Clear();
            if (this.rWeapon.Checked)
            {
                this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ItemID,
                this.ItemName,
                this.Value,
                this.Damage,
                this.AttackRollBonus});

                
                itemList = this._weaponWrapper.getItems();
                foreach (Item tmpItem in itemList)
                {
                    Weapon tmpWeapon = (Weapon)tmpItem;
                    int tmpKey = 0;
                    int tmpID = tmpItem.itemID;
                    string tmpName = tmpWeapon.itemName;
                    string tmpDamage = tmpWeapon.damage.ToString();
                    string tmpValue = tmpWeapon.value.ToString();
                    string tmpAttackRollBonus = tmpWeapon.AttackRollBonus.ToString();
                    this.dgvItems.Rows.Insert(tmpKey, tmpID, tmpName, tmpValue, tmpDamage, tmpAttackRollBonus);
                }
            }
            else
            {
                this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ItemID,
                this.ItemName,
                this.Value,
                this.Potency});

                itemList = this._potionWrapper.getItems();
                foreach (Item tmpItem in itemList)
                {
                    Potion tmpWeapon = (Potion)tmpItem;
                    int tmpKey = 0;
                    int tmpID = tmpItem.itemID;
                    string tmpName = tmpWeapon.itemName;
                    string tmpPotency = tmpWeapon.getPotency().ToString();
                    string tmpValue = tmpWeapon.value.ToString();
                    this.dgvItems.Rows.Insert(tmpKey, tmpID, tmpName,tmpValue, tmpPotency);
                }
            }
            this.dgvItems.ClearSelection();
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvItems.SelectedCells.Count > 0)
            {
                if (this.rWeapon.Checked)
                {
                    int tmpID = Int32.Parse(this.dgvItems.SelectedRows[0].Cells[0].Value.ToString());
                    Weapon selectedWeapon = (Weapon)_weaponWrapper.getItem(tmpID);
                    this.txtName.Text = selectedWeapon.itemName;
                    this.nValue.Value = selectedWeapon.value;
                    this.nEffect.Value = selectedWeapon.damage;
                    this.nAttackRollBonus.Value = selectedWeapon.AttackRollBonus;
                    this.selectedItemID = selectedWeapon.itemID;
                }
                else
                {
                    int tmpID = Int32.Parse(this.dgvItems.SelectedRows[0].Cells[0].Value.ToString());
                    Potion selectedPotion = (Potion)_potionWrapper.getItem(tmpID);
                    this.txtName.Text = selectedPotion.itemName;
                    this.nValue.Value = selectedPotion.value;
                    this.nEffect.Value = selectedPotion.getPotency();
                    this.selectedItemID = selectedPotion.itemID;

                }
                this.btnRemove.Enabled = true;
            }
            else
            {
                this.btnRemove.Enabled = false;
                clearInfo();
            }
        }

        private void cIDOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cIDOverride.Checked)
            {
                this.nIDForce.Enabled = true;
            }
            else
            {
                this.nIDForce.Enabled = false;
            }

            populateDataGrid();
        }

        private void NewItem_Load(object sender, EventArgs e)
        {
            populateDataGrid();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.rWeapon.Checked)
            {
                Weapon removing = (Weapon)this._weaponWrapper.getItem(this.selectedItemID);
                this._weaponWrapper.removeItem(removing);
            }
            else if (rPotion.Checked) 
            {
                Potion removing = (Potion)this._potionWrapper.getItem(this.selectedItemID);
                this._potionWrapper.removeItem(removing);
            }
            populateDataGrid();
            this.changesSaved = false;
        }



    }
}
