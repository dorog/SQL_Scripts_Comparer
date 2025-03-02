using System.Collections.Generic;

namespace SQL.CreateTable;

internal sealed class SqlCreateTableCommand
{
    internal required string TableName { get; init; }
    internal required List<SqlCreateTableColumn> Columns { get; init; }
    internal required List<SqlCreateTableKeyConstraint> Constraints { get; init; }
}