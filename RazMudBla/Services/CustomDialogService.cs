namespace RazMudBla.Services;

public class WindowDimension
{
	public int? Width { get; init; }
	public int? Height { get; init; }
}

public interface ICustomDialogService
{
	Task<string> ShowDialogWithEntry(string title, string text, string okText = "Ok", string cancelText = "Cancel");
	Task<bool> ShowDialog(string title, string text, string okText = "Ok", string cancelText = "Cancel");
	Task ShowError(string title, string text, string okText = "Close");
	Task ShowMessage(string title, string text, string okText = "Ok");
	Task<bool> ShowWarning(string title, string text, string okText = "Ok", string cancelText = "Cancel");
	Task<WindowDimension> GetWindowDimensions();
}

public class CustomDialogService : ICustomDialogService
{
	private readonly IJSRuntime _jsRuntime;

	public CustomDialogService(IDialogService dialogService, IJSRuntime JsRuntime)
	{
		_dialogService = dialogService;
		_jsRuntime = JsRuntime;
	}

	private IDialogService _dialogService { get; }
	private DialogTemplateBase DialogTemplateBase { get; }

	private void AddCommonParams(string title, string text, string okText, DialogParameters parameters, string cancelText = "Cancel")
	{
		parameters.Add(nameof(DialogTemplateBase.Title), title);
		parameters.Add(nameof(DialogTemplateBase.ContentText), text);
		parameters.Add(nameof(DialogTemplateBase.ButtonText), okText);
		parameters.Add(nameof(DialogTemplateBase.CancelText), cancelText);
	}

	public async Task<string> ShowDialogWithEntry(string title, string text, string okText = "Ok", string cancelText = "Cancel")
	{
		var parameters = new DialogParameters();
		AddCommonParams(title, text, okText, parameters, cancelText);
		parameters.Add(nameof(DialogTemplateBase.Color), Color.Info);

		string entryVal = null;
		parameters.Add(nameof(DialogTemplateBase.EnteredText), entryVal);
		parameters.Add(nameof(DialogTemplateBase.ShowEntry), true);
        parameters.Add(nameof(DialogTemplateBase.WindowDimensionSize), await GetWindowDimensions());

        var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.Small };
		var userSelect = _dialogService.Show<DialogTemplate>(title, parameters, options);
		var result = await userSelect.Result;
		return result.Data?.ToString();
	}

	public async Task<bool> ShowDialog(string title, string text, string okText = "Ok", string cancelText = "Cancel")
	{
		var parameters = new DialogParameters();
		AddCommonParams(title, text, okText, parameters, cancelText);
		parameters.Add(nameof(DialogTemplateBase.Color), Color.Info);
        parameters.Add(nameof(DialogTemplateBase.WindowDimensionSize), await GetWindowDimensions());

        var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.Small };
		var userSelect = _dialogService.Show<DialogTemplate>(title, parameters, options);
		var result = await userSelect.Result;

		return !result.Canceled;
	}

	public async Task<bool> ShowWarning(string title, string text, string okText = "Ok", string cancelText = "Cancel")
	{
		var parameters = new DialogParameters();
		AddCommonParams(title, text, okText, parameters, cancelText);
		parameters.Add(nameof(DialogTemplateBase.Color), Color.Warning);
        parameters.Add(nameof(DialogTemplateBase.WindowDimensionSize), await GetWindowDimensions());

        var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.Small };
		var userSelect = _dialogService.Show<DialogTemplate>(title, parameters, options);
		var result = await userSelect.Result;

		return !result.Canceled;
	}

	public async Task ShowMessage(string title, string text, string okText = "Ok")
	{
		var parameters = new DialogParameters();
		AddCommonParams(title, text, okText, parameters);
		parameters.Add(nameof(DialogTemplateBase.Color), Color.Info);
		parameters.Add(nameof(DialogTemplateBase.ShowCancel), false);
		parameters.Add(nameof(DialogTemplateBase.WindowDimensionSize), await GetWindowDimensions());

		var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small };
		var userSelect = _dialogService.Show<DialogTemplate>(title, parameters, options);
		var result = await userSelect.Result;
		return;
	}

	public async Task ShowError(string title, string text, string okText = "Close")
	{
		var parameters = new DialogParameters();
		parameters.Add(nameof(DialogTemplateBase.Title), title);
		parameters.Add(nameof(DialogTemplateBase.ContentText), text);
		parameters.Add(nameof(DialogTemplateBase.ButtonText), okText);
		parameters.Add(nameof(DialogTemplateBase.Color), Color.Error);
		parameters.Add(nameof(DialogTemplateBase.ShowCancel), false);
        parameters.Add(nameof(DialogTemplateBase.WindowDimensionSize), await GetWindowDimensions());

        var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.Small };
		var userSelect = _dialogService.Show<DialogTemplate>(title, parameters, options);
		var result = await userSelect.Result;
		return;
	}

	public async Task<WindowDimension> GetWindowDimensions()
	{
		var dimension = await _jsRuntime.InvokeAsync<WindowDimension>("getWindowDimensions");
		return dimension;
	}
}
