using System;
using System.IO;
using Microsoft.Data.Sqlite; // ← エラーが出る場合はNuGetでインストールしてください

// SQLiteデータベースへの接続と初期化を担当するクラス
public static class Database {
    // DBファイルの保存場所
    private static readonly string DatabasePath =
        Path.Combine(AppContext.BaseDirectory, "products.db");

    // SQLiteへ接続するための接続文字列
    private static readonly string ConnectionString =
        $"Data Source={DatabasePath}";

    // DBファイルの保存場所を外部から確認するための読み取り専用プロパティ
    public static string FilePath => DatabasePath;

    // 新しいSqliteConnectionを生成して返す
    public static SqliteConnection GetConnection() {
        return new SqliteConnection(ConnectionString);
    }

    // DBの初期化処理
    public static void Initialize() {
        
        using var connection = GetConnection();

        // DBを開く
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Products(
                Id      INTEGER PRIMARY KEY AUTOINCREMENT,
                Name    TEXT NOT NULL,
                Price   INTEGER NOT NULL CHECK (Price >= 0)
            );
            """;

        // SQLを実際に実行してテーブルを作成する命令（必須）
        command.ExecuteNonQuery();
    }
}