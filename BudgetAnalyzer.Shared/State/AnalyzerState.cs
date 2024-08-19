using BudgetAnalyzer.Shared.Data;

namespace BudgetAnalyzer.Shared.State;
public record AnalyzerState
{
    public Budget? CurrentBudget { get; init; }

    public int CounterValue { get; init; }

    public AnalyzerState() => CounterValue = 0;

}
