namespace BudgetAnalyzer.Shared.State;

/// <summary> Tries to parse the json string, doing nothing if parsing failed </summary>
public record class SetAppFromJsonAction(string JsonString) : IAction
{
    public AnalyzerState UpdateState(AnalyzerState state) => AnalyzerState.FromJsonOrDefault(JsonString) ?? state;
}
