using System;

namespace BlazorBasic.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureF { get; set; }

        public int TemperatureC => (int)((TemperatureF - 32) /1.8);

        public string Summary { get; set; }
    }
}
