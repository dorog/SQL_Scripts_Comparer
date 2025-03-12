using SQL.CreateTable;
using System.Collections.Generic;

namespace SQL;

internal sealed class SqlScriptResult
{
    internal List<SqlCreateTableCommand> SqlCreateTableCommands { get; } = [];

    internal List<string> SqlRawCommands { get; } = [];
}