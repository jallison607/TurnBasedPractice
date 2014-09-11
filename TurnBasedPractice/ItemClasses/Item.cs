using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;

namespace TurnBasedPractice.ItemClasses

{
    public abstract class Item
    {
        public int itemID;
        public string itemName;
        public int value;
        private bool canBuy;

        public Item(int tmpID, string tmpName, int tmpValue, bool tmpCanBuy){
            this.itemID = tmpID;
            this.itemName = tmpName;
            this.value = tmpValue;
            this.canBuy = tmpCanBuy;
        }

        public Item(string EString)
        {
            throw new NotImplementedException();
        }

        public abstract string ToEString();
        public abstract Item Clone(int tmpID);

    }
}
