using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using GameTools.Basic;
using TurnBasedPractice.GameClasses;

namespace TurnBasedPractice.ItemClasses
{
    public class ItemWrapper : WrapperAbstract
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
                bLogger = new BasicLogger(_WLog);
            }
            else if (tmpType == "Potion")
            {
                bLogger = new BasicLogger(_PLog);
            }
            else
            {
                this.bLogger = new BasicLogger(this._ActivePath);
                bLogger.Log("ItemWrapper:ItemWrapper(Type): - Critical Error - Invalid ItemType");
                MessageBox.Show("Critical Error, please see crit.err");
                Environment.FailFast("Invalid Type");
            }
            reload();
        }

        override public void reload()
        {
            if (type == "Weapon")
            {
                OdbcCommand WeaponQuery = new OdbcCommand("select * from Weapon", dbConnection);
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                OdbcDataReader reader = WeaponQuery.ExecuteReader();
                while (reader.Read())
                {
                    int WeaponID = (int)reader[0];
                    string WeaponName = reader[1].ToString();
                    string tmpCanBuy = reader[2].ToString();
                    bool WeaponCanBuy;
                    if (tmpCanBuy == "False")
                    {
                        WeaponCanBuy = false;
                    }
                    else
                    {
                        WeaponCanBuy = true;
                    }
                    int WeaponValue = (int)reader[3];
                    int WeaponPower = (int)reader[4];
                    int WeaponMagiPower = (int)reader[5];
                    List<int> WeaponEffects = new List<int>();
                    List<int> WeaponClasses = new List<int>();

                    OdbcCommand WeaponEffectsQuery = new OdbcCommand("select EffectID from WeaponEffects where WeaponID = " + WeaponID, dbConnection);
                    OdbcDataReader WeaponEffectReader = WeaponEffectsQuery.ExecuteReader();

                    while (WeaponEffectReader.Read())
                    {
                        WeaponEffects.Add((int)WeaponEffectReader[0]);
                    }

                    OdbcCommand WeaponClassesQuery = new OdbcCommand("select ClassID from WeaponClasses where WeaponID = " + WeaponID, dbConnection);
                    OdbcDataReader WeaponClassesReader = WeaponClassesQuery.ExecuteReader();
                    while (WeaponClassesReader.Read())
                    {
                        WeaponClasses.Add((int)WeaponClassesReader[0]);
                    }

                    _listOfItems.Add(new Weapon(WeaponID, WeaponName, WeaponValue, WeaponPower, WeaponMagiPower, WeaponCanBuy, WeaponEffects, WeaponClasses));
                    _usedIDs.Add(WeaponID);
                }
                dbConnection.Close();

            }
            else if (type == "Potion")
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

        override public void saveCacheChanges()
        {
            if (type == "Weapon")
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                OdbcCommand WeaponClear = new OdbcCommand("delete from Weapon", dbConnection);
                OdbcCommand WeaponEffectsClear = new OdbcCommand("delete from WeaponEffects", dbConnection);
                OdbcCommand WeaponClassClear = new OdbcCommand("delete from WeaponClasses", dbConnection);
                WeaponClear.ExecuteNonQuery();
                WeaponEffectsClear.ExecuteNonQuery();
                WeaponClassClear.ExecuteNonQuery();
                foreach (Item tmpItem in _listOfItems)
                {
                    //public Weapon(int tmpID, string tmpName, int tmpValue, int tmpPower, int tmpAccuracy, bool tmpCanBuy, List<int> tmpMagicalEffects, List<int> tmpClassesCanUse)
                    Weapon tmpWeapon = (Weapon)tmpItem;
                    OdbcCommand WeaponInsert = new OdbcCommand("insert into Weapon(WeaponID, WeaponName, CanBuy, WeaponValue, WeaponPower) VALUES (" + tmpWeapon.ItemID + ",'" + tmpWeapon.ItemName + "'," + tmpWeapon.canBuy + ","+ tmpWeapon.value + ","+ tmpWeapon.getPower() + ")", dbConnection);
                    WeaponInsert.ExecuteNonQuery();
                    foreach (int tmpID in tmpWeapon.getMagicalEffects())
                    {
                        OdbcCommand WeaponEffectAdd = new OdbcCommand("insert into WeaponEffects(WeaponID, EffectID) VALUES (" + tmpWeapon.ItemID + "," + tmpID + ")", dbConnection);
                        WeaponEffectAdd.ExecuteNonQuery();
                    }

                    foreach (int tmpID in tmpWeapon.ValidClasses)
                    {
                        OdbcCommand WeaponEffectAdd = new OdbcCommand("insert into WeaponClasses(WeaponID, ClassID) VALUES (" + tmpWeapon.ItemID + "," + tmpID + ")", dbConnection);
                        WeaponEffectAdd.ExecuteNonQuery();
                    }
                }
                dbConnection.Close();
            }
            else if (type == "Potion")
            {

            }
        }

        public override int NextID()
        {
            int i = 0;
            bool found = false;
            while (!found)
            {
                if (_usedIDs.Contains(i))
                {
                    i++;
                }
                else
                {
                    found = true;
                    _usedIDs.Add(i);
                }
            }
            return i;
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
                if (this._listOfItems[i].ItemID == tmpNewItem.ItemID)
                {
                    this._listOfItems[i] = tmpNewItem;
                    added = true;
                }
            }

            if (!added)
            {
                this._listOfItems.Add(tmpNewItem);
                this._usedIDs.Add(tmpNewItem.ItemID);
                added = true;
            }

            return added;
        }

        public bool removeItem(Item tmpRemoveItem)
        {
            bool removed = false;

            for (int i = 0; i < this._listOfItems.Count; i++)
            {
                if (this._listOfItems[i].ItemID == tmpRemoveItem.ItemID)
                {
                    this._usedIDs.Remove(tmpRemoveItem.ItemID);
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
                if (tmpItem.ItemID == tmpID)
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
