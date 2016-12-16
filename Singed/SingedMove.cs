using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged
{
    class SingedMove
    {
        private static AIHeroClient Me => Player.Instance;
        public static double x;
        public static double y;
        public static double z;
        void move()
        {
            SharpDX.Vector3 vec = Player.Instance.ServerPosition;
            Player.IssueOrder(GameObjectOrder.MoveTo, position);
            Player.Instance.Position;
        }
    }
}
