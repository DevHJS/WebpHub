// Ignore Spelling: Webp exe
using MetadataExtractor;

namespace WEBPHUB.Models;

public class WebpCenterModel
{
    public string Options { get; set; } = string.Empty;

    public bool IsAnimatedWebp(string path)
    {
        var dirs = ImageMetadataReader.ReadMetadata(path);
        var selectedDir = dirs.SelectMany(dir => dir.Tags)
            .Where(tag => tag.Name.Contains("Animation"));
        Tag tag = selectedDir.FirstOrDefault(tag => tag.Name.Contains("Animation"));
        string result = tag?.Description ?? string.Empty;
        if (result.Contains("true"))
            return true;
        else
            return false;
    }

    public async Task ScriptRunner(string exe, string input, string folderPath, string options = "")
    {
        var filename = Path.GetFileNameWithoutExtension(input);
        var newFilename = Path.Combine(folderPath, $"{filename}.webp");

        var info = new ProcessStartInfo
        {
            FileName = exe,
            Arguments = $@" {options} ""{input}"" -o ""{newFilename}"" ",
            UseShellExecute = false,
            CreateNoWindow = true,
        };
        Process.Start(info);
        await Task.CompletedTask;
    }

    public async Task ScriptRunner(string exe, string input, string folderPath, string options, string format)
    {
        var filename = Path.GetFileNameWithoutExtension(input);
        var newFilename = Path.Combine(folderPath, $"{filename}{format}");

        var info = new ProcessStartInfo
        {
            FileName = exe,
            Arguments = $@" {options} ""{input}"" -o ""{newFilename}"" ",
            UseShellExecute = false,
            CreateNoWindow = true,
        };
        Process.Start(info);
        await Task.CompletedTask;
    }

    public async Task ScriptRunnerBulk(string exe, List<ImageModel> list, string folderPath, string options = "")
    {
        using var proc = new Process();
        proc.StartInfo.FileName = exe;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.CreateNoWindow = true;
        int time = 3000;
        foreach (var item in list)
        {
            var filename = Path.GetFileNameWithoutExtension(item.Location);
            var newFilename = Path.Combine(folderPath, $"{filename}.webp");
            proc.StartInfo.Arguments = $@"{options} ""{item.Location}"" -o ""{newFilename}"" ";
            proc.Start();

            if (item.Size < 55_050_240 && item.Size > 20_971_520) // 50mb and 20mb
                time = 5000;
            else if (item.Size > 55_050_240) // above 50mb
                time = 10_000;

            if (!proc.WaitForExit(time))
                proc.Kill();
            time = 3000;
        }
        await Task.CompletedTask;
    }

    public async Task ScriptRunnerBulk(string exe, List<ImageModel> list, string folderPath, string format, string options = "")
    {
        using var proc = new Process();
        proc.StartInfo.FileName = exe;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.CreateNoWindow = true;
        int time = 3000;
        foreach (var item in list)
        {
            var filename = Path.GetFileNameWithoutExtension(item.Location);
            var newFilename = Path.Combine(folderPath, $"{filename}{format}");
            proc.StartInfo.Arguments = $@"{options} ""{item.Location}"" -o ""{newFilename}"" ";
            proc.Start();

            if (item.Size < 55_050_240 && item.Size > 20_971_520) // 50mb and 20mb
                time = 5500;
            else if (item.Size > 55_050_240) // above 50mb
                time = 10_500;

            if (!proc.WaitForExit(time))
                proc.Kill();
            time = 3000;
        }
        await Task.CompletedTask;
    }
}
