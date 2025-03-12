using Microsoft.SqlServer.TransactSql.ScriptDom;
using SQL.Shared;
using System;
using System.Collections.Generic;

namespace SQL.CreateTable.Parse;

internal static class SqlCreateTableTokensParser
{
    private static readonly SqlScriptCreateTableParseResult _failedSqlScriptCreateTableParseResult = new()
    {
        IsSuccess = false,
        SqlCreateTableCommand = null,
    };

    internal static ISqlScriptParseResult ParseSqlTokens(TSqlParserToken[] sqlParserTokens)
    {
        if (StartsWithCreateTable(sqlParserTokens))
        {
            try
            {
                return TryParseSqlTokens(sqlParserTokens);
            }
            catch
            {
                return _failedSqlScriptCreateTableParseResult;
            }
        }
        else
        {
            return _failedSqlScriptCreateTableParseResult;
        }
    }

    private static bool StartsWithCreateTable(TSqlParserToken[] sqlParserTokens)
    {
        return sqlParserTokens.Length > 2 &&
            IgnoreCaseStringComparer.Equals("CREATE", sqlParserTokens[0].Text) &&
            IgnoreCaseStringComparer.Equals("TABLE", sqlParserTokens[1].Text);
    }

    private static SqlScriptCreateTableParseResult TryParseSqlTokens(TSqlParserToken[] sqlParserTokens)
    {
        int currentIndex = 2;

        string tableName = SqlCreateTableTableNameParser.Parse(sqlParserTokens, ref currentIndex);

        currentIndex++;

        if (sqlParserTokens[currentIndex].TokenType == TSqlTokenType.LeftParenthesis)
        {
            currentIndex++;
        }

        List<SqlCreateTableColumn> sqlCreateTableColumns = SqlCreateTableColumnParser.Parse(sqlParserTokens,
            ref currentIndex);

        List<SqlCreateTableKeyConstraint> sqlCreateTableKeyConstraints = SqlCreateTableKeyConstraintParser.Parse(
            sqlParserTokens, ref currentIndex, sqlCreateTableColumns);

        return CreateSuccessfulSqlScriptCreateTableParseResult(tableName, sqlCreateTableColumns,
            sqlCreateTableKeyConstraints);
    }

    private static SqlScriptCreateTableParseResult CreateSuccessfulSqlScriptCreateTableParseResult(
        string tableName,
        List<SqlCreateTableColumn> sqlCreateTableColumns,
        List<SqlCreateTableKeyConstraint> sqlCreateTableKeyConstraints)
    {
        return new SqlScriptCreateTableParseResult
        {
            IsSuccess = true,
            SqlCreateTableCommand = new SqlCreateTableCommand
            {
                TableName = tableName,
                Columns = sqlCreateTableColumns,
                Constraints = sqlCreateTableKeyConstraints
            }
        };
    }
}