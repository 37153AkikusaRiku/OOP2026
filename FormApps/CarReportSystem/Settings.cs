using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public sealed class Settings {

        private static readonly string FileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CarReportSystem_setting.xml");

        //唯一のSettingオブジェクト
        private static readonly Settings _instance = new Settings();

        //メイン画面に設定した色情報
        public int MainFormBackColor { get; set; }
        = SystemColors.Control.ToArgb();

        //唯一のオブジェクトを取得する            
        public static Settings Instance {
            get { return _instance; }
        }

        //外部からnewできない
        private Settings() { }

        public void Save() {
            var data = new SettingsData {MainFormBackColor = MainFormBackColor};

            using var writer = XmlWriter.Create(FileName);
            var serializer = new XmlSerializer(typeof(SettingsData));


            serializer.Serialize(writer, data);


        }


        public void Load() {
            // ファイルが存在しない場合は、初期値のまま処理を抜ける
            if (!System.IO.File.Exists(FileName)) {
                return;
            }

            try {
                using var reader = XmlReader.Create(FileName);
                var serializer = new XmlSerializer(typeof(SettingsData));

                // ファイルからデータを読み込む
                var data = (SettingsData)serializer.Deserialize(reader);

                // 読み込んだ値を自分自身にセットする
                if (data != null) {
                    MainFormBackColor = data.MainFormBackColor;
                }
            }
            catch (Exception) {
                // ファイルが破損しているなどの場合はエラーにせず初期値で動かす
            }
        }




    }

    //XML保存用のクラス
    public class SettingsData {
        public int MainFormBackColor { get; set; }
    }







}
