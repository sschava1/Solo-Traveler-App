using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoloTravelerApp.Entity
{
    public class WeatherDataResponseCurrently
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public string precipType { get; set; }
        public double temperature { get; set; }
        public double apparentTemperature { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double windSpeed { get; set; }
        public int windBearing { get; set; }
        public double visibility { get; set; }
        public double cloudCover { get; set; }
        public double pressure { get; set; }
        public int uvIndex { get; set; }
    }

    public class WeatherDataResponseDatum
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public long sunriseTime { get; set; }
        public long sunsetTime { get; set; }
        public double moonPhase { get; set; }
        public string precipType { get; set; }
        public double temperatureMin { get; set; }
        public int temperatureMinTime { get; set; }
        public double temperatureMax { get; set; }
        public int temperatureMaxTime { get; set; }
        public double apparentTemperatureMin { get; set; }
        public int apparentTemperatureMinTime { get; set; }
        public double apparentTemperatureMax { get; set; }
        public int apparentTemperatureMaxTime { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double windSpeed { get; set; }
        public int windBearing { get; set; }
        public double visibility { get; set; }
        public double cloudCover { get; set; }
        public double pressure { get; set; }
        public int uvIndex { get; set; }
        public int uvIndexTime { get; set; }
    }

    public class WeatherDataResponseDaily
    {
        public List<WeatherDataResponseDatum> data { get; set; }
    }

    public class WeatherDataResponse
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public WeatherDataResponseCurrently currently { get; set; }
        public WeatherDataResponseDaily daily { get; set; }
    }
}