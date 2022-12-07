using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022.Days
{
    public class Day04 : IDay
    {
        public string Title()
        {
            return "Day 4: Camp Cleanup";
        }
        public string Part1(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-04.txt";
            int count = 0;
            string line;
            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    String[] elves = line.Split(",");
                    String[] elf1 = elves[0].Split("-");
                    String[] elf2 = elves[1].Split("-");
                    if (FullyContained(int.Parse(elf1[0]), int.Parse(elf1[1]), int.Parse(elf2[0]), int.Parse(elf2[1])))
                    {
                        count++;
                    }
                    else if (FullyContained(int.Parse(elf2[0]), int.Parse(elf2[1]), int.Parse(elf1[0]), int.Parse(elf1[1])))
                    {
                        count++;
                    }
                }
            }
            return count.ToString();
        }
        public string Part2(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-04.txt";
            int count = 0;
            string line;
            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    String[] elves = line.Split(",");
                    String[] elf1 = elves[0].Split("-");
                    String[] elf2 = elves[1].Split("-");

                    if (Overlap(int.Parse(elf1[0]), int.Parse(elf1[1]), int.Parse(elf2[0]), int.Parse(elf2[1])))
                    {
                        count++;
                    }
                }
            }
            return count.ToString();
        }
        //helper functions
        static internal bool FullyContained(int a, int b, int c, int d)
        {
            if (a <= c && b >= d)
            {
                return true;
            }
            return false;
        }
        static internal bool Overlap(int a, int b, int c, int d)
        {
            if (a <= d && c <= b)
            {
                return true;
            }
            return false;
        }
    }
}
