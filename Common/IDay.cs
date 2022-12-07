using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IDay
    {
        string Title();
        string Part1(string input);
        string Part2(string input);
    }
}