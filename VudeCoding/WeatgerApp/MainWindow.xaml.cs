using System;
using System.Windows;

namespace WeatgerApp;

/// <summary>
/// 画面の操作と表示を担当するクラス
/// </summary>
public partial class MainWindow : Window {
    // データ取得専用のクラスを用意
    private readonly WeatherService _weatherService = new();

    // 東京の緯度・経度（まずは東京固定の最小構成）
    private const double TokyoLatitude = 35.6895;
    private const double TokyoLongitude = 139.6917;

    public MainWindow() {
        InitializeComponent();
    }

    /// <summary>
    /// 「最新の天気を取得」ボタンが押されたときの処理
    /// </summary>
    private async void BtnGetWeather_Click(object sender, RoutedEventArgs e) {
        // 1. 通信前の画面リセットと二重クリック防止
        BtnGetWeather.IsEnabled = false;
        TxtError.Text = "";
        TxtCurrentWeather.Text = "東京の天気データを取得しています...";
        DgWeekly.ItemsSource = null;

        try {
            // 2. WeatherServiceに依頼して、非同期で天気データを取得
            WeatherData data = await _weatherService.GetWeatherAsync(TokyoLatitude, TokyoLongitude);

            // 3. 現在の天気を画面に日本語で表示
            TxtCurrentWeather.Text = $"【東京の現在の天気】\n" +
                                     $"天気：{data.Current.WeatherDescription}　／　" +
                                     $"気温：{data.Current.Temperature:F1} ℃　／　" +
                                     $"湿度：{data.Current.Humidity} %　／　" +
                                     $"風速：{data.Current.WindSpeed:F1} m/s";

            // 4. 7日間の予報リストを表（DataGrid）に流し込む
            DgWeekly.ItemsSource = data.DailyList;
        }
        catch (Exception ex) {
            // 5. 通信失敗時は強制終了せず、原因を赤字で画面に表示
            TxtCurrentWeather.Text = "天気情報の取得に失敗しました。";
            TxtError.Text = ex.Message;
        }
        finally {
            // 成功しても失敗しても、最後にボタンを再び押せるようにする
            BtnGetWeather.IsEnabled = true;
        }
    }
}
