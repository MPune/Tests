using System;

namespace Task1
{
    class Program
    {
        static public void Main(string[] args)
        {
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);

            var max = n;
            var offset = m - 1;
            var current = 1;
            var result = string.Empty;
            do
            {
                result = result + current;
                current += offset;
                if (current > max)
                {
                    var newVal = current % (max);
                    if (newVal == 0)
                        newVal = max;
                    current = newVal;
                }
            }
            while (current != 1);
            Console.WriteLine(result);
        }
    }
}
