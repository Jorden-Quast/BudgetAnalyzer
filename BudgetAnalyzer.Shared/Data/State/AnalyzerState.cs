using BudgetAnalyzer.Shared.Data;
using System.Collections.Immutable;

namespace BudgetAnalyzer.Shared.State;
public record AnalyzerState
{
    public Budget? CurrentBudget { get; init; }
    public ImmutableList<Budget> AvailableBudgets { get; init; } = ImmutableList.Create([Budget.Default, Budget.Default, Budget.Default]);

    public int CounterValue { get; init; }

    public AnalyzerState() => CounterValue = 0;

}
