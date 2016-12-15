using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace SurferSinged
{

    /*
     * 
     * 
     * 
     * TODO LIST:
     * debug and test automated spells, primarily fling
     * test summoner spells (ESPECIALLY TELE)
     * TEST AUTOLAUGH AND MASTERY FROM SingedSpell Class
     * 
     */

    class Program
    {


        private static AIHeroClient Me => Player.Instance;
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //asdf
            if (!Me.ChampionName.Equals("Singed")) return; //nullifies plugin if champion not singed

            SingedSpell.loadSpells();
            

            Chat.Print("African Singed Loaded!");


            Game.OnTick += OnTick;

            

        }
        private static void OnTick(EventArgs args)
        {
            //recall debug
            if (SingedSpell.isRecalling())
            {
                Chat.Print("Recalling...");
            }


            if (Me.IsDead || SingedSpell.isRecalling()) return; //IGNORES REST OF CODE ON TICK WHEN DEAD OR RECALLING

            //Handles buffered Q casting without stalling thread
            SingedSpell.checkQTogglePending();
            SingedSpell.setPoisonStatus();

            
            

        }
        
        
    }
}
