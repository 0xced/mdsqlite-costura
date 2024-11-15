using System;
using System.Reflection;
using Microsoft.Data.Sqlite;
using SQLitePCL;

SQLite3Provider_dynamic_cdecl.Setup("e_sqlite3", new ModuleGetFunctionPointer("e_sqlite3"));
raw.SetProvider(new SQLite3Provider_dynamic_cdecl());

using var connection = new SqliteConnection("Data Source=:memory:");
connection.Open();
using var command = new SqliteCommand("select sqlite_version()", connection);
var version = command.ExecuteScalar();

var assembly = typeof(SqliteConnection).Assembly;
var info = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? assembly.GetName().Version.ToString();
Console.WriteLine($"✔️ {assembly.GetName().Name} {info} is working with Costura and {raw.GetNativeLibraryName()} version {version}");