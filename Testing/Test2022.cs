using Main;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Testing
{
    public class Test2022 : TestBase
    {
        [Fact] public void Day01_Part1() => Assert.Equal("24000", Runner.GetDay(2022, 1).Part1(@"..\..\..\..\Test Inputs\2022-01.txt"));

        [Fact] public void Day01_Part2() => Assert.Equal("45000", Runner.GetDay(2022, 1).Part2(@"..\..\..\..\Test Inputs\2022-01.txt"));

        [Fact] public void Day02_Part1() => Assert.Equal("15", Runner.GetDay(2022, 2).Part1(@"..\..\..\..\Test Inputs\2022-02.txt"));
        [Fact] public void Day02_Part2() => Assert.Equal("12", Runner.GetDay(2022, 2).Part2(@"..\..\..\..\Test Inputs\2022-02.txt"));

        [Fact] public void Day03_Part1() => Assert.Equal("157", Runner.GetDay(2022, 3).Part1(@"..\..\..\..\Test Inputs\2022-03.txt"));
        [Fact] public void Day03_Part2() => Assert.Equal("70", Runner.GetDay(2022, 3).Part2(@"..\..\..\..\Test Inputs\2022-03.txt"));

        [Fact] public void Day04_Part1() => Assert.Equal("2", Runner.GetDay(2022, 4).Part1(@"..\..\..\..\Test Inputs\2022-04.txt"));
        [Fact] public void Day04_Part2() => Assert.Equal("4", Runner.GetDay(2022,4).Part2(@"..\..\..\..\Test Inputs\2022-04.txt"));

        [Fact] public void Day05_Part1() => Assert.Equal("CMZ", Runner.GetDay(2022, 5).Part1(@"..\..\..\..\Test Inputs\2022-05.txt"));
        [Fact] public void Day05_Part2() => Assert.Equal("MCD", Runner.GetDay(2022, 5).Part2(@"..\..\..\..\Test Inputs\2022-05.txt"));

        [Fact] public void Day06_Part1_1() => Assert.Equal("7", Runner.GetDay(2022, 6).Part1("mjqjpqmgbljsphdztnvjfqwrcgsmlb"));
        [Fact] public void Day06_Part1_2() => Assert.Equal("5", Runner.GetDay(2022, 6).Part1("bvwbjplbgvbhsrlpgdmjqwftvncz"));
        [Fact] public void Day06_Part1_3() => Assert.Equal("6", Runner.GetDay(2022, 6).Part1("nppdvjthqldpwncqszvftbrmjlhg"));
        [Fact] public void Day06_Part1_4() => Assert.Equal("10", Runner.GetDay(2022, 6).Part1("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"));
        [Fact] public void Day06_Part1_5() => Assert.Equal("11", Runner.GetDay(2022, 6).Part1("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"));
        [Fact] public void Day06_Part2_1() => Assert.Equal("19", Runner.GetDay(2022, 6).Part2("mjqjpqmgbljsphdztnvjfqwrcgsmlb"));
        [Fact] public void Day06_Part2_2() => Assert.Equal("23", Runner.GetDay(2022, 6).Part2("bvwbjplbgvbhsrlpgdmjqwftvncz"));
        [Fact] public void Day06_Part2_3() => Assert.Equal("23", Runner.GetDay(2022, 6).Part2("nppdvjthqldpwncqszvftbrmjlhg"));
        [Fact] public void Day06_Part2_4() => Assert.Equal("29", Runner.GetDay(2022, 6).Part2("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"));
        [Fact] public void Day06_Part2_5() => Assert.Equal("26", Runner.GetDay(2022, 6).Part2("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"));
        [Fact] public void Day07_Part1() => Assert.Equal("95437", Runner.GetDay(2022, 7).Part1(@"..\..\..\..\Test Inputs\2022-07.txt"));
        [Fact] public void Day07_Part2() => Assert.Equal("24933642", Runner.GetDay(2022, 7).Part2(@"..\..\..\..\Test Inputs\2022-07.txt"));

    }
}