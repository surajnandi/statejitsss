using Microsoft.AspNetCore.SignalR;

namespace statejitsss.Helpers
{
    public static class SignalRConfig
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddSignalR();
        }

        public static void MapHubEndpoint<THub>(this IEndpointRouteBuilder endpoints, string path)
            where THub : Hub
        {
            endpoints.MapHub<THub>(path);
        }
    }
}
