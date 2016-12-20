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
    class CombatAI
    {
        public static void OnTick(EventArgs args)
        {
            flipNearestHeroInRange(true);
        }

        private static void flipNearestHeroInRange(bool gooflip)
        {
            List<AIHeroClient> enemiesInRange = Threat.getEnemiesInRange(125);
            if (enemiesInRange != null)
            {
                AIHeroClient target = TargetSelector.GetTarget(SingedSpell.E.Range, EloBuddy.DamageType.Magical);
                if (Extensions.IsValidTarget(target, SingedSpell.E.Range))
                {
                    if(SingedSpell.E.IsOnCooldown == false)
                    {
                        if (SingedSpell.W.IsOnCooldown == false && gooflip == true)
                        {
                            //gooflip
                            SharpDX.Vector3 evec = target.Position;
                            SharpDX.Vector3 pvec = Player.Instance.Position;
                            
                            float deltaX = (evec.X - pvec.X);
                            float deltaY = (evec.Y - pvec.Y);
                            float P = -1 * ((425 * deltaX) / 125);
                            float F = -1 * ((425 * deltaY) / 125);
                            SharpDX.Vector3 goovec = new SharpDX.Vector3(pvec.X + P, pvec.Y + F, pvec.Z);
                            SingedSpell.W.Cast(goovec);
                            Program.wrlist.Add(new WaitRun(() => SingedSpell.E.Cast(target),(float) 0.20, Game.Time));
                        }
                        else
                        {
                            //flip
                            SingedSpell.E.Cast(target);
                        }
                    }
                    
                }
                
            }
        }
    }
}
