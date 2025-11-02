namespace RazMudBla.Features.Tool;

public class ToolCompBase : CompBase
{
    public string ButtonText { get; set; } = "Click Me";
    public int ClickCount { get; set; }

    public async Task OnButtonClicked()
    {
        // Tool method logic here
        ClickCount += 1;
        ShowLoading($"Clicked {ClickCount}.");
        ButtonText = $"{ClickCount}. Click Me Again";
        await Task.Delay(TimeSpan.FromSeconds(1));

        HideLoading();
    }
}
