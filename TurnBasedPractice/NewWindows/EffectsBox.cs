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
        public EffectsBox()
        {
            InitializeComponent();
        }

        public void updateData()
        {
            updateInUse();
            updateAllAvailable();
        }

        private void updateInUse()
        {

        }

        private void updateAllAvailable()
        {
            cmbEffects.Items.Clear();
            foreach(Effect tmpEffect in this._effectWrapper.getEffectsList()){
                cmbEffects.Items.Add(tmpEffect.name);
            }
        }

        private void btnEditEffects_Click(object sender, EventArgs e)
        {
            new UpdateEffectList(_effectWrapper).ShowDialog();
            updateData();
        }



    }
}
