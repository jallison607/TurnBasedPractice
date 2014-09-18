using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurnBasedPractice.GameClasses
{
    public class MagiElement
    {
        private int id;
        private string name;
        public int ElementID
        {
            get { return id; }
        }
        public string ElementName
        {
            get { return name; }
        }

        public MagiElement(int tmpID, string tmpName)
        {
            this.id = tmpID;
            this.name = tmpName;
        }
    }
}
