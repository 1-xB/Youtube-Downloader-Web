using System.Diagnostics;
using YoutubeDownloaderAPI.Services;

namespace YoutubeDownloaderAPI.Endpoints;

public static class DownloadEndpoints
{
    public static RouteGroupBuilder MapDownloadEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/download");

        group.MapGet("/", async (string link, IDownloadService downloadService) =>
        {
            if (!await downloadService.CheckLink(link)) return Results.BadRequest();
            ProcessStartInfo downloadInfo = new()
            {
                FileName = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "yt-dlp.exe"),
                Arguments = $"-f best -o - {link} --progress",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using Process process = new();
            process.StartInfo = downloadInfo;

            process.Start();
            var stream = process.StandardOutput.BaseStream;
            return Results.File(stream, "video/mp4", "video.mp4");
        });
        
        return group;
    }
}