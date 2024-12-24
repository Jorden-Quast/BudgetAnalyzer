using BudgetAnalyzer.Shared.Data;
using BudgetAnalyzer.Shared.State;

namespace BudgetAnalyzer.Shared.Controls;

public abstract class IncomePageControl : SubscribedComponent
{
    protected abstract void SetControlToDefault();

    protected void AddBudgetCategories()
    {
        IncomeState stateCopy = State.IncomeState;
        Dictionary<Guid, decimal> balanceCopy = stateCopy.CategoryBalances.ToDictionary();
        Dictionary<Guid, Percentage> percentageCopy = stateCopy.CustomPercentages.ToDictionary();

        var availableCategories = State.SelectedBudget.Categories;
        for (int i = 0; i < State.SelectedBudget.Categories.Count; i++)
        {
            var category = State.SelectedBudget.Categories[i];
            if (!balanceCopy.Keys.Contains(category.Id))
                balanceCopy.Add(category.Id, 0);
            if (!percentageCopy.Keys.Contains(category.Id))
                percentageCopy.Add(category.Id, 0);
        }

        IncomeState updatedState = stateCopy with { CategoryBalances = balanceCopy, CustomPercentages = percentageCopy };
        AddAction(new SetIncomeStateAction(updatedState));
    }

    protected void SetCategoryBalance(decimal newValue, Guid id)
    {
        var balances = State.IncomeState.CategoryBalances.ToDictionary();
        balances[id] = newValue;
        AddAction(new SetIncomeStateAction(State.IncomeState with { CategoryBalances = balances }));
    }
}
