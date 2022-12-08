using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022.Days
{
    internal class Day05 : IDay
    {
        public string Title()
        {
            return "Day 5: Supply Stacks";
        }
        public string Part1(string input)
        {
            input ??= @"..\..\..\..\Inputs\2022-05.txt";

            var stream = input.GetStream();
            Dictionary<int, Stack<char>> stacks = new();
            stacks = ReadStacks(stream, stacks);
            string line;
            String[] separator = { "move ", " from ", " to " };
            String[] cleanList;
            string answer = String.Empty;

            while ((line = stream.ReadLine()) != null)
            {
                cleanList = line.Split(separator, 3, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < int.Parse(cleanList[0]); i++)
                {
                    if (stacks.ContainsKey(int.Parse(cleanList[1])))
                    {
                           stacks[int.Parse(cleanList[2])].Push(stacks[int.Parse(cleanList[1])].Pop());
                    }
                }
            }

            foreach (var stack in stacks.OrderByDescending(x => x.Key).Reverse()) {
                if (stack.Value.Count > 0) { 
                    answer += stack.Value.Peek().ToString();
                }
            }
            return answer;
        }

        public string Part2(string input)
        {
            input ??= @"..\..\..\..\Inputs\2022-05.txt";

            var stream = input.GetStream();
            Dictionary<int, Stack<char>> stacks = new();
            stacks = ReadStacks(stream, stacks);
            string line;
            String[] separator = { "move ", " from ", " to " };
            String[] cleanList;
            string answer = String.Empty;
            List<char> savedStack = new List<char>();

            while ((line = stream.ReadLine()) != null)
            {
                savedStack = new List<char>();
                cleanList = line.Split(separator, 3, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < int.Parse(cleanList[0]); i++)
                {
                    if (stacks.ContainsKey(int.Parse(cleanList[1])) && stacks[int.Parse(cleanList[1])].Count > 0)
                    {
                        savedStack.Add(stacks[int.Parse(cleanList[1])].Pop());
                    }
                }
                savedStack.Reverse();
                foreach (var crate in savedStack)
                {
                    stacks[int.Parse(cleanList[2])].Push(crate);
                }
            }

            foreach (var stack in stacks.OrderByDescending(x => x.Key).Reverse())
            {
                if (stack.Value.Count > 0)
                {
                    answer += stack.Value.Peek().ToString();
                }
            }
            return answer;
        }
        //helper functions
        public Dictionary<int, Stack<char>> ReadStacks(StreamReader stream, Dictionary<int, Stack<char>> stacks)
        {
            string line;
            int count = 0;
            int lineLength = 0;
            int position = 1;
            
            while ((line = stream.ReadLine()) != null)
            {
                if(count == 0) {
                    lineLength = line.Length;
                }
                if (line.Length == 0)
                {
                    foreach (var stack in stacks)
                    {
                        stacks[stack.Key] = Reverse(stacks[stack.Key]);
                    }
                    return stacks;
                }

                while (position < lineLength) 
                {
                    count++;
                    if (stacks.ContainsKey((int)(position / 4) + 1) && line[position] >= 'A' && line[position] <= 'Z')
                    {
                        stacks[(int)(position / 4) + 1].Push((char)line[position]);
                    }
                    else if(line[position] >= 'A' && line[position] <= 'Z')
                    {
                        stacks[(int)(position / 4)+1] = new Stack<char>();
                        stacks[(int)(position / 4)+1].Push((char)line[position]);
                    }
                    position += 4;
                }
                count = 0;
                position = 1;
            }
            foreach (var stack in stacks)
            {
                stacks[stack.Key] = Reverse(stacks[stack.Key]);
            }
            return stacks;
        }

        public static Stack<char> Reverse(Stack<char> input)
        {
            Stack<char> temp = new Stack<char>();

            while (input.Count != 0)
                temp.Push(input.Pop());

            return temp;
        }
    }
}
