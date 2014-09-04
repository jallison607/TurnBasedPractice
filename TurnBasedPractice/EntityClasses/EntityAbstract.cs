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
        public int constitution; //Used to derive HP | MaxHP = 5*Constitution
        public int magi; //Used to derive mana | MaxMana = 5*Magi
        public int dexterity; //Used to derive speed | Speed Bonus = (dexterity/2)Rounded
        public int strength; //Used to derive damage | Damage Bonus = (Strength/2)Rounded
        

        public EntityAbstract(string EString)
        {
            this.id = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            int nameLength = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);

            this.name = ParseItems.parseStringFrom(EString, nameLength);
            EString = EString.Substring(nameLength);
        }

        public EntityAbstract(int tmpID, string tmpName)
        {
            this.id = tmpID;
            this.name = tmpName;
        }

        public abstract EntityAbstract Clone();
        public abstract string ToEString();
    }
}
