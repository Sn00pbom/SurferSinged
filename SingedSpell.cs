using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged
{


    class SingedSpell
    {
        // S1 summoner 1 will always be ghost
        // S2 summoner 2 will always be teleport
        private static Spell.Active Q, R, S1;
        private static Spell.SimpleSkillshot W;
        private static Spell.Targeted E, S2;

        private Boolean poisonOn = false;

        

        public static void LoadSpells()
        {
            Q = new Spell.Active(SpellSlot.Q);
            R = new Spell.Active(SpellSlot.R);
            S1 = new Spell.Active(SpellSlot.Summoner1);
            W = new Spell.SimpleSkillshot(SpellSlot.W);
            E = new Spell.Targeted(SpellSlot.E, 125); //125 is singed fling range
            S2 = new Spell.Targeted(SpellSlot.Summoner2, 1000000000); //Teleport: hopefully this range is large enough to be global Kappa

        }
        public static void TryE()
        {
            //MUST BE RUN ON TICK TO GET TARGET
            var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);
            if (target != null && E.CanCast(target) == true)
            {
                E.Cast();
            }
        }
        public static void ToggleQ()
        {
            while (Q.IsOnCooldown)
            {
                //INFINITE LOOP to wait for GARENteed Q toggle
            }
            Q.Cast();

        }
        public static void bm()
        {
            
            Player.DoEmote(Emote.Laugh);
            Player.DoMasteryBadge();
        }
    }
}
