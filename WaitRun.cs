using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged
{
    class WaitRun
    {
        /*
         * 
         * 
 __    __     ______     _____     ______        ______     __  __        ______     __   __     ______     ______     ______   ______     ______     __    __    
/\ "-./  \   /\  __ \   /\  __-.  /\  ___\      /\  == \   /\ \_\ \      /\  ___\   /\ "-.\ \   /\  __ \   /\  __ \   /\  == \ /\  == \   /\  __ \   /\ "-./  \   
\ \ \-./\ \  \ \  __ \  \ \ \/\ \ \ \  __\      \ \  __<   \ \____ \     \ \___  \  \ \ \-.  \  \ \ \/\ \  \ \ \/\ \  \ \  _-/ \ \  __<   \ \ \/\ \  \ \ \-./\ \  
 \ \_\ \ \_\  \ \_\ \_\  \ \____-  \ \_____\     \ \_____\  \/\_____\     \/\_____\  \ \_\\"\_\  \ \_____\  \ \_____\  \ \_\    \ \_____\  \ \_____\  \ \_\ \ \_\ 
  \/_/  \/_/   \/_/\/_/   \/____/   \/_____/      \/_____/   \/_____/      \/_____/   \/_/ \/_/   \/_____/   \/_____/   \/_/     \/_____/   \/_____/   \/_/  \/_/ 
                                                                                                                                                                  
         *****************************************************************
         * Usage:
         * yourList.Add(new WaitRun(() => yourMethod("yourParameter), 10, 400));
         * (runs method 10 seconds after execution time of 400 seconds)
         * ***************************************************************
         */
        public Boolean waiting = false;
        public Action methodName;
        public float elapsed = 0;
        public float waitSec = 1;
        public float startTime = 1;
        
        public WaitRun(Action mN, float wS, float sT)
        {
            methodName = mN;
            waitSec = wS;
            startTime = sT;
            waiting = true;

        }
        public void waitRun()
        {
                methodName();
            
        }
        public static void updateTick(List<WaitRun> wrl, float cTime) //cTime(Current Time)
        {
            for (int i = 0; i < wrl.Capacity; i++)
            {
                WaitRun wr = wrl[i];
                if (wr != null)
                {
                    if (wr.waiting == false)
                    {
                        wrl.Remove(wr);
                    }else
                    {
                        if(!(cTime < wr.startTime))
                        {
                            wr.elapsed = cTime - wr.startTime;
                            if (wr.elapsed >= wr.waitSec)
                            {
                                wr.waitRun();
                            }
                        }
                        
                        
                    }
                }
                else
                {
                    break;
                }
            }
        }
        

    }
}
