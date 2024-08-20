using BudgetAnalyzer.Shared.Data;
namespace BudgetAnalyzer.Shared.State;

public class AddBudgetAction : IAction
{
    public AnalyzerState UpdateState(AnalyzerState state)
    {
        return state with { AvailableBudgets = state.AvailableBudgets.Add(Budget.Default) };
    }
}
