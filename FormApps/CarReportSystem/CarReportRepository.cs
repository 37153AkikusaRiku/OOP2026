using CarReportSystem;
using Microsoft.Data.Sqlite;
using SQLiteProductSample;
using System.Data;
using System.Drawing.Imaging;
using System.Globalization;

namespace SQLiteProductSample;

public class CarReportRepository
{
    // <summary>
    // データベースからすべての製品情報を取得
    // CRUDを担当

    public List<CarReport> GetAll() {
        // 取得したデータを格納するための空のリストを初期化
        var carReports = new List<CarReport>();

        // 【using 宣言】メソッドを抜けるときに、データベース接続（connection）を自動で安全に閉じます（Dispose）
        using var connection = Database.GetConnection();

        // データベースへの接続を開く
        connection.Open();

        // SQLコマンドを実行するためのオブジェクトを作成
        using var command = connection.CreateCommand();

        // 【Raw文字列リテラル】""" 
        command.CommandText =
        """
    SELECT Id, Date, Author, Maker, CarName, Report, Picture
    FROM CarReports
    ORDER BY Id;
    """;

        // SQLを実行
        using var reader = command.ExecuteReader();

        // 読み込めるデータ（次の行）がある間、ループを繰り返す
        while (reader.Read()) {
            // 取得した各列のデータを Product オブジェクトに変換してリストに追加
            carReports.Add(new CarReport {
                Id = reader.GetInt32(0),
                Date = DateTime.ParseExact(
                    reader.GetString(1),
                    "yyyy-MM-dd", 
                    CultureInfo.InvariantCulture),
                Author = reader.GetString(2),
                Maker = (CarReport.MakerGroup)reader.GetInt32(3),
                CarName = reader.GetString(4),
                Report = reader.GetString(5),
                Picture = reader.IsDBNull(6)
                             ? null: BytesToImage(reader.GetFieldValue<byte[]>(6))

            });

        }
        return carReports;
    } // すべての行の読み込みが終わったらループを抜ける

    // 完成した製品データのリストを呼び出し元に返す



    // ImageをSQLiteへ保存できるbyte[]へ変換する
    private static byte[]? ImageToBytes(Image? image) {
        if (image is null) return null;

        using var stream = new MemoryStream();
        // DBへはPNG形式で保存
        image.Save(stream, ImageFormat.Png);
        return stream.ToArray();
    }

    // SQLiteのBLOB（byte[]）をImageへ変換する
    private static Image BytesToImage(byte[] data) {
        using var stream = new MemoryStream(data);
        using var image = Image.FromStream(stream);
        // MemoryStream破棄後も利用できるようBitmapとしてコピーする。
        return new Bitmap(image);
    }









    //商品を一件追加する。Create（INSERT）に相当する。
    //戻り値として自動裁判されたIdを返す。
    public int Add(CarReport  carReport ) {

        using var connection =Database.GetConnection();

        // DBを開く
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText =
            """
            INSERT INTO CarReports
            (Date, Author, Maker, CarName, Report, Picture)
            VALUES
            ($date, $author, $maker, $carName, $report, $picture);

            SELECT last_insert_rowid();
            """;

        command.Parameters.AddWithValue("$date", carReport.Date);
        command.Parameters.AddWithValue("$author", carReport.Author);
        command.Parameters.AddWithValue("$maker", carReport.Maker);
        command.Parameters.AddWithValue("$carName", carReport.CarName);
        command.Parameters.AddWithValue("$report", carReport.Report);

        // 一つの値を返すSQLを実行する
        var result = command.ExecuteScalar();

        if (result is null) 
            throw new InvalidOperationException("登録した商品のIDを取得できませんでした。");
            return Convert.ToInt32((long)result);
        

        }

    public  void Update(CarReport carReport) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        // 指定したIDの「商品名」と「価格」を書き換えるSQL
        command.CommandText =
            """
            UPDATE CarReports SET Date = $date,
            Author = $author, Maker = $maker,
            CarName = $carName, Report = $report,
            Picture = $picture WHERE Id = $id;";
            """;

        command.Parameters.AddWithValue("$date",carReport.Date);
        command.Parameters.AddWithValue("$author", carReport.Author);
        command.Parameters.AddWithValue("$maker", carReport.Maker);
        command.Parameters.AddWithValue("$carName", carReport.CarName);
        command.Parameters.AddWithValue("$report", carReport.Report);

        // データの書き換え（戻り値なし）なので ExecuteNonQuery を使う
        command.ExecuteNonQuery();
    }

    // 商品を一件削除する。CRUDの「D（Delete）」に相当する。【新規追加】
    public void Delete(CarReport carReport) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        // 指定したIDの行を削除するSQL
        command.CommandText =
            """
            DELETE FROM CarReports
            WHERE Id = $id;";
            """;

        command.Parameters.AddWithValue("$id", carReport.Id);

        command.ExecuteNonQuery();
    }
}

