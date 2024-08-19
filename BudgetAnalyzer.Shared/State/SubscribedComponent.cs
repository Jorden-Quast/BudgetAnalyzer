using Microsoft.AspNetCore.Components;

namespace BudgetAnalyzer.Shared.State;

public class SubscribedComponent : ComponentBase, IDisposable
{
    [Inject]
    private StateManager StateManager { get; set; } = default!;
    protected AnalyzerState State => StateManager.State;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        StateManager.Subscribe(OnStateHasChanged);
    }
    public void Dispose() => StateManager.Unsubscribe(OnStateHasChanged);


    /// <summary> The action to perform when the state updates </summary>
    protected virtual void OnStateHasChanged(object? sender, AnalyzerState newState) => StateHasChanged();

    /// <summary> Adds an action to be processed by the state manager </summary>
    protected void AddAction(IAction action) => StateManager.AddAction(action);

}
