using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;
using TurnBasedPractice.GameClasses;

namespace TurnBasedPractice.ItemClasses
{
    public class Weapon : Item
    {
        private int power;
        private int magiPower;
        private List<int> classesCanUse = new List<int>();
        public List<int> ValidClasses
        {
            get { return classesCanUse; }
        }
        private List<int> magicalEffects = new List<int>();

        public Weapon(int tmpID, string tmpName, int tmpValue, int tmpPower, int tmpMagiPower, bool tmpCanBuy, List<int> tmpMagicalEffects, List<int> tmpClassesCanUse)
            : base(tmpID, tmpName, tmpValue, tmpCanBuy)
        {
            this.power = tmpPower;
            this.magicalEffects = tmpMagicalEffects;
            foreach (int tmpClassID in tmpClassesCanUse)
            {
                this.classesCanUse.Add(tmpClassID);
            }
            
        }

        /*
         * Return string to be encrypted in this format 
         * 
         * length + ID + NameLength + Name + canBuy + Value + Power + accuracy
         * 
         * xxx + xxxx + xx + xn + x + xxxx + 
         * 
         */
        override public string ToEString()
        {
            throw new NotImplementedException();
        }

        public int getPower()
        {
            return this.power;
        }

        public int getMagiPower()
        {
            return this.magiPower;
        }

        public List<int> getMagicalEffects()
        {
            return this.magicalEffects;
        }

        public override Item Clone(int tmpID)
        {
            Weapon tmpNewWep = new Weapon(tmpID, ItemName, value, power, magiPower, canBuy, magicalEffects, classesCanUse);
            return tmpNewWep;
        }

    }
}
