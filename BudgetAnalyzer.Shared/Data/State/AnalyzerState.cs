using BudgetAnalyzer.Shared.Data;

namespace BudgetAnalyzer.Shared.State;
public record AnalyzerState
{
    public Budget? CurrentBudget { get; init; }
    public IEnumerable<Budget> AvailableBudgets { get; init; } = new List<Budget>() { Budget.Default, Budget.Default, Budget.Default};

    public int CounterValue { get; init; }

    public AnalyzerState() => CounterValue = 0;

}
