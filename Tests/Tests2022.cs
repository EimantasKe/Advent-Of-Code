using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Main;
using Common;
using m

namespace Tests
{
    public class Tests2022
    {
        [Fact]
        public void Day01_Part1() =>  Assert.Equal(GetDay(2022, 1).Part1(), "67633");

        [Fact] public void Day02() => TestHelpers.AssertDay<Day02>("1586300", "3737498");
        [Fact] public void Day03() => TestHelpers.AssertDay<Day03>("2081", "2341");
        [Fact] public void Day04() => TestHelpers.AssertDay<Day04>("254575", "1038736");
    }
}
