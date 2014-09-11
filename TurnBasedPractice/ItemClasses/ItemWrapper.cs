using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using GameTools.Basic;


namespace TurnBasedPractice.ItemClasses
{
    public class ItemWrapper
    {
        //Debug variable
        private bool debug = false;

        //Logs and things
        private string _WLog = "data\\w.log";
        private string _PLog = "data\\p.log";
        private string _ActivePath = "data\\crit.err";
        private string type;
        //Variables all instances of this use
        private List<Item> _listOfItems = new List<Item>();
        private List<int> _usedIDs = new List<int>();
        private BasicLogger bLogger;
        private string connectionString = @"Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=data\\GameEditor.mdb;Uid=Admin;Pwd=;";
        private OdbcConnection dbConnection = new OdbcConnection();

        public ItemWrapper(string tmpType)
        {
            type = tmpType;
            if (tmpType == "Weapon")
            {
                OdbcCommand effectQuery = new OdbcCommand("select * from Weapon", dbConnection);
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
            else if (tmpType == "Potion")
            {

            }
            else
            {
                this.bLogger = new BasicLogger(this._ActivePath);
                bLogger.Log("ItemWrapper:ItemWrapper(Type): - Critical Error - Invalid ItemType");
                MessageBox.Show("Critical Error, please see crit.err");
                Environment.FailFast("Invalid Type");
            }

        }

        public void saveItems()
        {
            if (type == "Weapon")
            {

            }
            else if (type == "Potion")
            {

            }
        }

        //###Modify & Get of Items
        public List<Item> getItems()
        {
            return this._listOfItems;
        }

        public bool AddItem(Item tmpNewItem)
        {
            bool added = false;

            for (int i = 0; i < this._listOfItems.Count; i++)
            {
                if (this._listOfItems[i].itemID == tmpNewItem.itemID)
                {
                    this._listOfItems[i] = tmpNewItem;
                    added = true;
                }
            }

            if (!added)
            {
                this._listOfItems.Add(tmpNewItem);
                this._usedIDs.Add(tmpNewItem.itemID);
                added = true;
            }

            return added;
        }

        public bool removeItem(Item tmpRemoveItem)
        {
            bool removed = false;

            for (int i = 0; i < this._listOfItems.Count; i++)
            {
                if (this._listOfItems[i].itemID == tmpRemoveItem.itemID)
                {
                    this._usedIDs.Remove(tmpRemoveItem.itemID);
                    this._listOfItems.RemoveAt(i);
                    removed = true;
                }
            }

            return removed;
        }

        public Item getItem(int tmpID)
        {
            Item returnItem;
            foreach (Item tmpItem in this._listOfItems)
            {
                if (tmpItem.itemID == tmpID)
                {
                    returnItem = tmpItem;
                    return returnItem;
                }
                
            }

            return null;
        }


        public int getNextID()
        {

            bool found = false;
            int i = 100;
            while (!found && i < 9999)
            {
                if(_usedIDs.Contains(i)){
                    i++;
                }else{
                    found = true;
                }
            }

            return i;

        }

    }
}
