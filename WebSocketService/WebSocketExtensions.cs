using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketService
{
    public static class WebSocketExtensions
    {
        public static Task SendUtf8StringAsync(this WebSocket ws, string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            return ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public static async Task<string> ReceiveUtf8StringAsync(this WebSocket ws)
        {
            byte[] bytes = new byte[4 * 1024];
            var result = await ws.ReceiveAsync(new ArraySegment<byte>(bytes), CancellationToken.None);
            string str = Encoding.UTF8.GetString(bytes);
            return str;
        }
    }
}
