using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.Windows;
using TurnBasedPractice.EntityClasses;
using TurnBasedPractice.ItemClasses;

namespace TurnBasedPractice
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {

            InitializeComponent();
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            new NewItem().Show();
        }

        private void btnNewEntity_Click(object sender, EventArgs e)
        {
            new NewEntity().Show();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            new NewEntityTemplate().Show();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            List<Entity> tmpList = new List<Entity>();   
            Weapon tmpWeapon = new Weapon(0,"unarmed",0,5,0);
            tmpList.Add(new Entity(0,"Joe",1,tmpWeapon));
            tmpList.Add(new Entity(1,"Joe 2",1,tmpWeapon));
            tmpList.Add(new Entity(1,"Joe 3",1,tmpWeapon));
            Entity foe = new Entity(1,"Joe 3",1,tmpWeapon);
            
            Party newParty = new Party(tmpList, 3);

            foreach (Entity tmpTarget in newParty.getActiveParty())
            {
                if (tmpTarget.id == 0)
                {
                    foe.basicAttackHit();
                    if (foe.attackTry >= tmpTarget.dodge())
                    {
                        int damage = foe.basicAttackDamage();
                        tmpTarget.takeDamage(damage);
                        MessageBox.Show(foe.name + " hit " + tmpTarget.name + " for " + damage + " his previous health was " + tmpTarget.getMaxHP());
                    }
                    
                }
            }

            MessageBox.Show(tmpList[0].name + " has " + tmpList[0].currentHP() + " out of " + tmpList[0].getMaxHP());
        }

        private void btnBattle_Click(object sender, EventArgs e)
        {
            new BattleSetup().Show();
        }
    }
}
