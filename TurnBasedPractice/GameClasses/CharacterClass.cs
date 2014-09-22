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
        public readonly int constitutionBonus = 0; //Used to derive HP
        public readonly int magiBonus = 0; //Used to derive mana
        public readonly int dexterityBonus = 0; //Used to determine effectness at evasion
        public readonly int strengthBonus = 0; //Used to determine effectiveness at hitting
        public readonly int spiritBonus = 0; //Used to determine effectiveness at hitting with magi
        public readonly int speedBonus = 0; //Used to determine speed of turn recharge(AKA time between characters turn)

        public readonly int constitutionPrereq = 0; 
        public readonly int magiPrereq = 0; 
        public readonly int dexterityPrereq = 0;
        public readonly int strengthPrereq = 0; 
        public readonly int spiritPrereq = 0; 
        public readonly int speedPrereq = 0; 

        public readonly Dictionary<int,int> preReqClasses = new Dictionary<int,int>();
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
        public CharacterClass(int tmpID, string tmpName, Dictionary<string, int> tmpStats, List<int> tmpElements, Dictionary<int,int> tmpAbilities, Dictionary<string, int> tmpPreReqStats, Dictionary<int,int> tmpPreReqClasses)
        {
            this.id = tmpID;
            this.name = tmpName;
            this.magiElementsCanUse = tmpElements;
            this.abilitiesLearnedByLevel = tmpAbilities;

            //Stats Stuff
            if (tmpStats.ContainsKey("Con"))
            {
                this.constitutionBonus = tmpStats["Con"];
            }

            if (tmpStats.ContainsKey("Mag"))
            {
                this.magiBonus = tmpStats["Mag"];
            }

            if (tmpStats.ContainsKey("Dex"))
            {
                this.dexterityBonus = tmpStats["Dex"];
            }

            if (tmpStats.ContainsKey("Str"))
            {
                this.strengthBonus = tmpStats["Str"];
            }

            if (tmpStats.ContainsKey("Spr"))
            {
                this.spiritBonus = tmpStats["Spr"];
            }

            if (tmpStats.ContainsKey("Spd"))
            {
                this.speedBonus = tmpStats["Spd"];
            }

            //PreReq Stuff
            if (tmpPreReqStats.ContainsKey("Con"))
            {
                this.constitutionPrereq = tmpPreReqStats["Con"];
            }
            
            if (tmpPreReqStats.ContainsKey("Mag"))
            {
                this.magiPrereq = tmpPreReqStats["Mag"];
            }
            
            if (tmpPreReqStats.ContainsKey("Dex"))
            {
                this.dexterityPrereq = tmpPreReqStats["Dex"];
            }
            
            if (tmpPreReqStats.ContainsKey("Str"))
            {
                this.strengthPrereq = tmpPreReqStats["Str"];
            }
            
            if (tmpPreReqStats.ContainsKey("Spr"))
            {
                this.spiritPrereq = tmpPreReqStats["Spr"];
            }

            if (tmpPreReqStats.ContainsKey("Spd"))
            {
                this.speedPrereq = tmpPreReqStats["Spd"];
            }

            this.preReqClasses = tmpPreReqClasses;

        }

        private Dictionary<string, int> preReqStatsToDictionary()
        {
            Dictionary<string, int> tmpStats = new Dictionary<string, int>();
            tmpStats.Add("Con", constitutionPrereq);
            tmpStats.Add("Mag", magiPrereq);
            tmpStats.Add("Dex", dexterityPrereq);
            tmpStats.Add("Str", strengthPrereq);
            tmpStats.Add("Spr", spiritPrereq);
            tmpStats.Add("Spd", speedPrereq);

            return tmpStats;
        }

        private Dictionary<string, int> statsToDictionary()
        {
            Dictionary<string, int> tmpStats = new Dictionary<string, int>();
            tmpStats.Add("Con", constitutionBonus);
            tmpStats.Add("Mag", magiBonus);
            tmpStats.Add("Dex", dexterityBonus);
            tmpStats.Add("Str", strengthBonus);
            tmpStats.Add("Spr", spiritBonus);
            tmpStats.Add("Spd", speedBonus);

            return tmpStats;
        }

        public CharacterClass Clone(int tmpID)
        {
            CharacterClass tmpNewClass = new CharacterClass(tmpID, this.name, statsToDictionary(), this.magiElementsCanUse, this.abilitiesLearnedByLevel, preReqStatsToDictionary(), preReqClasses);

            return tmpNewClass;
        }
    }
}
