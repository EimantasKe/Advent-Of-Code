using Main;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Testing
{
    public class Test2015 : TestBase
    {
        [Fact] public void Day01_Part1_1() => Assert.Equal("0", Runner.GetDay(2015, 1).Part1("(())"));
        [Fact] public void Day01_Part1_2() => Assert.Equal("0", Runner.GetDay(2015, 1).Part1("()()"));
        [Fact] public void Day01_Part1_3() => Assert.Equal("3", Runner.GetDay(2015, 1).Part1("((("));
        [Fact] public void Day01_Part1_4() => Assert.Equal("3", Runner.GetDay(2015, 1).Part1("(()(()("));
        [Fact] public void Day01_Part1_5() => Assert.Equal("3", Runner.GetDay(2015, 1).Part1("))((((("));
        [Fact] public void Day01_Part1_6() => Assert.Equal("-1", Runner.GetDay(2015, 1).Part1("())"));
        [Fact] public void Day01_Part1_7() => Assert.Equal("-1", Runner.GetDay(2015, 1).Part1("))("));
        [Fact] public void Day01_Part1_8() => Assert.Equal("-3", Runner.GetDay(2015, 1).Part1(")))"));
        [Fact] public void Day01_Part1_9() => Assert.Equal("-3", Runner.GetDay(2015, 1).Part1(")())())"));

        [Fact] public void Day01_Part2_1() => Assert.Equal("1", Runner.GetDay(2015, 1).Part2(")"));
        [Fact] public void Day01_Part2_2() => Assert.Equal("5", Runner.GetDay(2015, 1).Part2("()())"));


        [Fact] public void Day02_Part1_1() => Assert.Equal("58", Runner.GetDay(2015, 2).Part1("2x3x4"));
        [Fact] public void Day02_Part1_2() => Assert.Equal("43", Runner.GetDay(2015, 2).Part1("1x1x10"));

        [Fact] public void Day02_Part2_1() => Assert.Equal("34", Runner.GetDay(2015, 2).Part2("2x3x4"));
        [Fact] public void Day02_Part2_2() => Assert.Equal("14", Runner.GetDay(2015, 2).Part2("1x1x10"));


        [Fact] public void Day03_Part1_1() => Assert.Equal("2", Runner.GetDay(2015, 3).Part1(">"));
        [Fact] public void Day03_Part1_2() => Assert.Equal("4", Runner.GetDay(2015, 3).Part1("^>v<"));
        [Fact] public void Day03_Part1_3() => Assert.Equal("2", Runner.GetDay(2015, 3).Part1("^v^v^v^v^v"));

        [Fact] public void Day03_Part2_1() => Assert.Equal("3", Runner.GetDay(2015, 3).Part2("^v"));
        [Fact] public void Day03_Part2_2() => Assert.Equal("3", Runner.GetDay(2015, 3).Part2("^>v<"));
        [Fact] public void Day03_Part2_3() => Assert.Equal("11", Runner.GetDay(2015, 3).Part2("^v^v^v^v^v"));


        [Fact] public void Day04_Part1_1() => Assert.Equal("609043", Runner.GetDay(2015, 4).Part1("abcdef"));
        [Fact] public void Day04_Part1_2() => Assert.Equal("1048970", Runner.GetDay(2015, 4).Part1("pqrstuv"));
        // [Fact] public void Day04_Part2() => Assert.Equal("4", Runner.GetDay(2015, 4).Part2(@"..\..\..\..\Test Inputs\2022-04.txt"));
        
    }
}