using System;

class Program
{
    static void Main()
    {
        string str1 = "ABCBDAB";
        string str2 = "BDCAB";

        Console.WriteLine("The Length of LCS is " + LCS(str1, str2, str1.Length, str2.Length));
        Console.WriteLine("The Length of LCS through DP is " + DynamicProgrammingLCS(str1, str2));
        Console.WriteLine("The Length of LCS through DP with space complexity is " + LCSDpComplexityOptimisation(str1, str2));
    }

    static int LCS(string str1, string str2, int length1, int length2)
    {
        if (length1 == 0 || length2 == 0)
        {
            return 0;
        }
        else if (str1[length1 - 1] == str2[length2 - 1])
        {
           return 1+LCS(str1, str2, length1-1, length2-1); 
        }
        else
        {
            return Math.Max(LCS(str1, str2, length1-1, length2),LCS(str1,str2,length1,length2-1));
        }
    }

            //    Simplified Algorithm Steps
            //   -----------------------------
            //Create a grid(2D array) with extra space for empty strings.
            //Fill the first row and column with zeros.
            //For each character in string X:
            //For each character in string Y:
            //If characters match: Add 1 to the value from the diagonal cell.
            //If characters don't match: Take the maximum of the left and top cells.
            //The final cell gives you the length of LCS
    static int DynamicProgrammingLCS(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;
        int[,] dp=new int[m+1,n+1];

       for(int i=0;i<=m;i++)
        {
            for(int j = 0; j <=n; j++)
            {
                if (i==0||j==0)//Fill the first row and column with zeros.
                {
                    dp[i,j] = 0;
                }
                else if (str1[i-1] == str2[j-1])//If characters match: Add 1 to the value from the diagonal cell.
                {
                    dp[i, j] = 1 + dp[i-1,j-1];
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i,j-1]);//If characters don't match: Take the maximum of the left and top cells.
                }
            }
        }
        return dp[m, n];
    }
            //TODO Variations of subsequence
        //1. LCS space complexity optimisation -use 2 1D array
        //2.Minimum insertions and deletions to convert s1 into s2, find the lcs and delete ones not in the other array
        //3.Length of super sequence of S1 and S2
        //4.Longest repeating subsequence-copy same array twice and for the matching condition add an & operator i!=j
        //5.Longest palindromic subsequence-reverse the string and copy into str2 and find the LCS
        static int LCSDpComplexityOptimisation(string str1,string str2) {
        // Swap strings if str2 is shorter than str1
        if (str1.Length < str2.Length)
        {
            var temp = str1;
            str1 = str2;
            str2 = temp; 
        }

        int m = str1.Length;
        int n = str2.Length;
        int[] arr1 = new int[m + 1];
        int[] arr2 = new int[m + 1];

        for (int i = 0; i <= m; i++)
        {
            for(int j=0;j <=n; j++)
            {
                if (i == 0 || j == 0)
                {
                    arr2[j] = 0;
                }

                else if (str1[i - 1] == str2[j - 1])
                {
                    arr2[j] = 1 + arr1[j - 1];
                }
                else
                {
                    arr2[j] = Math.Max(arr1[j], arr2[j - 1]);
                }
            }
            for (int k = 0; k <= n; k++)
            {
                arr1[k] = arr2[k];
            }

        }
        return arr2[n];
    }

}
