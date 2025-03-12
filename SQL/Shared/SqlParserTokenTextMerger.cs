using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace SQL.Shared;

internal static class SqlParserTokenTextMerger
{
    internal static string MergeTexts(TSqlParserToken[] tokens, ref int startIndex, int length)
    {
        // TODO: Use LINQ 'Take'
        string mergedTexts = "";
        for (int i = 0; i < length; i++)
        {
            mergedTexts += tokens[startIndex].Text;
            startIndex++;
        }

        return mergedTexts;
    }
}