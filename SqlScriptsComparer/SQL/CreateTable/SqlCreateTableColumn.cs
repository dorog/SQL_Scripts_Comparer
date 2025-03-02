namespace SQL.CreateTable;

internal sealed record SqlCreateTableColumn
{
    internal required string ColumnName { get; init; }
    internal required string ColumnType { get; init; }
    internal required string Identifier { get; init; }
    internal required bool IsNullable { get; init; }
}