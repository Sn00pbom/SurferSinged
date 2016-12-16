using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged
{
    class LinearEquation
    {
        //Sn00pbom
        public enum LeftSide
        {
            X,
            Y
        };
        public enum Inequality
        {
            GREATERTHAN,
            LESSTHAN,
            EQUAL
        };
        public enum State
        {
            POSITIVE,
            NEGATIVE,
            ZERO,
            UNDEFINED 
        };

        private LeftSide lSide { set; get; }

        public State getMState(float x1, float y1, float x2, float y2)
        {
            float output = ((y2 - y1) / (x2 - x1));
            if((x2 - x1) == 0)
            {
                return State.UNDEFINED;
            }else if((y2 - y1) == 0)
            {
                return State.UNDEFINED;
            }else if(output < 0)
            {
                return State.NEGATIVE;
            }else if(output > 0)
            {
                return State.POSITIVE;
            }
            return State.ZERO;
        }
        public float getB(float x1, float y1, float x2, float y2)
        {
            return (y2 - (((x2 * y2) - (x2 * y1)) / (x2 - x1)));
        }
        public Inequality getLinearInequality(float x1, float y1, float x2, float y2, float newx, float newy)
        {

            float output;
            if (x1 == x2)
            {
                output =  x1;
                lSide = LeftSide.X;
                if(newx < output)
                {
                    return Inequality.LESSTHAN;
                }else if(newx == output)
                {
                    return Inequality.EQUAL;
                }else if(newx > output)
                {
                    return Inequality.GREATERTHAN;
                }
            }
            else if (y1 == y2)
            {
                output =  y1;
                lSide = LeftSide.Y;
                if (newy < output)
                {
                    return Inequality.LESSTHAN;
                }
                else if (newy == output)
                {
                    return Inequality.EQUAL;
                }
                else if (newy > output)
                {
                    return Inequality.GREATERTHAN;
                }
            }
            else
            {
                output =  (((y2 - y1) / (x2 - x1)) * newx) + (y2 - (((x2 * y2) - (x2 * y1)) / (x2 - x1)));
                lSide = LeftSide.Y;
                if (newy < output)
                {
                    return Inequality.LESSTHAN;
                }
                else if (newy == output)
                {
                    return Inequality.EQUAL;
                }
                else if (newy > output)
                {
                    return Inequality.GREATERTHAN;
                }
            }
            return Inequality.EQUAL;
        }
    }
}
