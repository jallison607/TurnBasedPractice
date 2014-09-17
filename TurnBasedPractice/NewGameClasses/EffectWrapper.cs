using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;
using GameTools.Encryption;

namespace TurnBasedPractice.GameClasses
{
    public class EffectWrapper : WrapperAbstract
    {
        private string epath = "data\\eff.js1";
        private string elog = "data\\eff.log";
        private string _key = "57-30-30-186-117-30-189-168-44-129-200-128-233-225-3-43-40-163-45-13-153-173-32-110-49-128-220-150-133-175-105-219-147-202-31-22-156-119-157-146-17-73-197-188-68-134-189-42-198-136-70-226-85-7-155-140-254-176-137-244-65-39-36-125-25-237-236-31-195-236-142-176-7-155-252-81-231-99-42-171-195-179-208-252-106-134-134-141-48-147-23-236-237-168-81-233-37-73-163-87-154-158-103-218-249-149-220-185-11-75-164-155-134-222-50-142-87-39-19-147-103-96-239-48-213-162-195-94-74-19-44-159-192-211-18-37-77-245-4-212-169-204-131-228-239-124-102-15-119-194-147-254-54-17-239-58-175-55-5-88-210-126-112-247-32-5-219-179-205-14-66-97-36-63-233-154-221-11-65-90-60-180-231-135-127-46-105-176-227-215-117-22-241-172-2-44-93-139-197-234-161-179-65-105-129-51-218-247-39-86-93-165-245-170-28-31-151-232-120-241-156-43-207-246-152-44-111-120-62-190-62-82-69-87-185-136-115-126-6-77-83-114-137-142-122-207-33-71-144-227-148-116-20-211-78-118";
        private List<Effect> _listOfEffects = new List<Effect>();
        private List<int> _usedIDs = new List<int>();
        private EncrypterDecrypter _effectEncrypter;
        private BasicLogger bLogger;

        public EffectWrapper(int tmpint)
        {

        }

        /// <summary>
        /// Constructs the wrapper(Opens/decryptes the effect data file and starts the logger)
        /// </summary>
        public EffectWrapper()
        {
            bLogger = new BasicLogger(elog);
            _effectEncrypter = new EncrypterDecrypter(_key);
            string decryptedResults = _effectEncrypter.decryptFile(epath);
            int numOfEffects = 0;
            if (decryptedResults.Length > 0)
            {
                numOfEffects = ParseItems.parseIntFrom(decryptedResults, 4);
                decryptedResults = decryptedResults.Substring(4);
            }
            

            int i = 0;
            while (i < numOfEffects)
            {
                int length = ParseItems.parseIntFrom(decryptedResults, 3);
                decryptedResults = decryptedResults.Substring(3);
                string currentEffect = ParseItems.parseStringFrom(decryptedResults, length);
                _listOfEffects.Add(new Effect(currentEffect));
                _usedIDs.Add(_listOfEffects.Last().id);
                decryptedResults = decryptedResults.Substring(length);
                i++;
            }
        }

        override public void reload()
        {
            string decryptedResults = _effectEncrypter.decryptFile(epath);
            int numOfEffects = 0;
            if (decryptedResults.Length > 0)
            {
                numOfEffects = ParseItems.parseIntFrom(decryptedResults, 4);
                decryptedResults = decryptedResults.Substring(4);
            }

            this._listOfEffects.Clear();
            this._usedIDs.Clear();
            int i = 0;
            while (i < numOfEffects)
            {
                int length = ParseItems.parseIntFrom(decryptedResults, 3);
                decryptedResults = decryptedResults.Substring(3);
                string currentEffect = ParseItems.parseStringFrom(decryptedResults, length);
                _listOfEffects.Add(new Effect(currentEffect));
                _usedIDs.Add(_listOfEffects.Last().id);
                decryptedResults = decryptedResults.Substring(length);
                i++;
            }
        }

        override public void save()
        {
            string ToBeEncrypted = string.Empty;
            foreach (Effect tmpEffect in _listOfEffects)
            {
                ToBeEncrypted += tmpEffect.ToEString();
            }
            ToBeEncrypted = ParseItems.convertToLength(_listOfEffects.Count, 4) + ToBeEncrypted;
            _effectEncrypter.encryptToFile(ToBeEncrypted, this.epath);
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
