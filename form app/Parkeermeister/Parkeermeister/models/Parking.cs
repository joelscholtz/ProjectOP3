using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeermeister.models
{
    public class LocationForDisplay
    {
        public string coordinatesType { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Parking
    {
        public List<object> entrances { get; set; }
        public List<object> paymentMethods { get; set; }
        public List<object> openingTimes { get; set; }
        public List<object> tariff { get; set; }
        public LocationForDisplay locationForDisplay { get; set; }
        public List<object> contact { get; set; }
        public string identifier { get; set; }
        public string name { get; set; }
    }

    public class RootObject
    {
        public List<Parking> Results { get; set; }
    }
}
