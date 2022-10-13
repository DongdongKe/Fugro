using System;

namespace Library
{
    public sealed class Position
    {
        public Position(double latitude, double longitude, double height)
        {
            Latitude = latitude;
            Longitude = longitude;
            Height = height;
        }

        /// <summary>
        /// Latitude in decimal degrees
        /// </summary>
        public double Latitude
        {
            get;
        }

        /// <summary>
        /// Longitude in decimal degrees
        /// </summary>
        public double Longitude
        {
            get;
        }

        /// <summary>
        /// Height in metres
        /// </summary>
        public double Height
        {
            get;
        }

    }
}
