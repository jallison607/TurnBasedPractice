using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.GameClasses;

namespace TurnBasedPractice.Windows
{
    public partial class UpdateAbilityWindow : Form
    {
        private AbilityWrapper _abilityWrapper = new AbilityWrapper(0);
        private Ability newAbility = new Ability(-1, "New Ability", new List<int>());
        private Ability selectedAbility = new Ability(-1, "New Ability", new List<int>());
        private bool changesSaved = true;

        public UpdateAbilityWindow(AbilityWrapper tmpAbilityWrapper, EffectWrapper tmpEffectWrapper)
        {
            InitializeComponent();
            this._abilityWrapper = tmpAbilityWrapper;
            this.effectsBox1._effectWrapper = tmpEffectWrapper;
            this.effectsBox1.updateData();
            loadPreExsistingAbilities();
            cmbCurrent.SelectedIndex = 0;
        }

        private void loadPreExsistingAbilities()
        {
            cmbCurrent.Items.Clear();
            cmbCurrent.Items.Add("New Ability");

            foreach (Ability tmpAbility in this._abilityWrapper.getAbilityList())
            {
                cmbCurrent.Items.Add(tmpAbility.name);
            }
        }

        private void updateSelectedItemsInfo()
        {
            txtName.Text = selectedAbility.name;
            effectsBox1.setList(selectedAbility.effects);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!changesSaved)
            {
                DialogResult ds = MessageBox.Show("Commit Changes?", "Save", MessageBoxButtons.YesNoCancel);

                if (ds == DialogResult.Yes)
                {
                    _abilityWrapper.save();
                    this.Close();
                }
                else if (ds == DialogResult.No)
                {
                    this._abilityWrapper.reload();
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void cmbCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurrent.SelectedIndex == 0)
            {
                selectedAbility = newAbility.Clone(-1);
            }
            else
            {
                selectedAbility = _abilityWrapper.getAbilityList()[cmbCurrent.SelectedIndex - 1];
            }

            updateSelectedItemsInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            selectedAbility.name = txtName.Text;
            if (selectedAbility.id == -1)
            {
                selectedAbility.id = _abilityWrapper.NextID();
            }
            selectedAbility.effects = effectsBox1.getList().ToList();
            _abilityWrapper.addAbility(selectedAbility);
            loadPreExsistingAbilities();
            cmbCurrent.SelectedIndex = 0;
            changesSaved = false;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            _abilityWrapper.save();
            changesSaved = true;
        }

    }
}
