using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeCorner
{
    private static int currentPointer;
    private static int upperPointer;
    private static int lowerPointer;

    private static int lastPointer;

    public static int[] ProcessOnce(int[] input, int rowSize, out bool twoPointsInARow)
    {
        int[] result = new int[input.Length];

        SetBoundRowsToZero(ref result, rowSize);
        SetPointersInitialValue(input.Length, rowSize);
        twoPointsInARow = ProcessInternalCorners(input, ref result, rowSize);

        return result;
    }

    public static int[] AccumulateReductions(List<int[]> accumulativeData)
    {
        int dataLength = accumulativeData[0].Length;

        int[] result = new int[accumulativeData[0].Length];

        foreach (int[] entry in accumulativeData)
        {
            for (int i=0; i<dataLength; i++)
            {
                result[i] = result[i] + entry[i];
            }
        }

        return result;
    }

    public static void SetBoundRowsToZero(ref int[] input, int rowSize)
    {
        for (int i=0; i<rowSize; i++)
        {
            input[i] = 0;
            input[rowSize - 1 - i] = 0;
        }
    }

    private static void SetPointersInitialValue(int inputLength, int rowSize)
    {
        currentPointer = rowSize;
        upperPointer = 0;
        lowerPointer = rowSize + rowSize;

        lastPointer = inputLength - rowSize;
    }

    private static void AllPointersUp()
    {
        currentPointer++;
        upperPointer++;
        lowerPointer++;
    }

    public static bool ProcessInternalCorners(int[] dataInput, ref int[] resultOutput, int rowSize)
    {
        bool anyTwoPointsInARow = false;
        bool previousWasActive = false;

        int pointerModule = 0;
        while (currentPointer != lastPointer)
        {
            pointerModule = currentPointer % rowSize;
            if (pointerModule == 0)
            {
                previousWasActive = false;
                AllPointersUp();
                continue;
            }
            if (pointerModule == rowSize - 1)
            {
                previousWasActive = false;
                AllPointersUp();
                continue;
            }

            bool surroundingValuesAllNonZero =
                dataInput[currentPointer] > 0 &&
                dataInput[currentPointer - 1] > 0 &&
                dataInput[currentPointer + 1] > 0 &&

                dataInput[upperPointer] > 0 &&
                dataInput[upperPointer - 1] > 0 &&
                dataInput[upperPointer + 1] > 0 &&

                dataInput[lowerPointer] > 0 &&
                dataInput[lowerPointer - 1] > 0 &&
                dataInput[lowerPointer + 1] > 0;

            if (surroundingValuesAllNonZero)
            {
                resultOutput[currentPointer] = 1;

                if (!anyTwoPointsInARow && previousWasActive)
                {
                    anyTwoPointsInARow = true;
                }

                previousWasActive = true;
            }
            else
            {
                previousWasActive = false;
            }

            AllPointersUp();
        }

        return anyTwoPointsInARow;
    }

    public static int[] GetAccumulation(int[] inputData, int ImageSize, bool writeDataOut = false)
    {
        List<int> ResolutionsData = new List<int>();
        ResolutionsData.Add(HandleMaths.NonZeroInSet(inputData));

        int reductions = 1;
        bool process = true;
        List<int[]> accumulativeData = new List<int[]>();
        while (process && reductions < 10)
        {
            int[] newData = ProcessOnce(inputData, ImageSize, out process);

            if (writeDataOut)
            {
                string line = DataParsing.NumberSetToStringNormalize(newData, ImageSize);
                FileCreation.CreateTXT(line, "Naudr#" + reductions);
            }

            accumulativeData.Add(newData);
            ResolutionsData.Add(HandleMaths.NonZeroInSet(newData));

            inputData = newData;

            reductions++;
        }

        int[] accumulatedReductions = AccumulateReductions(accumulativeData);

        if (writeDataOut)
        {
            string finalData = DataParsing.NumberSetToString(accumulatedReductions, ImageSize);
            FileCreation.CreateTXT(finalData, "Naudr#SUM");

            string resolutionReport = "";
            int initialResolution = ResolutionsData[0];
            resolutionReport += "Initial resolution of " + initialResolution + "px (100%) \n";
            for (int i = 1; i < ResolutionsData.Count; i++)
            {
                int currentResolution = ResolutionsData[i];
                float resolutionPercentage = ((float)currentResolution / (float)initialResolution) * 100;
                resolutionReport += "Resolution reduction#" + i + " --- " + currentResolution + "px (" + resolutionPercentage + "%) \n";
            }
            FileCreation.CreateTXT(resolutionReport, "Naudr#RESOLUTION");
        }

        return accumulatedReductions;
    }
}
