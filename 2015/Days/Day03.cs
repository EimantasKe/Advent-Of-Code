using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015.Days
{
    public class Day03 : IDay
    {
        public string Title()
        {
            return "Day 3: Perfectly Spherical Houses in a Vacuum";
        }
        public string Part1(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2015-03.txt";

            int x = 0;
            int y = 0;
            int count = 0;
            char currentAction;

            Dictionary<(int, int), int> houses = new();
            int actionsTaken = 0;
            using (StreamReader sr = input.GetStream())
            {
                count = IncrementCount(houses, 0, 0, count);
                while (sr.Peek() >= 0)
                {
                    currentAction = (char)sr.Read();
                    if (currentAction == '<')
                    {
                        x--;
                    }
                    else if (currentAction == '>')
                    {
                        x++;
                    }
                    else if (currentAction == '^')
                    {
                        y++;
                    }
                    else if (currentAction == 'v')
                    {
                        y--;
                    }
                    count = IncrementCount(houses, x, y, count);
                    actionsTaken += 1;
                }
            }
            return count.ToString();
        }
        public string Part2(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2015-03.txt";

            int count = 0;
            int santaX = 0;
            int santaY = 0;
            int roboX = 0;
            int roboY = 0;
            char santaAction;
            char roboAction;
            Dictionary<(int, int), int> houses = new();
            int actionsTaken = 0;

            using (StreamReader sr = input.GetStream())
            {
                count = IncrementCount(houses, 0, 0, count);
                while (sr.Peek() >= 0)
                {
                    santaAction = (char)sr.Read();
                    roboAction = (char)sr.Read();
                    if (santaAction == '<')
                    {
                        santaX--;
                    }
                    else if (santaAction == '>')
                    {
                        santaX++;
                    }
                    else if (santaAction == '^')
                    {
                        santaY++;
                    }
                    else if (santaAction == 'v')
                    {
                        santaY--;
                    }

                    if (roboAction == '<')
                    {
                        roboX--;
                    }
                    else if (roboAction == '>')
                    {
                        roboX++;
                    }
                    else if (roboAction == '^')
                    {
                        roboY++;
                    }
                    else if (roboAction == 'v')
                    {
                        roboY--;
                    }
                    count = IncrementCount(houses, santaX, santaY, count);
                    count = IncrementCount(houses, roboX, roboY, count);
                    actionsTaken += 1;
                }
            }
            return count.ToString();
        }
        //helper functions
        static int IncrementCount(Dictionary<(int, int), int> someDictionary, int x, int y, int count)
        {
            int currentCount;
            if (someDictionary.TryGetValue((x, y), out currentCount))
            {
                someDictionary[(x, y)] = currentCount + 1;
                return count;
            }
            else
            {
                someDictionary[(x, y)] = 1;
                return ++count;
            }
        }
    }
}
