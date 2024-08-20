﻿using System.Collections.Immutable;

namespace BudgetAnalyzer.Shared.Data;

public record BudgetCategory(string Name, Percentage Percentage, decimal? Cutoff) 
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public static BudgetCategory Default => new("Default Cagetory", 0, null); 
}

public sealed record Budget(string Name, ImmutableList<BudgetCategory> Categories)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public static Budget Default => new("Default Budget", []);

    public bool IsValid(out string? errorMessage)
    {
        errorMessage = null;
        if (Categories.Sum(c => c.Percentage) > 100)
            errorMessage = "Percentages should sum to no more that 100%";

        return string.IsNullOrWhiteSpace(errorMessage);
    }

    // Equality Stuff
    public bool Equals(Budget? other)
    {
        if(other == null) return false;
        return Id == other.Id;
    }

    public bool ValueEquals(Budget? other)
    {
        if (other == null) return false;
        return Name == other.Name
               && Categories.SequenceEqual(other.Categories);
    } 

    public override int GetHashCode() => Id.GetHashCode();
}
