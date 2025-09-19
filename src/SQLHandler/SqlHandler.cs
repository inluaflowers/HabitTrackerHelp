using Microsoft.Data.Sqlite;

namespace SQLHandler;

public class SqlHandler
{
    private const string ConnectionString = "Data Source=data.db";

    public static void CreateTable(string tableName, Dictionary<string, string> keyNameValueType )
    {
        List<string> listKvp = [];

        keyNameValueType.ToList().ForEach(kvp => listKvp.Add($"{kvp.Key} {kvp.Value}"));

        var sql = $@"
            CREATE TABLE IF NOT EXISTS [{tableName}](
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            {string.Join(',', listKvp)})";

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var cmd = new SqliteCommand(sql, connection);
        cmd.ExecuteNonQuery();
    }
}