using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedPractice.ItemClasses;

namespace TurnBasedPractice.EntityClasses
{
    public class Party
    {
        private List<Entity> _charactersInParty = new List<Entity>();
        private List<Entity> _activeParty = new List<Entity>();
        private int maxActive;
        private Dictionary<Item, int> inventory = new Dictionary<Item, int>();

        public Party(List<Entity> tmpPartyChars, int tmpMaxActive)
        {
            maxActive = tmpMaxActive;
            this._charactersInParty = tmpPartyChars;
            int i = 0;
            while (i < maxActive && i < this._charactersInParty.Count)
            {
                this._activeParty.Add(this._charactersInParty[i]);
                i++;
            }
        }

        //####Getters
        public List<Entity> getEntities()
        {
            return this._charactersInParty;
        }

        public Entity[] getActiveParty()
        {
            return this._activeParty.ToArray();
        }


        //####Party Function Methods
        public void changeParty(int[] selected)
        {
            if (selected.Count() <= this._activeParty.Count())
            {
                for (int i = 0; i < selected.Count(); i++)
                {
                    this._activeParty[i] = this._charactersInParty[selected[i]];
                }

                if (selected.Count() == 1)
                {
                    this._activeParty[1] = null;
                }
            }
            else
            {
                //Invalid entries
            }
        }

        public void useEquipItem(Item tmpItem, ref Entity tmpTarget)
        {
            bool used = false;
            
            foreach (KeyValuePair<Item, int> tmpEntry in this.inventory)
            {
                if (!used && tmpItem == tmpEntry.Key)
                {
                    if(tmpItem.GetType() == typeof(Weapon)){
                        if (tmpTarget.getEquipedWeapon() != null)
                        {
                            addItemToInventory(tmpTarget.getEquipedWeapon(), 1);
                            tmpTarget.unequipWeapon();
                            tmpTarget.equipWeapon((Weapon)tmpItem);
                        }
                    }
                    else if (tmpItem.GetType() == typeof(Potion))
                    {
                        tmpTarget.takeDamage(((Potion)tmpItem).healDamage());
                    }
                }
            }
        }

        public void addItemToInventory(Item tmpItem, int qty)
        {
            if(this.inventory.ContainsKey(tmpItem)){
                this.inventory[tmpItem] += qty;
            }else{
                this.inventory.Add(tmpItem, qty);
            }
        }

        public void removeItemToInventory(Item tmpItem, int qty)
        {
            if (this.inventory.ContainsKey(tmpItem))
            {
                if (this.inventory[tmpItem] > qty)
                {
                    this.inventory[tmpItem] =- qty;
                }
                else if (this.inventory[tmpItem] == qty)
                {
                    this.inventory.Remove(tmpItem);
                }
                
            }
        }

        public Dictionary<Item, int> getInventory()
        {
            return this.inventory;
        }

        public void addEntity(Entity newEnt)
        {
            _charactersInParty.Add(newEnt);
            if (_activeParty.Count < maxActive)
            {
                _activeParty.Add(newEnt);
            }
        }

        public void removeEntity(Entity oldEnt)
        {
            bool inActiveParty = false;
            foreach (Entity tmpEnt in _activeParty)
            {
                if (tmpEnt.id == oldEnt.id)
                {
                    inActiveParty = true;
                }
            }
            _charactersInParty.Remove(oldEnt);

            if (inActiveParty)
            {
                _activeParty.Remove(oldEnt);
            }

        }

        public void updateEntity(Entity tmpUpdatedEnt)
        {
            int index = -1;
            foreach (Entity tmpEnt in _charactersInParty)
            {
                if (tmpUpdatedEnt.id == tmpEnt.id)
                {
                    index = _charactersInParty.IndexOf(tmpEnt);
                }
            }
            if (index > -1)
            {
                _charactersInParty[index] = tmpUpdatedEnt;
                index = -1;
            }

            foreach (Entity tmpEnt in _activeParty)
            {
                if (tmpUpdatedEnt.id == tmpEnt.id)
                {
                    index = _charactersInParty.IndexOf(tmpEnt);
                }
            }

            if (index > -1)
            {
                _activeParty[index] = tmpUpdatedEnt;
            }


        }

    }
}
