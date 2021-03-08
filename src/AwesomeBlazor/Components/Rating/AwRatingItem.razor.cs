using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace AwesomeBlazor.Components.Rating
{
    public partial class AwRatingItem : BaseComponent
    {
        [CascadingParameter]
        private AwRating Rating { get; set; }

        [Parameter] public int ItemValue { get; set; }

        internal string Name { get; set; }

        internal bool IsActive { get; set; }

        private bool IsChecked => ItemValue == Rating?.SelectedValue;


        /// <summary>
        /// The Size of the icon.
        /// </summary>
        [Parameter] public Size Size { get; set; } = Size.Medium;

        /// <summary>
        /// The color of the component. It supports the theme colors.
        /// </summary>
        [Parameter] public Color Color { get; set; } = Color.Primary;

        /// <summary>
        /// If true, the controls will be disabled.
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// If true, the item will be readonly.
        /// </summary>
        [Parameter] public bool ReadOnly { get; set; }

        /// <summary>
        /// Fires when element clicked.
        /// </summary>
        [Parameter] public EventCallback<int> ItemClicked { get; set; }

        /// <summary>
        /// Fires when element hovered.
        /// </summary>
        [Parameter] public EventCallback<int?> ItemHovered { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Name = SelectIcon();
        }

        private string SelectIcon()
        {
            if (Rating == null)
                return null;
            if (Rating.HoveredValue.HasValue && Rating.HoveredValue.Value >= ItemValue)
            {
                // full icon when @RatingItem hovered
                return Rating.FullIcon;
            }
            else if (Rating.SelectedValue >= ItemValue)
            {
                if (Rating.HoveredValue.HasValue && Rating.HoveredValue.Value < ItemValue)
                {
                    // empty icon when equal or higher RatingItem value clicked, but less value hovered 
                    return Rating.EmptyIcon;
                }
                else
                {
                    // full icon when equal or higher RatingItem value clicked
                    return Rating.FullIcon;
                }
            }
            else
            {
                // empty icon when this or higher RatingItem is not clicked and not hovered
                return Rating.EmptyIcon;
            }
        }

        // rating item lose hover
        private async Task HandleMouseOut(MouseEventArgs e)
        {
            if (Disabled) return;
            if (Rating == null)
                return;

            IsActive = false;
            await ItemHovered.InvokeAsync(null);
        }

        private void HandleMouseOver(MouseEventArgs e)
        {
            if (Disabled) return;

            IsActive = true;
            ItemHovered.InvokeAsync(ItemValue);
        }

        private void HandleClick(MouseEventArgs e)
        {
            if (Disabled) return;
            IsActive = false;
            if (Rating?.SelectedValue == ItemValue)
            {
                ItemClicked.InvokeAsync(0);
            }
            else
            {
                ItemClicked.InvokeAsync(ItemValue);
            }
        }
    }
}
