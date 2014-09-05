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
    public partial class UpdateEffectList : Form
    {
        private EffectWrapper _effectWrapper = new EffectWrapper(0);
        private Effect newEffect = new Effect(-1, "New Effect", 0, 0, 0, 1, 1);
        private Effect selectedEffect = new Effect(-1,"New Effect", 0,0,0,1,1);
        private bool changesSaved = true;

        public UpdateEffectList(EffectWrapper tmpWrapper)
        {
            this._effectWrapper = tmpWrapper;
            InitializeComponent();
            loadPreExsistingEffects();
            cmbCurrent.SelectedIndex = 0;
        }

        //Functional Methods
        private void loadPreExsistingEffects()
        {
            cmbCurrent.Items.Clear();
            cmbCurrent.Items.Add("New Effect");

            foreach (Effect tmpEffect in _effectWrapper.getEffectsList())
            {
                cmbCurrent.Items.Add(tmpEffect.name);
            }
        }

        private void updateSelectedItemsInfo()
        {
            this.txtName.Text = selectedEffect.name;
            this.cmbElement.SelectedIndex = selectedEffect.elementalType;
            this.cmbType.SelectedIndex = selectedEffect.effectType;
            this.cmbStat.SelectedIndex = selectedEffect.effectedStat;
            this.nudEffect.Value = selectedEffect.effectAmount;
            this.nudDuration.Value = selectedEffect.effectDuration;
        }

        //Events
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 2)
            {
                pSpecial.Enabled = true;
                pSpecial.Visible = true;
                pStandard.Enabled = false;
                pStandard.Visible = false;
            }
            else
            {
                pSpecial.Enabled = false;
                pSpecial.Visible = false;
                pStandard.Enabled = true;
                pStandard.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!changesSaved)
            {
                DialogResult ds = MessageBox.Show("Save Changes?", "Save", MessageBoxButtons.YesNoCancel);

                if (ds == DialogResult.Yes)
                {
                    _effectWrapper.save();
                    this.Close();
                }
                else if (ds == DialogResult.No)
                {
                    this._effectWrapper.reload();
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }

        }

        private void UpdateEffectList_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            cmbElement.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbCurrent.SelectedIndex > 0)
            {
                Effect tmpToRemove = _effectWrapper.getEffectsList()[cmbCurrent.SelectedIndex - 1];
                _effectWrapper.removeEffect(tmpToRemove);
                loadPreExsistingEffects();
                cmbCurrent.SelectedIndex = 0;
                changesSaved = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            selectedEffect.name = txtName.Text;
            selectedEffect.elementalType = cmbElement.SelectedIndex;
            selectedEffect.effectType = cmbType.SelectedIndex;
            selectedEffect.effectedStat = cmbStat.SelectedIndex;
            selectedEffect.effectAmount = (int)nudEffect.Value;
            selectedEffect.effectDuration = (int)nudDuration.Value;

            if (selectedEffect.id == -1)
            {
                selectedEffect.id = _effectWrapper.NextID();
            }

            _effectWrapper.addEffect(selectedEffect);
            loadPreExsistingEffects();
            cmbCurrent.SelectedIndex = 0;
            changesSaved = false;
        }

        private void cmbCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurrent.SelectedIndex == 0)
            {
                selectedEffect = newEffect.Clone(-1);
            }
            else
            {
                selectedEffect = _effectWrapper.getEffectsList()[cmbCurrent.SelectedIndex - 1];
            }

            updateSelectedItemsInfo();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {

            _effectWrapper.save();
            changesSaved = true;
        }


    }
}
