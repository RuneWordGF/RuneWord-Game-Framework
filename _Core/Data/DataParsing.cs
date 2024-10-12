using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataParsing
{
    public static int[] SingleDigitsStringToSet(string input)
    {
        List<int> result = new List<int>();
        foreach (char entry in input)
        {
            if (int.TryParse(entry + "", out int digit))
            {
                result.Add(digit);
            }
        }
        return result.ToArray();
    }

    public static string NumberSetToStringNormalize(int[] input, int newLineCount)
    {
        int totalSize = newLineCount * newLineCount;
        string line = "";
        for (int i = 0; i < totalSize; i++)
        {
            line += input[i] > 0 ? 1 : 0;
            if (i % newLineCount == newLineCount - 1)
            {
                line += "\n";
            }
        }

        return line;
    }

    public static string NumberSetToStringChars(int[] input, int newLineCount, char charOnData, char charOnZero)
    {
        int totalSize = newLineCount * newLineCount;
        string line = "";
        for (int i = 0; i < totalSize; i++)
        {
            line += input[i] > 0 ? charOnData : charOnZero;
            if (i % newLineCount == newLineCount - 1)
            {
                line += "\n";
            }
        }

        return line;
    }

    public static string NumberSetToString(int[] input, int newLineCount)
    {
        int totalSize = newLineCount * newLineCount;
        string line = "";
        for (int i = 0; i < totalSize; i++)
        {
            line += input[i];
            if (i % newLineCount == newLineCount - 1)
            {
                line += "\n";
            }
        }

        return line;
    }

    public static int[] Transpose(int[] input, int rowSize)
    {
        int[] output = new int[input.Length];
        for (int i=0; i<rowSize; i++)
        {
            for (int j=0; j<rowSize; j++)
            {
                output[i + j * rowSize] = input[j + i * rowSize];
            }
        }
        return output;
    }
}
