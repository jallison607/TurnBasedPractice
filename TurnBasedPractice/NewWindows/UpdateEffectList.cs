using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurnBasedPractice.NewWindows
{
    public partial class UpdateEffectList : Form
    {
        public UpdateEffectList()
        {
            InitializeComponent();
        }

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
            this.Close();
        }

        private void UpdateEffectList_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            cmbElement.SelectedIndex = 0;
        }


    }
}
