namespace YoutubeDownloaderAPI.Services;

public interface IDownloadService
{
    Task Download(string link);
    Task<bool> CheckLink(string link);
    Task<string?> GetVideoInfo(string link);
}