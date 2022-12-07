using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Main
{
    public class Runner
    {
        public Runner() { }
        public Runner(bool runner)
        {
            int year, day;
            // to add a year extend array below and the switch in GetDayType()
            string[] years = { "2015", "2022" };
            Dictionary<int, string> days = new();

            Del checkYear = CheckIfInvalidYearChoice;
            Del checkDay = CheckIfInvalidDayChoice;

            PrintYearChoices(years);
            year = GetInputForChoice(checkYear, years);

            if (year == 0)
            {
                PrintAllDaysAndYears(years);
            }
            else
            {
                days = GetListOfDaysForYear(year);
                PrintDayChoices(year, days);
                day = GetInputForChoice(checkDay, days.Keys.Select(x => x.ToString().TrimStart('0')).ToArray());
                Console.WriteLine("===================");
                Console.WriteLine("Part 1: {0}", GetDay(year, day).Part1(null));
                Console.WriteLine("Part 2: {0}", GetDay(year, day).Part2(null));
            }
        }
        public void PrintDayChoices(int chosenYear, Dictionary<int, string> daysOfYear)
        {
            Console.WriteLine("\n========= {0} =========", chosenYear);
            Console.WriteLine("Available days: (type number only)");
            Array.ForEach(daysOfYear.Values.ToArray(), Console.WriteLine);
        }
        public void PrintYearChoices(string[] yearsToPrint)
        {
            Console.WriteLine("Enter year or 0 to print all available results");
            Console.WriteLine("Available years:");
            Array.ForEach(yearsToPrint, Console.WriteLine);
        }
        public void PrintAllDaysAndYears(string[] years)
        {
            foreach (var y in years)
            {
                Console.WriteLine("\n========= {0} =========", y);
                Dictionary<int, string> days = GetListOfDaysForYear(int.Parse(y));
                int[] keys = days.Keys.Select(x => x).ToArray();
                foreach (var d in keys)
                {
                    Console.WriteLine(days[d]);
                    Console.WriteLine("Part 1: {0}", GetDay(int.Parse(y), d).Part1(null));
                    Console.WriteLine("Part 2: {0}", GetDay(int.Parse(y), d).Part2(null));
                    if (!d.Equals(keys.Last())) Console.WriteLine("-----------------");
                }
            }

        }
        public Boolean CheckIfInvalidYearChoice(string? choice, string[] years)
        {
            int number;
            bool parseSuccess = int.TryParse(choice, out number);
            if (choice == "0")
            {
                return false;
            }
            else if (string.IsNullOrEmpty(choice) || !parseSuccess || !years.Contains(choice))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean CheckIfInvalidDayChoice(string? choice, string[] days)
        {
            int number;
            bool parseSuccess = int.TryParse(choice, out number);
            if (!string.IsNullOrEmpty(choice) && parseSuccess && days.Contains(choice))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public IDay? GetDay(int year, int day)
        {
            if (GetDayType(year, day) is Type type)
            {
                return (IDay?)Activator.CreateInstance(type);
            }

            return null;
        }
        public Type? GetDayType(int year, int day)
        {
            Assembly? assembly = year switch
            {
                2015 => typeof(_2015.Days.Day01).Assembly,
                2022 => typeof(_2022.Days.Day01).Assembly,
                _ => null
            };

            if (assembly != null)
            {
                foreach (Type t in assembly.GetTypes())
                {
                    if (t.Name == $"Day{day:D2}")
                    {
                        return t;
                    }
                }
            }

            return null;
        }
        public Dictionary<int, string> GetListOfDaysForYear(int year)
        {
            Dictionary<int, string> days = new();
            Assembly? assembly = year switch
            {
                2015 => typeof(_2015.Days.Day01).Assembly,
                2022 => typeof(_2022.Days.Day01).Assembly,
                _ => null
            };
            if (assembly != null)
            {
                foreach (Type t in assembly.GetTypes())
                {
                    if (t.Name.StartsWith("Day"))
                    {
                        var day = (IDay?)Activator.CreateInstance(t);
                        var numberPart = Regex.Match(t.Name, @"\d+").Value;
                        var number = int.Parse(numberPart);
                        days.Add(number, day.Title());
                    }
                }
            }
            return days;
        }
        public int GetInputForChoice(Del check, string[] list)
        {
            string? choice = null;
            do
            {
                Console.Write("\nInput: ");
                choice = Console.ReadLine();
            }
            while (check(choice, list) || choice == null);
            return int.Parse(choice);
        }
        public delegate bool Del(string? choice, string[] list);
    }
}
