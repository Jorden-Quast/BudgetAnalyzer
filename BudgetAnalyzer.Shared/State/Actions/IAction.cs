namespace BudgetAnalyzer.Shared.State;

public interface IAction
{
    public AnalyzerState UpdateState(AnalyzerState state);
}
