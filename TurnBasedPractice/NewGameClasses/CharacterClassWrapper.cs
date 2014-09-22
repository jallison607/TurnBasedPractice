using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;
using System.Data.Odbc;

namespace TurnBasedPractice.GameClasses
{
    class CharacterClassWrapper : WrapperAbstract
    {
        private string clog = "data\\c.log";
        private string connectionString = @"Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=data\\GameEditor.mdb;Uid=Admin;Pwd=;";
        private OdbcConnection dbConnection = new OdbcConnection();
        private List<CharacterClass> _listOfClasses = new List<CharacterClass>();
        private List<int> _usedIDs = new List<int>();
        private BasicLogger bLogger;
        private bool debug = false;
        private bool info = true;

        public CharacterClassWrapper()
        {
            bLogger = new BasicLogger(clog);
            reload();
        }

        /// <summary>
        /// Reloads the list of Spells - note it clears the cache of requested IDs as well
        /// </summary>
        public override void reload()
        {
            _listOfClasses.Clear();
            _usedIDs.Clear();
            OdbcCommand ClassQuery = new OdbcCommand("select * from CharacterClass",dbConnection);
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcDataReader reader = ClassQuery.ExecuteReader();
            while (reader.Read())
            {
                int classID = (int)reader[0];
                string className = reader[1].ToString();
                bLogger.Log("Loading stat bonuses for class: " + className, debug);

                Dictionary<string, int> stats = new Dictionary<string, int>();
                Dictionary<string, int> preReqStats = new Dictionary<string, int>();
                stats.Add("Con", (int)reader[2]);
                stats.Add("Mag", (int)reader[3]);
                stats.Add("Dex", (int)reader[4]);
                stats.Add("Str", (int)reader[5]);
                stats.Add("Spr", (int)reader[6]);
                stats.Add("Spd", (int)reader[7]);

                preReqStats.Add("Con", (int)reader[8]);
                preReqStats.Add("Mag", (int)reader[9]);
                preReqStats.Add("Dex", (int)reader[10]);
                preReqStats.Add("Str", (int)reader[11]);
                preReqStats.Add("Spr", (int)reader[12]);
                preReqStats.Add("Spd", (int)reader[13]);

                bLogger.Log("Retreiving Class Pre Req Classes from data source", debug);
                OdbcCommand classPrereqQuery = new OdbcCommand("select PreReqClassID, PreReqLevel from ClassPrereqClasses where ClassID =" + classID, dbConnection);
                OdbcDataReader classPrereqReader = classPrereqQuery.ExecuteReader();
                bLogger.Log("Loading Class Prereq", debug);
                Dictionary<int, int> preReqClasses = new Dictionary<int, int>();
                while (classPrereqReader.Read())
                {
                    preReqClasses.Add((int)classPrereqReader[0], (int)classPrereqReader[1]);
                }

                bLogger.Log("Retreiving Class Elements from data source", debug);
                OdbcCommand classElementQuery = new OdbcCommand("select ElementID from ClassElements where ClassID =" + classID, dbConnection);
                OdbcDataReader classElementReader = classElementQuery.ExecuteReader();
                bLogger.Log("Loading Class Elements", debug);
                List<int> elements = new List<int>();
                while (classElementReader.Read())
                {
                    elements.Add((int)classElementReader[0]);
                }

                bLogger.Log("Retreiving Class Abilities from data source", debug);
                OdbcCommand classAbilitiesQuery = new OdbcCommand("select AbilityID, LevelLearned from ClassAbilities where ClassID =" + classID, dbConnection);
                OdbcDataReader classAbilityReader = classAbilitiesQuery.ExecuteReader();
                bLogger.Log("Loading Class Abilities", debug);
                Dictionary<int, int> abilities = new Dictionary<int, int>();
                while (classAbilityReader.Read())
                {
                    abilities.Add((int)classAbilityReader[0], (int)classAbilityReader[1]);
                }

                bLogger.Log("Saving class " + className + " into cache.", debug);
                _listOfClasses.Add(new CharacterClass(classID, className, stats, elements, abilities, preReqStats, preReqClasses));
                _usedIDs.Add(classID);
            }
            dbConnection.Close();
            bLogger.Log("Finished Loading all classes", debug);
        }


