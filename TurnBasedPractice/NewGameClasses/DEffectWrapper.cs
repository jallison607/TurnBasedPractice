using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;
using System.Data.Odbc;

namespace TurnBasedPractice.GameClasses
{
    public class EffectWrapper : WrapperAbstract
    {
        private string elog = "data\\eff.log";
        private List<Effect> _listOfEffects = new List<Effect>();
        private List<int> _usedIDs = new List<int>();
        private BasicLogger bLogger;
        private string connectionString = @"Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=data\\GameEditor.mdb;Uid=Admin;Pwd=;";
        private OdbcConnection dbConnection = new OdbcConnection();


        public EffectWrapper(int tmpint)
        {

        }

        /// <summary>
        /// Constructs the wrapper(Opens/decryptes the effect data file and starts the logger)
        /// </summary>
        public EffectWrapper()
        {
            bLogger = new BasicLogger(elog);
            OdbcCommand effectQuery = new OdbcCommand("select * from Effect", dbConnection);
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcDataReader reader = effectQuery.ExecuteReader();
            while (reader.Read())
            {
                int EffectID = (int)reader[0];
                string EffectName = reader[1].ToString();
                int ElementType = (int)reader[2];
                int EffectType = (int)reader[3];
                int EffectedStat = (int)reader[4];
                int EffectedAmount = (int)reader[5];
                int EffectedDuration = (int)reader[6];
                _listOfEffects.Add(new Effect(EffectID, EffectName, ElementType, EffectType, EffectedStat,EffectedAmount, EffectedDuration));
                _usedIDs.Add(EffectID);
            }
            dbConnection.Close();
        }

        override public void reload()
        {
            _listOfEffects.Clear();
            OdbcCommand effectQuery = new OdbcCommand("select * from Effect", dbConnection);
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcDataReader reader = effectQuery.ExecuteReader();
            while (reader.Read())
            {
                int EffectID = (int)reader[0];
                string EffectName = reader[1].ToString();
                int ElementType = (int)reader[2];
                int EffectType = (int)reader[3];
                int EffectedStat = (int)reader[4];
                int EffectedAmount = (int)reader[5];
                int EffectedDuration = (int)reader[6];
                _listOfEffects.Add(new Effect(EffectID, EffectName, ElementType, EffectType, EffectedStat, EffectedAmount, EffectedDuration));
                _usedIDs.Add(EffectID);
            }
            dbConnection.Close();
        }

        override public void saveCacheChanges()
        {
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcCommand EffectClear = new OdbcCommand("delete from Effect", dbConnection);
            EffectClear.ExecuteNonQuery();
            foreach (Effect tmpEffect in _listOfEffects)
            {
                OdbcCommand EffectInsert = new OdbcCommand("insert into Effect(EffectID, EffectName,ElementType,EffectType,EffectedStat,EffectAmount,EffectDuration) VALUES (" 
                    + tmpEffect.id + ",'" + tmpEffect.name + "', " + tmpEffect.elementalType +"," + tmpEffect.effectType + "," + tmpEffect.effectedStat + "," + tmpEffect.effectAmount + ","
                    + tmpEffect.effectDuration + ")", dbConnection);
                EffectInsert.ExecuteNonQuery();
            }
            dbConnection.Close();
        }

        /// <summary>
        /// Returns a list of all effects
        /// </summary>
        /// <returns>List<Effect></returns>
        public List<Effect> getEffectsList()
        {
            sortEffectsAlphabetically();
            return this._listOfEffects;
        }

        private void sortEffectsAlphabetically()
        {
            this._listOfEffects.Sort((a, b) =>  a.name.CompareTo(b.name));
        }

        /// <summary>
        /// Removes specified effect
        /// </summary>
        /// <param name="tmpToRemoveEffect"></param>
        public void removeEffect(Effect tmpToRemoveEffect)
        {
            if (this._listOfEffects.Contains(tmpToRemoveEffect))
            {
                _listOfEffects.Remove(tmpToRemoveEffect);
            }
        }

        /// <summary>
        /// Returns effect of specified ID or null if effect of ID does not exsist in wrapper
        /// </summary>
        /// <param name="tmpID"></param>
        /// <returns></returns>
        public Effect getEffect(int tmpID)
        {
            int index = -1;
            foreach (Effect tmpEffect in _listOfEffects)
            {
                if (tmpEffect.id == tmpID)
                {
                    index = _listOfEffects.IndexOf(tmpEffect);
                }
            }

            if (index != -1)
            {
                return _listOfEffects[index];
            }
            else
            {
                return null;
            }
        }

        public bool hasEffect(int tmpID)
        {
            bool hasEffect = false;
            foreach (Effect tmpEffect in _listOfEffects)
            {
                if (tmpEffect.id == tmpID)
                {
                    return hasEffect = true;
                }
            }

            return hasEffect;
        }

        /// <summary>
        /// Adds an effect to the wrapper list
        /// </summary>
        /// <param name="tmpNewEffect"></param>
        public void addEffect(Effect tmpNewEffect)
        {
            int index = -1;
            foreach (Effect tmpEffect in _listOfEffects)
            {
                if (tmpEffect.id == tmpNewEffect.id)
                {
                    index = _listOfEffects.IndexOf(tmpEffect);
                }
            }

            if (index != -1)
            {
                _listOfEffects[index] = tmpNewEffect;
            }
            else
            {
                _listOfEffects.Add(tmpNewEffect);
            }
        }

        /// <summary>
        /// Gets the next available ID for an effect and reserves it(Use on the construction/clone of an effect)
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
