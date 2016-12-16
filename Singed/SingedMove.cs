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
        
        

        public static void moveChange(float changeX, float changeY) //Relative Movement
        {
            SharpDX.Vector3 vec = Me.ServerPosition;
            SharpDX.Vector3 newvec = new SharpDX.Vector3(vec.X+changeX, vec.Y+changeY, vec.Z);
            Player.IssueOrder(GameObjectOrder.MoveTo, newvec);
            
            
        }
        public static void moveTo(float newX, float newY) //Absolute Movement
        {
            SharpDX.Vector3 newvec = new SharpDX.Vector3(newX, newY, 0);
            Player.IssueOrder(GameObjectOrder.MoveTo, newvec);
        }
    }
}
