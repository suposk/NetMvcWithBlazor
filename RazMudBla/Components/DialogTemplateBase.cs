namespace RazMudBla.Components;

public class DialogTemplateBase : Microsoft.AspNetCore.Components.ComponentBase
{
    [CascadingParameter] IMudDialogInstance MudDialog { get; set; }

    [Parameter] public string EnteredText { get; set; }

    [Parameter] public string ContentText { get; set; }
    [Parameter] public string Title { get; set; }

    [Parameter] public string ButtonText { get; set; }
    [Parameter] public string CancelText { get; set; }

    [Parameter] public Color Color { get; set; }

    [Parameter] public bool ShowCancel { get; set; } = true;

    [Parameter] public bool ShowEntry { get; set; }

    [Parameter] public WindowDimension? WindowDimensionSize { get; set;}

    protected bool ShowLargeText => WindowDimensionSize != null && ContentText?.Length > 500 && WindowDimensionSize.Height > 50 && WindowDimensionSize.Height > 50;

    protected WindowDimension WindowDimensionSizeOffset => !ShowLargeText ? null : new WindowDimension { Height = WindowDimensionSize.Height - 200, Width = WindowDimensionSize.Width * 3 / 4 };

    // protected string LargeTextStyle => $"width:{WindowDimensionSizeOffset?.Width}px; {WindowDimensionSizeOffset?.Height}:px";
    protected string LargeTextStyle => $"""height:{WindowDimensionSizeOffset?.Height}px;overflow: auto;""";
    public void Submit()
    {
        if (ShowEntry)
        {
            if (!string.IsNullOrWhiteSpace(EnteredText) && EnteredText.Length >= 4)
                MudDialog.Close(DialogResult.Ok(EnteredText));
        }
        else
            MudDialog.Close(DialogResult.Ok(true)); 
    }
    public void Cancel() => MudDialog.Cancel();
}
