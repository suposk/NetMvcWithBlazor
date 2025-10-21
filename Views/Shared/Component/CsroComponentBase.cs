namespace NetMvcWithBlazor.Views.Shared.Component;

public class CsroComponentBase : ComponentBase, IDisposable
{
    [Parameter]
    public bool IsValidationEnabled { get; set; }

    [Parameter]
    public bool Refresh { get; set; }

    /// <summary>
    /// Callback to other other Components
    /// </summary>
    [Parameter]
    public EventCallback<bool> RefreshChanged { get; set; }

    public bool? IsValid { get; set; }

    public virtual bool IsValidatedAndValid => IsValid.HasValue && IsValid.Value;

    /// <summary>
    /// Show Validation summary only if IsValidationEnabled == true and IsValid was set and not valid
    /// </summary>
    public bool IsValidationSummaryVisible => IsValidationEnabled && IsValid.HasValue && !IsValid.Value;

    public const string LOADING_MESSAGE = "Loading...";
    public const string PROCESSING_MESSAGE = "Processing...";        

    protected bool IsLoading { get; set; }
    protected string LoadingMessage { get; set; } = LOADING_MESSAGE;

    protected bool IsLoadingSecondary { get; set; }
    protected string LoadingMessageSecondary { get; set; } = LOADING_MESSAGE;

    public CancellationTokenSource CancelToken;
    protected bool CancelCalled { get; set; }
    protected bool RefreshCalled { get; set; }

    protected bool Success { get; set; }        

    public virtual bool CanLoad => !IsLoading || RefreshCalled ? true : false;
    public async virtual Task RefreshAsync() 
    {
        RefreshCalled = true;
        await RefreshChanged.InvokeAsync(true);
        await LoadAsync();
        RefreshCalled = false;
    }
    public virtual Task LoadAsync() => Task.CompletedTask;    
    
    public virtual void Cancel()
    {
        CancelCalled = true; // in HandleException will check this propr and reset it
        //HideLoading(); bug
        CancelToken?.Cancel();
        IsLoading = false;
    }

    /// <summary>
    /// Also Create cancelation token
    /// </summary>
    /// <param name="loadingMessage"></param>
    public virtual void ShowLoading(string loadingMessage = LOADING_MESSAGE)
    {
        IsLoading = true;
        CreateToken();
        LoadingMessage = loadingMessage;
        StateHasChanged();
    }

    public virtual void ShowProcessing(string loadingMessage = PROCESSING_MESSAGE)
    {
        IsLoading = true;
        CreateToken();
        LoadingMessage = loadingMessage;
        StateHasChanged();
    }

    /// <summary>
    /// Also cancel token
    /// </summary>
    public virtual void HideLoading()
    {
        IsLoading = false;
        ClearCancelTokon();
        StateHasChanged();
    }

    public virtual void ShowLoadingSecondary(string loadingMessage = LOADING_MESSAGE)
    {
        IsLoadingSecondary = true;
        LoadingMessageSecondary = loadingMessage;
        StateHasChanged();
    }

    public virtual void HideLoadingSecondary()
    {
        IsLoadingSecondary = false;
        StateHasChanged();
    }



    public virtual void Dispose()
    {
        ClearCancelTokon();
    }

    protected void CreateToken()
    {
        CancelToken?.Cancel();
        CancelToken = new CancellationTokenSource();
        CancelToken.Token.ThrowIfCancellationRequested();
    }

    protected void ClearCancelTokon()
    {
        CancelToken?.Cancel();
        //CancelToken = null;
    }

}
