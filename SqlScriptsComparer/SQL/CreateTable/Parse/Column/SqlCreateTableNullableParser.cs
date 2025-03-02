using Microsoft.SqlServer.TransactSql.ScriptDom;
using SQL.Shared;

namespace SQL.CreateTable.Parse;

internal static class SqlCreateTableNullableParser
{
    internal static bool Parse(TSqlParserToken[] tokens, ref int startIndex)
    {
        if (IgnoreCaseStringComparer.Equals("NOT", tokens[startIndex].Text) &&
            IgnoreCaseStringComparer.Equals("NULL", tokens[startIndex + 1].Text))
        {
            startIndex += 2;
            return false;
        }
        else
        {
            startIndex++;
            return true;
        }
    }
}