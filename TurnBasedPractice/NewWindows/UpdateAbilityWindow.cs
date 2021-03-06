﻿using System;
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
        private AbilityWrapper _abilityWrapper = new AbilityWrapper();
        private Ability newAbility = new Ability(-1, "New Ability", new List<int>());
        private Ability selectedAbility = new Ability(-1, "New Ability", new List<int>());
        private bool changesSaved = true;

        public UpdateAbilityWindow()
        {
            InitializeComponent();
            effectsBox1._effectWrapper = new EffectWrapper();
            effectsBox1.updateData();
            loadPreExsistingAbilities();
            cmbCurrent.SelectedIndex = 0;
            configureGui();
        }

        private void loadPreExsistingAbilities()
        {
            cmbCurrent.Items.Clear();
            cmbCurrent.Items.Add("New Ability");

            foreach (Ability tmpAbility in this._abilityWrapper.getAbilityList())
            {
                cmbCurrent.Items.Add(tmpAbility.AbilityName);
            }
        }

        private void updateSelectedItemsInfo()
        {
            txtName.Text = selectedAbility.AbilityName;
            effectsBox1.setList(selectedAbility.effects);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!changesSaved)
            {
                DialogResult ds = MessageBox.Show("Commit Changes?", "Save", MessageBoxButtons.YesNoCancel);

                if (ds == DialogResult.Yes)
                {
                    _abilityWrapper.saveCacheChanges();
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
            string tmpAbilityName = txtName.Text;
            int tmpAbilityID;
            if (selectedAbility.AbilityID == -1)
            {
                tmpAbilityID = _abilityWrapper.NextID();
            }
            else
            {
                tmpAbilityID = selectedAbility.AbilityID;
            }
            selectedAbility = new Ability(tmpAbilityID, tmpAbilityName, effectsBox1.getList().ToList());
            _abilityWrapper.addAbilityToTempCache(selectedAbility);
            loadPreExsistingAbilities();
            selectedAbility = newAbility.Clone(-1);
            cmbCurrent.SelectedIndex = 0;
            changesSaved = false;
            configureGui();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            _abilityWrapper.saveCacheChanges();
            changesSaved = true;
            configureGui();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbCurrent.SelectedIndex > 0)
            {
                Ability tmpToRemove = _abilityWrapper.getAbilityList()[cmbCurrent.SelectedIndex - 1];
                _abilityWrapper.removeAbilityFromTempCache(tmpToRemove);
                loadPreExsistingAbilities();
                cmbCurrent.SelectedIndex = 0;
                changesSaved = false;
                configureGui();
            }
        }

    }
}
