using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged.AI_Logic
{
    /* LIST OF SINGED ITEMS
     *
     * ITEM                       ID    DESCRIPTION
     * Refillable Potion..........2031..Starting item
     * The Dark Seal..............1082..Starting item
     * 
     * Corrupting Potion..........2033..Get on first back/execute at wave 3
     * Boots of Speed.............1001..Get after refill potion
     * Boots of Swiftness.........3009..
     * Mercury's Treads...........3111..Check enemy CC strength? otherwise just get swiftness boots 100%
     * 
     * Zz'Rot Portal..............3512..First or Second item
     * Rylai's Crystal Scepter....3116..First or Second item
     * 
     * Dead Man's Plate...........3742..Third item usually
     * Liandry's Torment..........3151..Third item IF allied team lacks AP
     * 
     * Banshee's Veil.............3102..Fourth or fifth item
     * Thornmail..................3075..Fourth or fifth item 
     * Frozen Heart...............3110..Fourth or fifth item
     */

    class ShopAI
    {
        /* Each game-item will have a corresponding list of all of sub-items. These lists will be called in a specific order, creating our build path.
         * A list will be called at the beginning of the game, and upon the completion of each item, it will call a method to evaluate what item to build next
         * 
         * A method will evaluate what item (build list) is needed, then this list will be sent to our purchaser
         * 
         * Create a 2D list buildPath which is full of itemPaths. This will be overwritten by the evaluate build method
         * 
         * PURCHASE LOGIC
         * 
         * private static shop(itemList, singedGold) { 
         *      if (goldAmount > itemList(0).cost) {
         *          BUY ITEM
         *      } else {
         *      PRINT "Singed needs + ITEMPRICE + more gold to buy + ITEM"
         *      }
         * }
         */

        public static AIHeroClient Me = Player.Instance;
        public static AIHeroClient Target;
        private float gold = Me.Gold;

        public float getGold()
        {
            gold = Me.Gold;
            return gold;
        }

        //public bool hasItem(ItemId item)//returns true/false if user has itemID in their inventory
        //{
        //    if (Me.HasItem(item))
        //    {
        //        return true;
        //    }else
        //    {
        //        return false;
        //    }
        //}

        //public int numItem(ItemId item) //returns number of item in user inv
        //{
        //    TargetSelector.GetTarget(700, DamageType.Physical);
        //    return 1;
        //}

        public void setActiveList() //The active list is a list of lists. The sub-lists will contain the componants of building a completed item. The active list will contain an entire full build, and will be modified under certain conditions
        {

        }

        public void buyItem(ItemId item) //Attempts to buy an item 
        {

        }


        
    }

}
