using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace statejitsss.Helpers
{
    public static class NotificationHelper
    {
        // Scope → List of connection IDs
        private static readonly ConcurrentDictionary<string, HashSet<string>> ScopeConnections = new();

        // Add a connection to a scope
        public static void AddConnection(string scope, string connectionId)
        {
            ScopeConnections.AddOrUpdate(scope,
                _ => new HashSet<string> { connectionId },
                (_, set) =>
                {
                    set.Add(connectionId);
                    return set;
                });
        }

        // Remove a connection from a scope
        public static void RemoveConnection(string scope, string connectionId)
        {
            if (ScopeConnections.TryGetValue(scope, out var set))
            {
                set.Remove(connectionId);
                if (set.Count == 0)
                {
                    ScopeConnections.TryRemove(scope, out _);
                }
            }
        }

        // Send message to all clients
        public static async Task SendMessageToAll(IHubContext<NotificationHub> hubContext, string message)
        {
            await hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }

        // Send message only to clients in a given scope
        public static async Task SendMessage(IHubContext<NotificationHub> hubContext, string scope, string message)
        {
            if (ScopeConnections.TryGetValue(scope, out var connections))
            {
                foreach (var connectionId in connections)
                {
                    await hubContext.Clients.Client(connectionId)
                        .SendAsync("ReceiveMessage", message, connectionId);
                }
            }
        }
    }
}
