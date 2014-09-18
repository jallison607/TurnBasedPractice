using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;
using System.Data.Odbc;

namespace TurnBasedPractice.GameClasses
{
    class ElementWrapper : WrapperAbstract
    {
        private string logFile = "data\\element.log";
        private string connectionString = @"Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=data\\GameEditor.mdb;Uid=Admin;Pwd=;";
        private OdbcConnection dbConnection = new OdbcConnection();
        private List<MagiElement> _listOfElements = new List<MagiElement>();
        private List<int> _usedIDs = new List<int>();
        private BasicLogger bLogger;
        private bool debug = false;
        private bool info = true;

         public ElementWrapper()
        {
            bLogger = new BasicLogger(logFile);
            reload();
        }

        /// <summary>
        /// Reloads the list of Elements - note it clears the cache of requested IDs as well
        /// </summary>
        public override void reload()
        {
            _listOfElements.Clear();
            _usedIDs.Clear();
            OdbcCommand ElementQuery = new OdbcCommand("select * from Element",dbConnection);
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcDataReader reader = ElementQuery.ExecuteReader();
            while (reader.Read())
            {
                int elementID = (int)reader[0];
                string elementName = reader[1].ToString();
                
                bLogger.Log("Saving Element " + elementName + " into cache.", debug);
                _listOfElements.Add(new MagiElement(elementID, elementName));
                _usedIDs.Add(elementID);
            }
            dbConnection.Close();
            bLogger.Log("Finished Loading all MagiElements", debug);
        }


        /// <summary>
        /// Saves the cache to the datasource files
        /// </summary>
        public override void saveCacheChanges()
        {
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            OdbcCommand elementClear = new OdbcCommand("delete from MagiElement", dbConnection);
            bLogger.Log("Clearing previous Elements from data source", debug);
            elementClear.ExecuteNonQuery();
            
            foreach (MagiElement tmpElement in _listOfElements)
            {
                bLogger.Log("Saving " + tmpElement.ElementName + " into data source", debug);
                OdbcCommand elementInsert = new OdbcCommand("insert into Element (ElementID, ElementName) VALUES "
                    +"("+tmpElement.ElementID+",'"+tmpElement.ElementName+"')",dbConnection);
                elementInsert.ExecuteNonQuery();
            }
            
            bLogger.Log("Elements Saved into data source", info);
        }

        /// <summary>
        /// Returns alphabetic list of Elements
        /// </summary>
        /// <returns>List of Elements</returns>
        public List<MagiElement> getElementList()
        {
            sortElementsAlphabetically();
            return _listOfElements;
        }

        /// <summary>
        /// Returns element of specified ID, if none exsists returns null
        /// </summary>
        /// <param name="tmpID"></param>
        /// <returns></returns>
        public MagiElement getElement(int tmpID)
        {
            MagiElement tmpElement = null;
            foreach (MagiElement tmpAElement in _listOfElements)
            {
                if (tmpAElement.ElementID == tmpID)
                {
                    return tmpAElement;
                }
            }
            return tmpElement;
        }

        private void sortElementsAlphabetically()
        {
            _listOfElements.Sort((a, b) => a.ElementName.CompareTo(b.ElementName));
        }

        /// <summary>
        /// Removes specified element and ID from cache of used IDs
        /// </summary>
        /// <param name="tmpClass"></param>
        private void removeElementFromTempCache(MagiElement tmpElement)
        {
            if(_listOfElements.Contains(tmpElement)){
                _listOfElements.Remove(tmpElement);
                _usedIDs.Remove(tmpElement.ElementID);
            }
        }


        /// <summary>
        /// Add Element to wrapper cache/list - Does not commit addition - Run saveCacheChanges() to do this
        /// </summary>
        /// <param name="tmpNewClass"></param>
        public void addElementToTempCache(MagiElement tmpNewElement)
        {
            int index = -1;
            foreach (MagiElement tmpElement in _listOfElements)
            {
                if (tmpElement.ElementID == tmpNewElement.ElementID)
                {
                    index = _listOfElements.IndexOf(tmpElement);
                }
            }

            if (index != -1)
            {
                _listOfElements[index] = tmpNewElement;
            }
            else
            {
                _listOfElements.Add(tmpNewElement);
            }
        }


        /// <summary>
        /// Gets the next available ID for a Element and reserves it(Use on the construction/clone of a Element)
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
