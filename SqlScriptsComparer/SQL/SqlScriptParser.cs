using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SQL;

internal static class SqlScriptParser
{
    private static readonly TSql160Parser _sql160Parser = new(true, SqlEngineType.All);

    private static readonly Func<TSqlParserToken[], ISqlScriptParseResult>[] _parseSqlTokensFunctions =
    [
        // TODO: Add functions
    ];

    internal static SqlScriptResult ParseSqlScript(string sqlScript)
    {
        string[] sqlCommands = sqlScript.Split("GO\n");

        SqlScriptResult sqlScriptResult = new();
        foreach (string sqlCommand in sqlCommands.Where(sqlCommand => !string.IsNullOrWhiteSpace(sqlCommand)))
        {
            TSqlParserToken[] sqlParserTokens = GetSqlParserTokens(sqlCommand);

            ISqlScriptParseResult[] successfulSqlScriptParseResult = GetSuccessfulSqlScriptParseResult(sqlParserTokens);

            if (successfulSqlScriptParseResult.Length == 1)
            {
                successfulSqlScriptParseResult[0].AddSqlScriptParseResult(sqlScriptResult);
            }
            else
            {
                sqlScriptResult.RawSqlCommands.Add(sqlCommand);
            }
        }

        return sqlScriptResult;
    }

    private static TSqlParserToken[] GetSqlParserTokens(string sqlCommand)
    {
        TSqlFragment? sqlFragment = _sql160Parser.Parse(new StringReader(sqlCommand), out IList<ParseError> errors);

        return sqlFragment.ScriptTokenStream.Where(sqlParserToken => sqlParserToken.TokenType != TSqlTokenType.WhiteSpace)
            .ToArray();
    }

    private static ISqlScriptParseResult[] GetSuccessfulSqlScriptParseResult(TSqlParserToken[] sqlParserTokens)
    {
        return _parseSqlTokensFunctions.Select(parseSqlTokens => parseSqlTokens(sqlParserTokens))
            .Where(sqlScriptParseResult => sqlScriptParseResult.IsSuccess)
            .ToArray();
    }
}