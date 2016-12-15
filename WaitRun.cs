using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged
{
    class WaitRun
    {
        public static Boolean waiting = false;
        public static String methodName = "nullMethod";
        public static float waitSec = 1;
        public static float startTime = 1;
        public WaitRun()
        {
            Chat.Print("db");
            //null creation
        }
        public WaitRun(String mN, float wS, float sT)
        {
            methodName = mN;
            waitSec = wS;
            

        }
        public static void waitRun(Action methodName, float waitSec, float startTime) //Requires method to run and wait time (in seconds)
        {
            if (Game.Time >= startTime + waitSec)
            {
                methodName();
            }
            // Usage:
            // waitRun(() => Method1("MyParameter"), 10, Game.Time); runs Method1 after 10 seconds from execution
        }

    }
}
