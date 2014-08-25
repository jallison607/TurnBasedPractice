using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;

namespace TurnBasedPractice.ItemClasses
{
    public class Weapon : Item
    {
        public readonly int damage;
        public readonly int AttackRollBonus;

        public Weapon(int tmpID, string tmpName, int tmpValue, int tmpDamage, int tmpAttackRollBonus)
            : base(tmpID, tmpName, tmpValue)
        {
            this.damage = tmpDamage;
            this.AttackRollBonus = tmpAttackRollBonus;
        }

        public Weapon(string EString)
            : base(EString)
        {
            string remaining = EString.Substring(10 + this.itemName.Length);
            this.damage = ParseItems.parseIntFrom(remaining, 4);
            remaining = remaining.Substring(4);
            this.AttackRollBonus = ParseItems.parseIntFrom(remaining, 4);
            remaining = remaining.Substring(4);
        }
        
        /*
         * Return string to be encrypted in this format 
         * 
         * length + ID + NameLength + Name + Value + Damage + AttackRollBonus
         * 
         * xxx + xxxx + xx + xn + xxxx + xxxx + xxxx
         * 
         */
        override public string ToEString()
        {
            string toBeEncrypted = String.Empty;
            toBeEncrypted += ParseItems.convertToLength(this.itemID, 4);
            toBeEncrypted += ParseItems.convertToLength(this.itemName.Length, 2);
            toBeEncrypted += this.itemName;
            toBeEncrypted += ParseItems.convertToLength(this.value, 4);
            toBeEncrypted += ParseItems.convertToLength(this.damage, 4);
            toBeEncrypted += ParseItems.convertToLength(this.AttackRollBonus, 4);

            toBeEncrypted = ParseItems.convertToLength(toBeEncrypted.Length, 3) + toBeEncrypted;
            return toBeEncrypted;
        }

    }
}
