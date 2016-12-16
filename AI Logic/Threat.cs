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
            LOWEST,
            LOW,
            MEDIUM,
            HIGH,
            HIGHEST
        }
        public static Level currentThreat = Level.HIGHEST; //initializing as highest, change this if you have another idea
        public static Level analyzeThreat()
        {
            return Level.HIGHEST;
        }
    }
}
