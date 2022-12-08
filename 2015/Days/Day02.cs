using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015.Days
{
    public class Day02 : IDay
    {
        public string Title()
        {
            return "Day 2: I Was Told There Would Be No Math";
        }
        public string Part1(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2015-02.txt";

            int total = 0;
            int count = 0;
            int[] sides = new int[3];
            string line;

            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    String[] separated = line.Split("x");
                    for (int i = 0; i < 3; i++)
                    {
                        sides[i] = (int.Parse(separated[i]));
                    }
                    int[] array = { (sides[0] * sides[1]), (sides[0] * sides[2]), (sides[1] * sides[2]) };
                    total += (2 * sides[0] * sides[1]) + (2 * sides[0] * sides[2]) + (2 * sides[1] * sides[2]) + array.Min();

                    if (count == 0)
                    {
                        int x = array.Min();
                    }
                    count++;
                }
            }
            return total.ToString();
        }
        public string Part2(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2015-02.txt";

            int total = 0;
            int[] sides = new int[3];
            string line;

            using(StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    String[] separated = line.Split("x");
                    for (int i = 0; i < 3; i++)
                    {
                        sides[i] = (int.Parse(separated[i]));
                    }
                    sides = sides.OrderBy(i => i).ToArray();
                    total += 2 * sides[0] + 2 * sides[1] + (sides[0] * sides[1] * sides[2]);
                }
            }
            return total.ToString();
        }
    }
}
