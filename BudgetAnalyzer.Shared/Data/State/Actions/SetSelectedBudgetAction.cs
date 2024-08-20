namespace BudgetAnalyzer.Shared.State;

public record SetSelectedBudgetAction(Guid SelectedBudgetId): IAction
{
    public AnalyzerState UpdateState(AnalyzerState state) => state with { Settings = state.Settings with { CurrentBudgetId = SelectedBudgetId } };
}
