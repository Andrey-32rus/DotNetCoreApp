// See https://aka.ms/new-console-template for more information

using System.Data;
using Oracle.ManagedDataAccess.Client;

Console.WriteLine("Hello, World!");
await using var conn = new OracleConnection();
await using var cmd = new OracleCommand("call", conn);
await using var reader = await cmd.ExecuteReaderAsync();
DataTable dt = new DataTable();
dt.Load(reader);
