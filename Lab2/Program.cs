using System;
using System.IO;
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("D:/Users/Denta/Desktop/Lab2/input.txt");
            string[] tokens = lines[0].Split();
            int n = int.Parse(tokens[0]);
            int k = int.Parse(tokens[1]);
            int[,] a = new int[n + 2, n + 2];
            int[,,] dp = new int[n + 2, n + 2, k + 2];
            for (int i = 0; i < n; ++i)
            {
                string str = lines[i + 1];
                for (int j = 0; j < n; ++j)
                {
                    if (str[j] == '0')
                    {
                        a[i + 1, j + 1] = 0;
                    }
                    else
                    {
                        a[i + 1, j + 1] = 1;
                    }
                }
            }
            dp[1, 1, 0] = 1;
            for (int s = 1; s <= k; s++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            dp[i, j, s] = dp[i - 1, j, s - 1] + dp[i + 1, j, s - 1] + dp[i, j - 1, s - 1] + dp[i, j + 1, s - 1];
                        }
                    }
                }
            }
            File.WriteAllText("D:/Users/Denta/Desktop/Lab2/output.txt", dp[n, n, k].ToString());
        }
    }
}
