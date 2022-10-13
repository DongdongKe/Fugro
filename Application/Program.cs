using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fugro. Enjoy your assignment!");
            List<Position> positions = new List<Position>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Input No.{i+1} latitude");
                double latitude = UserInput();
                if (latitude<-90 || latitude>90)
                {
                    Console.WriteLine("Error! Please input latitude between -90 and 90 degree");
                    latitude = UserInput();
                }
                Console.WriteLine($"Input No.{i+1} longtitude");
                double longitude = UserInput();
                if (longitude < -180 || longitude > 180)
                {
                    Console.WriteLine("Error! Please input longtitude between -180 and 180 degree");
                    longitude = UserInput();
                }
                Console.WriteLine($"Input No.{i+1} height");
                double height = UserInput();
                positions.Add(new Position(latitude, longitude, height));
            }
            checkDuplicatedPosition(positions);
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
            var list =  positionsList.GroupBy(x => new { x.Longitude, x.Latitude, x.Height }).ToList();
            foreach (var i in list)
            {
                if (i.Count() > 1)
                    throw new PositionDuplicatedException("Position Duplicated");
            }
        }

        public static void WriteToConsole(List<Position> items)
        {
            foreach (object o in items)
            {
                Console.WriteLine(o);
            }
        }
    }
}
