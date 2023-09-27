using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Reflection;

namespace LuminaireConfigurator6.Client.Shared
{
    public partial class CustomSelect<TItem, TValue, TDisplay>
                                      : ComponentBase
    {
        [CascadingParameter]
        public EditContext? EditContext { get; set; }
        public ValidationMessageStore? messageStore { get; set; }
        private object? fieldHolder;
        private string? fieldName;
        private MemberExpression? memberInfo;
        private Expression<Func<TItem>> selected = null!;
        [Parameter, EditorRequired]
        public Expression<Func<TItem>> Selected
        {
            get => selected;
            set
            {
                selected = value;
                if (selected != null)
                {
                    memberInfo = GetMemberInfo(selected);
                    fieldHolder = EditContext?.Model;
                    fieldName = memberInfo.Member.Name;
                }
                else
                {
                    memberInfo = null;
                    fieldHolder = null;
                    fieldName = null;
                }
            }
        }
        [Parameter, EditorRequired]
        public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();
        [Parameter, EditorRequired]
        public Func<TItem, TValue> ValueSelector { get; set; } = null!;
        [Parameter, EditorRequired]
        public Func<TItem, TDisplay> DisplaySelector { get; set; } = null!;
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
                    SetModelProperty(value);
                    SelectedValueChanged.InvokeAsync(value);
                }
            }
        }
        private void SetModelProperty(TValue? value)
        {
            if (fieldName != null && fieldHolder != null && ValueSelector != null)
            {
                var newItem = Items.FirstOrDefault(item => ValueSelector(item)?.Equals(value) == true);
                var property = memberInfo?.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(fieldHolder, newItem);
                    // warn form that property has changed value so that validation can occur
                    EditContext?.NotifyFieldChanged(new FieldIdentifier(fieldHolder, fieldName));
                }
            }
        }
        private static MemberExpression GetMemberInfo(Expression method)
        {
            LambdaExpression lambda = (LambdaExpression)method;
            if (lambda.Body.NodeType == ExpressionType.Convert)
                return (MemberExpression)((UnaryExpression)lambda.Body).Operand;
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
                return (MemberExpression)lambda.Body;
            throw new Exception("Not a MemberExpression");
        }
        protected override void OnInitialized()
        {
            if (EditContext != null)
                messageStore = new ValidationMessageStore(EditContext);
        }
    }
}
