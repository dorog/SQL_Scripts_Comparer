namespace SQL;

public static class SqlScriptsComparer
{
    public static string CompareSqlScripts(string leftSqlScript, string rightSqlScript)
    {
        SqlScriptResult leftSqlScriptResult = SqlScriptParser.ParseSqlScript(leftSqlScript);
        SqlScriptResult rightSqlScriptResult = SqlScriptParser.ParseSqlScript(rightSqlScript);

        // TODO: Add real comparing

        return leftSqlScriptResult.RawSqlCommands.Count + "\n\n" + rightSqlScriptResult.RawSqlCommands.Count;
    }
}