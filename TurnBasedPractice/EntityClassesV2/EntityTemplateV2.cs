using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedPractice.ItemClasses;
using GameTools.Basic;

namespace TurnBasedPractice.EntityClasses
{
    public class EntityTemplate
    {
        public int id;
        public string name;
        private int minLevel;
        

        /* Base Stats
         * 0: Constitituon
         * 1: Magi
         * 2: Dexterity
         * 3: Streingth
         */
        private int[] baseStats = new int[4];
        private List<int> weaponIDs;

        public EntityTemplate(int tmpID, string tmpName, int tmpMinLevel, int[] tmpStats,List<int> tmpWeapons)
        {
            this.id = tmpID;
            this.name = tmpName;
            this.minLevel = tmpMinLevel;
            this.baseStats = tmpStats;
            this.weaponIDs = tmpWeapons;
        }

        public EntityTemplate(string EString)
        {
            this.id = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            int nameLength = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);

            this.name = ParseItems.parseStringFrom(EString, nameLength);
            EString = EString.Substring(nameLength);

            this.baseStats[0] = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.baseStats[1] = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.baseStats[2] = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.baseStats[3] = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            int numOfWepIDS = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            int i = 0;
            while (i < numOfWepIDS)
            {
                weaponIDs.Add(ParseItems.parseIntFrom(EString,4));
                if (i != numOfWepIDS - 1)
                {
                    EString = EString.Substring(4);
                }
                i++;
            }
        }

        /*
         * To EString in the following format
         * 
         * 
         */
        public string ToEString()
        {
            string ToBeEncrypted = String.Empty;

            ToBeEncrypted += ParseItems.convertToLength(this.id, 3);
            ToBeEncrypted += ParseItems.convertToLength(this.name.Length, 2);
            ToBeEncrypted += this.name;

            foreach (int tmpStat in this.baseStats)
            {
                ToBeEncrypted += ParseItems.convertToLength(tmpStat, 3);
            }

            ToBeEncrypted += ParseItems.convertToLength(this.weaponIDs.Count, 3);

            foreach (int tmpWepID in this.weaponIDs)
            {
                ToBeEncrypted += ParseItems.convertToLength(tmpWepID, 3);
            }

            return ToBeEncrypted;
        }

        //######Getters
        public int getMinLevel()
        {
            return this.minLevel;
        }

        /// <summary>
        /// Base stats (AKA priority of stat)
        /// 0: Constitituon
        /// 1: Magi
        /// 2: Dexterity
        /// 3: Streingth
        /// </summary>
        /// <returns></returns>
        public int[] getBaseStats()
        {
            return this.baseStats;
        }

        public List<int> getWeapons()
        {
            return this.weaponIDs;
        }

        public void removeWeapon(int tmpID)
        {
            weaponIDs.Remove(tmpID);
        }

        public EntityTemplate Clone()
        {
            string oldEntity = this.ToEString();
            oldEntity = oldEntity.Substring(3);
            EntityTemplate newEntityTemplate = new EntityTemplate(oldEntity);
            return newEntityTemplate;
        }

        public Entity generateAnEntity(int tmpId, string tmpName, List<Weapon> tmpWeapons)
        {

            //Figure out which stat has priority
            List<int> sortedStats = baseStats.ToList();
            sortedStats.Sort();
            List<int> indexes = new List<int>();
            foreach (int tmpPriorityValue in sortedStats)
            {
                bool found = false;
                int i = 0;
                while (!found)
                {
                    if (baseStats[i] == tmpPriorityValue && !indexes.Contains(i))
                    {
                        indexes.Add(i);
                        found = true;
                    }
                    i++;
                }
            }

            //Spend all points earned by this level
            int points = 2 * this.minLevel;
            int[] gStats = new int[5]{this.minLevel,1,1,1,1};
            int j = 1;
            while (points > 0)
            {
                int spending = RandomInt.r.Next(0, 1);
                if (spending == 1)
                {
                    gStats[indexes[j]] += 1;
                    points -= 1;
                    j = 1;
                }
                else if (j == 4)
                {
                    j = 1;
                }
                else
                {
                    j++;
                }
                
            }



            //Select a random weapon from weapons this template uses
            int selectedID = RandomInt.r.Next(0, weaponIDs.Count);
            Weapon selectedWep = new Weapon(0, "Unarmed", 0, 0, true, new List<int>(), new List<int>());
            foreach(Weapon tmpWep in tmpWeapons)
            {
                if(tmpWep.ItemID == weaponIDs[selectedID]){
                    selectedWep = tmpWep;
                }
            }

            //Create the Entity
            Entity tmpEnt = new Entity(tmpId, tmpName, gStats, selectedWep);

            return tmpEnt;
        }
    
        
    }
}
