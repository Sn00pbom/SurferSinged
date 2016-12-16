using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged
{
    class Region
    {

        private float ax { get; set; }
        private float ay { get; set; }

        private float bx { get; set; }
        private float by { get; set; }

        private float cx { get; set; }
        private float cy { get; set; }

        private float dx { get; set; }
        private float dy { get; set; }

        public bool equals(Region bound)//comparing two bounds 
        {

            if (bound.ax == ax && bound.ay == ay && bound.bx == bx && bound.by == by && bound.cx == cx && bound.cy == cy && bound.dx == dx && bound.dy == dy)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public bool isHeroInside(AIHeroClient p)
        {
            SharpDX.Vector3 vec = p.ServerPosition;
            float vX = vec.X;
            float vY = vec.Y;
            LinearEquation le = new LinearEquation();
            bool w1 = false;
            bool w2 = false;
            bool w3 = false;
            bool w4 = false;

            /*
             * w1
             * <+
             * <-
             * w2
             * <-
             * >+
             * w3
             * >+
             * >-
             * w4
             * >-
             * <+
             */
            if ((le.getLinearInequality(ax, ay, bx, by, vX, vY) == LinearEquation.Inequality.LESSTHAN && le.getMState(ax, ay, bx, by) == LinearEquation.State.POSITIVE) ||
                (le.getLinearInequality(ax, ay, bx, by, vX, vY) == LinearEquation.Inequality.LESSTHAN && le.getMState(ax, ay, bx, by) == LinearEquation.State.NEGATIVE) ||
                (le.getLinearInequality(ax, ay, bx, by, vX, vY) == LinearEquation.Inequality.LESSTHAN && le.getMState(ax, ay, bx, by) == LinearEquation.State.ZERO) ||
                (le.getLinearInequality(ax, ay, bx, by, vX, vY) == LinearEquation.Inequality.EQUAL))
            {
                w1 = true;
            }
            else
            {
                return false;
            }


            if ((le.getLinearInequality(bx, by, cx, cy, vX, vY) == LinearEquation.Inequality.LESSTHAN && le.getMState(bx, by, cx, cy) == LinearEquation.State.NEGATIVE) ||
                (le.getLinearInequality(bx, by, cx, cy, vX, vY) == LinearEquation.Inequality.GREATERTHAN && le.getMState(bx, by, cx, cy) == LinearEquation.State.POSITIVE) ||
                (le.getLinearInequality(bx, by, cx, cy, vX, vY) == LinearEquation.Inequality.LESSTHAN && le.getMState(bx, by, cx, cy) == LinearEquation.State.UNDEFINED) ||
                (le.getLinearInequality(bx, by, cx, cy, vX, vY) == LinearEquation.Inequality.EQUAL))
            {
                w2 = true;
            }
            else
            {
                return false;
            }


            if ((le.getLinearInequality(cx, cy, dx, dy, vX, vY) == LinearEquation.Inequality.GREATERTHAN && le.getMState(cx, cy, dx, dy) == LinearEquation.State.POSITIVE) ||
                (le.getLinearInequality(cx, cy, dx, dy, vX, vY) == LinearEquation.Inequality.GREATERTHAN && le.getMState(cx, cy, dx, dy) == LinearEquation.State.NEGATIVE) ||
                (le.getLinearInequality(cx, cy, dx, dy, vX, vY) == LinearEquation.Inequality.GREATERTHAN && le.getMState(cx, cy, dx, dy) == LinearEquation.State.ZERO) ||
                (le.getLinearInequality(cx, cy, dx, dy, vX, vY) == LinearEquation.Inequality.EQUAL))
            {
                w3 = true;
            }
            else
            {
                return false;
            }


            if ((le.getLinearInequality(dx, dy, ax, ay, vX, vY) == LinearEquation.Inequality.GREATERTHAN && le.getMState(dx, dy, ax, ay) == LinearEquation.State.NEGATIVE) ||
                (le.getLinearInequality(dx, dy, ax, ay, vX, vY) == LinearEquation.Inequality.LESSTHAN && le.getMState(dx, dy, ax, ay) == LinearEquation.State.POSITIVE) ||
                (le.getLinearInequality(dx, dy, ax, ay, vX, vY) == LinearEquation.Inequality.GREATERTHAN && le.getMState(dx, dy, ax, ay) == LinearEquation.State.UNDEFINED) ||
                (le.getLinearInequality(dx, dy, ax, ay, vX, vY) == LinearEquation.Inequality.EQUAL))
            {
                w4 = true;
            }
            else
            {
                return false;
            }

            if (w1 == true && w2 == true && w3 == true && w4 == true)
            {
                return true;
            }
            return false;


        }

    }
}
