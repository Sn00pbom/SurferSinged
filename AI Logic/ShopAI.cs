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

        public static AIHeroClient Me = Player.Instance;
        public static AIHeroClient Target;
        private float gold = Me.Gold;
        public float getGold()
        {
            gold = Me.Gold;
            return gold;
        }
        public bool hasItem(ItemId item)//returns true/false if user has itemID in their inventory
        {
            if (Me.HasItem(item))
            {
                return true;
            }else
            {
                return false;
            }
        }
        public int numItem(ItemId item)//returns number of item in user inv
        {
            TargetSelector.GetTarget(700, DamageType.Physical);
            return 1;
        }
        public void nextItem()
        {
            
        }
        
    }

    class EvaluateTeams
    {
        //Pull 
    }
}
