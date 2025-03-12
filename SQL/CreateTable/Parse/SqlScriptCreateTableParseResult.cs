namespace SQL.CreateTable.Parse;

internal sealed class SqlScriptCreateTableParseResult : ISqlScriptParseResult
{
    public required bool IsSuccess { get; init; }
    internal required SqlCreateTableCommand? SqlCreateTableCommand { get; init; }

    public void AddSqlScriptParseResult(SqlScriptResult sqlScriptResult)
    {
        if (SqlCreateTableCommand is not null)
        {
            sqlScriptResult.SqlCreateTableCommands.Add(SqlCreateTableCommand);
        }
    }
}