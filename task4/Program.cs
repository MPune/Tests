using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace Task4
{
    class Program
    {
        static public void Main(string[] args)
        {
            var values = File.ReadAllLines(args[0])
                .Select(x => Int32.Parse(x))
                .OrderBy(x => x)
                .ToArray();

            var indexMid = values.Length / 2;
            if (values.Length % 2 == 1)
                ++indexMid;

            var needValue = values[indexMid];
            var iter = 0;
            foreach (var value in values)
            {
                iter += Math.Abs(value - needValue);
            }
            Console.WriteLine(iter);
        }
    }
}
