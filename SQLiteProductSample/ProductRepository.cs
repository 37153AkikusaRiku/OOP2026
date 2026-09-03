using Microsoft.Data.Sqlite;
using SQLiteProductSample;

namespace SQLiteProductSample;

public class ProductRepository
{
    // <summary>
    // データベースからすべての製品情報を取得
    // CRUDを担当

    public List<Product> GetAll() {
        // 取得したデータを格納するための空のリストを初期化
        var products = new List<Product>();

        // 【using 宣言】メソッドを抜けるときに、データベース接続（connection）を自動で安全に閉じます（Dispose）
        using var connection = Database.GetConnection();

        // データベースへの接続を開く
        connection.Open();

        // SQLコマンドを実行するためのオブジェクトを作成
        using var command = connection.CreateCommand();

        // 【Raw文字列リテラル】""" 
        command.CommandText =
        """
    SELECT Id, Name, Price
    FROM Products
    ORDER BY Id;
    """;

        // SQLを実行
        using var reader = command.ExecuteReader();

        // 読み込めるデータ（次の行）がある間、ループを繰り返す
        while (reader.Read()) {
            // 取得した各列のデータを Product オブジェクトに変換してリストに追加
            products.Add(new Product {
                // 0番目の列（Id）をint型として取得
                Id = reader.GetInt32(0),

                // 1番目の列（Name）をstring型として取得
                Name = reader.GetString(1),

                // 2番目の列（Price）をint型として取得
                Price = reader.GetInt32(2)
            });
        } // すべての行の読み込みが終わったらループを抜ける

        // 完成した製品データのリストを呼び出し元に返す
        return products;
    }
    //商品を一件追加する。Create（INSERT）に相当する。
    //戻り値として自動裁判されたIdを返す。
    public int Add(string name,int price) {

        using var connection =Database.GetConnection();

        // DBを開く
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText =
            """
            INSERT INTO Products(Name,Price)
            VALUES($name,$price);

            SELECT last_insert_rowid();
            """;

        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$price", price);

        // 一つの値を返すSQLを実行する
        var result = command.ExecuteScalar();

        if (result is null) 
            throw new InvalidOperationException("登録した商品のIDを取得できませんでした。");
            return Convert.ToInt32((long)result);
        

        }

    public  void Update(Product product) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        // 指定したIDの「商品名」と「価格」を書き換えるSQL
        command.CommandText =
            """
            UPDATE Products
            SET Name = $name, Price = $price
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue("$id", product.Id);
        command.Parameters.AddWithValue("$name", product.Name);
        command.Parameters.AddWithValue("$price",product.Price);

        // データの書き換え（戻り値なし）なので ExecuteNonQuery を使う
        command.ExecuteNonQuery();
    }

    // 商品を一件削除する。CRUDの「D（Delete）」に相当する。【新規追加】
    public void Delete(int id) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        // 指定したIDの行を削除するSQL
        command.CommandText =
            """
            DELETE FROM Products
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue("$id", id);

        command.ExecuteNonQuery();
    }
}

