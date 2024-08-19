namespace BudgetAnalyzer.Shared.State;

public record IncrementCounterAction(int IncrementAmount) : IAction
{
    public AnalyzerState UpdateState(AnalyzerState state)
    {
        int newValue = state.CounterValue + IncrementAmount;

        return state with { CounterValue = newValue };
    }
}
