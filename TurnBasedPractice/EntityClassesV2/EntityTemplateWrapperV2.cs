using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTools.Encryption;
using GameTools.Basic;
using TurnBasedPractice.ItemClasses;

namespace TurnBasedPractice.EntityClasses
{
    public class EntityTemplateWrapper
    {
        //Debug variable
        private bool debug = false;

        //Logs and things
        private string _ETPath = "data\\et.jsa";
        private string _ETLog = "data\\et.log";
        private string _ActivePath = "data\\crit.err";
        //Variables all instances of this use
        private string _key = "57-30-30-186-117-30-189-168-44-129-200-128-233-225-3-43-40-163-45-13-153-173-32-110-49-128-220-150-133-175-105-219-147-202-31-22-156-119-157-146-17-73-197-188-68-134-189-42-198-136-70-226-85-7-155-140-254-176-137-244-65-39-36-125-25-237-236-31-195-236-142-176-7-155-252-81-231-99-42-171-195-179-208-252-106-134-134-141-48-147-23-236-237-168-81-233-37-73-163-87-154-158-103-218-249-149-220-185-11-75-164-155-134-222-50-142-87-39-19-147-103-96-239-48-213-162-195-94-74-19-44-159-192-211-18-37-77-245-4-212-169-204-131-228-239-124-102-15-119-194-147-254-54-17-239-58-175-55-5-88-210-126-112-247-32-5-219-179-205-14-66-97-36-63-233-154-221-11-65-90-60-180-231-135-127-46-105-176-227-215-117-22-241-172-2-44-93-139-197-234-161-179-65-105-129-51-218-247-39-86-93-165-245-170-28-31-151-232-120-241-156-43-207-246-152-44-111-120-62-190-62-82-69-87-185-136-115-126-6-77-83-114-137-142-122-207-33-71-144-227-148-116-20-211-78-118";
        private List<EntityTemplate> _listOfEntities = new List<EntityTemplate>();
        private List<int> _usedIDs = new List<int>();
        private EncrypterDecrypter _EntityEncrypter;
        private BasicLogger bLogger;


        /// <summary>
        /// Creates the wrapper for the specified type. Current valid types are:
        /// 
        /// "Entity"
        /// "Player Entity"
        /// "Generated Entity"
        /// "Entity Template"
        /// 
        /// </summary>
        /// <param name="tmpType"></param>
        public EntityTemplateWrapper(string tmpType)
        {
            this._EntityEncrypter = new EncrypterDecrypter();
            this._EntityEncrypter.setKey(this._key);
            if (tmpType == "Entity Template")
            {

                this.bLogger = new BasicLogger(this._ETLog);
                this._ActivePath = this._ETPath;
                string encryptedEntities = this._EntityEncrypter.decryptFile(this._ETPath);
                if (encryptedEntities.Length > 0)
                {
                    int TotalEntries = ParseItems.parseIntFrom(encryptedEntities, 4);
                    encryptedEntities = encryptedEntities.Substring(4);
                    int i = 0;
                    while (i < TotalEntries)
                    {
                        int lengthOfEntity = ParseItems.parseIntFrom(encryptedEntities, 3);
                        encryptedEntities = encryptedEntities.Substring(3);
                        this.bLogger.Log("Attempting to decrypt: " + encryptedEntities.Substring(0, lengthOfEntity), debug);
                        EntityTemplate newEntity = new EntityTemplate(encryptedEntities.Substring(0, lengthOfEntity));
                        encryptedEntities = encryptedEntities.Substring(lengthOfEntity);
                        this._listOfEntities.Add(newEntity);
                        this._usedIDs.Add(newEntity.id);
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

        public void saveEntities()
        {
            string EString = ParseItems.convertToLength(this._listOfEntities.Count, 4);

            foreach (EntityTemplate tmpItem in _listOfEntities)
            {
                EString += tmpItem.ToEString();
            }

            this._EntityEncrypter.encryptToFile(EString, this._ActivePath);
        }

        //###Modify & Get of Items
        public List<EntityTemplate> getEntities()
        {
            return this._listOfEntities;
        }

        public bool AddEntity(EntityTemplate tmpNewEntity)
        {
            bool added = false;


            //Loops through all pre-exsisting Entities and adds if a matchis found
            for (int i = 0; i < this._listOfEntities.Count; i++)
            {
                if (this._listOfEntities[i].id == tmpNewEntity.id)
                {
                    this._listOfEntities[i] = tmpNewEntity;
                    added = true;
                }
            }


            //If no match is found then add new entry
            if (!added)
            {
                this._listOfEntities.Add(tmpNewEntity);
                if (!this._usedIDs.Contains(tmpNewEntity.id))
                {
                    this._usedIDs.Add(tmpNewEntity.id);
                }
                added = true;
            }
            

            return added;
        }

        public bool removeEntity(EntityTemplate tmpRemoveEntity)
        {
            bool removed = false;

            for (int i = 0; i < this._listOfEntities.Count; i++)
            {
                if (this._listOfEntities[i].id == tmpRemoveEntity.id)
                {
                    this._usedIDs.Remove(tmpRemoveEntity.id);
                    this._listOfEntities.RemoveAt(i);
                    removed = true;
                }
            }

            return removed;
        }

        public EntityTemplate getEntity(int tmpID)
        {

            foreach (EntityTemplate tmpEntity in this._listOfEntities)
            {
                if (tmpEntity.id == tmpID)
                {
                    return tmpEntity.Clone();
                }
            }

            return null;
        }

        /// <summary>
        /// This will return the next available ID and place a lock on the id returned(not to be returned again)
        /// </summary>
        /// <returns></returns>
        public int getNextID()
        {

            bool found = false;
            int i = 0;
            while (!found && i < 9999)
            {
                if(_usedIDs.Contains(i)){
                    i++;
                }else{
                    found = true;
                }
            }

            if (found)
            {
                this._usedIDs.Add(i);
            }
            return i;

        }

    }
}
