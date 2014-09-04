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

namespace TurnBasedPractice.Windows
{
    public partial class NewEntityTemplate : Form
    {
        private EntityWrapper _entityWrapper;
        private ItemWrapper _weaponWrapper;
        private bool changesSaved = true;
        private int selectedWeaponID  = 0;
        private int selectedEntityID  = -1;

        public NewEntityTemplate()
        {
            InitializeComponent();
            this._weaponWrapper = new ItemWrapper("Weapon");
            this._entityWrapper = new EntityWrapper("Entity Template");
        }


        //Events
        private void NewEntityTemplate_Load(object sender, EventArgs e)
        {
            populateDataGrid();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearInfo();
        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            if (selectedEntityID == -1)
            {
                int tmpID = this._entityWrapper.getNextID();
                Weapon selectedWep = (Weapon) this._weaponWrapper.getItem(this.selectedWeaponID);
                EntityTemplate tmpNewEntityTemplate = new EntityTemplate(tmpID, this.txtName.Text, (int)this.nLevel.Value, selectedWep,(int) nBaseHP.Value,(int)this.nSpeed.Value);
                this._entityWrapper.AddEntity(tmpNewEntityTemplate);
                this.populateDataGrid();
            }
            else
            {
                int tmpID = selectedEntityID;
                Weapon selectedWep = (Weapon)this._weaponWrapper.getItem(this.selectedWeaponID);
                EntityTemplate tmpNewEntityTemplate = new EntityTemplate(tmpID, this.txtName.Text, (int)this.nLevel.Value, selectedWep, (int)nBaseHP.Value, (int)this.nSpeed.Value);
                this._entityWrapper.AddEntity(tmpNewEntityTemplate);
                this.populateDataGrid();
            }
            changesSaved = false;
            clearInfo();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this._entityWrapper.saveEntities();
            this.changesSaved = true;
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
                    this._entityWrapper.saveEntities();
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Entity removing = (Entity)this._entityWrapper.getEntity(this.selectedEntityID);
            this._entityWrapper.removeEntity(removing);
            populateDataGrid();
            this.changesSaved = false;
        }

        private void btnWepChange_Click(object sender, EventArgs e)
        {
            WeaponSearch wepSearch = new WeaponSearch(_weaponWrapper.getItems());
            DialogResult dialogResult = wepSearch.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.selectedWeaponID = wepSearch.selectedWep.itemID;
                this.txtWeapon.Text = wepSearch.selectedWep.itemName;
                changesSaved = false;
            }
            else if (dialogResult == DialogResult.Cancel)
            {
             
            }
            
        }

        //Other Methods
        private void clearInfo()
        {
            this.txtName.Text = "";
            this.nLevel.Value = this.nLevel.Minimum;
            this.nBaseHP.Value = this.nBaseHP.Minimum;
            this.selectedWeaponID = 0;
            this.nSpeed.Value = this.nSpeed.Minimum;
            this.selectedEntityID = -1;
            this.txtWeapon.Text = this._weaponWrapper.getItem(selectedWeaponID).itemName;
        }

        private void populateDataGrid()
        {
            List<EntityAbstract> entityList = this._entityWrapper.getEntities();
            this.dgvEntities.Rows.Clear();

            foreach (EntityAbstract tmpEntityEntry in entityList)
            {
                EntityTemplate tmpEntity = (EntityTemplate)tmpEntityEntry;
                int tmpKey = 0;
                int tmpID = tmpEntity.getID();
                string tmpName = tmpEntity.name;
                string tmpMaxHP = tmpEntity.getBaseHP().ToString();
                string tmpLevel = tmpEntity.getMinLevel().ToString();
                Weapon tmpWeapon = tmpEntity.getEquipedWeapon();
                string tmpWeaponName = tmpWeapon.itemName;
                string tmpSpeed = tmpEntity.getSpeed().ToString();
                this.dgvEntities.Rows.Insert(tmpKey, tmpID, tmpName, tmpMaxHP, tmpLevel, tmpWeaponName, tmpSpeed);
            }
            
            this.dgvEntities.ClearSelection();
        }

        private void dgvEntities_SelectionChanged(object sender, EventArgs e)
        {
            
            if (this.dgvEntities.SelectedRows.Count > 0)
            {
                int tmpID = Int32.Parse(this.dgvEntities.SelectedRows[0].Cells[0].Value.ToString());
                EntityTemplate selectedEntity = (EntityTemplate)this._entityWrapper.getEntity(tmpID);
                this.txtName.Text = selectedEntity.name;
                this.nBaseHP.Value = selectedEntity.getBaseHP();
                this.nLevel.Value = selectedEntity.getMinLevel();
                this.selectedEntityID = selectedEntity.getID();
                this.txtWeapon.Text = selectedEntity.getEquipedWeapon().itemName;
                this.selectedWeaponID = selectedEntity.getEquipedWeapon().itemID;
                this.btnRemove.Enabled = true;
            }
            else
            {
                this.btnRemove.Enabled = false;
                clearInfo();
            }
        }



    }
}
