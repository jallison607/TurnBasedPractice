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

        public Potion(int tmpID, string tmpName, int tmpValue, int tmpPotency, bool tmpCanBuy)
            : base(tmpID, tmpName, tmpValue, tmpCanBuy)
        {
            this.potency = tmpPotency;
        }

        public Potion(string EString)
            : base(EString)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
