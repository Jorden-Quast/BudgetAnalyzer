namespace BudgetAnalyzer.Shared.State;

public record SetCounterAction(int CounterVal) : IAction
{
    public AnalyzerState UpdateState(AnalyzerState? state)
    {
        if(state is null) throw new ArgumentNullException(nameof(state));

        return state with { CounterValue = CounterVal };
    }
}
