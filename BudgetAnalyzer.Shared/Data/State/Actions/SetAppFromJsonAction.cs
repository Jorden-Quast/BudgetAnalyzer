namespace BudgetAnalyzer.Shared.State;

/// <summary> Tries to parse the json string, returning a default state if failed </summary>
public record class SetAppFromJsonAction(string JsonString) : IAction
{
    public AnalyzerState UpdateState(AnalyzerState state) => AnalyzerState.FromJsonOrDefault(JsonString) ?? new AnalyzerState();
}
