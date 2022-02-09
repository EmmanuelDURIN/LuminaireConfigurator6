using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Shared
{
  public partial class CustomSelect<TItem,TValue,TDisplay> : ComponentBase
  {
    [Parameter]
    public TItem? Selected { get; set; }
    [Parameter]
    public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
    [Parameter]
    public Func<TItem, TValue>? ValueSelector { get; set; }
    [Parameter]
    public Func<TItem, TDisplay>? DisplaySelector { get; set; }
    [Parameter]
    public EventCallback<TItem> SelectedChanged { get; set; }

    private TValue? selectedValue { get; set; }
    public TValue? SelectedValue
    {
      get => selectedValue;
      set
      {
        selectedValue = value;
        Selected = Items.FirstOrDefault(i => ValueSelector != null && ValueSelector(i)?.ToString()?.Equals(value?.ToString()) == true);
        SelectedChanged.InvokeAsync(Selected);
      }
    }
  }
}
