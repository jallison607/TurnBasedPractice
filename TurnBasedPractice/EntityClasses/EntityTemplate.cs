using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedPractice.ItemClasses;
using GameTools.Basic;

namespace TurnBasedPractice.EntityClasses
{
    public class EntityTemplate : EntityAbstract
    {

        private int baseHP;
        private int speed;
        private int minLevel;
        private Weapon equipedWeapon;

        public EntityTemplate(int tmpID, string tmpName, int tmpminLevel, Weapon tmpWeapon) :base(tmpID,tmpName)
        {

            this.minLevel = tmpminLevel;
            this.equipedWeapon = tmpWeapon;
            this.baseHP = 10 * tmpminLevel;
            this.speed = 1;
        }

        public EntityTemplate(int tmpID, string tmpName, int tmpminLevel, Weapon tmpWeapon, int tmpBaseHP, int tmpSpeed)
            : base(tmpID, tmpName)
        {

            this.minLevel = tmpminLevel;
            this.equipedWeapon = tmpWeapon;
            this.baseHP = tmpBaseHP;
            this.speed = tmpSpeed;
        }

        public EntityTemplate(string EString):base(EString)
        {
            EString = EString.Substring(6 + name.Length);

            this.baseHP = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            this.minLevel = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            this.speed = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            int weaponLength = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.equipWeapon(new Weapon(ParseItems.parseStringFrom(EString, weaponLength)));

        }

        /*
         * To EString in the following format
         * 
         * length + id + nameLength + name + baseHP + minLevel + speed + currentDamage + wepToEString
         * 
         * xxx + xxxx + xx + xn + xxxx + xxxx + xxxx + xxxx + x(unknown)
         * 
         * 
         * 
         */
        public override string ToEString()
        {
            string ToBeEncrypted = String.Empty;

            ToBeEncrypted += ParseItems.convertToLength(this.id, 4);
            ToBeEncrypted += ParseItems.convertToLength(this.name.Length, 2);
            ToBeEncrypted += this.name;
            ToBeEncrypted += ParseItems.convertToLength(this.baseHP, 4);
            ToBeEncrypted += ParseItems.convertToLength(this.minLevel, 4);
            ToBeEncrypted += ParseItems.convertToLength(this.speed, 4);
            ToBeEncrypted += this.equipedWeapon.ToEString();

            ToBeEncrypted = ParseItems.convertToLength(ToBeEncrypted.Length, 3) + ToBeEncrypted;

            return ToBeEncrypted;
        }

        //######Getters

        public int getBaseHP()
        {
            return this.baseHP;
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public int getMinLevel()
        {
            return this.minLevel;
        }

        public int getID()
        {
            return this.id;
        }

        public override EntityAbstract  Clone()
        {
            string oldEntity = this.ToEString();
            oldEntity = oldEntity.Substring(3);
            EntityTemplate newEntityTemplate = new EntityTemplate(oldEntity);
            return newEntityTemplate;
        }
    
        //#####Combat Methods
        public void equipWeapon(Weapon tmpNewWep)
        {
            this.equipedWeapon = tmpNewWep;
        }

        public Weapon getEquipedWeapon()
        {
            return this.equipedWeapon;
        }
    }
}
