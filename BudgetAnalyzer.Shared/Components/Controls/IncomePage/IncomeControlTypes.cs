namespace BudgetAnalyzer.Shared.Controls;

internal class IncomeControlTypes
{
    public string Name { get; }
    public string Tooltip { get; }
    public Type ControlType { get; }

    public static IncomeControlTypes Standard = new("Standard Breakdown", "Breakdown Using Standard Percentages", typeof(StandardBreakdownControl));
    public static IncomeControlTypes Custom = new("Custom Breakdown", "Breakdown Using Custom Percentages", typeof(CustomBreakdownControl));
    public static IncomeControlTypes Balancing = new("Balancing", "Balance Budget against Bank Account", typeof(BalancingControl));
    public static IncomeControlTypes[] ControlTypes = [Standard, Custom, Balancing];

    private IncomeControlTypes(string name, string toolTip, Type controlType)
    {
        Name = name;
        Tooltip = toolTip;
        ControlType = controlType;
    }
}
