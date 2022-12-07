using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc.Years._2022
{
    internal class Day01 : IDay
    {
        public string Title()
        {
            return "Day 1: Calorie Counting";
        }
        // Part 1 and helper functions
        public string Part1()
        {
            int maxSum = 0;
            int currentSum = 0;

            foreach (string line in File.ReadLines(@"..\..\..\Inputs\1.txt"))
            {
                if (String.IsNullOrEmpty(line))
                {
                    maxSum = currentSum > maxSum ? currentSum : maxSum;
                    currentSum = 0;
                }
                else
                {
                    currentSum += int.Parse(line);
                }
            }
            maxSum = currentSum > maxSum ? currentSum : maxSum;
            return maxSum.ToString();
        }
        // Part 2 and helper functions
        public string Part2()
        {
            int currentSum = 0;
            List<int> allSums = new List<int>();

            foreach (string line in File.ReadLines(@"..\..\..\Inputs\1.txt"))
            {
                if (String.IsNullOrEmpty(line))
                {
                    allSums.Add(currentSum);
                    currentSum = 0;
                }
                else
                {
                    currentSum += int.Parse(line);
                }
            }

            allSums.Sort();
            allSums.Reverse();
            int total = allSums.Take(3).Sum();
            return total.ToString();
        }
    }
}
