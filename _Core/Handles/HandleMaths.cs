using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HandleMaths
{
    public static int GreatestSquared(int input)
    {
        int result = 1;

        int root = 1;
        int squareResult = 1;
        while (squareResult < input)
        {
            root++;
            squareResult = root * root;
            if (squareResult < input)
            {
                result = root;
            }
        }

        return result;
    }

    public static int DigitsIn(int input)
    {
        return input.ToString().Length;
    }

    public static int NonZeroInSet(int[] inputSet)
    {
        int nonZeroCount = 0;
        foreach(int entry in inputSet)
        {
            if (entry > 0)
            {
                nonZeroCount++;
            }
        }
        return nonZeroCount;
    }
}
