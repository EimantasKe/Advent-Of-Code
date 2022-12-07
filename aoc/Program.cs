using aoc;
using System.Reflection;


byte[] inputBytes = await AdventRunner.GetInputAsync(year, day, fetchIfMissing: true);
string input = Encoding.ASCII.GetString(inputBytes);

var parse = (string s) =>
{
    return s;
};

var lines = input.TrimEnd('\n').Split("\n\n").Select(parse).ToArray();

for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i];
}

Console.WriteLine();

Type? GetYearType(int year, int day)
{
    Assembly? assembly = year switch
    {
        2015 => typeof(Years._2022.Day01).Assembly,
        2016 => typeof(Solvers.Day01).Assembly,
        2017 => typeof(Y2017.Solvers.Day01).Assembly,
        2018 => typeof(Y2018.Solvers.Day01).Assembly,
        2019 => typeof(Y2019.Solvers.Day01).Assembly,
        2020 => typeof(Y2020.Solvers.Day01).Assembly,
        2021 => typeof(Y2021.Solvers.Day01).Assembly,
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













string? choice = null;
Dictionary<int, Func<IDay>> map = new();

do
{
    Console.WriteLine("Get results of what day? 1-25 (0 for all days so far)");
    choice = Console.ReadLine();
}
while (CheckIfInvalidChoice(choice) || choice == null);

MapAllDays();

if (int.Parse(choice) == 0)
{
    foreach (int index in Enumerable.Range(1, 25))
    {
        InvokeAndWrite(index);
    }
}
else
{
    InvokeAndWrite(int.Parse(choice));
}

void InvokeAndWrite(int mapKey)
{
    IDay res = map[mapKey].Invoke();
    string part1Result = res.part1();
    string part2Result = res.part2();
    if (!part1Result.Equals("Not implemented yet") && !part2Result.Equals("Not implemented yet"))
    {
        Console.WriteLine("================");
        Console.WriteLine(res.title());
        Console.WriteLine("Part 1: {0}", part1Result);
        Console.WriteLine("Part 2: {0}", part2Result);
    }
}

Boolean CheckIfInvalidChoice(string? choice)
{
    int number;
    List<int> numberList = Enumerable.Range(0, 25).ToList();

    bool parseSuccess = int.TryParse(choice, out number);
    if (!string.IsNullOrEmpty(choice) && parseSuccess && (numberList.IndexOf(number) != -1))
    {
        return false;
    }
    else
    {
        return true;
    }
}

void MapAllDaysToYear()
{
    map.Add(1, () => new Day01());
    map.Add(2, () => new Day02());
    map.Add(3, () => new Day03());
    map.Add(4, () => new Day04());
    map.Add(5, () => new Day05());
    map.Add(6, () => new Day06());
    map.Add(7, () => new Day07());
    map.Add(8, () => new Day08());
    map.Add(9, () => new Day09());
    map.Add(10, () => new Day10());
    map.Add(11, () => new Day11());
    map.Add(12, () => new Day12());
    map.Add(13, () => new Day13());
    map.Add(14, () => new Day14());
    map.Add(15, () => new Day15());
    map.Add(16, () => new Day16());
    map.Add(17, () => new Day17());
    map.Add(18, () => new Day18());
    map.Add(19, () => new Day19());
    map.Add(20, () => new Day20());
    map.Add(21, () => new Day21());
    map.Add(22, () => new Day22());
    map.Add(23, () => new Day23());
    map.Add(24, () => new Day24());
    map.Add(25, () => new Day25());
}
// =============== DAY 4 ================
// 1000 - too high
// 896 - too high
// 726
// 669 - too low


int count = 0;
foreach (string line in File.ReadLines(@"..\..\..\input2022-4.txt"))
{
String[] elves = line.Split(",");
String[] elf1 = elves[0].Split("-");
String[] elf2 = elves[1].Split("-");

if (Overlap(int.Parse(elf1[0]), int.Parse(elf1[1]), int.Parse(elf2[0]), int.Parse(elf2[1])))
{
    count++;
}
}

Console.WriteLine(count);
bool Overlap(int a, int b, int c, int d)
{
    if (a <= d && c <= b )
    {
        return true;
    }
    return false;
}



/* PART 1
int count = 0;
foreach (string line in File.ReadLines(@"..\..\..\input2022-4.txt")) {
    String[] elves = line.Split(",");
    String[] elf1 = elves[0].Split("-");
    String[] elf2 = elves[1].Split("-");
    if (FullyContained(int.Parse(elf1[0]), int.Parse(elf1[1]), int.Parse(elf2[0]), int.Parse(elf2[1])))
    {
        count++;
    }
    else if (FullyContained( int.Parse(elf2[0]), int.Parse(elf2[1]), int.Parse(elf1[0]), int.Parse(elf1[1])))
    {
        count++;
    }
}

Console.WriteLine(count);
bool FullyContained(int a, int b,int c,int d)
{
    if(a <= c && b>= d)
    {
        return true;
    }
    return false;
}

/* DAY 3
int total = 0;
int reset = 0;
byte[] firstElf = new byte[byte.MaxValue];
byte[] secondElf = new byte[byte.MaxValue];
byte[] thirdElf = new byte[byte.MaxValue];

foreach (string line in File.ReadLines(@"..\..\..\input2022-3.txt"))
{
    reset += 1;
    string firstHalf = line.Substring(0, line.Length / 2);
    string secondHalf = line.Substring(line.Length / 2, line.Length - (line.Length / 2));
    byte[] asciiFirst = Encoding.ASCII.GetBytes(firstHalf);
    byte[] asciiSecond = Encoding.ASCII.GetBytes(secondHalf);

    if (reset == 1)
    {
        firstElf = Encoding.ASCII.GetBytes(line);
    }
    else if (reset == 2)
    {
        secondElf = Encoding.ASCII.GetBytes(line);
    }
    else if (reset == 3)
    {
        thirdElf = Encoding.ASCII.GetBytes(line);


        foreach (byte item in firstElf.Intersect(secondElf.Intersect(thirdElf)))
        {
            if (item >= 65 && item <= 90)
            {
                int value = item - 38;
                total += value;
            }
            else
            {
                int value = item - 96;
                total += value;
            }
        }
        reset = 0;
    }
}
Console.WriteLine(total);

/*
int total = 0;

foreach (string line in File.ReadLines(@"..\..\..\input2022-3.txt"))
{
    string firstHalf = line.Substring(0, line.Length / 2);
    string secondHalf = line.Substring(line.Length / 2, line.Length - (line.Length /2));
    byte[] asciiFirst = Encoding.ASCII.GetBytes(firstHalf);
    byte[] asciiSecond = Encoding.ASCII.GetBytes(secondHalf);
    foreach (byte item in asciiFirst.Intersect(asciiSecond))
    {
        if(item >= 65 && item <= 90)
        {
            int value = item - 38;
            total += value;
        }
        else
        {
            int value = item - 96;
            total += value;
        }
    }

}*/

//Console.WriteLine(total);
/*
int[] ascii = Enumerable.Range(65, 122).ToArray();
foreach(int item in ascii)
{
    if (item >= 65 && item <= 90)
    {
        int value = item % 32 + 26;
        total += value;
        Console.WriteLine("{0}: {1}", Convert.ToChar(item),value);
    }
    else
    {
        if(item == 97)
        {
            Console.WriteLine("---------");
        }
        int value = item % 32;
        total += value;
        Console.WriteLine("{0}: {1}", Convert.ToChar(item), value);
    }
}

string filepath = @"..\..\..\input2022-3.txt";

/*var part1 = File.ReadAllLines(filepath)
                 .Select(line => line.Chunk(line.Length / 2).ToArray())
                 .Select(rs => rs[0].Intersect(rs[1]).First())
                 .Select(letter => Char.IsLower(letter) ? letter - 96 : letter - 38)
                 .Sum();

Console.WriteLine(part1);

var part2 = File.ReadAllLines(filepath)
                  .Chunk(3)
                  .Select(g => g[0].Intersect(g[1]).Intersect(g[2]).First())
                  .Select(letter => Char.IsLower(letter) ? letter - 96 : letter - 38)
                  .Sum();

Console.WriteLine(part2);

*/
/* ==============  DAY2 ==============
int total = 0;
foreach (string line in File.ReadLines(@"..\..\..\input2022-2.txt"))
{
    String[] separated = line.Split(" ");
    // total += GetPointsPart1(separated[0], separated[1]);
    total += GetPointsPart2(separated[0], separated[1]);
}
Console.WriteLine(total);
// Rock A X
// Paper B Y
// Scissors C Z
// 13670


int GetPointsPart1(string oppShape, string myShape)
{
    if(oppShape == "A" && myShape == "X")
    {
        return 1 + 3;
    }else if (oppShape == "A" && myShape == "Y")
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

int GetPointsPart2(string oppShape, string myShape)
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
*/