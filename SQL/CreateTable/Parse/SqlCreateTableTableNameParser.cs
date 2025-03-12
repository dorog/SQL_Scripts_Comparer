using Microsoft.SqlServer.TransactSql.ScriptDom;
using SQL.Shared;

namespace SQL.CreateTable.Parse;

internal static class SqlCreateTableTableNameParser
{
    internal static string Parse(TSqlParserToken[] tokens, ref int startIndex)
    {
        if (tokens[startIndex + 1].TokenType == TSqlTokenType.Dot)
        {
            return SqlParserTokenTextMerger.MergeTexts(tokens, ref startIndex, 3);
        }
        else
        {
            return tokens[startIndex].Text;
        }
    }
}