using System.Diagnostics;

namespace YoutubeDownloaderAPI.Services;

public class DownloadService : IDownloadService
{
    public async Task<bool> CheckLink(string link)
    {
        string arguments = $"--print title \"{link}\"";

        ProcessStartInfo info = new()
        {
            FileName = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "yt-dlp.exe"),
            Arguments = arguments,
            RedirectStandardError = true,
            UseShellExecute = false, 
            CreateNoWindow = true
        };

        using Process process = new();
        process.StartInfo = info;

        process.Start();
        string output = await process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();

        if (output.StartsWith("ERROR:"))
        {
            return false;
        }

        return true;
    }
    public async Task<string?> GetVideoInfo(string link)
    {
        var arguments = $"--print title --print thumbnail --print duration \"{link}\"";

        ProcessStartInfo info = new()
        {
            FileName = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "yt-dlp.exe"),
            Arguments = arguments,
            RedirectStandardOutput = true, // Dostajemy output z yt-dlp
            RedirectStandardError = true,
            UseShellExecute = false, 
            CreateNoWindow = true
        };

        using Process process = new();
        process.StartInfo = info;

        process.Start();
        string output = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync();

        if (output.StartsWith("Error:"))
        {
            return null;
        }
        
        return output;
    }
}