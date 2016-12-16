using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SurferSinged.Pathing
{
    class Bound
    {
        
        private float ax { get; set; }
        private float ay { get; set; }

        private float bx { get; set; }
        private float by { get; set; }

        private float cx { get; set; }
        private float cy { get; set; }

        private float dx { get; set; }
        private float dy { get; set; }

        public Boolean equals(Bound bound)
        {
            
            if (bound.ax == ax && bound.ay == ay && bound.bx == bx && bound.by == by && bound.cx == cx && bound.cy == cy && bound.dx == dx && bound.dy == dy)
            {
                return true;
            }else
            {
                return false;
                
            }
        }
        //public Boolean checkInside(AIHeroClient p)
        //{
        //    SharpDX.Vector3 vec = p.ServerPosition;
        //    float vX = vec.X;
        //    float vY = vec.Y;
            
        //}
        
    }
}
