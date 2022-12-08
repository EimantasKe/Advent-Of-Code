using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015.Days
{
    public class Day04 : IDay
    {
        public string Title()
        {
            return "Day 4: The Ideal Stocking Stuffer";
        }
        public string Part1(string? input)
        {
            input ??= "bgvyzdsv";

            int i = 0;
            bool found = false;

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                while (!found)
                {
                    string secretString = input + i.ToString();
                    byte[] inputBytes = Encoding.ASCII.GetBytes(secretString);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    string firstFive = Convert.ToHexString(hashBytes).Substring(0, 5);
                    if (firstFive == "00000")
                    {
                        found = true;
                    }
                    i++;
                }
            }
            return (i - 1).ToString();
        }
        public string Part2(string? input)
        { 
            input ??= "bgvyzdsv";

            int i = 0;
            bool found = false;

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                while (!found)
                {
                    string secretString = input + i.ToString();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(secretString);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    string firstFive = Convert.ToHexString(hashBytes).Substring(0, 6);
                    if (firstFive == "000000")
                    {
                        found = true;
                    }
                    i++;
                }
            }
            return (i - 1).ToString();
        }
    }
}