        /// <summary>
        /// Saves the cache to the datasource files
        /// </summary>
        public override void saveCacheChanges()
        {
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcCommand classClear = new OdbcCommand("delete from CharacterClass", dbConnection);
            OdbcCommand classElementsClear = new OdbcCommand("delete from ClassElements", dbConnection);
            OdbcCommand classAbilitiesClear = new OdbcCommand("delete from ClassAbilities", dbConnection);
            OdbcCommand classPrereqClassesClear = new OdbcCommand("delete from ClassPrereqClasses", dbConnection);
            bLogger.Log("Clearing previous Class Abilities from data source", debug);
            classAbilitiesClear.ExecuteNonQuery();
            bLogger.Log("Clearing previous Class Elements from data source", debug);
            classElementsClear.ExecuteNonQuery();
            bLogger.Log("Clearing previous class prereq classes from data source", debug);
            classPrereqClassesClear.ExecuteNonQuery();
            bLogger.Log("Clearing previous Classes from data source", debug);
            classClear.ExecuteNonQuery();
            

            foreach (CharacterClass tmpClass in _listOfClasses)
            {
                bLogger.Log("Saving " + tmpClass.ClassName + " into data source", debug);
                OdbcCommand ClassInsert = new OdbcCommand("insert into CharacterClass (ClassID, ClassName, ConBonus, MagBonus, DexBonus, StrBonus, SprBonus, SpdBonus, ConPrereq, MagPrereq, DexPrereq, StrPrereq, SprPrereq, SpdPrereq) VALUES "
                    +"("+ tmpClass.ClassID +",'"+ tmpClass.ClassName +"',"+ tmpClass.constitutionBonus + ","+ tmpClass.magiBonus +","+ tmpClass.dexterityBonus +","+ tmpClass.strengthBonus +","+ tmpClass.spiritBonus +","+ tmpClass.speedBonus 
                    +"," + tmpClass.constitutionPrereq + "," + tmpClass.magiPrereq + "," + tmpClass.dexterityPrereq + "," + tmpClass.strengthPrereq + "," + tmpClass.spiritPrereq + "," + tmpClass.speedPrereq + ")",dbConnection);
                ClassInsert.ExecuteNonQuery();

                bLogger.Log("Saving class prerequisit classes into data source", debug);
                foreach (KeyValuePair<int, int> tmpClassClassPrereq in tmpClass.preReqClasses)
                {
                    OdbcCommand ClassClassPreReq = new OdbcCommand("insert into ClassPrereqClasses (ClassID, PreReqClassID, PreReqLevel) Values (" + tmpClass.ClassID + "," + tmpClassClassPrereq.Key + "," + tmpClassClassPrereq.Value + ")", dbConnection);
                    ClassClassPreReq.ExecuteNonQuery();
                }

                bLogger.Log("Saving class Elements into data source", debug);
                foreach (int tmpElementID in tmpClass.magiElementsCanUse)
                {
                    OdbcCommand ClassElementInsert = new OdbcCommand("insert into ClassElements (ClassID, ElementID) Values ("+ tmpClass.ClassID +","+ tmpElementID+")",dbConnection);
                    ClassElementInsert.ExecuteNonQuery();
                }

                bLogger.Log("Saving class Abilities into data source", debug);
                foreach (KeyValuePair<int, int> tmpAbilitySet in tmpClass.abilitiesLearnedByLevel)
                {
                    OdbcCommand ClassAbilityInsert = new OdbcCommand("insert into ClassAbilities (ClassID, AbilityID, LevelLearned) Values ("+ tmpClass.ClassID + "," + tmpAbilitySet.Key + "," + tmpAbilitySet.Value + ")",dbConnection);
                    ClassAbilityInsert.ExecuteNonQuery();
                }
            }
            
            bLogger.Log("Classes Saved into data source", info);
        }

        /// <summary>
        /// Returns alphabetic list of Classes
        /// </summary>
        /// <returns>List of classes</returns>
        public List<CharacterClass> getClassList()
        {
            sortClassesAlphabetically();
            return _listOfClasses;
        }

        /// <summary>
        /// Returns class of specified ID, if none exsists returns null
        /// </summary>
        /// <param name="tmpID"></param>
        /// <returns></returns>
        public CharacterClass getClass(int tmpID)
        {
            CharacterClass tmpClass = null;
            foreach (CharacterClass tmpAClass in _listOfClasses)
            {
                if (tmpAClass.ClassID == tmpID)
                {
                    return tmpAClass;
                }
            }
            return tmpClass;
        }

        private void sortClassesAlphabetically()
        {
            _listOfClasses.Sort((a, b) => a.ClassName.CompareTo(b.ClassName));
        }

        /// <summary>
        /// Removeds specified Class and ID from cache of used IDs
        /// </summary>
        /// <param name="tmpClass"></param>
        public void removeClassFromTempCache(CharacterClass tmpClass)
        {
            if(_listOfClasses.Contains(tmpClass)){
                _listOfClasses.Remove(tmpClass);
                _usedIDs.Remove(tmpClass.ClassID);
            }
        }

        /// <summary>
        /// Add CharacterClass to wrapper cache/list - Does not commit addition - Run saveCacheChanges() to do this
        /// </summary>
        /// <param name="tmpNewClass"></param>
        public void addClassToTempCache(CharacterClass tmpNewClass)
        {
            int index = -1;
            foreach (CharacterClass tmpClass in _listOfClasses)
            {
                if (tmpClass.ClassID == tmpNewClass.ClassID)
                {
                    index = _listOfClasses.IndexOf(tmpClass);
                }
            }

            if (index != -1)
            {
                _listOfClasses[index] = tmpNewClass;
            }
            else
            {
                _listOfClasses.Add(tmpNewClass);
            }
        }


        /// <summary>
        /// Gets the next available ID for a CharacterClass and reserves it(Use on the construction/clone of a CharacterClass)
        /// </summary>
        /// <returns></returns>
        public override int NextID()
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
