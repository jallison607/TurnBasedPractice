using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurnBasedPractice.GuiClasses
{
    class ButtonWithID : Button
    {
        public readonly int _ID;

        public ButtonWithID(int tmpID)
        {
            this._ID = tmpID;
        }

    }

    public class NamePlate : Panel
    {

        public readonly int _ID;

        public NamePlate(int tmpID, Label tmpName, ProgressBar tmpHP, Label tmpHPText)
        {
            this.Visible = true;
            this.Enabled = true;
            this.Width = tmpHP.Width + 5;
            this.Height = tmpHP.Height * 3;
            this.BorderStyle = BorderStyle.FixedSingle;
            this._ID = tmpID;
            this.Controls.Add(tmpName);
            this.Controls.Add(tmpHP);
            this.Controls.Add(tmpHPText);
            updateHP(tmpHP.Maximum);

        }

        public void updateHP(int newValue)
        {
            Control[] hpBar = this.Controls.Find("pFoeHP",false);
            ((ProgressBar)hpBar[0]).Value = newValue;
            int max = ((ProgressBar)hpBar[0]).Maximum;
            Control[] hpText = this.Controls.Find("lblFoeHP", false);
            hpText[0].Text = newValue + "/" + max;
            
        }
    }

}
