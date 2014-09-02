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
        public override string Text
        {
            get
            {
                return mainBox.Text;
            }
            set
            {
                mainBox.Text = value;
            }
        }

        public EffectsBox()
        {
            InitializeComponent();
        }

        public void updateData(int tmpID, string tmpName, List<Effect> tmpInUse, List<Effect> tmpAvailable)
        {
            this.txtName.Text = tmpName;
            updateInUse(tmpInUse);
            updateAllAvailable(tmpAvailable);
        }

        private void updateInUse(List<Effect> tmpEList)
        {

        }

        private void updateAllAvailable(List<Effect> tmpAList)
        {

        }



    }
}
