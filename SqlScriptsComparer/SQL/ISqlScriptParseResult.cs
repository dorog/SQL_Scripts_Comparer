namespace SQL;

internal interface ISqlScriptParseResult
{
    internal bool IsSuccess { get; }

    internal void AddSqlScriptParseResult(SqlScriptResult sqlScriptResult);
}
