namespace SQL.CreateTable;

internal sealed record SqlCreateTableKeyConstraint
{
    internal required string Name { get; init; }
    internal required SqlCreateTableKeyType Type { get; init; }
    internal required SqlCreateTableColumn ReferredColumn { get; init; }
}