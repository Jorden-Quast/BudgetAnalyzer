namespace BudgetAnalyzer.Shared.State;

public class StateManager
{
    public AnalyzerState State => _State ?? throw new NullReferenceException($"{nameof(State)} can not be null");
    private AnalyzerState _State = new();

    public void AddAction(IAction action)
    {
        _State = action.UpdateState(_State);
    }
}
