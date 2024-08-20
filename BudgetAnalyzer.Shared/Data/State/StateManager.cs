namespace BudgetAnalyzer.Shared.State;

public class StateManager
{
    public AnalyzerState State => _State ?? throw new NullReferenceException($"{nameof(State)} can not be null");
    private AnalyzerState _State = new();

    private event EventHandler<AnalyzerState>? StateChanged;

    public void AddAction(IAction action)
    {
        _State = action.UpdateState(_State);
        StateChanged?.Invoke(this, _State);
    }

    public void Subscribe(EventHandler<AnalyzerState> action) => StateChanged += action;
    public void Unsubscribe(EventHandler<AnalyzerState> action) => StateChanged -= action;

}
