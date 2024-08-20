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
            File.WriteAllText(DocPath, defaultState.ToJson(false));
            return defaultState;
        }
        string serializedState = File.ReadAllText(DocPath);
        if (AnalyzerState.FromJsonOrDefault(serializedState) is not AnalyzerState deserializedState)
        {
            AnalyzerState defaultState = new();
            File.WriteAllText(DocPath, defaultState.ToJson(false));
            return defaultState;
        }

        return deserializedState;
    }

    private void SaveState()
    {
        string serializedState = _State.ToJson(false);
        File.WriteAllText(DocPath, serializedState);
    }

    public void Subscribe(EventHandler<AnalyzerState> action) => StateChanged += action;
    public void Unsubscribe(EventHandler<AnalyzerState> action) => StateChanged -= action;

}
