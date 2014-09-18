using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedPractice.GameClasses;

namespace TurnBasedPractice.GameClasses
{
    public class CharacterClass
    {
        
        private int id;
        public int ClassID
        {
            get { return id; }
        }
        private string name;
        public string ClassName
        {
            get { return name; }
        }
        public readonly int constitutionBonus; //Used to derive HP
        public readonly int magiBonus; //Used to derive mana
        public readonly int dexterityBonus; //Used to determine effectness at evasion
        public readonly int strengthBonus; //Used to determine effectiveness at hitting
        public readonly int spiritBonus; //Used to determine effectiveness at hitting with magi
        public readonly int speedBonus; //Used to determine speed of turn recharge(AKA time between characters turn)

        public readonly List<int> magiElementsCanUse = new List<int>();
        public readonly Dictionary<int/*Ability ID*/, int/*Level Learned*/> abilitiesLearnedByLevel = new Dictionary<int/*Ability ID*/, int/*Level Learned*/>();

        /// <summary>
        /// Construct a CharacterClass
        /// </summary>
        /// <param name="tmpID"></param>
        /// <param name="tmpName"></param>
        /// <param name="tmpConBonus"></param>
        /// <param name="tmpMagBonus"></param>
        /// <param name="tmpDexBonus"></param>
        /// <param name="tmpStrBonus"></param>
        /// <param name="tmpSprBonus"></param>
        /// <param name="tmpSpeBonus"></param>
        /// <param name="tmpElements">List of element IDs that this class can use(Magi)</param>
        /// <param name="tmpAbilities">Dictionary of <Ability IDs, Level Learned></param>
        public CharacterClass(int tmpID, string tmpName, int tmpConBonus, int tmpMagBonus, int tmpDexBonus, int tmpStrBonus, int tmpSprBonus, int tmpSpdBonus, List<int> tmpElements, Dictionary<int,int> tmpAbilities)
        {
            this.id = tmpID;
            this.name = tmpName;
            this.constitutionBonus = tmpConBonus;
            this.magiBonus = tmpMagBonus;
            this.dexterityBonus = tmpDexBonus;
            this.strengthBonus = tmpStrBonus;
            this.spiritBonus = tmpSprBonus;
            this.speedBonus = tmpSpdBonus;
            this.magiElementsCanUse = tmpElements;
            this.abilitiesLearnedByLevel = tmpAbilities;
        }

        public CharacterClass Clone(int tmpID)
        {
            CharacterClass tmpNewClass = new CharacterClass(tmpID, this.name, this.constitutionBonus, this.magiBonus, this.dexterityBonus, this.strengthBonus, this.spiritBonus, this.speedBonus, this.magiElementsCanUse, this.abilitiesLearnedByLevel);

            return tmpNewClass;
        }
    }
}
