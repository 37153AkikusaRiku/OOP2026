using Microsoft.Data.Sqlite;

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


}
