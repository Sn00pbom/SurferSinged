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
        public static void move()
        {
            //Player.Instance.ServerPosition.
            SharpDX.Vector3 vec = Player.Instance.ServerPosition;
            int shift = 100;
            SharpDX.Vector3 newvec = new SharpDX.Vector3(vec.X+shift, vec.Y+shift, vec.Z);
            Player.IssueOrder(GameObjectOrder.MoveTo, newvec);
            //Player.Instance.Position;
        }
    }
}
