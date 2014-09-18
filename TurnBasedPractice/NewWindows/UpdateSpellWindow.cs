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
    public partial class UpdateMagicWindow : Form
    {
        private SpellWrapper _SpellWrapper = new SpellWrapper();
        private Spell newSpell = new Spell(-1, "New Spell", 0, new List<int>());
        private Spell selectedSpell = new Spell(-1, "New Spell", 0, new List<int>());
        private bool changesSaved = true;

        public UpdateMagicWindow()
        {
            InitializeComponent();
            effectsBox1._effectWrapper = new EffectWrapper();
            effectsBox1.updateData();
            loadPreExsistingSpells();
            cmbCurrent.SelectedIndex = 0;
            updateCmbInfo();
            configureGui();
        }

        private void loadPreExsistingSpells()
        {
            spellBindingSource.Clear();
            spellBindingSource.Add(newSpell);

            foreach (Spell tmpSpell in _SpellWrapper.getSpellList())
            {
                spellBindingSource.Add(tmpSpell);
            }
        }


        private void updateCmbInfo()
        {
            if (cmbCurrent.SelectedValue != null)
            {
                if (((int)cmbCurrent.SelectedValue) == -1)
                {
                    selectedSpell = newSpell.Clone(-1);
                }
                else
                {
                    selectedSpell = _SpellWrapper.getSpell((int)cmbCurrent.SelectedValue);
                }

                updateSelectedItemsInfo();
            }
        }

        private void updateSelectedItemsInfo()
        {
            txtName.Text = selectedSpell.SpellName;
            effectsBox1.setList(selectedSpell.getEffects());
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
                    _SpellWrapper.saveCacheChanges();
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

        private void btnCommit_Click(object sender, EventArgs e)
        {
            _SpellWrapper.saveCacheChanges();
            changesSaved = true;
            configureGui();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            selectedSpell.SpellName = txtName.Text;
            if (selectedSpell.SpellName != string.Empty)
            {
                if (selectedSpell.SpellID == -1)
                {
                    selectedSpell.SpellID = _SpellWrapper.NextID();
                }
                selectedSpell = new Spell(selectedSpell.SpellID, selectedSpell.SpellName, (int)nudMagiCost.Value, effectsBox1.getList().ToList());
                _SpellWrapper.addSpellToTempCache(selectedSpell);
                loadPreExsistingSpells();
                cmbCurrent.SelectedIndex = 0;
                selectedSpell = newSpell.Clone(-1);
                changesSaved = false;
                configureGui();
                updateSelectedItemsInfo();
            }
            else
            {
                MessageBox.Show("Please Enter a Spell Name");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbCurrent.SelectedIndex > 0)
            {
                Spell tmpToRemove = _SpellWrapper.getSpellList()[cmbCurrent.SelectedIndex - 1];
                _SpellWrapper.removeSpellFromTempCache(tmpToRemove);
                loadPreExsistingSpells();
                cmbCurrent.SelectedIndex = 0;
                changesSaved = false;
                configureGui();
            }
        }



        private void cmbCurrentSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCmbInfo();
        }

    }
}
