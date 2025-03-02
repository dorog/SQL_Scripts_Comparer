namespace SQL;

internal interface ISqlScriptParseResult
{
    bool IsSuccess { get; }

    void AddSqlScriptParseResult(SqlScriptResult sqlScriptResult);
}
