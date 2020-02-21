using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            TacoParser parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToList();
            //locations.RemoveAt(locations.IndexOf(null));

            try
            {
                bool warning = true;
                for (int i = 0; i < locations.Count; i++)
                {
                    if (locations[i] == null)
                    {
                        if (warning)
                        {
                            logger.LogWarning("Null references discovered in locations List.\n");
                            logger.LogInfo("Removing all null references.\n");
                        }
                        locations.RemoveAt(i);//Here is why locations was changed from an array to a List.
                        warning = false;
                    }
                }
            }
            // Catches IORException thrown when records are deleted from locations List.
            catch (IndexOutOfRangeException e)
            {
                logger.LogInfo("All null references have been removed.\n");
            }


            ITrackable locationA;
            ITrackable locationB;
            ITrackable permLocA = null;
            ITrackable permLocB = null;
            double distanceBetweenLocations;
            double permanentDistance = 0;


            //Changed locations.Length to locations.Count to accomodate changing locations from array to List.
            for (int i = 0; i < locations.Count; i++)
            {
                locationA = locations[i];

                double latitudeA = locationA.Location.Latitude;
                double longitudeA = locationA.Location.Longitude;

                GeoCoordinate coordinateA = new GeoCoordinate(latitudeA, longitudeA);

                foreach (var otherLocation in locations)
                {
                    locationB = otherLocation;
                    double latitudeB = locationB.Location.Latitude;
                    double longitudeB = locationB.Location.Longitude;
                    GeoCoordinate coordinateB = new GeoCoordinate(latitudeB, longitudeB);
                    distanceBetweenLocations = coordinateA.GetDistanceTo(coordinateB);
                    if (distanceBetweenLocations > permanentDistance)
                    {
                        permLocA = locationA;
                        permLocB = locationB;
                        permanentDistance = distanceBetweenLocations;
                    }
                }
            }

            // cleaned up report and made it clearer, rounded distance to .1km.
            Console.WriteLine("The longest distance between Taco Bells is {0}km\nbetween {1} and {2}",
                               Math.Round(permanentDistance / 1000, 1), permLocA.Name, permLocB.Name);
            Console.ReadLine();
        }
    }
}