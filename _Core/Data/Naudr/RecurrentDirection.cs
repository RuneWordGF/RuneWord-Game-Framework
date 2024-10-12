using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecurrentDirection
{
    public static int[] Process(int[] input, int minimumRecursion = 5)
    {
        int setSize = input.Length;
        int[] result = new int[setSize];

        int anchorIndex = 0;
        int currentAnchorCount = 0;

        bool recursionFound = false;
        for (int i=0; i<setSize; i++)
        {
            bool nonZero = input[i] > 0;

            if (currentAnchorCount == 0 && nonZero)
            {
                anchorIndex = i;
                currentAnchorCount++;
                continue;
            }

            if (!nonZero)
            {
                currentAnchorCount = 0;
                recursionFound = false;
            }
            if (!recursionFound && nonZero)
            {
                currentAnchorCount++;
                if (currentAnchorCount >= minimumRecursion)
                {
                    recursionFound = true;

                    for (int j=anchorIndex; j!=i; j++)
                    {
                        result[j] = 1;
                    }
                }
            }
            if (recursionFound)
            {
                result[i] = 1;
            }
        }

        return result;
    }
}
