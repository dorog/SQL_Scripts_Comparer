using Microsoft.SqlServer.TransactSql.ScriptDom;
using SQL.Shared;

namespace SQL.CreateTable.Parse;

internal static class SqlCreateTableColumnTypeParser
{
    internal static string Parse(TSqlParserToken[] tokens, ref int startIndex)
    {
        if (tokens[startIndex + 1].TokenType == TSqlTokenType.LeftParenthesis)
        {
            return SqlParserTokenTextMerger.MergeTexts(tokens, ref startIndex, 4);
        }
        else
        {
            return tokens[startIndex++].Text;
        }
    }
}