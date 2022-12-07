using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Reader
    {
         private static bool CheckIfFilePath(string input)
        {
            if (File.Exists(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static StreamReader GetStream(this string? input)
        {
            if (CheckIfFilePath(input))
            {
                return new StreamReader(@input);
            }
            else
            {
                return new StreamReader(ToStream(input));
            }
        }
        private static Stream ToStream(this string value, Encoding encoding = null) => new MemoryStream((encoding ?? Encoding.UTF8).GetBytes(value ?? string.Empty));
    }
}
