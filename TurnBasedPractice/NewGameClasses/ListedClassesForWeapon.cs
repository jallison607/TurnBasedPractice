using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurnBasedPractice.GameClasses
{
    class ListedClassesForWeapon
    {
        private int id;
        private string name;
        private bool allowed;
        public int ClassID
        {
            get { return id; }
        }
        public string ClassName
        {
            get { return name; }
        }
        public bool IsPermited
        {
            get { return allowed; }
            set { allowed = value; }
        }

        public ListedClassesForWeapon(int tmpID, string tmpName, bool tmpAllowed)
        {
            this.id = tmpID;
            this.name = tmpName;
            this.allowed = tmpAllowed;
        }
    }
}
