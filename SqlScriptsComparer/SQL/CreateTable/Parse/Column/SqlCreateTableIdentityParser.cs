using Microsoft.SqlServer.TransactSql.ScriptDom;
using SQL.Shared;

namespace SQL.CreateTable.Parse;

internal static class SqlCreateTableIdentityParser
{
    internal static string Parse(TSqlParserToken[] tokens, ref int startIndex)
    {
        if (IgnoreCaseStringComparer.Equals("IDENTITY", tokens[startIndex].Text))
        {
            return SqlParserTokenTextMerger.MergeTexts(tokens, ref startIndex, 6);
        }
        else
        {
            return string.Empty;
        }
    }
}