using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Middleware;
public class BlogWebSocketMiddleware(RequestDelegate next)
{
    private static readonly List<WebSocket> _sockets = [];

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path != "/ws")
        {
            await next(context);
            return;
        }

        if (!context.WebSockets.IsWebSocketRequest)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        _sockets.Add(webSocket);
        await ListenWebSocket(webSocket);
    }

    private static async Task ListenWebSocket(WebSocket socket)
    {
        var buffer = new byte[1024 * 4];
        while (socket.State == WebSocketState.Open)
        {
            WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                _sockets.Remove(socket);
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed", CancellationToken.None);
                return;
            }

            string messageText = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Console.WriteLine("Message received: {0}", messageText);

        }
    }

    public static async Task NotifyUsers(string message)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);

        foreach (var socket in _sockets.Where(s => s.State == WebSocketState.Open))
        {
            await socket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
