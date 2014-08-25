using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedPractice.EntityClasses;
using TurnBasedPractice.ItemClasses;

namespace TurnBasedPractice.GameClasses
{
    public class Battle
    {
        private List<int> foesInstanceIDs = new List<int>();
        private List<int> AllyInstanceIDs = new List<int>();
        public List<Entity> orderedParticipents = new List<Entity>();
        private Entity currentEntity;
        private Party playerParty;
        private Party foeParty;
        public string log;

        public Battle(Party tmpPlayerParty, Party tmpFoeParty)
        {
            int nextInstanceID = 0;
            foreach (Entity tmpEnt in tmpPlayerParty.getActiveParty())
            {
                tmpEnt.setInstanceID(nextInstanceID);
                AllyInstanceIDs.Add(tmpEnt.getInstanceID());
                nextInstanceID++;
                orderedParticipents.Add(tmpEnt);
            }
            
            foreach (Entity tmpEnt in tmpFoeParty.getActiveParty())
            {
                tmpEnt.setInstanceID(nextInstanceID);
                foesInstanceIDs.Add(tmpEnt.getInstanceID());
                nextInstanceID++;
                orderedParticipents.Add(tmpEnt);
            }

            this.playerParty = tmpPlayerParty;
            this.foeParty = tmpFoeParty;
            this.currentEntity = this.playerParty.getActiveParty()[0];
        }

        private void OrderList()
        {
            //Will have some sort of ordering on speed thing in here at some point but for now Player goes, then foeBoss then foe
        }

        private void PCGo()
        {
            int target = TurnBasedPractice.RandomInt.r.Next(0, AllyInstanceIDs.Count);
            foreach (Entity tmpTarget in this.playerParty.getActiveParty())
            {
                if (tmpTarget.id == target)
                {
                    this.currentEntity.basicAttackHit();
                    if (this.currentEntity.attackTry >= tmpTarget.dodge())
                    {
                        int damage = this.currentEntity.basicAttackDamage();
                        tmpTarget.takeDamage(damage);
                        this.log += "\r\n" + this.currentEntity.name + " hit " + tmpTarget.name + " for " + damage;
                        Next();

                    }
                    else
                    {
                        this.log += "\r\n" + this.currentEntity.name + " missed " + tmpTarget.name;
                    }
                    return;
                }
            }
        }

        public bool PCTurn()
        {
            bool isPCTurn = false;

            foreach (int tmpID in this.foesInstanceIDs)
            {
                if (tmpID == this.currentEntity.getInstanceID())
                {
                    isPCTurn = true;
                }
            }

            return isPCTurn;
        }

        public void Next()
        {
            bool next = false;

            foreach (Entity tmpEntity in orderedParticipents)
            {
                if (next)
                {
                    this.currentEntity = tmpEntity;
                    return;
                }else if (tmpEntity.getInstanceID() == currentEntity.getInstanceID())
                {
                    next = true;
                }
            }

        }

        public List<int> getFoeIDs()
        {
            return this.foesInstanceIDs;
        }

        public List<int> getAllyIDs()
        {
            return this.AllyInstanceIDs;
        }

        public Party getPlayerParty()
        {
            return this.playerParty;
        }

        public Party getFoeParty()
        {
            return this.foeParty;
        }

        public void useItemOn(int targetInstanceID, Item toUse)
        {

            //Focus on target
            int index = -1;
            int i = 0;
            foreach(Entity tmpEnt in orderedParticipents){
                if (tmpEnt.getInstanceID() == targetInstanceID)
                {
                    index = i;
                }
                i++;
            }

            //Use on Target
            if (toUse.GetType() == typeof(Potion))
            {
                Potion potToUse = (Potion)toUse;
                this.orderedParticipents[index].takeDamage(potToUse.healDamage());
            }
            else
            {
                //Not yet implemented
            }
        }

    }
}
