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

        public static bool poisonActive = false;

        private static AIHeroClient Me => Player.Instance;

        public static void loadSpells()
        {
            //Initialize spell references and listeners
            Q = new Spell.Active(SpellSlot.Q);
            R = new Spell.Active(SpellSlot.R);
            S1 = new Spell.Active(SpellSlot.Summoner1);
            W = new Spell.SimpleSkillshot(SpellSlot.W);
            E = new Spell.Targeted(SpellSlot.E, 125); //125 is singed fling range
            S2 = new Spell.Targeted(SpellSlot.Summoner2, 1000000000); //Teleport: hopefully this range is large enough to be global Kappa

            
            //Spellbook.OnCastSpell += onCastSpell;
            //Q.OnSpellCasted += onCastSpellQ;
            W.OnSpellCasted += onCastSpellW;
            E.OnSpellCasted += onCastSpellE;
            R.OnSpellCasted += onCastSpellR;
            S1.OnSpellCasted += onCastSpellS1;
            S2.OnSpellCasted += onCastSpellS2;

            Player.OnBuffGain += onBuffAdd;
            Player.OnBuffLose += onBuffRemove;

        }
        public static void tryE()
        {
            //MUST BE RUN ON TICK TO GET TARGET
            var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);
            
            if (target != null && E.CanCast(target) == true && E.IsOnCooldown == false)
            {
                E.Cast();
            }
        }
        public static void checkQTogglePending() // ON TICK
        {
            if (SingedAttack.castingQ == true && Q.IsOnCooldown == false)
            {
                Q.Cast();
                SingedAttack.toggleQCasting();
            }
        }
        //private static void onCastSpell(Object sender, EventArgs args)
        //{
        //    //Spell Cast Listener
        //    Chat.Print("Spell Casted!");
        //    bm(true);

        //}
        private static void onBuffAdd(Object sender, EventArgs args)
        {
            if(Player.HasBuff("Poison Trail"))
            {
                poisonActive = true;
            }
        }
        private static void onBuffRemove(Object sender, EventArgs args)
        {
            if (!Player.HasBuff("Poison Trail"))
            {
                poisonActive = false;
            }
        }
        //private static void onCastSpellQ(Object sender, EventArgs args)
        //{
        //    //Q cast Listener
        //    // buff name: "Poison Trail"
        //    Chat.Print(SingedSpell.Q.Name + " casted!");
        //    bm(true);

        //}

        private static void onCastSpellW(Object sender, EventArgs args)
        {
            //W cast Listener
            Chat.Print(SingedSpell.W.Name + " casted!");
            bm(true);
            //crashGame();

        }
        private static void onCastSpellE(Object sender, EventArgs args)
        {
            //Q cast Listener
            Chat.Print(SingedSpell.E.Name + " casted!");
            bm(false);
            
            

        }
        private static void onCastSpellR(Object sender, EventArgs args)
        {
            //R cast Listener
            Chat.Print(SingedSpell.R.Name + " casted!");
            bm(true);

        }
        private static void onCastSpellS1(Object sender, EventArgs args)
        {
            //Summoner1 cast Listener
            Chat.Print(SingedSpell.S1.Name + " casted!");
            bm(true);

        }
        private static void onCastSpellS2(Object sender, EventArgs args)
        {
            //Summoner2 cast Listener
            Chat.Print(SingedSpell.S2.Name + " casted!");
            bm(true);

        }
        public static void setPoisonStatus()
        {
            if (Me.HasBuff("Poison Trail"))
            {
                SingedSpell.poisonActive = true;
            }
            else
            {
                SingedSpell.poisonActive = false;
            }
        }
        public static bool isRecalling()
        {
            //ALL BUFFS, POSITIVE, NEGATIVE, OR NEUTRAL COUNT AS BUFFS
            if (Me.HasBuff("Recall"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void bm(bool laugh)
        {
            if (laugh == true)
            {
                Program.wrlist.Add(new WaitRun(() => Player.DoEmote(Emote.Laugh),(float) 0.5,Game.Time));
            }
            
            //Program.wrlist.Add(new WaitRun(() => Player.DoMasteryBadge(), (float)1, Game.Time));
        }
        public static void crashGame()
        {
            
            Player.DoEmote(Emote.Laugh);
            

            Player.DoMasteryBadge();
        }
    }
}
