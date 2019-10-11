
using System.ComponentModel.DataAnnotations;

namespace WeatherDemoApp.Data
{
    public class CityWeatherInfo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        public string CityImageUrl { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Range(20, 120)]
        public int Temperature { get; set; }

        [Required]
        public string FeelsLike { get; set; }
        public string FeelsLikeURL { get; set; }

    }
}
