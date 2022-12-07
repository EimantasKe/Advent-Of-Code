using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _2022.Days
{
    public class Day01 : IDay
    {
        public string Title()
        {
            return "Day 1: Calorie Counting";
        }
        public string Part1(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-01.txt";

            int maxSum = 0;
            int currentSum = 0;
            using (StreamReader sr = input.GetStream())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                     if (string.IsNullOrEmpty(line))
                {
                    maxSum = currentSum > maxSum ? currentSum : maxSum;
                    currentSum = 0;
                }
                else
                {
                    currentSum += int.Parse(line);
                }
                }
            }
            maxSum = currentSum > maxSum ? currentSum : maxSum;
            return maxSum.ToString();
        }
        public string Part2(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-01.txt";

            int currentSum = 0;
            List<int> allSums = new List<int>();
            using (StreamReader sr = input.GetStream())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        allSums.Add(currentSum);
                        currentSum = 0;
                    }
                    else
                    {
                        currentSum += int.Parse(line);
                    }
                }
                allSums.Add(currentSum);
            }
            allSums.Sort();
            allSums.Reverse();
            int total = allSums.Take(3).Sum();
            return total.ToString();
        }
    }
}
