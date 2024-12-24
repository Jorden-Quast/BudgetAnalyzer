namespace BudgetAnalyzer.Shared.Data;

public record class IncomeState
{
    public static readonly IncomeState Default = new(0, 0, 0, true, new Dictionary<Guid, Percentage>(), new Dictionary<Guid, decimal>());
    public decimal StandardIncome { get; init; }
    public decimal CustomIncome { get; init; }
    public decimal BankAccountBalance { get; init; }
    public bool RespectCutoffs { get; init; }
    public IReadOnlyDictionary<Guid, Percentage> CustomPercentages { get; init; }
    public IReadOnlyDictionary<Guid, decimal> CategoryBalances { get; init; }

    private IncomeState(decimal standardIncome, decimal customIncome, decimal bankAccountBalance, bool respectCutoffs, IReadOnlyDictionary<Guid, Percentage> customPercentages, IReadOnlyDictionary<Guid, decimal> categoryBalances)
    {
        StandardIncome = standardIncome; 
        CustomIncome = customIncome;
        BankAccountBalance = bankAccountBalance;
        RespectCutoffs = respectCutoffs;
        CustomPercentages = customPercentages;
        CategoryBalances = categoryBalances;
    }
}
