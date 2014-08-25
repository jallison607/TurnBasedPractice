using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;

namespace TurnBasedPractice.ItemClasses

{
    public abstract class Item
    {
        public readonly int itemID;
        public readonly string itemName;
        public readonly int value;

        public Item(int tmpID, string tmpName, int tmpValue){
            this.itemID = tmpID;
            this.itemName = tmpName;
            this.value = tmpValue;

        }

        public Item(string EString)
        {
            this.itemID = ParseItems.parseIntFrom(EString, 4);
            EString = EString.Substring(4);
            int nameLength = ParseItems.parseIntFrom(EString, 2);
            EString = EString.Substring(2);
            this.itemName = ParseItems.parseStringFrom(EString, nameLength);
            EString = EString.Substring(nameLength);
            this.value = ParseItems.parseIntFrom(EString, 4);
        }

        public abstract string ToEString();

    }
}
