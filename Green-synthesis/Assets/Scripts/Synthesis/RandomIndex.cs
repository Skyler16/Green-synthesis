using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIndex
{
    public static int GetRandomIndex(int[] ranges, int[] weights)
    {
        int ret = 0;
        int weightSum = 0;
        int[] weightRange = new int[weights.Length];
        for (int i = 0; i < weights.Length; ++i)
        {
            weightSum += weights[i];
            weightRange[i] = weightSum;
        }

        int num = Random.Range(1, weightSum);

        for(int i=0; i<weights.Length; ++i)
        {
            if(num <= weightRange[i])
            {
                int rmin = 0, rmax = ranges[i];
                if (i > 0) rmin = ranges[i - 1];
                ret = Random.Range(rmin, rmax);
                break;
            }
        }
        return ret;
    }
}
