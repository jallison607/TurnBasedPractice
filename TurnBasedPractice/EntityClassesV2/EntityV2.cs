using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedPractice.ItemClasses;
using TurnBasedPractice.GameClasses;
using GameTools.Basic;
using System.Threading;

namespace TurnBasedPractice.EntityClasses
{
    public class Entity :EntityAbstract
    {
        private int InstanceID = 0;
        public int attackTry;
        private Weapon equipedWeapon;
        private CharacterClass activeClass;
        private Dictionary<CharacterClass, int> playerClassesAndLevels = new Dictionary<CharacterClass, int>();

        //Constructors
        public Entity(int tmpID, string tmpName, int[] tmpStats, Weapon tmpWeapon)
            : base(tmpID, tmpName, tmpStats)
        {
            
            this.equipedWeapon = tmpWeapon;
            
        }

        public Entity(string EString, List<Weapon> currentWeapons):base(EString)
        {
            EString = EString.Substring(29 + this.name.Length);

            int WepID = ParseItems.parseIntFrom(EString, 4);

            foreach (Weapon tmpWep in currentWeapons)
            {
                if (tmpWep.ItemID == WepID)
                {
                    this.equipedWeapon = tmpWep;
                }
            }
            
        }


        /*
         * To EString in the following format
         * 
         * length + id + nameLength + name + (Level, Constitution, Magi, Dexterity, Strength) +  maxHP + manaReduction + currentDamage + wepIDToEString
         * 
         * xxx + xxxx + xx + xn + +xxx+xxx+xxx+xxx + xxxx + xxxx + xxxx + xxxx + xxxx
         * 
         * 
         * 
         */
        public override string ToEString()
        {
            string ToBeEncrypted = String.Empty;

            ToBeEncrypted += statsToEncrption();
            ToBeEncrypted += ParseItems.convertToLength(this.equipedWeapon.ItemID, 4);

            ToBeEncrypted = ParseItems.convertToLength(ToBeEncrypted.Length, 3) + ToBeEncrypted;

            return ToBeEncrypted;
        }

        //######Getters

        public int getInstanceID()
        {
            return this.InstanceID;
        }

        public void setInstanceID(int tmpIID)
        {
            this.InstanceID = tmpIID;
        }

        

        //#####Combat Methods
        public int dodge()
        {
            
            return TurnBasedPractice.RandomInt.r.Next(0, 100);
        }

        

        public int basicAttackHit()
        {
            
            //int tmpAttackTry = TurnBasedPractice.RandomInt.r.Next(0, 100);
            //tmpAttackTry += this.equipedWeapon.AttackRollBonus + this.strength;
            //return tmpAttackTry;
            throw new NotImplementedException();
        }

        public int basicAttackDamage()
        {
            //return this.equipedWeapon.damage;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unequips and returns the previously equiped weapon
        /// "Equips" unarmed weapon with ID of -001
        /// </summary>
        /// <returns></returns>
        public Weapon unequipWeapon()
        {
            Weapon tmpOld = this.equipedWeapon;
            this.equipedWeapon = new Weapon(-001, "Unarmed", 0, 1, false,new List<int>(), new List<int>());
            return tmpOld;
        }

        public void equipWeapon(Weapon tmpNewWep)
        {
            this.equipedWeapon = tmpNewWep;
        }

        public Weapon getEquipedWeapon()
        {
            return this.equipedWeapon;
        }

        public CharacterClass getActiveClass()
        {
            return this.activeClass;
        }

        public void setActiveClass(CharacterClass tmpClass)
        {
            this.activeClass = tmpClass;
        }

        /// <summary>
        /// Returns a dictionary of all classes this Entity has and what level
        /// </summary>
        /// <returns>playerClassesAndLevels</returns>
        public Dictionary<CharacterClass, int> getClasses()
        {
            return this.playerClassesAndLevels;
        }

        public override EntityAbstract Clone()
        {
            string oldEntity = this.ToEString();
            oldEntity = oldEntity.Substring(3);
            List<Weapon> tmpWeps = new List<Weapon>();
            tmpWeps.Add(this.equipedWeapon);
            Entity newEntity = new Entity(oldEntity, tmpWeps);
            return newEntity;
        }
    }
}
