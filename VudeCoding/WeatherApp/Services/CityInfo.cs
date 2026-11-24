namespace WeatherApp.Models {
    // 地域（都市）の名前と緯度・経度を保持するクラス
    public class CityInfo {
        public string Name { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
