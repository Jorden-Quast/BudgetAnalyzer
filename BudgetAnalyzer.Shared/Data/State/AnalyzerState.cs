using BudgetAnalyzer.Shared.Data;
using System.Collections.Immutable;
using System.Text.Json;

namespace BudgetAnalyzer.Shared.State;

public record AnalyzerState
{
    public AppSettings Settings { get; init; }
    public ImmutableList<Budget> AvailableBudgets { get; init; }
    public Budget? SelectedBudget => AvailableBudgets.FirstOrDefault(b => b.Id == Settings.CurrentBudgetId);

    public AnalyzerState()
    {
        AvailableBudgets = ImmutableList.Create([Budget.Default]);
        Settings = new AppSettings(AvailableBudgets.First().Id);
    }

    public string ToJson(bool writeIndented = false) => JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = writeIndented});
    public static AnalyzerState FromJson(string jsonString) => FromJsonOrDefault(jsonString) ?? throw new ArgumentNullException($"{nameof(jsonString)} could not be parsed");
    public static AnalyzerState? FromJsonOrDefault(string jsonString) => JsonSerializer.Deserialize<AnalyzerState>(jsonString);
}
