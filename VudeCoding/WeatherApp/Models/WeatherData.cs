using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.Models {
    public class WeatherResponse {
        [JsonPropertyName("current")]
        public CurrentWeather? Current { get; set; }

        [JsonPropertyName("daily")]
        public DailyWeather? Daily { get; set; }
    }

    public class CurrentWeather {
        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public int Humidity { get; set; }

        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed { get; set; }

        // 【追加】現在の降水量 (mm)
        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }
    }

    public class DailyWeather {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; } = new();

        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; } = new();

        [JsonPropertyName("temperature_2m_max")]
        public List<double> MaxTemperature { get; set; } = new();

        [JsonPropertyName("temperature_2m_min")]
        public List<double> MinTemperature { get; set; } = new();

        [JsonPropertyName("precipitation_probability_max")]
        public List<int> PrecipitationProbability { get; set; } = new();
    }

    public class DailyForecastItem {
        public string Date { get; set; } = string.Empty;
        public string WeatherText { get; set; } = string.Empty;
        public string TemperatureRange { get; set; } = string.Empty;
        public string RainProbability { get; set; } = string.Empty;
    }
}
