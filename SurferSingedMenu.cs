using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace SurferSinged
{
    class SurferSingedMenu
    {
        public static Menu MainMenu { get; private set; }

        public static void createMenu()
        {
            
            if (MainMenu != null)
            {
                return;
            }
            MainMenu = EloBuddy.SDK.Menu.MainMenu.AddMenu("Surfer Singed", "SurferSinged");

            MainMenu.Add("X", new Slider("X", 0, -1000, 1000));
            MainMenu.Add("Y", new Slider("Y", 0, -1000, 1000));
            MainMenu.Add("Z", new Slider("Z", 0, -1000, 1000));
        }
        
    }
}
