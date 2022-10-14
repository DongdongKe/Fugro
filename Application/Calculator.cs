using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Application
{
    public static class Calculator
    {
        public static List<double> CalculateDistance(List<Position> positionsList)
        {
            List<double> distance = new List<double>();
            for (int i = 0; i < positionsList.Count; i++)
            {
                int j = i + 1;
                if (i==3)
                {
                    j = 0;
                }
                double latitudeDelta = positionsList[i].Latitude - positionsList[j].Latitude;
                double longitudeDelta = positionsList[i].Longitude - positionsList[j].Longitude;
                double latitudeDeltaMeter = latitudeDelta * Math.PI / 180 * 6378137;
                double longitudeDeltaMeter = longitudeDelta * Math.PI / 180 * 6378137;
                double deltaHeight = positionsList[i].Height - positionsList[j].Height;
                distance.Add(Math.Sqrt(Math.Pow(latitudeDeltaMeter, 2)+Math.Pow(longitudeDeltaMeter,2)+Math.Pow(deltaHeight,2)));
            }
            return distance;
        }
    }
}
