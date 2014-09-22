using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurnBasedPractice.GameClasses
{
    public class ListedAbility
    {
        private int id;
        private string text;
        private int level;
        public int AbilityID
        {
            get { return id; }
        }
        public string ListText
        {
            get { return text; }
        }
        public int LevelLearned
        {
            get { return level; }
        }
        public ListedAbility(int tmpID, string tmpText, int tmpLevel)
        {
            this.id = tmpID;
            this.text = tmpText;
            this.level = tmpLevel;
        }
    }
}
