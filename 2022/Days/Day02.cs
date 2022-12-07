using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022.Days
{
    public class Day02 : IDay
    {
        public string Title()
        {
            return "Day 2: Rock Paper Scissors";
        }
        public string Part1(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-02.txt";
            
            int total = 0;
            string line;
            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    String[] separated = line.Split(" ");
                    total += GetPointsPart1(separated[0], separated[1]);
                }
            }
            return total.ToString();
        }
        public string Part2(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-02.txt";

            int total = 0;
            string line;
            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    String[] separated = line.Split(" ");
                    total += GetPointsPart2(separated[0], separated[1]);
                }
            }
            return total.ToString();
        }
        //helper functions
        static internal int GetPointsPart1(string oppShape, string myShape)
        {
            if (oppShape == "A" && myShape == "X")
            {
                return 1 + 3;
            }
            else if (oppShape == "A" && myShape == "Y")
            {
                return 2 + 6;
            }
            else if (oppShape == "A" && myShape == "Z")
            {
                return 3 + 0;
            }
            else if (oppShape == "B" && myShape == "X")
            {
                return 1 + 0;
            }
            else if (oppShape == "B" && myShape == "Y")
            {
                return 2 + 3;
            }
            else if (oppShape == "B" && myShape == "Z")
            {
                return 3 + 6;
            }
            else if (oppShape == "C" && myShape == "X")
            {
                return 1 + 6;
            }
            else if (oppShape == "C" && myShape == "Y")
            {
                return 2 + 0;
            }
            else if (oppShape == "C" && myShape == "Z")
            {
                return 3 + 3;
            }
            else
            {
                return 0;
            }

        }
        static internal int GetPointsPart2(string oppShape, string myShape)
        {
            if (oppShape == "A" && myShape == "X")
            {
                return 3 + 0;
            }
            else if (oppShape == "A" && myShape == "Y")
            {
                return 1 + 3;
            }
            else if (oppShape == "A" && myShape == "Z")
            {
                return 2 + 6;
            }
            else if (oppShape == "B" && myShape == "X")
            {
                return 1 + 0;
            }
            else if (oppShape == "B" && myShape == "Y")
            {
                return 2 + 3;
            }
            else if (oppShape == "B" && myShape == "Z")
            {
                return 3 + 6;
            }
            else if (oppShape == "C" && myShape == "X")
            {
                return 2 + 0;
            }
            else if (oppShape == "C" && myShape == "Y")
            {
                return 3 + 3;
            }
            else if (oppShape == "C" && myShape == "Z")
            {
                return 1 + 6;
            }
            else
            {
                return 0;
            }
        }
    }
}
