using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp {
    public partial class MainWindow : Window {
        private readonly WeatherService _weatherService = new WeatherService();

        private readonly List<CityInfo> _cities = new()
        {
            new CityInfo { Name = "東京", Latitude = 35.6895, Longitude = 139.6917 },
            new CityInfo { Name = "太田（群馬）", Latitude = 36.2911, Longitude = 139.3753 },
            new CityInfo { Name = "前橋（群馬）", Latitude = 36.3911, Longitude = 139.0608 },
            new CityInfo { Name = "札幌", Latitude = 43.0642, Longitude = 141.3469 },
            new CityInfo { Name = "仙台", Latitude = 38.2682, Longitude = 140.8694 },
            new CityInfo { Name = "名古屋", Latitude = 35.1815, Longitude = 136.9066 },
            new CityInfo { Name = "大阪", Latitude = 34.6937, Longitude = 135.5023 },
            new CityInfo { Name = "広島", Latitude = 34.3853, Longitude = 132.4553 },
            new CityInfo { Name = "福岡", Latitude = 33.5904, Longitude = 130.4017 },
            new CityInfo { Name = "那覇", Latitude = 26.2124, Longitude = 127.6809 }
        };

        public MainWindow() {
            InitializeComponent();

            CityComboBox.ItemsSource = _cities;
            CityComboBox.SelectedIndex = 0;

            // アプリ起動時に日本地図の降水量カラーを更新する
            Loaded += async (s, e) => await UpdateJapanMapColorsAsync();
        }

        // 【追加】5地方の降水量を取得して日本地図の色を塗り替えるメソッド
        private async Task UpdateJapanMapColorsAsync() {
            try {
                var regions = await _weatherService.GetRegionPrecipitationsAsync();
                if (regions != null && regions.Count >= 5) {
                    ApplyRainColor(HokkaidoPolygon, regions[0].Current?.Precipitation ?? 0);
                    ApplyRainColor(HonshuPolygon, regions[1].Current?.Precipitation ?? 0);
                    ApplyRainColor(ShikokuPolygon, regions[2].Current?.Precipitation ?? 0);
                    ApplyRainColor(KyushuPolygon, regions[3].Current?.Precipitation ?? 0);
                    ApplyRainColor(OkinawaPolygon, regions[4].Current?.Precipitation ?? 0);
                }
            }
            catch {
                // 地図の色更新失敗時はデフォルト色のまま維持する
            }
        }

        // 【追加】降水量(mm)に応じてポリゴンの塗りと枠線の色を変えるヘルパーメソッド
        private static void ApplyRainColor(Polygon polygon, double precipMm) {
            if (precipMm <= 0) {
                // 0mm（雨なし）：緑
                polygon.Fill = new SolidColorBrush(Color.FromRgb(134, 239, 172));
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(22, 163, 74));
            } else if (precipMm < 1.0) {
                // 0.1〜0.9mm（弱雨）：水色
                polygon.Fill = new SolidColorBrush(Color.FromRgb(125, 211, 252));
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(2, 132, 199));
            } else if (precipMm < 5.0) {
                // 1.0〜4.9mm（本降り）：青
                polygon.Fill = new SolidColorBrush(Color.FromRgb(59, 130, 246));
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(29, 78, 216));
            } else {
                // 5.0mm以上（強い雨）：濃紺
                polygon.Fill = new SolidColorBrush(Color.FromRgb(30, 58, 138));
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(23, 37, 84));
            }
        }

        private void MapCityButton_Click(object sender, RoutedEventArgs e) {
            if (sender is Button clickedButton && clickedButton.Tag is string cityName) {
                var targetCity = _cities.FirstOrDefault(c => c.Name == cityName);
                if (targetCity != null) {
                    CityComboBox.SelectedItem = targetCity;
                }
            }
        }

        private void HighlightSelectedCityOnMap(string selectedCityName) {
            foreach (var child in JapanMapCanvas.Children) {
                if (child is Button btn && btn.Tag is string cityName) {
                    if (cityName == selectedCityName) {
                        btn.Background = new SolidColorBrush(Color.FromRgb(239, 68, 68));
                        btn.Foreground = Brushes.White;
                    } else {
                        btn.Background = Brushes.White;
                        btn.Foreground = new SolidColorBrush(Color.FromRgb(15, 23, 42));
                    }
                }
            }
        }

        private async void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            await LoadSelectedCityWeatherAsync();
        }

        // 「更新」ボタンが押されたときは、選択中の都市と日本地図の色を両方更新する
        private async void RefreshButton_Click(object sender, RoutedEventArgs e) {
            await LoadSelectedCityWeatherAsync();
            await UpdateJapanMapColorsAsync();
        }

        private async Task LoadSelectedCityWeatherAsync() {
            if (CityComboBox.SelectedItem is not CityInfo selectedCity) {
                return;
            }

            HighlightSelectedCityOnMap(selectedCity.Name);

            try {
                RefreshButton.IsEnabled = false;
                CityComboBox.IsEnabled = false;
                CurrentWeatherText.Text = "取得中...";

                var data = await _weatherService.GetWeatherAsync(selectedCity.Latitude, selectedCity.Longitude);

                if (data?.Current != null) {
                    CurrentTempText.Text = $"{data.Current.Temperature:F1} ℃";
                    CurrentWeatherText.Text = WeatherService.ConvertWeatherCodeToJapanese(data.Current.WeatherCode);
                    CurrentHumidityText.Text = $"湿度: {data.Current.Humidity} %";
                    CurrentWindText.Text = $"風速: {data.Current.WindSpeed:F1} m/s";
                    CurrentPrecipText.Text = $"降水量: {data.Current.Precipitation:F1} mm";
                }

                if (data?.Daily != null) {
                    var forecastItems = new List<DailyForecastItem>();
                    int count = data.Daily.Time.Count;

                    for (int i = 0; i < count; i++) {
                        string dateStr = DateTime.Parse(data.Daily.Time[i]).ToString("MM/dd");
                        string weather = WeatherService.ConvertWeatherCodeToJapanese(data.Daily.WeatherCode[i]);
                        string tempRange = $"{data.Daily.MaxTemperature[i]:F1}℃ / {data.Daily.MinTemperature[i]:F1}℃";
                        string rainProb = $"降水 {data.Daily.PrecipitationProbability[i]}%";

                        forecastItems.Add(new DailyForecastItem {
                            Date = dateStr,
                            WeatherText = weather,
                            TemperatureRange = tempRange,
                            RainProbability = rainProb
                        });
                    }

                    DailyForecastList.ItemsSource = forecastItems;
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"天気の取得に失敗しました。\n詳細: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                CurrentWeatherText.Text = "取得エラー";
            }
            finally {
                RefreshButton.IsEnabled = true;
                CityComboBox.IsEnabled = true;
            }
        }
    }
}
