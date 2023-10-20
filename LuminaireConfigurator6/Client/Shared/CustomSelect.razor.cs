using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace LuminaireConfigurator6.Client.Shared
{
    public partial class CustomSelect<TItem, TValue, TDisplay>
                                      : ComponentBase
    {
        [CascadingParameter]
        private EditContext? CascadedEditContext { get; set; }
        protected internal FieldIdentifier FieldIdentifier { get; set; }
        private TItem? selected;
        [Parameter, EditorRequired]
        public TItem? Selected
        {
            get => selected;
            set => selected = value;
        }
        [Parameter] public EventCallback<TItem> SelectedChanged { get; set; }

        private Expression<Func<TItem>>? selectedExpression { get; set; }
        [Parameter]
        public Expression<Func<TItem>>? SelectedExpression
        {
            get => selectedExpression;
            set => selectedExpression = value;
        }
        [Parameter, EditorRequired]
        public Func<TItem, TDisplay> DisplaySelector { get; set; } = null!;
        [Parameter, EditorRequired]
        public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();
        [Parameter, EditorRequired]
        public Func<TItem, TValue> ValueSelector { get; set; } = null!;
        [Parameter]
        public EventCallback<TValue> SelectedValueChanged { get; set; }
        private TValue? selectedValue;
        public TValue? SelectedValue
        {
            get => selectedValue;
            set
            {
                if (selectedValue?.Equals(value) == false)
                {
                    selectedValue = value;
                    selected = Items.FirstOrDefault(i => value?.Equals(ValueSelector(i)) == true);
                    SelectedValueChanged.InvokeAsync(value);
                    SelectedChanged.InvokeAsync(selected);
                    if (CascadedEditContext != null)
                    {
                        CascadedEditContext.NotifyFieldChanged(FieldIdentifier);
                        CascadedEditContext?.NotifyValidationStateChanged();
                    }
                }
            }
        }
        private void OnValidateStateChanged(object? sender, ValidationStateChangedEventArgs eventArgs)
        {
            StateHasChanged();
        }
        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);
            if (SelectedExpression != null)
                FieldIdentifier = FieldIdentifier.Create(SelectedExpression);
            if (CascadedEditContext != null)
                CascadedEditContext.OnValidationStateChanged += OnValidateStateChanged;
            return base.SetParametersAsync(ParameterView.Empty);
        }
    }
}
