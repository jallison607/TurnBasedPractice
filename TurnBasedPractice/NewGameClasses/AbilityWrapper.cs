using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;
using GameTools.Encryption;

namespace TurnBasedPractice.GameClasses
{
    public class AbilityWrapper : WrapperAbstract
    {
        private string apath = "data\\abi.js1";
        private string alog = "data\\abi.log";
        private string _key = "57-30-30-186-117-30-189-168-44-129-200-128-233-225-3-43-40-163-45-13-153-173-32-110-49-128-220-150-133-175-105-219-147-202-31-22-156-119-157-146-17-73-197-188-68-134-189-42-198-136-70-226-85-7-155-140-254-176-137-244-65-39-36-125-25-237-236-31-195-236-142-176-7-155-252-81-231-99-42-171-195-179-208-252-106-134-134-141-48-147-23-236-237-168-81-233-37-73-163-87-154-158-103-218-249-149-220-185-11-75-164-155-134-222-50-142-87-39-19-147-103-96-239-48-213-162-195-94-74-19-44-159-192-211-18-37-77-245-4-212-169-204-131-228-239-124-102-15-119-194-147-254-54-17-239-58-175-55-5-88-210-126-112-247-32-5-219-179-205-14-66-97-36-63-233-154-221-11-65-90-60-180-231-135-127-46-105-176-227-215-117-22-241-172-2-44-93-139-197-234-161-179-65-105-129-51-218-247-39-86-93-165-245-170-28-31-151-232-120-241-156-43-207-246-152-44-111-120-62-190-62-82-69-87-185-136-115-126-6-77-83-114-137-142-122-207-33-71-144-227-148-116-20-211-78-118";
        private List<Ability> _listOfAbilities = new List<Ability>();
        private List<int> _usedIDs = new List<int>();
        private EncrypterDecrypter _abilityEncrypter;
        private BasicLogger bLogger;

        public AbilityWrapper(int tmpint)
        {

        }

        public AbilityWrapper()
        {
            bLogger = new BasicLogger(alog);
            _abilityEncrypter = new EncrypterDecrypter(_key);
            string decryptedResults = _abilityEncrypter.decryptFile(apath);
            int numOfAbilities = 0;
            if (decryptedResults.Length > 0)
            {
                numOfAbilities = ParseItems.parseIntFrom(decryptedResults, 4);
                decryptedResults = decryptedResults.Substring(4);
            }


            int i = 0;
            while (i < numOfAbilities)
            {
                int length = ParseItems.parseIntFrom(decryptedResults, 3);
                decryptedResults = decryptedResults.Substring(3);
                string currentAbility = ParseItems.parseStringFrom(decryptedResults, length);
                _listOfAbilities.Add(new Ability(currentAbility));
                _usedIDs.Add(_listOfAbilities.Last().id);
                decryptedResults = decryptedResults.Substring(length);
                i++;
            }
        }

        /// <summary>
        /// Reloads the list of Abilities - Note it clears the cache of requested IDs as well
        /// </summary>
        override public void reload()
        {
            string decryptedResults = _abilityEncrypter.decryptFile(apath);
            int numOfEffects = 0;
            if (decryptedResults.Length > 0)
            {
                numOfEffects = ParseItems.parseIntFrom(decryptedResults, 4);
                decryptedResults = decryptedResults.Substring(4);
            }

            this._listOfAbilities.Clear();
            this._usedIDs.Clear();
            int i = 0;
            while (i < numOfEffects)
            {
                int length = ParseItems.parseIntFrom(decryptedResults, 3);
                decryptedResults = decryptedResults.Substring(3);
                string currentAbility = ParseItems.parseStringFrom(decryptedResults, length);
                _listOfAbilities.Add(new Ability(currentAbility));
                _usedIDs.Add(_listOfAbilities.Last().id);
                decryptedResults = decryptedResults.Substring(length);
                i++;
            }
        }

        override public void save()
        {
            string ToBeEncrypted = string.Empty;
            foreach (Ability tmpAbility in _listOfAbilities)
            {
                ToBeEncrypted += tmpAbility.ToEString();
            }
            ToBeEncrypted = ParseItems.convertToLength(_listOfAbilities.Count, 4) + ToBeEncrypted;
            _abilityEncrypter.encryptToFile(ToBeEncrypted, this.apath);
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
        /// Removes specified Ability
        /// </summary>
        /// <param name="tmpToRemoveAbility"></param>
        public void removeAbility(Ability tmpToRemoveAbility)
        {
            if (this._listOfAbilities.Contains(tmpToRemoveAbility))
            {
                _listOfAbilities.Remove(tmpToRemoveAbility);
            }
        }

        /// <summary>
        /// Adds an Ability to the wrapper list
        /// </summary>
        /// <param name="tmpNewAbility"></param>
        public void addAbility(Ability tmpNewAbility)
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
        /// Gets the next available ID for an ability and reserves it(Use on the construction/clone of an effect)
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
