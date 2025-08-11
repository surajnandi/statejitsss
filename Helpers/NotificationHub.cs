using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.SignalR;
using statejitsss.BAL.Interfaces;

namespace statejitsss.Helpers
{
    public class NotificationHub : Hub
    {
        private readonly IAuthService _authService;

        public NotificationHub(IAuthService authService)
        {
            _authService = authService;
        }

        public override Task OnConnectedAsync()
        {
            var scope = _authService.User.Scope;
            if (!string.IsNullOrEmpty(scope))
            {
                NotificationHelper.AddConnection(scope, Context.ConnectionId);
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var scope = _authService.User.Scope;
            if (!string.IsNullOrEmpty(scope))
            {
                NotificationHelper.RemoveConnection(scope, Context.ConnectionId);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
