using BudgetAnalyzer.Shared.Data;

namespace BudgetAnalyzer.Shared.State;

public record class SetIncomeStateAction(IncomeState newIncomeState) : IAction
{
    public AnalyzerState UpdateState(AnalyzerState state) => state with { IncomeState = newIncomeState };
}
