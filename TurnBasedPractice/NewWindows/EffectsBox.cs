using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.GameClasses;

namespace TurnBasedPractice.Windows
{
    public partial class EffectsBox : UserControl
    {
        public EffectWrapper _effectWrapper = new EffectWrapper(0);
        private Effect selectedEffect;
        private List<int> includedEffects = new List<int>();
        
        public EffectsBox()
        {
            InitializeComponent();
        }
        
        public void updateData()
        {
            updateAllAvailable();
        }

        public void setList(List<int> effectIDs)
        {
            includedEffects.Clear();

            foreach (int tmpEffect in effectIDs)
            {
                includedEffects.Add(tmpEffect);
            }
            updateInUse();
        }

        public List<int> getList()
        {
            return this.includedEffects;
        }

        private void updateInUse()
        {
            lstEffects.Items.Clear();
            List<int> tmpInUse = includedEffects.ToList<int>();
            foreach (int tmpID in tmpInUse)
            {
                if (_effectWrapper.hasEffect(tmpID))
                {
                    lstEffects.Items.Add(_effectWrapper.getEffect(tmpID).name);
                }
                else
                {
                    includedEffects.Remove(tmpID);
                }
            }
        }

        private void updateAllAvailable()
        {
            cmbEffects.Items.Clear();
            foreach(Effect tmpEffect in this._effectWrapper.getEffectsList()){
                cmbEffects.Items.Add(tmpEffect.name);
            }
        }

        private void updateSelectedInfo()
        {
            this.txtName.Text = selectedEffect.name;
            this.txtElement.Text = selectedEffect.getElementName();
            this.txtType.Text = selectedEffect.getEffectType();
            this.txtEffectAmount.Text = selectedEffect.effectAmount.ToString();
            this.txtEffectDuration.Text = "over " + selectedEffect.effectDuration.ToString() + " rounds";
            this.txtStatChanged.Text = selectedEffect.getEffectedStatName();
        }

        private void clearInfo()
        {
            this.txtName.Text = "";
            this.txtElement.Text = "";
            this.txtType.Text = "";
            this.txtEffectAmount.Text = "";
            this.txtEffectDuration.Text = "";
            this.txtStatChanged.Text = "";
        }

        private void btnEditEffects_Click(object sender, EventArgs e)
        {
            new UpdateEffectList().ShowDialog();
            _effectWrapper.reload();
            updateData();
            updateInUse();
            clearInfo();
        }

        private void cmbEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEffect = this._effectWrapper.getEffectsList()[cmbEffects.SelectedIndex];
            updateSelectedInfo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbEffects.SelectedIndex != -1)
            {
                if (!includedEffects.Contains(selectedEffect.id))
                {
                    includedEffects.Add(selectedEffect.id);
                }
                updateInUse();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstEffects.SelectedIndex >= 0)
            {
                includedEffects.RemoveAt(lstEffects.SelectedIndex);
                updateInUse();
            }
        }



    }
}
