using BudgetAnalyzer.Shared.State;
using CommunityToolkit.Maui.Storage;

namespace BudgetAnalyzer.Shared.Data;

public static class AppDataTransporter
{
    public static async Task<string?> UploadJsonFile()
    {
        FilePickerFileType allowedFileTypes = new(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".json" } }
                });

        PickOptions options = new() { FileTypes = allowedFileTypes };
        FileResult? fileResult = await FilePicker.PickAsync(options);
        if (fileResult is null) return null;

        Stream fileStream = await fileResult.OpenReadAsync();
        StreamReader reader = new(fileStream);

        string fileText = await reader.ReadToEndAsync();

        return fileText;
    }

    public static async Task DownloadJsonFile(AnalyzerState state) => await FileSaver.SaveAsync("AppData.json", new MemoryStream(state.ToJsonByteArray()));
    public static async Task CopyJson(AnalyzerState state) => await Clipboard.SetTextAsync(state.ToJson());
}
