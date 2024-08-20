using BudgetAnalyzer.Shared.Data;
using System.Collections.Immutable;

namespace BudgetAnalyzer.Shared.State;

public record UpdateBudget(Guid BudgetId, string Name, IEnumerable<BudgetCategory> Categories) : IAction
{
    public UpdateBudget(Budget updatedBudget) : this(updatedBudget.Id, updatedBudget.Name, updatedBudget.Categories) { }

    public AnalyzerState UpdateState(AnalyzerState state)
    {
        Budget originalBudget = state.AvailableBudgets.Single(b => b.Id == BudgetId);
        Budget newBudget =  originalBudget with { Name = Name, Categories = Categories.ToImmutableList() };

        return state with { AvailableBudgets = state.AvailableBudgets.Replace(originalBudget, newBudget) };
    }
}
