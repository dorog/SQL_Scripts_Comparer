using System.Collections.Generic;

namespace SQL;

internal sealed class SqlScriptResult
{
    public List<string> RawSqlCommands { get; } = [];
}