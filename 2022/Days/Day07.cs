using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace _2022.Days
{
    internal class Day07 : IDay
    {
        public string Title()
        {
            return "Day 7: No Space Left On Device";
        }
        public string Part1(string input)
        {
            input ??= @"..\..\..\..\Inputs\2022-07.txt";

            Dictionary<string, List<int>> files = GetDirectorySizes(input);
            int total = 0;

            foreach (var x in files.Keys)
            {
                Console.WriteLine(x);
                int sum = files[x].Sum(x => x);
                if (sum <= 100000)
                {
                    Console.WriteLine(x);
                    total += sum;
                }
            }
            return total.ToString();
        }

        public string Part2(string input)
        {
            input ??= @"..\..\..\..\Inputs\2022-07.txt";

            Dictionary<string, List<int>> files = GetDirectorySizes(input);
            int totalDiskSpaceAvailable = 70000000; 
            int usedSpace = files["/"].Sum(x => x); ;
            int neededFreeSpace = 30000000;
            List<int> possibleDirectories = new();

            foreach (var x in files.Keys)
            {
                int sum = files[x].Sum(x => x);
                if ((totalDiskSpaceAvailable - usedSpace + sum) >= neededFreeSpace){
                    possibleDirectories.Add(sum);
                }
            }
            return possibleDirectories.Min().ToString();
        }
        //helper functions
        public string GetHigherLevel(string directory)
        {
            string[] parts = directory.Split('/');
            if (directory == "/")
            {
                return "";
            }
            parts = parts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            directory = "/";
            foreach (var part in parts.SkipLast(1))
            {
                directory += part + "/";
            }
            return directory;//.Remove(directory.Length - 1, 1);
        }
        public Dictionary<string, List<int>> GetDirectorySizes(string input)
        {
            string line;
            Dictionary<string, List<int>> files = new();
            string currentDirectory = "";
            
            using (StreamReader sr = input.GetStream())
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] separated = line.Split(' ');
                    int size;
                    bool parseSuccess = int.TryParse(separated[0], out size);
                    if (separated[0] == "$")
                    {
                        if (separated[1] == "cd" && separated[2] != "..")
                        {
                            if (separated[2] == "/")
                            {
                                currentDirectory += separated[2];
                            }
                            else
                            {
                                currentDirectory += separated[2] + "/";
                            }

                        }
                        else if (separated[1] == "cd" && separated[2] == "..")
                        {
                            string[] parts = currentDirectory.Split('/');
                            parts = parts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            currentDirectory = "/";
                            foreach (var part in parts.SkipLast(1))
                            {
                                currentDirectory += part + "/";
                            }
                        }
                    }
                    else if (parseSuccess)
                    {
                        if (!files.ContainsKey(currentDirectory))
                        {
                            files.Add(currentDirectory, new List<int>());
                        }
                        files[currentDirectory].Add(size);
                        string dir = currentDirectory;
                        while (dir.Length != 0)
                        {
                            dir = GetHigherLevel(dir);
                            if (!files.ContainsKey(dir))
                            {
                                files.Add(dir, new List<int>());
                            }
                            files[dir].Add(size);
                        }
                    }
                }
            }
            return files;
        }
    }
}