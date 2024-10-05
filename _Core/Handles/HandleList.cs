using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HandleList
{
    public static List<T> ReturnScrambled<T>(List<T> input)
    {
        List<T> newList = new List<T>();

        List<int> occupiedIndexes = new List<int>();
        int generatedNumber;
        while (occupiedIndexes.Count < input.Count)
        {
            generatedNumber = Random.Range(0, input.Count);
            if (!occupiedIndexes.Contains(generatedNumber))
            {
                occupiedIndexes.Add(generatedNumber);
                newList.Add(input[generatedNumber]);
            }
        }

        return newList;
    }

    public static T PullRandom<T>(List<T> from)
    {
        return from[Random.Range(0, from.Count)];
    }

    public static List<T> SubList<T>(List<T> target, int startElement)
    {
        List<T> result = new List<T>();
        int targetCount = target.Count;
        for (int i=startElement; i<targetCount; i++)
        {
            result.Add(target[i]);
        }
        return result;
    }
}
