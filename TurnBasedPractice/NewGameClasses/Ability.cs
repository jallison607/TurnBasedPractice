using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;

namespace TurnBasedPractice.GameClasses
{
    public class Ability
    {
        private int id;
        private string name;
        public int AbilityID
        {
            get { return id; }
        }
        public string AbilityName
        {
            get { return name; }
        }
        public List<int> effects = new List<int>();

        public Ability(int tmpID, string tmpName, List<int> tmpEffects)
        {
            this.id = tmpID;
            this.name = tmpName;
            this.effects = tmpEffects;
        }

        public Ability(string EString)
        {
            this.id = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);
            int nameLength = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);
            this.name = ParseItems.parseStringFrom(EString, nameLength);
            EString = EString.Substring(nameLength);

            int numOfIDs = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);
            int i = 0;

            while (i < numOfIDs)
            {
                effects.Add(ParseItems.parseIntFrom(EString, 3));
                i++;
                if (i < numOfIDs)
                {
                    EString = EString.Substring(3);
                }
            }


        }
        /// <summary>
        /// Creates EString for ability in following format
        /// 
        /// id + nameLength + name + numOfEffects + eachEffectID
        /// 
        /// xxx + xx + xxxxxxxxxxxx + xx + xxx*n
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToEString()
        {
            string result = string.Empty;
            result = ParseItems.convertToLength(id, 3);
            result += ParseItems.convertToLength(name.Length, 2);
            result += name;
            result += ParseItems.convertToLength(effects.Count, 2);

            foreach (int tmpEffectID in effects)
            {
                result += ParseItems.convertToLength(tmpEffectID, 3);
            }

            result = ParseItems.convertToLength(result.Length, 3) + result;

            return result;
        }

        public void addEffect(int tmpNewEffectID)
        {
            if (!effects.Contains(tmpNewEffectID))
            {
                this.effects.Add(tmpNewEffectID);
            }
        }

        public void removeEffect(int tmpOldEffectID)
        {
            if (effects.Contains(tmpOldEffectID))
            {
                effects.Remove(tmpOldEffectID);
            }
        }

        public Ability Clone(int tmpId)
        {
            Ability newAbility = new Ability(tmpId, name, effects);

            return newAbility;
        }
    }
}
