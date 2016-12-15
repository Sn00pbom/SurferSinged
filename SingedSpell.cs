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
        public static Spell.Active Q, R, S1;
        public static Spell.SimpleSkillshot W;
        public static Spell.Targeted E, S2;

        public static Boolean poisonActive = false;
        public static Boolean castingQ = false;
        
        

        public static void LoadSpells()
        {
            //Initialize spell references and listeners
            Q = new Spell.Active(SpellSlot.Q);
            R = new Spell.Active(SpellSlot.R);
            S1 = new Spell.Active(SpellSlot.Summoner1);
            Chat.Print(SpellSlot.W.GetType());
            //W = new Spell.Skillshot(SpellSlot.W);
            E = new Spell.Targeted(SpellSlot.E, 125); //125 is singed fling range
            S2 = new Spell.Targeted(SpellSlot.Summoner2, 1000000000); //Teleport: hopefully this range is large enough to be global Kappa

            Spellbook.OnCastSpell += OnCastSpell;
            Q.OnSpellCasted += OnCastSpellQ;
            //W.OnSpellCasted += OnCastSpellW;
            E.OnSpellCasted += OnCastSpellE;
            R.OnSpellCasted += OnCastSpellR;
            S1.OnSpellCasted += OnCastSpellS1;
            S2.OnSpellCasted += OnCastSpellS2;
        }
        public static void TryE()
        {
            //MUST BE RUN ON TICK TO GET TARGET
            var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);
            
            if (target != null && E.CanCast(target) == true && E.IsOnCooldown == false)
            {
                E.Cast();
            }
        }
        public static void ToggleQCasting()
        {
            
            if(castingQ == false)
            {
                castingQ = true;
            }else
            {
                castingQ = false;
            }

        }
        private static void OnCastSpell(Object sender, EventArgs args)
        {
            //Spell Cast Listener
            Chat.Print("Spell Casted!");

        }
        private static void OnCastSpellQ(Object sender, EventArgs args)
        {
            //Q cast Listener
            Chat.Print(SingedSpell.Q.Name + " casted!");
            bm(true);

        }
        private static void OnCastSpellW(Object sender, EventArgs args)
        {
            //W cast Listener
            Chat.Print(SingedSpell.W.Name + " casted!");
            bm(true);

        }
        private static void OnCastSpellE(Object sender, EventArgs args)
        {
            //Q cast Listener
            Chat.Print(SingedSpell.E.Name + " casted!");
            ToggleQCasting();
            bm(false);

        }
        private static void OnCastSpellR(Object sender, EventArgs args)
        {
            //R cast Listener
            Chat.Print(SingedSpell.R.Name + " casted!");
            bm(true);

        }
        private static void OnCastSpellS1(Object sender, EventArgs args)
        {
            //Summoner1 cast Listener
            Chat.Print(SingedSpell.S1.Name + " casted!");
            bm(true);

        }
        private static void OnCastSpellS2(Object sender, EventArgs args)
        {
            //Summoner2 cast Listener
            Chat.Print(SingedSpell.S2.Name + " casted!");
            bm(true);

        }
        public static void bm(Boolean laugh)
        {
            if(laugh == true)
            {
                Player.DoEmote(Emote.Laugh);
            }
            
            Player.DoMasteryBadge();
        }
    }
}
