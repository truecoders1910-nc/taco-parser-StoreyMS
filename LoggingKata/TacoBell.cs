using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    class TacoBell : ITrackable
    {
        public TacoBell(string[] cells)
        {
            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);
            // need to parse out useless info from string
            Location = new Point(latitude, longitude);
            cells[2] = cells[2].Replace(" (Free trial * Add to Cart for a full POI info)", "");
            cells[2] = cells[2].Replace("Taco Bell ", "");
            cells[2] = cells[2].Replace(".", "");
            cells[2] = cells[2].Replace("/", "");
            Name = cells[2];
        }

        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
