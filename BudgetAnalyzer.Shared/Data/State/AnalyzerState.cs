using BudgetAnalyzer.Shared.Data;
using System.Collections.Immutable;

namespace BudgetAnalyzer.Shared.State;

public record AnalyzerState
{
    public AppSettings Settings { get; init; }
    public ImmutableList<Budget> AvailableBudgets { get; init; }
    public Budget? SelectedBudget => AvailableBudgets.FirstOrDefault(b => b.Id == Settings.CurrentBudgetId);

    public AnalyzerState()
    {
        AvailableBudgets = ImmutableList.Create([Budget.Default]);
        Settings = new AppSettings(AvailableBudgets.First().Id);
    }
}
