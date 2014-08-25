using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;

namespace TurnBasedPractice.EntityClasses
{
    public abstract class EntityAbstract
    {
        public readonly int id;
        public readonly string name;


        public EntityAbstract(string EString)
        {
            this.id = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);

            int nameLength = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);

            this.name = ParseItems.parseStringFrom(EString, nameLength);
            EString = EString.Substring(nameLength);
        }

        public EntityAbstract(int tmpID, string tmpName)
        {
            this.id = tmpID;
            this.name = tmpName;
        }

        public abstract EntityAbstract Clone();
        public abstract string ToEString();
    }
}
