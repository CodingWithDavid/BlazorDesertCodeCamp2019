
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//locals
using WeatherDemoApp.Data;

namespace WeatherDemoApp.Services
{
    public class CityWeatherService
    {
        private List<CityWeatherInfo> cityInfos = new List<CityWeatherInfo>();

        public CityWeatherService()
        {
            GetCityWeather();
        }

        public async Task<List<CityWeatherInfo>> GetWeatherAsync()
        {
            if (!cityInfos.Any())
            {
                GetCityWeather();
            }
            await Task.CompletedTask;
            return cityInfos;
        }

        public List<CityWeatherInfo> GetAll()
        {
            return cityInfos;
        }

        public async Task<string> AddAsync(CityWeatherInfo entity)
        {
            string result = "";
            //validate the object
            if(entity.Id == 0 && CityNotAdded(entity.City))
            {
                var newId = (from a in cityInfos
                             select a.Id).Max() + 1;
                entity.Id = newId;
                //add to the collection
                cityInfos.Add(entity);
            }
            else
            {
                result = "City is already is in use.";
            }
            await Task.CompletedTask;
            return result;
        }

        public async Task<string> UpdateAsync(CityWeatherInfo entity)
        {
            string result = "";
            var t = from a in cityInfos
                    where a.Id == entity.Id
                    select a;
            if(t.Any())
            {
                CityWeatherInfo old = t.FirstOrDefault();
                old.City = entity.City;
                old.State = entity.State;
                old.Temperature = entity.Temperature;
                old.FeelsLike = entity.FeelsLike;
            }
            else
            {
                result = "Unable to find city to update";
            }
            await Task.CompletedTask;
            return result;
        }

        private bool CityNotAdded(string city)
        {
            bool result = true;
            var t = from a in cityInfos
                    where a.City.ToLower() == city.ToLower()
                    select a;
            result = !t.Any();
            return result;
        }

        private void GetCityWeather()
        {
            CityWeatherInfo data = new CityWeatherInfo()
            {
                City = "Chandler",
                State = "Az",
                FeelsLike = "Nice",
                Temperature = 82,
                Id = 1
            };
            cityInfos.Add(data);
            data = new CityWeatherInfo()
            {
                City = "Odessa",
                State = "Tx",
                FeelsLike = "Windy",
                Temperature = 68,
                Id = 2
            };
            cityInfos.Add(data);
            data = new CityWeatherInfo()
            {
                City = "San Diego",
                State = "Ca",
                FeelsLike = "Beaching",
                Temperature = 74,
                Id = 3
            };
            cityInfos.Add(data);
            data = new CityWeatherInfo()
            {
                City = "Shemya",
                State = "Ak",
                FeelsLike = "Bad",
                Temperature = 35,
                Id = 4
            };
            cityInfos.Add(data);
            data = new CityWeatherInfo()
            {
                City = "Gilbert",
                State = "Az",
                FeelsLike = "Nicer",
                Temperature = 84,
                Id = 5
            };
            cityInfos.Add(data);
        }
    }
}
