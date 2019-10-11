using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace BlazorWithspinnerControl.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate, bool wait = false)
        {
            var rng = new Random();
            return await Populate(rng, startDate, wait);
        }

        private async Task<WeatherForecast[]> Populate(Random rng, DateTime startDate, bool wait)
        {
            if (wait)
                Thread.Sleep(5000);
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
