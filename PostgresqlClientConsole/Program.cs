using System.Data;
using Npgsql;

string connStr = "Host=localhost;Database=database1;Username=postgres;Password=postgres;Persist Security Info=True";
var conn = new NpgsqlConnection(connStr);
await using var cmd = new NpgsqlCommand("SELECT * FROM public.tbl", conn);
await conn.OpenAsync();
await using var reader = await cmd.ExecuteReaderAsync();
DataTable dt = new DataTable();
dt.Load(reader);

Console.WriteLine(dt);
Console.ReadLine();
 