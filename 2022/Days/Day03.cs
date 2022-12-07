using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022.Days
{
    public class Day03 : IDay
    {
        public string Title()
        {
            return "Day 3: Rucksack Reorganization";
        }
        public string Part1(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-03.txt";
            int total = 0;
            string line;
            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string firstHalf = line.Substring(0, line.Length / 2);
                    string secondHalf = line.Substring(line.Length / 2, line.Length - (line.Length / 2));
                    byte[] asciiFirst = Encoding.ASCII.GetBytes(firstHalf);
                    byte[] asciiSecond = Encoding.ASCII.GetBytes(secondHalf);
                    foreach (byte item in asciiFirst.Intersect(asciiSecond))
                    {
                        if (item >= 65 && item <= 90)
                        {
                            int value = item - 38;
                            total += value;
                        }
                        else
                        {
                            int value = item - 96;
                            total += value;
                        }
                    }
                }
            }
            return total.ToString();
        }
        public string Part2(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-03.txt";
            int total = 0;
            int reset = 0;
            string line;
            byte[] firstElf = new byte[byte.MaxValue];
            byte[] secondElf = new byte[byte.MaxValue];
            byte[] thirdElf = new byte[byte.MaxValue];
            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    reset += 1;
                    string firstHalf = line.Substring(0, line.Length / 2);
                    string secondHalf = line.Substring(line.Length / 2, line.Length - (line.Length / 2));

                    if (reset == 1)
                    {
                        firstElf = Encoding.ASCII.GetBytes(line);
                    }
                    else if (reset == 2)
                    {
                        secondElf = Encoding.ASCII.GetBytes(line);
                    }
                    else if (reset == 3)
                    {
                        thirdElf = Encoding.ASCII.GetBytes(line);

                        foreach (byte item in firstElf.Intersect(secondElf.Intersect(thirdElf)))
                        {
                            if (item >= 65 && item <= 90)
                            {
                                int value = item - 38;
                                total += value;
                            }
                            else
                            {
                                int value = item - 96;
                                total += value;
                            }
                        }
                        reset = 0;
                    }
                }
            }
            return total.ToString();
        }
    }
}