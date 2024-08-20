using BudgetAnalyzer.Shared.Data;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BudgetAnalyzer.Shared.State;

public record AnalyzerState
{
    public AppSettings Settings { get; init; }
    public ImmutableList<Budget> AvailableBudgets { get; init; }

    [JsonIgnore]
    public Budget? SelectedBudget => AvailableBudgets.FirstOrDefault(b => b.Id == Settings.CurrentBudgetId);

    public AnalyzerState()
    {
        AvailableBudgets = ImmutableList.Create([Budget.Default]);
        Settings = new AppSettings(AvailableBudgets.First().Id);
    }

    public string ToJson(bool prettyOutput = true) => JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = prettyOutput});
    public byte[] ToJsonByteArray(bool prettyOutput = true) => Encoding.Default.GetBytes(ToJson(prettyOutput));

    public static AnalyzerState FromJson(string jsonString) => FromJsonOrDefault(jsonString) ?? throw new ArgumentNullException($"{nameof(jsonString)} could not be parsed");
    public static AnalyzerState? FromJsonOrDefault(string jsonString) => JsonSerializer.Deserialize<AnalyzerState>(jsonString);
}
