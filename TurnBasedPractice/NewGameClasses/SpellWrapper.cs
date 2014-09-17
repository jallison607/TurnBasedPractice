using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;
using System.Data.Odbc;

namespace TurnBasedPractice.GameClasses
{
    public class SpellWrapper : WrapperAbstract
    {
        private string slog = "data\\s.log";
        private string connectionString = @"Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=data\\GameEditor.mdb;Uid=Admin;Pwd=;";
        private OdbcConnection dbConnection = new OdbcConnection();
        private List<Spell> _listOfSpells = new List<Spell>();
        private List<int> _usedIDs = new List<int>();
        private BasicLogger bLogger;

        public SpellWrapper()
        {
            bLogger = new BasicLogger(slog);
            OdbcCommand SpellQuery = new OdbcCommand("select * from Spell", dbConnection);
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcDataReader reader = SpellQuery.ExecuteReader();
            while (reader.Read())
            {
                int SpellID = (int)reader[0];
                string SpellName = reader[1].ToString();
                int MagiCost = (int)reader[2];
                OdbcCommand SpellEffectQuery = new OdbcCommand("select * from SpellEffects where SpellID=" + SpellID, dbConnection);
                OdbcDataReader spellEffectsReader = SpellEffectQuery.ExecuteReader();
                List<int> effects = new List<int>();
                while (spellEffectsReader.Read())
                {
                    effects.Add((int)spellEffectsReader[2]);
                }

                _listOfSpells.Add(new Spell(SpellID, SpellName,MagiCost,effects));
                _usedIDs.Add(SpellID);
            }
            dbConnection.Close();
        }

        /// <summary>
        /// Reloads the list of Spells - note it clears the cache of requested IDs as well
        /// </summary>
        override public void reload()
        {
            _listOfSpells.Clear();
            OdbcCommand SpellQuery = new OdbcCommand("select * from Spell", dbConnection);
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcDataReader reader = SpellQuery.ExecuteReader();
            while (reader.Read())
            {
                int SpellID = (int)reader[0];
                string SpellName = reader[1].ToString();
                int MagiCost = (int)reader[2];
                OdbcCommand SpellEffectQuery = new OdbcCommand("select * from SpellEffects where SpellID=" + SpellID, dbConnection);
                OdbcDataReader spellEffectsReader = SpellEffectQuery.ExecuteReader();
                List<int> effects = new List<int>();
                while (spellEffectsReader.Read())
                {
                    effects.Add((int)spellEffectsReader[2]);
                }

                _listOfSpells.Add(new Spell(SpellID, SpellName, MagiCost, effects));
                _usedIDs.Add(SpellID);
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
            OdbcCommand SpellClear = new OdbcCommand("delete from Spell", dbConnection);
            OdbcCommand SpellEffectsClear = new OdbcCommand("delete from SpellEffects", dbConnection);
            SpellClear.ExecuteNonQuery();
            SpellEffectsClear.ExecuteNonQuery();
            foreach (Spell tmpSpell in _listOfSpells)
            {
                OdbcCommand SpellInsert = new OdbcCommand("insert into Spell(SpellID, SpellName, SpellMagiCost) VALUES (" + tmpSpell.SpellID + ",'" + tmpSpell.SpellName + "'," + tmpSpell.getMagiCost() + ")", dbConnection);
                SpellInsert.ExecuteNonQuery();
                foreach (int tmpID in tmpSpell.getEffects())
                {
                    OdbcCommand SpellEffectAdd = new OdbcCommand("insert into SpellEffects (SpellID, EffectID) VALUES (" + tmpSpell.SpellID + "," + tmpID + ")", dbConnection);
                    SpellEffectAdd.ExecuteNonQuery();
                }
            }
            dbConnection.Close();
        }

        /// <summary>
        /// Returns alphabetic list of Spells
        /// </summary>
        /// <returns>List</returns>
        public List<Spell> getSpellList()
        {
            sortSpellsAlphabetically();
            return this._listOfSpells;
        }

        public Spell getSpell(int tmpID)
        {
            Spell tmpSpell = null;
            foreach (Spell tmpASpell in _listOfSpells)
            {
                if (tmpASpell.SpellID == tmpID)
                {
                    return tmpASpell;
                }
            }
            return tmpSpell;
        }

        private void sortSpellsAlphabetically()
        {
            this._listOfSpells.Sort((a, b) => a.SpellName.CompareTo(b.SpellName));
        }

        /// <summary>
        /// Removes specified Spell & ID from cache of used IDs
        /// </summary>
        /// <param name="tmpSpell"></param>
        public void removeSpellFromTempCache(Spell tmpSpell)
        {
            if (_listOfSpells.Contains(tmpSpell))
            {
                _listOfSpells.Remove(tmpSpell);
                _usedIDs.Remove(tmpSpell.SpellID);
            }
        }

        /// <summary>
        /// Adds a Spell to the wrapper list - Does not commit the addition - Run save() to do this
        /// </summary>
        /// <param name="tmpNewSpell"></param>
        public void addSpellToTempCache(Spell tmpNewSpell)
        {
            int index = -1;
            foreach (Spell tmpSpell in _listOfSpells)
            {
                if (tmpSpell.SpellID == tmpNewSpell.SpellID)
                {
                    index = _listOfSpells.IndexOf(tmpSpell);
                }
            }

            if (index != -1)
            {
                _listOfSpells[index] = tmpNewSpell;
            }
            else
            {
                _listOfSpells.Add(tmpNewSpell);
            }
        }
        /// <summary>
        /// Gets the next available ID for a Spell and reserves it(Use on the construction/clone of a Spell)
        /// </summary>
        /// <returns></returns>
        override public int NextID()
        {
            int next = 0;
            bool found = false;
            while (!found)
            {
                if (_usedIDs.Contains(next))
                {
                    next++;
                }
                else
                {
                    found = true;
                    _usedIDs.Add(next);
                }
            }

            return next;
        }

    }
}
