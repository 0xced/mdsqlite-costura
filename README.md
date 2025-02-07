This project demonstrates how to package [Microsoft.Data.Sqlite](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/) with [Costura](https://github.com/Fody/Costura) on .NET Framework (4.7.2)

## Instructions

1. Build the solution

```cmd
git clone https://github.com/0xced/mdsqlite-costura
cd mdsqlite-costura
dotnet build -c Release
```

This will build a single `mdsqlite.exe` executable that embeds all the required libraries as resources.

![Screenshot of mdsqlite.exe opened in dnSpy showing all the embedded resources](mdsqlite_resources.png)

2. Run the executable

```cmd
.\src\bin\Release\net472\mdsqlite.exe
```

This will print

```
✔️ Microsoft.Data.Sqlite 9.0.1 is working with Costura and e_sqlite3 version 3.46.1

Embedded resources
  📦 costura.costura.dll.compressed
  📦 costura.costura.pdb.compressed
  📦 costura.metadata
  📦 costura.microsoft.data.sqlite.dll.compressed
  📦 costura.sqlitepclraw.core.dll.compressed
  📦 costura.sqlitepclraw.provider.dynamic_cdecl.dll.compressed
  📦 costura.system.buffers.dll.compressed
  📦 costura.system.memory.dll.compressed
  📦 costura.system.numerics.vectors.dll.compressed
  📦 costura.system.runtime.compilerservices.unsafe.dll.compressed
  📦 costura_win_arm64.e_sqlite3.dll
  📦 costura_win_x64.e_sqlite3.dll
  📦 costura_win_x86.e_sqlite3.dll
```

