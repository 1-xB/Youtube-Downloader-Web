using System.Diagnostics;

namespace YoutubeDownloaderAPI.Services;

public class DownloadService : IDownloadService
{
    public Task Download(string link)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckLink(string link)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> GetVideoInfo(string link)
    {
        string arguments = $"--print title --print thumbnail --print duration \"{link}\"";

        ProcessStartInfo info = new()
        {
            FileName ="Assets/yt-dlp",
            Arguments = arguments,
            RedirectStandardOutput = true, // Dostajemy output z yt-dlp
            UseShellExecute = true, 
            CreateNoWindow = true
        };

        return "s";
    }
}