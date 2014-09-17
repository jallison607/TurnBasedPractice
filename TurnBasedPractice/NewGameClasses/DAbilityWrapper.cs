using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;
using System.Data.Odbc;

namespace TurnBasedPractice.GameClasses
{
    public class AbilityWrapper : WrapperAbstract
    {
        private string alog = "data\\abi.log";
        private string connectionString = @"Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=data\\GameEditor.mdb;Uid=Admin;Pwd=;";
        private OdbcConnection dbConnection = new OdbcConnection();
        private List<Ability> _listOfAbilities = new List<Ability>();
        private List<int> _usedIDs = new List<int>();
        private BasicLogger bLogger;

        public AbilityWrapper(int tmpint)
        {

        }

        public AbilityWrapper()
        {
            
            
            bLogger = new BasicLogger(alog);
            OdbcCommand AbilityQuery = new OdbcCommand("select * from Ability",dbConnection);
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcDataReader reader = AbilityQuery.ExecuteReader();
            while (reader.Read())
            {
                int AbilityID = (int)reader[0];
                string AbilityName = reader[1].ToString();
                OdbcCommand AbilityEffectQuery = new OdbcCommand("select * from AbilityEffects where AbilityID="+AbilityID,dbConnection);
                OdbcDataReader abilityEffectsReader = AbilityEffectQuery.ExecuteReader();
                List<int> effects = new List<int>();
                while (abilityEffectsReader.Read())
                {
                    effects.Add((int)abilityEffectsReader[2]);
                }

                _listOfAbilities.Add(new Ability(AbilityID, AbilityName, effects));
                _usedIDs.Add(AbilityID);
            }
            dbConnection.Close();
        }

        /// <summary>
        /// Reloads the list of Abilities - Note it clears the cache of requested IDs as well
        /// </summary>
        override public void reload()
        {
            _listOfAbilities.Clear();
            OdbcCommand AbilityQuery = new OdbcCommand("select * from Ability", dbConnection);
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcDataReader reader = AbilityQuery.ExecuteReader();
            while (reader.Read())
            {
                int AbilityID = (int)reader[0];
                string AbilityName = reader[1].ToString();
                OdbcCommand AbilityEffectQuery = new OdbcCommand("select * from AbilityEffects where AbilityID=" + AbilityID, dbConnection);
                OdbcDataReader abilityEffectsReader = AbilityEffectQuery.ExecuteReader();
                List<int> effects = new List<int>();
                while (abilityEffectsReader.Read())
                {
                    effects.Add((int)abilityEffectsReader[2]);
                }

                _listOfAbilities.Add(new Ability(AbilityID, AbilityName, effects));
                _usedIDs.Add(AbilityID);
            }
            dbConnection.Close();
        }

        /// <summary>
        /// It saves of course. And by save I mean commit to the DB/Source files
        /// </summary>
        override public void saveCacheChanges()
        {
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcCommand AbilityClear = new OdbcCommand("delete from Ability",dbConnection);
            OdbcCommand AbilityEffectsClear = new OdbcCommand("delete from AbilityEffects", dbConnection);
            AbilityClear.ExecuteNonQuery();
            AbilityEffectsClear.ExecuteNonQuery();
            foreach (Ability tmpAbility in _listOfAbilities)
            {
                OdbcCommand AbilityInsert = new OdbcCommand("insert into Ability(AbilityID, AbilityName) VALUES (" + tmpAbility.id + ",'"+tmpAbility.name+"')", dbConnection);
                AbilityInsert.ExecuteNonQuery();
                foreach (int tmpID in tmpAbility.effects)
                {
                    OdbcCommand AbilityEffectAdd = new OdbcCommand("insert into AbilityEffects (AbilityID, EffectID) VALUES (" + tmpAbility.id + "," + tmpID + ")",dbConnection);
                    AbilityEffectAdd.ExecuteNonQuery();
                }   
            }
            dbConnection.Close();
        }

        /// <summary>
        /// Returns alphabetic list of abilities
        /// </summary>
        /// <returns>List<Ability></returns>
        public List<Ability> getAbilityList()
        {
            sortAbilitiesAlphabetically();
            return this._listOfAbilities;
        }

        private void sortAbilitiesAlphabetically()
        {
            this._listOfAbilities.Sort((a, b) => a.name.CompareTo(b.name));
        }

        /// <summary>
        /// Removes specified Ability & ID from cache of used IDs
        /// </summary>
        /// <param name="tmpToRemoveAbility"></param>
        public void removeAbilityFromTempCache(Ability tmpToRemoveAbility)
        {
            if (this._listOfAbilities.Contains(tmpToRemoveAbility))
            {
                _listOfAbilities.Remove(tmpToRemoveAbility);
                _usedIDs.Remove(tmpToRemoveAbility.id);
            }
        }

        /// <summary>
        /// Adds an Ability to the wrapper list - Does not commit the addition - Run save() to do this
        /// </summary>
        /// <param name="tmpNewAbility"></param>
        public void addAbilityToTempCache(Ability tmpNewAbility)
        {
            int index = -1;
            foreach (Ability tmpAbility in _listOfAbilities)
            {
                if (tmpAbility.id == tmpNewAbility.id)
                {
                    index = _listOfAbilities.IndexOf(tmpAbility);
                }
            }

            if (index != -1)
            {
                _listOfAbilities[index] = tmpNewAbility;
            }
            else
            {
                _listOfAbilities.Add(tmpNewAbility);
            }
        }

        /// <summary>
        /// Gets the next available ID for an ability and reserves it(Use on the construction/clone of an Ability)
        /// </summary>
        /// <returns></returns>
        override public int NextID()
        {
            int next = 0;
            bool found = false;
            while (!found)
            {
                if (!this._usedIDs.Contains(next))
                {
                    found = true;
                    _usedIDs.Add(next);
                }
                else
                {
                    next++;
                }
            }
            return next;
        }

    }
}
