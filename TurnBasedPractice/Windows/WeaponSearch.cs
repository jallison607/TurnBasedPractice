using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.ItemClasses;

namespace TurnBasedPractice.Windows
{
    public partial class WeaponSearch : Form
    {
        public Weapon selectedWep;
        private List<Item> _listOfWeapons;

        public WeaponSearch(List<Item> weapons)
        {
            InitializeComponent();
            this._listOfWeapons = weapons;
            PopulateDataGrid();
        }

        private void PopulateDataGrid()
        {
            foreach (Weapon tmpWeaponEntry in _listOfWeapons)
            {
                Weapon tmpWeapon = (Weapon)tmpWeaponEntry;
                int tmpKey = 0;
                int tmpID = tmpWeapon.itemID;
                string tmpName = tmpWeapon.itemName;
                string Value = tmpWeapon.value.ToString(); ;
                string tmpDamage = tmpWeapon.damage.ToString();
                string tmpAttackRollBonus = tmpWeapon.AttackRollBonus.ToString();
                this.dgvWeapons.Rows.Insert(tmpKey, tmpID, tmpName, Value, tmpDamage, tmpAttackRollBonus);
            }

            this.dgvWeapons.ClearSelection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.dgvWeapons.SelectedCells.Count > 0)
            {
                int tmpID = Int32.Parse(this.dgvWeapons.SelectedRows[0].Cells[0].Value.ToString());
                foreach (Weapon tmpWep in this._listOfWeapons)
                {
                    if (tmpWep.itemID == tmpID)
                    {
                        this.selectedWep = tmpWep;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                
            }
        }
    }
}
