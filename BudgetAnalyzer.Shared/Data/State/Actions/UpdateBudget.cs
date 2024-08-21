using BudgetAnalyzer.Shared.Data;
using System.Collections.Immutable;

namespace BudgetAnalyzer.Shared.State;

public record UpdateBudget(Budget updatedBudget) : IAction
{
    public AnalyzerState UpdateState(AnalyzerState state)
    {
        Budget originalBudget = state.AvailableBudgets.Single(b => b.Id == updatedBudget.Id);

        return state with { AvailableBudgets = state.AvailableBudgets.Replace(originalBudget, updatedBudget) };
    }
}
