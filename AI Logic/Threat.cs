using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged
{
    class Threat
    {
        public enum Level
        {
            MAXLOW,
            LOWEST,
            LOW,
            MEDIUM,
            HIGH,
            HIGHEST,
            MAXHIGH
        }
        public static AIHeroClient Me => Player.Instance;

        public static Level currentThreat = Level.HIGHEST; //initializing as highest, change this if you have another idea
        public static Level analyzeThreat()
        {
            int risingThreat;
            //Me.CountEnemiesInRange;
            return Level.HIGH;
        }
        public static List<AIHeroClient> getEnemiesInRange(uint range) //returns all enemies within range
        {
            List<AIHeroClient> list = new List<AIHeroClient>();
            foreach (AIHeroClient hero in EntityManager.Heroes.Enemies)
            {
                
                //double nrange = (double)range;
                SharpDX.Vector3 pvec = Me.ServerPosition; //player vector
                SharpDX.Vector3 evec = hero.Position; //enemy vector
                
                //compare vectors and use pythagorean theorum for distance.
                float xdiff = pvec.X - evec.X;
                float ydiff = pvec.Y - evec.Y;
                //double xsq = xdiff * xdiff;
                //double ysq = ydiff * ydiff;
                double hypot = Math.Sqrt((xdiff * xdiff) + (ydiff * ydiff));
                int hypot1 = (int)hypot;
                if(hypot1<= range)
                {
                    //Chat.Print("db");
                    list.Add(hero);
                }
                
            }
            return list;
        }
    }
}

