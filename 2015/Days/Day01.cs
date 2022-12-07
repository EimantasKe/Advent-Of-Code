using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _2015.Days
{
    public class Day01 : IDay
    {
        public string Title()
        {
            return "Day 1: Not Quite Lisp";
        }
        public string Part1(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2015-01.txt";
            int floor = 0;
            using (StreamReader sr = input.GetStream())
            {
                
                while (sr.Peek() >= 0)
                {
                    if ((char)sr.Read() == '(')
                    {
                        floor++;
                    }
                    else
                    {
                        floor--;
                    }
                }
            }
            return floor.ToString();
        }
        public string Part2(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2015-01.txt";
            int i = 0;
            int floor = 0;
            using (StreamReader sr = input.GetStream())
            {
               
                while (sr.Peek() >= 0)
                {
                    i++;
                    if ((char)sr.Read() == '(')
                    {
                        floor++;
                    }
                    else
                    {
                        floor--;
                    }
                    if (floor < 0)
                    {
                        break;
                    }
                }
            }
            return i.ToString();
        }
    }
}
