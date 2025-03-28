namespace YoutubeDownloaderAPI.Endpoints;

public static class DownloadEndpoints
{
    public static RouteGroupBuilder MapDownloadEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/download");

        app.MapGet("/{link}", async (string link) =>
        {

        });
        
        return group;
    }
}