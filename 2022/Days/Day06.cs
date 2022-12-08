using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _2022.Days
{
    internal class Day06 : IDay
    {
        public string Title()
        {
            return "Day 6: Tuning Trouble";
        }
        public string Part1(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-06.txt";
            Queue<char> queue = new Queue<char>();
            int position = 0;

            using (StreamReader sr = input.GetStream())
            {

                while (sr.Peek() >= 0)
                {
                    position++;
                    if(queue.Count < 4)
                    {
                        queue.Enqueue((char)sr.Read());
                    }
                    else
                    {
                        queue.Dequeue();
                        queue.Enqueue((char)sr.Read());
                        if (queue.Distinct().Count() == queue.Count)
                        {
                            return position.ToString();
                        }
                    } 
                }
            }
            return "failure";
        }
        public string Part2(string? input)
        {
            input ??= @"..\..\..\..\Inputs\2022-06.txt";
            Queue<char> queue = new Queue<char>();
            int position = 0;

            using (StreamReader sr = input.GetStream())
            {

                while (sr.Peek() >= 0)
                {
                    position++;
                    if (queue.Count < 14)
                    {
                        queue.Enqueue((char)sr.Read());
                    }
                    else
                    {
                        queue.Dequeue();
                        queue.Enqueue((char)sr.Read());
                        if (queue.Distinct().Count() == queue.Count)
                        {
                            return position.ToString();
                        }
                    }
                }
            }
            return "failure";
        }
    }
}
