using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoloTravelerApp.Entity
{
    /// <summary>
    /// This file contains the classes required for Serializing 
    /// and deserializing the response of the Geocode service
    /// </summary>
    public class GeoCodeResponseAddressComponents
    {
        public string zip { get; set; }
        public string country { get; set; }
    }

    public class GeoCodeResponseInput
    {
        public GeoCodeResponseAddressComponents address_components { get; set; }
        public string formatted_address { get; set; }
    }

    public class AddressComponents2
    {
        public string city { get; set; }
        public string county { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
    }

    public class GeoCodeResponseLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class GeoCodeResponseResult
    {
        public AddressComponents2 address_components { get; set; }
        public string formatted_address { get; set; }
        public GeoCodeResponseLocation location { get; set; }
        public int accuracy { get; set; }
        public string accuracy_type { get; set; }
        public string source { get; set; }
    }

    public class GeoCodeResponse
    {
        public GeoCodeResponseInput input { get; set; }
        public List<GeoCodeResponseResult> results { get; set; }
    }
}