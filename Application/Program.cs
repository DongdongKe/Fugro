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
                Console.WriteLine($"Input No.{i+1} longtitude");
                double longtitude = UserInput();
                Console.WriteLine($"Input No.{i+1} height");
                double height = UserInput();
                positions.Add(new Position(latitude, longtitude, height));
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



    }
}
