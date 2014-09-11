using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;

namespace TurnBasedPractice.GameClasses
{
    public class Effect
    {
        
        public int id;
        public string name;
        
        /* Elemental Types
         * 0: Normal
         * 1: Fire
         * 2: Water
         * 3: Air
         * 4: Earth
         * 5: Poison
         * 6: Holy
         * 7: Time
         * 8: Ice
         */
        public int elementalType;

        /* Effect Types
         * 0: Decrease stat
         * 1: Increase stat
         * 2: Status
         */
        public int effectType;

        /* Stats
         * 0: Hit Points
         * 1: Magi Points
         * 2: Strength
         * 3: Dexterity
         * 4: Speed
         */
        public int effectedStat;
        
        /*
         * 
         */ 
        public int effectAmount;
        
        /* 
         * Duration of which to spread effect amounts over
         * example: 4 duration means efffect per round == effect amount/4
         */
        public int effectDuration;
        //private specialEffect specEffect

        public Effect(int tmpID, string tmpName, int tmpEType, int tmpType, int tmpStat, int tmpAmount, int tmpDuration)
        {
            this.id = tmpID;
            this.name = tmpName;
            this.elementalType = tmpEType;
            this.effectType = tmpType;
            this.effectedStat = tmpStat;
            this.effectAmount = tmpAmount;
            this.effectDuration = tmpDuration;
        }

        public Effect(string EString)
        {
            this.id = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);
            
            int nameLength = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);
            this.name = ParseItems.parseStringFrom(EString, nameLength);
            EString = EString.Substring(nameLength);

            this.elementalType = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);

            this.effectType = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);

            this.effectedStat = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);

            this.effectAmount = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);

            this.effectDuration = ParseItems.parseIntFrom(EString, 2);
            
        }


        public string ToEString()
        {
            string ToBeEncrypted = string.Empty;
            ToBeEncrypted += ParseItems.convertToLength(id, 3);
            ToBeEncrypted += ParseItems.convertToLength(name.Length, 2);
            ToBeEncrypted += name;
            ToBeEncrypted += ParseItems.convertToLength(elementalType, 2);
            ToBeEncrypted += ParseItems.convertToLength(effectType, 2);
            ToBeEncrypted += ParseItems.convertToLength(effectedStat, 2);
            ToBeEncrypted += ParseItems.convertToLength(effectAmount, 2);
            ToBeEncrypted += ParseItems.convertToLength(effectDuration, 2);
            ToBeEncrypted = ParseItems.convertToLength(ToBeEncrypted.Length, 3) + ToBeEncrypted;

            return ToBeEncrypted;
        }

        public Effect Clone(int ClonesID)
        {
            Effect tmpNew = new Effect(ClonesID, this.name, this.elementalType, this.effectType, this.effectedStat, this.effectAmount, this.effectDuration);

            return tmpNew;
        }

        public string getElementName()
        {
            string result = string.Empty;
            switch (this.elementalType)
            {
                case 0:
                    result = "Normal";
                    break;
                case 1:
                    result = "Fire";
                    break;
                case 2:
                    result = "Water";
                    break;
                case 3:
                    result = "Air";
                    break;
                case 4:
                    result = "Earth";
                    break;
                case 5:
                    result = "Posion";
                    break;
                case 6:
                    result = "Holy";
                    break;
                case 7:
                    result = "Time";
                    break;
                case 8:
                    result = "Ice";
                    break;
            }
            return result;
        }

        public string getEffectType()
        {
            string result = string.Empty;
            switch (this.effectType)
            {
                case 0:
                    result = "Decrease";
                    break;
                case 1:
                    result = "Increase";
                    break;
                case 2:
                    result = "Change status";
                    break;
            }
            return result;
        }

        public string getEffectedStatName()
        {
            /* Stats
         * 0: Hit Points
         * 1: Magi Points
         * 2: Strength
         * 3: Dexterity
         * 4: Speed
         */
            string result = string.Empty;
            switch (this.effectedStat)
            {
                case 0:
                    result = "Hit Points";
                    break;
                case 1:
                    result = "Magi Points";
                    break;
                case 2:
                    result = "Strength";
                    break;
                case 3:
                    result = "Dexterity";
                    break;
                case 4:
                    result = "Speed";
                    break;
            }
            return result;
        }
    }
}
