using System;

namespace SQL.Shared;

internal static class IgnoreCaseStringComparer
{
    internal static bool Equals(string left, string right)
    {
        return left.Equals(right, StringComparison.OrdinalIgnoreCase);
    }
}