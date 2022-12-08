using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _2022.Days
{
    internal class Day08 : IDay
    {
        public string Title()
        {
            return "Day 8: Treetop Tree House";
        }
        public string Part1(string input)
        {
            input ??= @"..\..\..\..\Inputs\2022-08.txt";

            Dictionary<(int,int), int> trees= new Dictionary<(int,int),int>();
            int treeY = 0;
            string line;

            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    treeY += 1;
                    for (int i = 0; i < line.Length; i++)
                    {
                        trees.Add((i + 1, treeY), int.Parse(line[i].ToString()));
                        ;
                    }
                }
            }

            var maxX = trees.Keys.Max(x => x.Item1);
            var maxY = trees.Keys.Max(x => x.Item2);
            bool checkLeft, checkRight, checkTop, checkBottom;
            int visibleTrees = 0;
            
            for (int i = 1; i <= maxX; i++)
            {
                for(int I = 1; I <= maxY; I++)
                {
                    checkLeft = trees.Where(t => t.Key.Item1 < i && t.Key.Item2 == I).Where(t => t.Value >= trees[(i, I)]).Count() > 0;
                    checkRight = trees.Where(t => t.Key.Item1 > i && t.Key.Item2 == I).Where(t => t.Value >= trees[(i, I)]).Count() > 0;
                    checkTop = trees.Where(t => t.Key.Item1 == i && t.Key.Item2 < I).Where(t => t.Value >= trees[(i, I)]).Count() > 0;
                    checkBottom = trees.Where(t => t.Key.Item1 == i && t.Key.Item2 > I).Where(t => t.Value >= trees[(i, I)]).Count() > 0;
                    if (!(checkLeft && checkRight && checkTop && checkBottom))
                    {
                        visibleTrees++;
                    }
                }
            }
            return visibleTrees.ToString();
        }

        public string Part2(string input)
        {
            input ??= @"..\..\..\..\Inputs\2022-08.txt";

            Dictionary<(int, int), int> trees = new Dictionary<(int, int), int>();
            int treeY = 0;
            string line;

            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    treeY += 1;
                    for (int i = 0; i < line.Length; i++)
                    {
                        trees.Add((i + 1, treeY), int.Parse(line[i].ToString()));
                        ;
                    }
                }
            }
            var maxX = trees.Keys.Max(x => x.Item1);
            var maxY = trees.Keys.Max(x => x.Item2);
            int maxScenicScore = 0;
            for (int i = 1; i <= maxX; i++)
            {
                for (int I = 1; I <= maxY; I++)
                { 
                    var treesLeft = trees.Where(t => t.Key.Item1 < i && t.Key.Item2 == I).Reverse().TakeWhile(t => t.Value < trees[(i, I)]);
                    var scoreLeft = treesLeft.Count();
                    if(treesLeft.Count() > 0 && treesLeft.Last().Key.Item1 != 1)
                    {
                        scoreLeft++;
                    }
                    
                    var treesRight = trees.Where(t => t.Key.Item1 > i && t.Key.Item2 == I).TakeWhile(t => t.Value < trees[(i, I)]);
                    var scoreRight = treesRight.Count();
                    if (treesRight.Count() > 0 && treesRight.Last().Key.Item1 != maxX)
                    {
                        scoreRight++;
                    }

                    var treesTop = trees.Where(t => t.Key.Item1 == i && t.Key.Item2 < I).Reverse().TakeWhile(t => t.Value < trees[(i, I)]);
                    var scoreTop = treesTop.Count();
                    if (treesTop.Count() > 0 && treesTop.Last().Key.Item2 != 1)
                    {
                        scoreTop++;
                    }

                    var treesBottom = trees.Where(t => t.Key.Item1 == i && t.Key.Item2 > I).TakeWhile(t => t.Value < trees[(i, I)]);
                    var scoreBottom = treesBottom.Count();
                    if (treesBottom.Count() > 0 && treesBottom.Last().Key.Item2 != maxY)
                    {
                        scoreBottom++;
                    }

                    if (maxScenicScore < scoreLeft * scoreRight * scoreTop * scoreBottom)
                    {
                        maxScenicScore = scoreLeft * scoreRight * scoreTop * scoreBottom;
                    }
                }
            }
            return maxScenicScore.ToString();
        }

        
    }
}
