using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurnBasedPractice.EntityClasses;
using TurnBasedPractice.ItemClasses;
using System.Threading;

namespace TurnBasedPractice.GameClasses
{
    public class BattleV2
    {
        public Entity foe;
        public Dictionary<int, Entity> foes = new Dictionary<int, Entity>();
        private Dictionary<int, Entity> friends = new Dictionary<int, Entity>();
        private List<int> TurnOrder = new List<int>(); //List of InstanceIDs
        private int nextID = 0;
        private int turnID = 0; //Index of current ID
        public Entity friend;
        public bool playerTurn;
        public string dataOut;
        public object BatonPlayerTurn = new object();
        private bool hasFled = false;
        
        public BattleV2(Party playerParty, Party foeParty)
        {
            this.friend = playerParty.getActiveParty()[0];
            this.friend.setInstanceID(nextID);
            nextID++;
            //this.TurnOrder.Add(this.friend.getInstanceID());
            
            foreach (Entity tmpFoe in foeParty.getActiveParty())
            {
                tmpFoe.setInstanceID(nextID);
                //this.TurnOrder.Add(tmpFoe.getInstanceID());
                foes.Add(tmpFoe.getInstanceID(), tmpFoe);
                nextID++;
            }
            this.foe = foeParty.getActiveParty()[0];
            this.dataOut = "You, " + this.friend.name + ", have encountered a level " + this.foe.getLevel() + " " + this.foe.name + "\r\n";
            OrderParicipents();
        }

        private void OrderParicipents()
        {
            List<Entity> tmpList = new List<Entity>();
            foreach (KeyValuePair<int, Entity> tmp in foes)
            {
                tmpList.Add(tmp.Value);
            }
            tmpList.Add(friend);

            tmpList = tmpList.OrderBy(Entity=>Entity.getSpeed()).ToList();

            string test = string.Empty;
            foreach (Entity tmp in tmpList)
            {
                TurnOrder.Add(tmp.getInstanceID());
                test += tmp.name + " - " + tmp.getSpeed() + "\r\n";
            }

            MessageBox.Show(test);

            if (TurnOrder[0] == friend.getInstanceID())
            {
                this.playerTurn = true;
            }
            else
            {
                this.playerTurn = false;
            }
        }

        public int CurrentID()
        {
            return this.TurnOrder[turnID];
        }

        public void next()
        {
            if (turnID < this.TurnOrder.Count() -1)
            {
                turnID++;
            }
            else
            {
                turnID = 0;
            }

            if (TurnOrder[turnID] == friend.getInstanceID())
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }
        }

        public bool isStillOn()
        {
            bool keepFighting = false;
            bool foePartyAlive = false;
            bool friendPartyAlive = false;
            foreach (KeyValuePair<int, Entity> tmpFoe in this.foes)
            {
                if (tmpFoe.Value.isAlive())
                {
                    foePartyAlive = true;
                }
            }


            if (friend.isAlive())
            {
                friendPartyAlive = true;
            }


            if (foePartyAlive && friendPartyAlive && !this.hasFled)
            {
                keepFighting = true;
            }
            return keepFighting;
            /*
            if (!this.foe.isAlive())
            {
                keepFighting = false;
                this.dataOut = "Enemy " + this.foe.name + " has been defeated!\r\n";

            }
            else if (!this.friend.isAlive())
            {
                keepFighting = false;
                this.dataOut = "You have been defated!\r\n";
            }*/
        }

        public void attack(Entity target)
        {
            if (playerTurn)
            {
                int AttackScore = this.friend.basicAttackHit();
                int dodge = target.dodge();

                // MessageBox.Show("First: " + AttackScore + " Second:" + dodge);
                if (AttackScore > dodge)
                {
                    int damage = this.friend.basicAttackDamage();
                    target.takeDamage(damage);
                    this.dataOut = "You hit " + target.name + " for " + damage + " damage!\r\n";
                }
                else
                {
                    this.dataOut = "You Missed!\r\n";
                }
                //foe = target;

                foes[target.getInstanceID()] = target;

            }
            else
            {
                this.foe = foes[TurnOrder[turnID]];
                if (this.foe.isAlive())
                {
                    int AttackScore = this.foe.basicAttackHit();
                    int dodge = target.dodge();
                    if (AttackScore > dodge)
                    {
                        int damage = this.foe.basicAttackDamage();
                        target.takeDamage(damage);
                        this.dataOut = foe.name + " hit you for " + damage + " damage!\r\n";
                    }
                    else
                    {
                        this.dataOut = foe.name + " Missed!\r\n";
                    }
                    friend = target;
                }
                else
                {
                    this.dataOut = "";
                }
            }

        }

        public void AIGo()
        {
            //Thread.Sleep(200);
            attack(friend);
            this.next();

        }

        public bool attemptToFlee()
        {
            bool fled = false;

            if ((TurnBasedPractice.RandomInt.r.Next(0, 10) + (this.friend.getSpeed() * this.friend.getLevel())) > 
                (TurnBasedPractice.RandomInt.r.Next(0, 10) + (this.foe.getSpeed() * this.foe.getLevel()))
                ){
                fled = true;
            }
            this.next();

            return hasFled = fled;
        }

    }
}
