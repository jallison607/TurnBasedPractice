using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurnBasedPractice.GameClasses
{
    public class ListedClassPreReq
    {
        private int id;
        private string text;
        private int level;
        public int PreReqID
        {
            get { return id; }
        }
        public string ListText
        {
            get { return text; }
        }
        public int PreReqLevel
        {
            get { return level; }
        }
        public ListedClassPreReq(int tmpID, string tmpText, int tmpLevel)
        {
            this.id = tmpID;
            this.text = tmpText;
            this.level = tmpLevel;
        }
    }
}
