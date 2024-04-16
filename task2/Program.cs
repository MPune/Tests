using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static double GetDistance(double p1x, double p1y, double p2x, double p2y)
        {
            return Math.Sqrt(Math.Pow((p1x - p2x), 2) + Math.Pow((p1y - p2y), 2));
        }

        static public void Main(string[] args)
        {
            var circleData = File.ReadAllLines(args[0]);
            var circleR = double.Parse(circleData[1]);
            var circleCoords = circleData[0].Replace('.', ',').Split(' ');
            var circleX = double.Parse(circleCoords[0]);
            var circleY = double.Parse(circleCoords[1]);

            var pointsData = File.ReadAllLines(args[1]);
            foreach (var pointCoordsStr in pointsData)
            {
                var pointCoords = pointCoordsStr.Replace('.', ',').Split(' ');
                var pointX = double.Parse(pointCoords[0]);
                var pointY = double.Parse(pointCoords[1]);

                var distance = GetDistance(pointX, pointY, circleX, circleY);
                if (circleR > distance)
                    Console.WriteLine("1");
                else if (circleR < distance)
                    Console.WriteLine("2");
                else
                    Console.WriteLine("0");
            }
        }
    }
}
