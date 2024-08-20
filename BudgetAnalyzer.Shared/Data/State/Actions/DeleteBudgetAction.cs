namespace BudgetAnalyzer.Shared.State;

public class DeleteBudgetAction(Guid BudgetIdToDelete) : IAction
{
    public AnalyzerState UpdateState(AnalyzerState state)
    {
        state = state with { AvailableBudgets = state.AvailableBudgets.RemoveAll(b => b.Id == BudgetIdToDelete) };

        if(BudgetIdToDelete == state.Settings.CurrentBudgetId)
        {
            Guid newSelection = state.AvailableBudgets.Select(b => b.Id).FirstOrDefault();
            state = (new SetSelectedBudgetAction(newSelection)).UpdateState(state);
        }

        return state;
    }
}
