using Microsoft.Data.Sqlite;

namespace SQLiteProductSample;

public static class Database
{
    private static readonly string DatabasePath =
        Path.Combine(AppContext.BaseDirectory, "products.db");

    private static readonly string ConnectionString =
        $"Data Source={DatabasePath}";

    public static string FilePath => DatabasePath;

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection(ConnectionString);
    }

    public static void Initialize()
    {
        using var connection = GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
        """
        CREATE TABLE IF NOT EXISTS Products (
            Id    INTEGER PRIMARY KEY AUTOINCREMENT,
            Name  TEXT NOT NULL,
            Price INTEGER NOT NULL CHECK (Price >= 0)
        );
        """;

        command.ExecuteNonQuery();
    }
}
