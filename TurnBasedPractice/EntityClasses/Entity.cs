using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedPractice.ItemClasses;
using GameTools.Basic;
using System.Threading;

namespace TurnBasedPractice.EntityClasses
{
    public class Entity :EntityAbstract
    {
        private int InstanceID = 0;
        private int maxHP;
        private int speed;
        private int level;
        private int currentDamage;
        public int attackTry;
        private Weapon equipedWeapon;

        //Constructors
        public Entity(int tmpID, string tmpName, int tmpLevel, Weapon tmpWeapon) :base(tmpID,tmpName)
        {
            this.level = tmpLevel;
            this.equipedWeapon = tmpWeapon;
            this.maxHP = 10 * tmpLevel;
            this.speed = 1 * tmpLevel;
            this.currentDamage = 0;
            speed = 0;
            Thread.Sleep(1);
            
        }

        public Entity(int tmpID, string tmpName, int tmpLevel, Weapon tmpWeapon, int tmpHP, int tmpSpeed)
            : base(tmpID, tmpName)
        {
            this.level = tmpLevel;
            this.equipedWeapon = tmpWeapon;
            this.maxHP = tmpHP;
            this.speed = tmpSpeed;
            this.currentDamage = 0;
            speed = tmpSpeed;
            Thread.Sleep(1);
            
        }

        public Entity(string EString):base(EString)
        {
            EString = EString.Substring(6 + this.name.Length);

            this.maxHP = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            this.level = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            this.speed = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            this.currentDamage = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            int weaponLength = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.equipWeapon(new Weapon(ParseItems.parseStringFrom(EString, weaponLength)));
            Thread.Sleep(1);
            
        }

        public Entity(EntityTemplate tmpTemplate, int lvl):base(tmpTemplate.id,tmpTemplate.name)
        {
            this.maxHP = tmpTemplate.getBaseHP() * lvl;
            this.level = lvl;
            this.speed = tmpTemplate.getSpeed();
            this.currentDamage = 0;
            this.equipWeapon(tmpTemplate.getEquipedWeapon());
            Thread.Sleep(1);
            
        }


        /*
         * To EString in the following format
         * 
         * length + id + nameLength + name + maxHP + level + speed + currentDamage + wepToEString
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
            ToBeEncrypted += ParseItems.convertToLength(this.maxHP, 4);
            ToBeEncrypted += ParseItems.convertToLength(this.level, 4);
            ToBeEncrypted += ParseItems.convertToLength(this.speed, 4);
            ToBeEncrypted += ParseItems.convertToLength(this.currentDamage, 4);
            ToBeEncrypted += this.equipedWeapon.ToEString();

            ToBeEncrypted = ParseItems.convertToLength(ToBeEncrypted.Length, 3) + ToBeEncrypted;

            return ToBeEncrypted;
        }

        //######Getters

        public int getMaxHP()
        {
            return this.maxHP;
        }

        public int currentHP()
        {
            return this.maxHP - currentDamage;
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public bool isAlive()
        {
            bool isAlive = true;
            if (maxHP - currentDamage <= 0)
            {
                isAlive = false;
            }
            return isAlive;
        }

        public int getLevel()
        {
            return this.level;
        }

        public int getID()
        {
            return this.id;
        }

        public int getInstanceID()
        {
            return this.InstanceID;
        }

        public void setInstanceID(int tmpIID)
        {
            this.InstanceID = tmpIID;
        }

        public void setLevel(int tmpLevel)
        {
            this.level = tmpLevel;
        }

        //#####Combat Methods
        public int dodge()
        {
            
            return TurnBasedPractice.RandomInt.r.Next(0, 100);
        }

        public void takeDamage(int tmpDamage)
        {
            if (tmpDamage > 0)
            {
                if (tmpDamage + this.currentDamage > this.maxHP)
                {
                    this.currentDamage = this.maxHP;
                }
                else
                {
                    this.currentDamage += tmpDamage;
                }
            }
            else
            {
                if (tmpDamage + this.currentDamage < 0)
                {
                    this.currentDamage = 0;
                }
                else
                {
                    this.currentDamage += tmpDamage;
                }
            }
            
        }

        public int basicAttackHit()
        {
            
            int tmpAttackTry = TurnBasedPractice.RandomInt.r.Next(0, 100);
            tmpAttackTry += this.equipedWeapon.AttackRollBonus;
            return tmpAttackTry;
        }

        public int basicAttackDamage()
        {
            return this.equipedWeapon.damage;
        }

        public void unequipWeapon()
        {
            this.equipedWeapon = new Weapon(-001, "Unarmed", 0, 1, 20);
        }

        public void equipWeapon(Weapon tmpNewWep)
        {
            this.equipedWeapon = tmpNewWep;
        }

        public Weapon getEquipedWeapon()
        {
            return this.equipedWeapon;
        }

        public override EntityAbstract Clone()
        {
            string oldEntity = this.ToEString();
            oldEntity = oldEntity.Substring(3);
            Entity newEntity = new Entity(oldEntity);
            return newEntity;
        }
    }
}
