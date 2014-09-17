using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTools.Encryption;
using GameTools.Basic;

namespace TurnBasedPractice.ItemClasses
{
    public class ItemWrapper
    {
        //Debug variable
        private bool debug = false;

        //Logs and things
        private string _WPath = "data\\w.jsa";
        private string _PPath = "data\\p.jsa";
        private string _WLog = "data\\w.log";
        private string _PLog = "data\\p.log";
        private string _ActivePath = "data\\crit.err";
        //Variables all instances of this use
        private string _key = "57-30-30-186-117-30-189-168-44-129-200-128-233-225-3-43-40-163-45-13-153-173-32-110-49-128-220-150-133-175-105-219-147-202-31-22-156-119-157-146-17-73-197-188-68-134-189-42-198-136-70-226-85-7-155-140-254-176-137-244-65-39-36-125-25-237-236-31-195-236-142-176-7-155-252-81-231-99-42-171-195-179-208-252-106-134-134-141-48-147-23-236-237-168-81-233-37-73-163-87-154-158-103-218-249-149-220-185-11-75-164-155-134-222-50-142-87-39-19-147-103-96-239-48-213-162-195-94-74-19-44-159-192-211-18-37-77-245-4-212-169-204-131-228-239-124-102-15-119-194-147-254-54-17-239-58-175-55-5-88-210-126-112-247-32-5-219-179-205-14-66-97-36-63-233-154-221-11-65-90-60-180-231-135-127-46-105-176-227-215-117-22-241-172-2-44-93-139-197-234-161-179-65-105-129-51-218-247-39-86-93-165-245-170-28-31-151-232-120-241-156-43-207-246-152-44-111-120-62-190-62-82-69-87-185-136-115-126-6-77-83-114-137-142-122-207-33-71-144-227-148-116-20-211-78-118";
        private List<Item> _listOfItems = new List<Item>();
        private List<int> _usedIDs = new List<int>();
        private EncrypterDecrypter _WeaponPotionEncrypter;
        private BasicLogger bLogger;

        public ItemWrapper(string tmpType)
        {
            this._WeaponPotionEncrypter = new EncrypterDecrypter();
            this._WeaponPotionEncrypter.setKey(this._key);
            if (tmpType == "Weapon")
            {
                this.bLogger = new BasicLogger(this._WLog);
                this._ActivePath = this._WPath;
                string encryptedWeapons = this._WeaponPotionEncrypter.decryptFile(this._WPath);
                if (encryptedWeapons.Length > 0)
                {
                    int TotalItems = ParseItems.parseIntFrom(encryptedWeapons, 4);
                    encryptedWeapons = encryptedWeapons.Substring(4);
                    int i = 0;
                    while (i < TotalItems)
                    {
                        int lengthOfWeapon = ParseItems.parseIntFrom(encryptedWeapons, 3);
                        encryptedWeapons = encryptedWeapons.Substring(3);
                        this.bLogger.Log("Attempting to decrypt: " + encryptedWeapons.Substring(0, lengthOfWeapon), debug);
                        Weapon newWeapon = new Weapon(encryptedWeapons.Substring(0, lengthOfWeapon));
                        encryptedWeapons = encryptedWeapons.Substring(lengthOfWeapon);
                        this._listOfItems.Add(newWeapon);
                        this._usedIDs.Add(newWeapon.itemID);
                        i++;
                    }
                }
            }
            else if (tmpType == "Potion")
            {
                this.bLogger = new BasicLogger(this._PLog);
                this._ActivePath = this._PPath;
                string encryptedPotions = this._WeaponPotionEncrypter.decryptFile(this._PPath);
                if (encryptedPotions.Length > 0)
                {
                    int TotalItems = ParseItems.parseIntFrom(encryptedPotions, 4);
                    encryptedPotions = encryptedPotions.Substring(4);
                    int i = 0;
                    while (i < TotalItems)
                    {
                        int lengthOfPotion = ParseItems.parseIntFrom(encryptedPotions, 3);
                        encryptedPotions = encryptedPotions.Substring(3);
                        Potion newPotion = new Potion(encryptedPotions.Substring(0, lengthOfPotion));
                        encryptedPotions = encryptedPotions.Substring(lengthOfPotion);
                        this._listOfItems.Add(newPotion);
                        this._usedIDs.Add(newPotion.itemID);
                        i++;
                    }
                }
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
            string EString = ParseItems.convertToLength(this._listOfItems.Count, 4);

            foreach (Item tmpItem in _listOfItems)
            {
                EString += tmpItem.ToEString();
            }

            this._WeaponPotionEncrypter.encryptToFile(EString, this._ActivePath);
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
