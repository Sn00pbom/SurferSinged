using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferSinged
{
    class Sort
    {
        public static double[] bubbleSort(double[] unsortedArray)
        {
            int length = unsortedArray.Length;
            for(int i = 0; i< length - 1; i++)
            {
                for(int j = 0; j< length - 1 - i; j++)
                {
                    if (unsortedArray[j] > unsortedArray[j + i])
                    {
                        double num = unsortedArray[j];
                        unsortedArray[j] = unsortedArray[j + i];
                        unsortedArray[j + i] = num;
                    }
                }
            }
            return unsortedArray;
        }
        public static int[] bubbleSort(int[] unsortedArray)
        {
            int length = unsortedArray.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (unsortedArray[j] > unsortedArray[j + i])
                    {
                        int num = unsortedArray[j];
                        unsortedArray[j] = unsortedArray[j + i];
                        unsortedArray[j + i] = num;
                    }
                }
            }
            return unsortedArray;
        }
        public static float[] bubbleSort(float[] unsortedArray)
        {
            int length = unsortedArray.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (unsortedArray[j] > unsortedArray[j + i])
                    {
                        float num = unsortedArray[j];
                        unsortedArray[j] = unsortedArray[j + i];
                        unsortedArray[j + i] = num;
                    }
                }
            }
            return unsortedArray;
        }
    }
}
