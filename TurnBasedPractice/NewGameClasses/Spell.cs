using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurnBasedPractice.GameClasses
{
    public class Spell
    {
        private int id;
        private string name;
        public string SpellName
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int SpellID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        private List<int> effects = new List<int>();
        private int magiCost;

        public Spell(int tmpID, string tmpName, int tmpMagiCost, List<int> tmpEffects)
        {
            this.id = tmpID;
            this.name = tmpName;
            this.effects = tmpEffects;
            this.magiCost = tmpMagiCost;
        }


        public string ToEString()
        {
            throw new NotImplementedException();
        }

        public int getMagiCost()
        {
            return magiCost;
        }

        public List<int> getEffects()
        {
            return this.effects;
        }

        public Spell Clone(int tmpID)
        {
            Spell tmpSpell = new Spell(tmpID, name, magiCost, effects);
            return tmpSpell;
        }
    }
}
