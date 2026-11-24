using System.Collections.Generic;

namespace WeatgerApp;

/// <summary>
/// 画面に渡す天気データのまとめ（現在の天気 ＋ 7日間予報）
/// </summary>
public class WeatherData {
    public CurrentWeather Current { get; set; } = new();
    public List<DailyForecast> DailyList { get; set; } = new();
}

/// <summary>
/// 現在の天気データ
/// </summary>
public class CurrentWeather {
    public double Temperature { get; set; }           // 気温 (℃)
    public int Humidity { get; set; }                 // 湿度 (%)
    public double WindSpeed { get; set; }             // 風速 (m/s)
    public string WeatherDescription { get; set; } = string.Empty; // 天気（日本語）
}

/// <summary>
/// 1日分の天気予報データ（7日分リストにして使う）
/// </summary>
public class DailyForecast {
    public string Date { get; set; } = string.Empty;               // 日付
    public string WeatherDescription { get; set; } = string.Empty; // 天気（日本語）
    public double MaxTemp { get; set; }                            // 最高気温 (℃)
    public double MinTemp { get; set; }                            // 最低気温 (℃)
    public int PrecipitationProb { get; set; }                     // 降水確率 (%)
}
