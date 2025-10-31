
namespace RazMudBla.Features.Importer;

public class ImporterCompBase : CompBase
{
    [Inject]
    public ICustomDialogService? CustomDialogService { get; set; }

    public string? SampleText { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadAsync();
    }

    public override async Task LoadAsync()
    {
        SampleText = "This is a sample text for the Importer Component.";        
        
        ShowLoading();
        await Task.Delay(TimeSpan.FromSeconds(1)); // Simulate loading delay
        ShowLoading("Taking longer then expected");
        //await Task.Delay(TimeSpan.FromSeconds(2)); // Simulate loading delay
        HideLoading();
    }
}
