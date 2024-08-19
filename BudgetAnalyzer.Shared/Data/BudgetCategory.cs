namespace BudgetAnalyzer.Shared.Data;

public record BudgetCategory(string Name, decimal Percentage, decimal? Cutoff) 
{
    public static readonly BudgetCategory Default = new("Default Cagetory", 0, null); 
}

public class Budget : IEquatable<Budget>
{
    public string Name { get; init; }
    public IEnumerable<BudgetCategory> Categories { get; init; }

    public Budget(string name, IEnumerable<BudgetCategory> categories)
    {
        Name = name;
        Categories = categories;
    }

    public bool Equals(Budget? other)
    {
        if(other == null) return false;

        return Name == other.Name
               && Categories.SequenceEqual(other.Categories);
    }
    public override bool Equals(object? obj) => Equals(obj as Budget);
    public override int GetHashCode() => HashCode.Combine(Name, Categories.GetHashCode());

    public static bool operator ==(Budget? left, Budget? right) => left?.Equals(right) ?? (left is null && right is null);
    public static bool operator !=(Budget? left, Budget? right) => !(left == right);
}
