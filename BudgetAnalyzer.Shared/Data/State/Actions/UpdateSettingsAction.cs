using BudgetAnalyzer.Shared.Data;

namespace BudgetAnalyzer.Shared.State;

public record UpdateSettingsAction(AppSettings NewSettings): IAction
{
    public AnalyzerState UpdateState(AnalyzerState state) => state with { Settings = NewSettings };
}
