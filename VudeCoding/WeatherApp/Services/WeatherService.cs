using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services {
    public class WeatherService {
        private static readonly HttpClient _httpClient = new HttpClient();

        // 指定した緯度・経度の天気データを非同期で取得するメソッド
        public async Task<WeatherResponse?> GetWeatherAsync(double latitude, double longitude) {
            string latStr = latitude.ToString(CultureInfo.InvariantCulture);
            string lonStr = longitude.ToString(CultureInfo.InvariantCulture);

            string protocol = "https://";
            string subDomain = "api.";
            string domain = "open-meteo.com";
            string path = "/v1/forecast";
            string query = $"?latitude={latStr}&longitude={lonStr}" +
                           "&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m,precipitation" +
                           "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max" +
                           "&wind_speed_unit=ms&timezone=Asia%2FTokyo";

            string url = protocol + subDomain + domain + path + query;

            string jsonResponse = await _httpClient.GetStringAsync(url);

            var weatherData = JsonSerializer.Deserialize<WeatherResponse>(jsonResponse);
            return weatherData;
        }

        // 【追加】5地方（北海道・本州・四国・九州・沖縄）の現在の降水量を一括取得するメソッド
        public async Task<List<WeatherResponse>?> GetRegionPrecipitationsAsync() {
            // 順番：0=北海道(札幌), 1=本州(東京), 2=四国(高松), 3=九州(福岡), 4=沖縄(那覇)
            string lats = "43.0642,35.6895,34.3401,33.5904,26.2124";
            string lons = "141.3469,139.6917,134.0434,130.4017,127.6809";

            string protocol = "https://";
            string subDomain = "api.";
            string domain = "open-meteo.com";
            string path = "/v1/forecast";
            string query = $"?latitude={lats}&longitude={lons}&current=precipitation&timezone=Asia%2FTokyo";

            string url = protocol + subDomain + domain + path + query;

            string jsonResponse = await _httpClient.GetStringAsync(url);

            // 複数地点を指定するとJSONは配列（List）で返ってきます
            var regionList = JsonSerializer.Deserialize<List<WeatherResponse>>(jsonResponse);
            return regionList;
        }

        public static string ConvertWeatherCodeToJapanese(int code) {
            return code switch {
                0 => "快晴",
                1 => "晴れ",
                2 => "一部曇り",
                3 => "曇り",
                45 or 48 => "霧",
                51 or 53 or 55 => "霧雨",
                56 or 57 => "着氷性の霧雨",
                61 or 63 or 65 => "雨",
                66 or 67 => "着氷性の雨",
                71 or 73 or 75 => "雪",
                77 => "霧雪",
                80 or 81 or 82 => "にわか雨",
                85 or 86 => "にわか雪",
                95 => "雷雨",
                96 or 99 => "ひょうを伴う雷雨",
                _ => "不明"
            };
        }
    }
}
