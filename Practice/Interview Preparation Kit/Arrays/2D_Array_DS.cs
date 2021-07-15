using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum(List<List<int>> arr)
    {
        int hg = 0; int tmp = 0;
        for(int i = 1; i < 5; i++)
            for(int y = 1; y < 5; y++){
                tmp = SumHourGlass(i, y, arr);                
                hg = i == 1 && y == 1 ? tmp :
                    tmp > hg ? tmp : hg;
            }
        return hg;
    }
    public static int SumHourGlass(int i, int y, List<List<int>> arr){  
        return arr[i - 1][y - 1] + arr[i - 1][y] + arr[i - 1][y + 1] +                 
                                   arr[i][y] + 
               arr[i + 1][y - 1] + arr[i + 1][y] + arr[i + 1][y + 1];
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
