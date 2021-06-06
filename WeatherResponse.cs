using System.Collections.Generic;

namespace Restik
{
    public class WeatherResponse
    {
        public MainInfo Main { get; set; }
        public string Name { get; set; }
        public List<WeatherInfo> Weather { get; set; }
    }

    public class MainInfo
    {
        public float Temp { get; set; }
    }

    public class WeatherInfo
    {
        public string Icon { get; set; }
    }
}