using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicmansoV2.Shared
{
    public class GeolocationPosition
    {
        public GeolocationCoordinates Coords { get; set; }
    }

    public class GeolocationCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
