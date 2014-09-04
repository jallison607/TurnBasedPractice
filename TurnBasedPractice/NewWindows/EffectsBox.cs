using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.NewGameClasses;

namespace TurnBasedPractice.NewWindows
{
    public partial class EffectsBox : UserControl
    {

        public EffectsBox()
        {
            InitializeComponent();
        }

        public void updateData(int tmpID, List<Effect> tmpInUse, List<Effect> tmpAvailable)
        {
            updateInUse(tmpInUse);
            updateAllAvailable(tmpAvailable);
        }

        private void updateInUse(List<Effect> tmpEList)
        {

        }

        private void updateAllAvailable(List<Effect> tmpAList)
        {

        }

        private void btnEditEffects_Click(object sender, EventArgs e)
        {
            new UpdateEffectList().Show();
        }



    }
}
