using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatgerApp;

/// <summary>
/// Open-Meteo APIと通信して天気データを取得・変換するクラス
/// </summary>
public class WeatherService {
    // HttpClientはアプリ全体で1つを使い回す（タイムアウトは10秒に設定）
    private static readonly HttpClient _httpClient = new() {
        Timeout = TimeSpan.FromSeconds(10)
    };

    /// <summary>
    /// 指定された緯度・経度の天気情報を非同期で取得する
    /// </summary>
    public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude) {
        // Open-Meteo APIのリクエストURL（現在の天気 + 7日間の予報）
        string url = $"https://open-meteo.com{latitude}&longitude={longitude}" +
                     $"&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m" +
                     $"&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max" +
                     $"&timezone=Asia%2FTokyo";

        try {
            // APIへGETリクエストを送信
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // 失敗（404や500など）なら例外を発生させる

            // 返ってきたJSON文字列を読み取る
            string json = await response.Content.ReadAsStringAsync();

            // JSONをC#のオブジェクトに変換（デシリアライズ）
            var apiResponse = JsonSerializer.Deserialize<OpenMeteoResponse>(json);

            if (apiResponse?.Current == null || apiResponse.Daily == null) {
                throw new Exception("APIから正しい形式のデータが返されませんでした。");
            }

            // 画面用のデータクラス（WeatherData）に詰め替える
            var weatherData = new WeatherData {
                Current = new CurrentWeather {
                    Temperature = apiResponse.Current.Temperature,
                    Humidity = apiResponse.Current.Humidity,
                    WindSpeed = apiResponse.Current.WindSpeed,
                    WeatherDescription = ConvertWeatherCodeToJapanese(apiResponse.Current.WeatherCode)
                }
            };

            // 7日分の予報データをループで追加
            for (int i = 0; i < apiResponse.Daily.Time.Count; i++) {
                weatherData.DailyList.Add(new DailyForecast {
                    Date = apiResponse.Daily.Time[i],
                    WeatherDescription = ConvertWeatherCodeToJapanese(apiResponse.Daily.WeatherCode[i]),
                    MaxTemp = apiResponse.Daily.TempMax[i],
                    MinTemp = apiResponse.Daily.TempMin[i],
                    PrecipitationProb = apiResponse.Daily.PrecipProb[i]
                });
            }

            return weatherData;
        }
        catch (HttpRequestException ex) {
            throw new Exception($"通信エラーが発生しました。インターネット接続を確認してください。\n（詳細: {ex.Message}）");
        }
        catch (TaskCanceledException) {
            throw new Exception("通信がタイムアウトしました。時間をおいて再度お試しください。");
        }
        catch (JsonException) {
            throw new Exception("天気データの解析に失敗しました。");
        }
        catch (Exception ex) {
            throw new Exception($"予期せぬエラーが発生しました: {ex.Message}");
        }
    }

    /// <summary>
    /// APIから返ってくる天気コード（数値）を日本語に変換する
    /// </summary>
    private string ConvertWeatherCodeToJapanese(int code) {
        return code switch {
            0 => "快晴",
            1 or 2 or 3 => "晴れ・曇り",
            45 or 48 => "霧",
            51 or 53 or 55 => "霧雨",
            61 or 63 or 65 => "雨",
            71 or 73 or 75 => "雪",
            80 or 81 or 82 => "にわか雨",
            95 or 96 or 99 => "雷雨",
            _ => "不明"
        };
    }

    // =========================================================================
    // 以下はOpen-Meteo APIのJSON構造をそのまま受け取るための内部専用クラス
    // =========================================================================
    private class OpenMeteoResponse {
        [JsonPropertyName("current")]
        public CurrentDto? Current { get; set; }

        [JsonPropertyName("daily")]
        public DailyDto? Daily { get; set; }
    }

    private class CurrentDto {
        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public int Humidity { get; set; }

        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed { get; set; }
    }

    private class DailyDto {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; } = new();

        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; } = new();

        [JsonPropertyName("temperature_2m_max")]
        public List<double> TempMax { get; set; } = new();

        [JsonPropertyName("temperature_2m_min")]
        public List<double> TempMin { get; set; } = new();

        [JsonPropertyName("precipitation_probability_max")]
        public List<int> PrecipProb { get; set; } = new();
    }
}
