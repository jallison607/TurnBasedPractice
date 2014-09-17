using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTools.Basic;

namespace TurnBasedPractice.ItemClasses

{
    public abstract class Item
    {
        private int itemID;
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        private string itemName;
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        
        public int value;
        public bool canBuy;

        public Item(int tmpID, string tmpName, int tmpValue, bool tmpCanBuy){
            this.ItemID = tmpID;
            this.ItemName = tmpName;
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
