using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurnBasedPractice.Windows
{
    public partial class BattleSetupV2 : Form
    {
        public BattleSetupV2()
        {
            InitializeComponent();
        }

        private void btnUpdateAbilityList_Click(object sender, EventArgs e)
        {
            new UpdateAbilityWindow().Show();

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateWeaponList_Click(object sender, EventArgs e)
        {
            new UpdateWeaponsWindow().Show();
        }


    }
}
