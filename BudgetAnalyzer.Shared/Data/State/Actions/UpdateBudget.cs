using BudgetAnalyzer.Shared.Data;

namespace BudgetAnalyzer.Shared.State;

public class UpdateBudget(Guid BudgetId, Budget NewBudget) : IAction
{
    public AnalyzerState UpdateState(AnalyzerState state)
    {
        List<Budget> currentBugets = state.AvailableBudgets.ToList();
        int replacementIndex = currentBugets.FindIndex(b => b.Id == BudgetId);
        if (replacementIndex == -1) { return state; }

        currentBugets.RemoveAt(replacementIndex);
        currentBugets.Insert(replacementIndex, NewBudget);

        return state with { AvailableBudgets = currentBugets };
    }
}
