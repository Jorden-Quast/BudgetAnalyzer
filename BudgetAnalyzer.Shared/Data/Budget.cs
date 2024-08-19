using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BudgetAnalyzer.Shared.Data;

public record BudgetCategory(string Name, decimal Percentage, decimal? Cutoff) 
{
    public readonly Guid Id = Guid.NewGuid();

    public static BudgetCategory Default => new("Default Cagetory", 0, null); 
}

public class Budget : IEquatable<Budget>
{
    public string Name { get; init; }
    public IEnumerable<BudgetCategory> Categories { get; init; }

    public readonly Guid Id = Guid.NewGuid();

    public static Budget Default => new("Default Budget", Enumerable.Empty<BudgetCategory>());
    public Budget(string name, IEnumerable<BudgetCategory> categories)
    {
        Name = name;
        Categories = categories;
    }

    public bool IsValid(out string? errorMessage)
    {
        errorMessage = null;
        if (Categories.Sum(c => c.Percentage) > 1)
            errorMessage = "Percentages should sum to at most 1";

        return string.IsNullOrWhiteSpace(errorMessage);
    }

    public bool Equals(Budget? other)
    {
        if(other == null) return false;
        if (Id == other.Id) return true;

        return Name == other.Name
               && Categories.SequenceEqual(other.Categories);
    }
    public override bool Equals(object? obj) => Equals(obj as Budget);
    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Budget? left, Budget? right) => left?.Equals(right) ?? (left is null && right is null);
    public static bool operator !=(Budget? left, Budget? right) => !(left == right);
}
