using BudgetAnalyzer.Shared.Data;

namespace BudgetAnalyzer.Shared.State;

public class DeleteBudgetAction(Guid BudgetIdToDelete) : IAction
{
    public AnalyzerState UpdateState(AnalyzerState state)
    {
        state = state with { AvailableBudgets = state.AvailableBudgets.RemoveAll(b => b.Id == BudgetIdToDelete) };

        if(BudgetIdToDelete == state.Settings.CurrentBudgetId)
        {
            Guid newSelection = state.AvailableBudgets.Select(b => b.Id).FirstOrDefault();
            AppSettings updatedSettings = state.Settings with { CurrentBudgetId = newSelection };
            state = (new UpdateSettingsAction(updatedSettings)).UpdateState(state);
        }

        return state;
    }
}
