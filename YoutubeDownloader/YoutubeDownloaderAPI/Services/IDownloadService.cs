namespace YoutubeDownloaderAPI.Services;

public interface IDownloadService
{
    Task<bool> CheckLink(string link);
    Task<string?> GetVideoInfo(string link);
}