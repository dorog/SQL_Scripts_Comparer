using Microsoft.SqlServer.TransactSql.ScriptDom;
using SQL.Shared;
using System.Collections.Generic;

namespace SQL.CreateTable.Parse;

internal static class SqlCreateTableColumnParser
{
    internal static List<SqlCreateTableColumn> Parse(TSqlParserToken[] tokens, ref int startIndex)
    {
        List<SqlCreateTableColumn> columns = [];

        while (!IgnoreCaseStringComparer.Equals("CONSTRAINT", tokens[startIndex].Text))
        {
            SqlCreateTableColumn column = new()
            {
                ColumnName = tokens[startIndex++].Text,
                ColumnType = SqlCreateTableColumnTypeParser.Parse(tokens, ref startIndex),
                Identifier = SqlCreateTableIdentityParser.Parse(tokens, ref startIndex),
                IsNullable = SqlCreateTableNullableParser.Parse(tokens, ref startIndex)
            };

            columns.Add(column);

            startIndex++;
        }

        return columns;
    }
}