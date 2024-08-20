namespace BudgetAnalyzer.Shared.State;

public class StateManager
{
    private static readonly string DocPath = AppDomain.CurrentDomain.BaseDirectory + "AppData.json";
    public AnalyzerState State => _State;
    private AnalyzerState _State = LoadState();

    private event EventHandler<AnalyzerState>? StateChanged;

    public void AddAction(IAction action)
    {
        _State = action.UpdateState(_State);
        StateChanged?.Invoke(this, _State);
        SaveState();
    }
    
    private static AnalyzerState LoadState()
    {
        if (!File.Exists(DocPath))
        {
            AnalyzerState defaultState = new();
            File.WriteAllText(DocPath, defaultState.ToJson(true));
            return defaultState;
        }

        string serializedState = File.ReadAllText(DocPath);
        return AnalyzerState.FromJson(serializedState);
    }

    private void SaveState()
    {
        string serializedState = _State.ToJson(true);
        File.WriteAllText(DocPath, serializedState);
    }

    public void Subscribe(EventHandler<AnalyzerState> action) => StateChanged += action;
    public void Unsubscribe(EventHandler<AnalyzerState> action) => StateChanged -= action;

}
