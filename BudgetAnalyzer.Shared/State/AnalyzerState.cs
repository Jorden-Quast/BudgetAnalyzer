namespace BudgetAnalyzer.Shared.State;
public record AnalyzerState
{
    public int CounterValue { get; init; }

    public AnalyzerState() => CounterValue = 0;

}
