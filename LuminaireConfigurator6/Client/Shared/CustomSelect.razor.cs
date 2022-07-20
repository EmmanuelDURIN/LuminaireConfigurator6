﻿using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Shared
{
  public partial class CustomSelect<TItem,TValue,TDisplay> : ComponentBase
  {
    [Parameter]
    public int Size { get; set; } = 1;
    [Parameter]
    public TItem? Selected { get; set; }
    [Parameter]
    public IEnumerable<TItem>? Items { get; set; } = Enumerable.Empty<TItem>();
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
    [Parameter, EditorRequired]
    public Func<TItem, TValue> ValueSelector { get; set; } = null!;
    [Parameter, EditorRequired]
    public Func<TItem, TDisplay> DisplaySelector { get; set; } = null!;
    [Parameter]
    public EventCallback<TItem> SelectedChanged { get; set; }

    private TValue? selectedValue { get; set; }
    public TValue? SelectedValue
    {
      get => selectedValue;
      set
      {
        selectedValue = value;
        Selected = Items.FirstOrDefault(i =>  ValueSelector(i)?.ToString()?.Equals(value?.ToString()) == true);
        SelectedChanged.InvokeAsync(Selected);
      }
    }
  }
}
