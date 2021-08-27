using System;
//using System.Collections.Generic;
//using System.Linq;

public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        int searchLowerLimit = 0;
        int searchUpperLimit = sortedArray.Length - 1;

        while ((searchUpperLimit - searchLowerLimit) > 1)
        {
            int mediumIndex = Convert.ToInt32(Math.Floor((searchUpperLimit - searchLowerLimit) / 2.0)) + searchLowerLimit;

            if (sortedArray[mediumIndex] < lessThan)
            {
                searchLowerLimit = mediumIndex;
            }
            else if (sortedArray[mediumIndex] > lessThan)
            {
                searchUpperLimit = mediumIndex;
            }
            else
            {
                searchLowerLimit = searchUpperLimit = mediumIndex;
                break;
            }
        }
        if (sortedArray[searchLowerLimit] >= lessThan)
        {
            return searchLowerLimit;
        }
        if (searchUpperLimit == 0)
        {
            return 1;
        }

        if (sortedArray[searchUpperLimit] >= lessThan)
        {
            return searchUpperLimit;
        }

        return searchUpperLimit + 1;
    }

    public static void TestSortedSearch(string[] args)
    {
        SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4);
        SortedSearch.CountNumbers(new int[] { 1 }, 4);
        SortedSearch.CountNumbers(new int[] { 1, 3 }, 4);
        SortedSearch.CountNumbers(new int[] { 1, 4 }, 4);
        SortedSearch.CountNumbers(new int[] { 5, 7 }, 4);
        SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7, 8, 9, 10, 11, 12, 13, 14 }, 4);
        SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7, 8, 9, 10, 11, 12, 13, 14 }, 11);
        SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7, 8, 9, 10, 11, 12, 13 }, 15);
        SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7, 8, 9, 10, 11, 12, 13, 14 }, 15);
        SortedSearch.CountNumbers(new int[] { 1, 3, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }, 15);
        SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 15);
    }
}
