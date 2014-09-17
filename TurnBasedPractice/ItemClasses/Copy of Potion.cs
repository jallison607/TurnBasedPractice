using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;

namespace TurnBasedPractice.ItemClasses
{
    public class Potion : Item
    {
        private readonly int potency; 

        public Potion(int tmpID, string tmpName, int tmpValue, int tmpPotency)
            : base(tmpID, tmpName, tmpValue)
        {
            this.potency = tmpPotency;
        }

        public Potion(string EString)
            : base(EString)
        {
            string remaining = EString.Substring(10 + this.itemName.Length);
            this.potency = ParseItems.parseIntFrom(remaining, 4);
            
        }

        /*
         * Return string to be encrypted in this format 
         * 
         * ID + NameLength + Name + Value + Potency
         * 
         * xxxx + xx + xn + xxxx + xxxx
         * 
         */
        override public string ToEString()
        {
            string toBeEncrypted = String.Empty;
            toBeEncrypted += ParseItems.convertToLength(this.itemID, 4);
            toBeEncrypted += ParseItems.convertToLength(this.itemName.Length, 2);
            toBeEncrypted += this.itemName;
            toBeEncrypted += ParseItems.convertToLength(this.value, 4);
            toBeEncrypted += ParseItems.convertToLength(this.potency, 4);

            toBeEncrypted = ParseItems.convertToLength(toBeEncrypted.Length, 3) + toBeEncrypted;
            return toBeEncrypted;
        }

        public int getPotency()
        {
            return potency;
        }

        public int healDamage()
        {
            return -potency;
        }


    }
}
