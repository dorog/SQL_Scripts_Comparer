using Microsoft.SqlServer.TransactSql.ScriptDom;
using SQL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQL.CreateTable.Parse;

internal static class SqlCreateTableKeyConstraintParser
{
    internal static List<SqlCreateTableKeyConstraint> Parse(
        TSqlParserToken[] tokens,
        ref int startIndex,
        List<SqlCreateTableColumn> createTableColumns)
    {
        startIndex++;

        List<SqlCreateTableKeyConstraint> createTableKeyConstraints = [];

        string createTableKeyConstraintName = tokens[startIndex++].Text;
        SqlCreateTableKeyType createTableKeyConstraintType = GetCreateTableKeyType(tokens, ref startIndex);

        startIndex += 2;

        SqlCreateTableKeyConstraint createTableKeyConstraint = new()
        {
            Name = createTableKeyConstraintName,
            Type = createTableKeyConstraintType,
            ReferredColumn = GetReferredColumn(tokens[startIndex], createTableColumns)
        };

        createTableKeyConstraints.Add(createTableKeyConstraint);

        return createTableKeyConstraints;
    }

    private static SqlCreateTableKeyType GetCreateTableKeyType(TSqlParserToken[] tokens, ref int startIndex)
    {
        if (IgnoreCaseStringComparer.Equals("PRIMARY", tokens[startIndex].Text) &&
            IgnoreCaseStringComparer.Equals("KEY", tokens[startIndex + 1].Text))
        {
            startIndex += 2;
            return SqlCreateTableKeyType.Pimary;
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private static SqlCreateTableColumn GetReferredColumn(TSqlParserToken token, List<SqlCreateTableColumn> createTableColumns)
    {
        return createTableColumns.First(createTableColumn => createTableColumn.ColumnName == token.Text);
    }
}