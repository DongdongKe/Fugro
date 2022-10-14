using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fugro. Enjoy your assignment!");
            List<Position> positions = new List<Position>();
            int latitudeMax = 90, latitudeMin = -90;
            int longitudeMax = 180, longitudeMin = -180;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Input No.{i+1} latitude");
                double latitude = UserInput();
                if (latitude < latitudeMin || latitude > latitudeMax)
                {
                    Console.WriteLine($"Error! Please input latitude between {latitudeMin} and {latitudeMax} degree");
                    latitude = UserInput();
                }
                Console.WriteLine($"Input No.{i+1} longitude");
                double longitude = UserInput();
                if (longitude < -180 || longitude > 180)
                {
                    Console.WriteLine($"Error! Please input longitude between {longitudeMax} and {longitudeMin} degree");
                    longitude = UserInput();
                }
                Console.WriteLine($"Input No.{i+1} height");
                double height = UserInput();
                positions.Add(new Position(latitude, longitude, height));
            }
            checkDuplicatedPosition(positions);
            foreach (var p in positions.OrderByDescending(x => x.Latitude).ThenBy(y => y.Longitude))
            {
                PrintSortedPosition(p);
            }
            List<double> results =Calculator.CalculateDistance(positions);
            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }

        public static double UserInput()
        {
            double value = -1;
            try
            {
                string input = Console.ReadLine();
                value = double.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong data, input again. Msg:" + e.Message);
                return UserInput();
            }
            return value;
        }

        public static void checkDuplicatedPosition(List<Position> positionsList)
        {
            var list = positionsList.GroupBy(x => new { x.Longitude, x.Latitude, x.Height }).ToList();
            foreach (var i in list)
            {
                if (i.Count() > 1)
                    throw new PositionDuplicatedException("Position Duplicated");
            }
        }

        private static void PrintSortedPosition(Position p)
        {
            Console.WriteLine($"latitude:{p.Latitude}, longitude:{p.Longitude}, height:{p.Height}");
        }
    }
}
