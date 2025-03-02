namespace SQL;

public static class SqlScriptsComparer
{
    public static string CompareSqlScripts(string leftSqlScript, string rightSqlScript)
    {
        SqlScriptResult leftSqlScriptResult = SqlScriptParser.ParseSqlScript(leftSqlScript);
        SqlScriptResult rightSqlScriptResult = SqlScriptParser.ParseSqlScript(rightSqlScript);

        // TODO: Add real comparing

        return leftSqlScriptResult.SqlCreateTableCommands.Count + "/" + leftSqlScriptResult.SqlRawCommands.Count + "\n\n" +
            rightSqlScriptResult.SqlCreateTableCommands.Count + "/" + rightSqlScriptResult.SqlRawCommands.Count;
    }
}