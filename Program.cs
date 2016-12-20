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

    /* x so d so
     * 
     * 
     * 
     * TODO LIST:
     * debug and test automated spells, primarily fling
     * test summoner spells (ESPECIALLY TELE)
     * TEST AUTOLAUGH AND MASTERY FROM SingedSpell Class
     * 
     * Obj_AI_Minion
     * AIHeroClient
     * 
     */

    class Program
    {

        public static List<WaitRun> wrlist = new List<WaitRun>();
        
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
            SurferSingedMenu.createMenu();

            Chat.Print("<b><font size='40' color='#00FFFF'>Surfer</font><font size='80' color='#088A29'> Singed</font><font size='20' color='#FF8000'> Loaded</font></b>");



            Game.OnTick += OnTick;
            

            

        }
        private static void OnTick(EventArgs args)
        {
            //recall debug
            //if (SingedSpell.isRecalling())
            //{
            //    Chat.Print("Recalling...");
            //}
            

            if (Me.IsDead || SingedSpell.isRecalling()) return; //IGNORES REST OF CODE ON TICK WHEN DEAD OR RECALLING

            //Handles buffered Q casting without stalling thread
            SingedSpell.checkQTogglePending();
            SingedSpell.setPoisonStatus();


            WaitRun.updateTick(wrlist, Game.Time);

            List<AIHeroClient> enemiesinrange = Threat.getEnemiesInRange(10000);
            if(enemiesinrange != null)
            {
                for (int i = 0; i < enemiesinrange.Count; i++)
                {
                    Chat.Print(enemiesinrange[i].ChampionName);
                }
            }else
            {
                Chat.Print("db");//debug
            }
            


        }
        
        
    }
}
