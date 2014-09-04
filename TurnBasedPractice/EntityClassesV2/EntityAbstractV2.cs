using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;

namespace TurnBasedPractice.EntityClasses
{
    public abstract class EntityAbstract
    {
        public int id;
        public string name;
        //Every level gets 2 points to distribute among the following stats - Tentative maximum of 99
        private int level;
        public int constitution; //Used to derive HP | MaxHP = 5*Constitution
        public int magi; //Used to derive mana | MaxMana = 5*Magi
        public int dexterity; //Used to derive speed | Speed Bonus = (dexterity/2)Rounded
        public int strength; //Used to derive damage | Damage Bonus = (Strength/2)Rounded
        public int speed; //Derived from dexterity (dex/2)
        private int maxHP;
        private int maxMana;
        private int currentDamage;
        private int manaReduction;

        public EntityAbstract(string EString)
        {
            this.id = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            int nameLength = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);

            this.name = ParseItems.parseStringFrom(EString, nameLength);
            EString = EString.Substring(nameLength);

            this.level = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.constitution = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.magi = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.dexterity = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.strength = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.maxHP = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            this.currentDamage = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

        }

        /// <summary>
        /// Constructor for id, name, level, & stats.
        /// </summary>
        /// <param name="tmpID"></param>
        /// <param name="tmpName"></param>
        /// <param name="stats">5 in length. 0: Level, 1: constitituon, 2: magi, 3: dexterity, 4: strength </param>
        public EntityAbstract(int tmpID, string tmpName, int[] stats)
        {
            this.id = tmpID;
            this.name = tmpName;
            this.level = stats[0];
            this.constitution = stats[1];
            this.magi = stats[2];
            this.dexterity = stats[3];
            this.strength = stats[4];
            deriveSpeed();
            this.maxHP = 5 * this.constitution;
            this.maxMana = 5 * this.magi;
            this.currentDamage = 0;
            this.manaReduction = 0;
        }

        private void deriveSpeed()
        {
            this.speed = (int) Math.Ceiling((double)(this.dexterity / 2));
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public int getLevel()
        {
            return this.level;
        }

        public int getID()
        {
            return this.id;
        }

        public void setLevel(int tmpLevel)
        {
            this.level = tmpLevel;
        }

        public int getMaxHP()
        {
            return this.maxHP;
        }

        public int currentHP()
        {
            return this.maxHP - currentDamage;
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

        protected string statsToEncrption()
        {
            string ToBeEncrypted = string.Empty;

            ToBeEncrypted += ParseItems.convertToLength(this.id, 4);
            
            int nameLength = this.name.Length;
            ToBeEncrypted += ParseItems.convertToLength(nameLength, 2);
            ToBeEncrypted += this.name;
            
            ToBeEncrypted += ParseItems.convertToLength(this.level, 3);
            ToBeEncrypted += ParseItems.convertToLength(this.constitution, 3);
            ToBeEncrypted += ParseItems.convertToLength(this.magi, 3);
            ToBeEncrypted += ParseItems.convertToLength(this.dexterity, 3);
            ToBeEncrypted += ParseItems.convertToLength(this.strength, 3);
            ToBeEncrypted += ParseItems.convertToLength(this.maxHP, 4);
            ToBeEncrypted += ParseItems.convertToLength(this.maxMana, 4);
            ToBeEncrypted += ParseItems.convertToLength(this.manaReduction, 4);
            ToBeEncrypted += ParseItems.convertToLength(this.currentDamage, 4);
            
            return ToBeEncrypted;
        }

        public abstract EntityAbstract Clone();
        public abstract string ToEString();
    }
}
