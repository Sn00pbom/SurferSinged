using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged.AI_Logic
{
    class ShopAI{

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
}
