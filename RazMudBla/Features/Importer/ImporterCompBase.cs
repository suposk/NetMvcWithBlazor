
namespace RazMudBla.Features.Importer;

public class ImporterCompBase : CompBase
{
    [Inject]
    public ICustomDialogService? CustomDialogService { get; set; }

    public string? SampleText { get; set; }

    public override async Task LoadAsync()
    {
        SampleText = "This is a sample text for the Importer Component.";
        await base.LoadAsync();
        
        ShowLoading();
        await Task.Delay(TimeSpan.FromSeconds(2)); // Simulate loading delay
        ShowLoading("Taking longer then expected");
        await Task.Delay(TimeSpan.FromSeconds(2)); // Simulate loading delay
        HideLoading();
    }
}
