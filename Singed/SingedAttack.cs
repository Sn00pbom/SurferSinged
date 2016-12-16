using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged
{
    class SingedAttack
    {
        private static AIHeroClient Me => Player.Instance;

        
        public static bool castingQ = false; // pending q cast

        public static void toggleQCasting() // sudo Q cast. Use when you would use Q.Cast();
        {
            if (castingQ == false)
            {
                castingQ = true;
            }
            else
            {
                castingQ = false;
            }
        }
        public static void aA(AIHeroClient p) // auto attack hero
        {
            Player.IssueOrder(GameObjectOrder.AttackUnit, p);
        }
        public static void aA(Obj_AI_Minion p) // overloaded auto attack minion
        {
            Player.IssueOrder(GameObjectOrder.AttackUnit, p);
        }
        
    }
}
