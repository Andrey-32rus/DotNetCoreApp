using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;

namespace CurrencyService.Hubs
{
    public class CurrenciesHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            var context = Context.GetHttpContext();
            var headers = context.Request.Headers;
            bool isTokenPresent = headers.TryGetValue("Authorization", out StringValues token);
            
            if (isTokenPresent == true && token.Count == 1)
            {
                var split = token[0].Split(' ');
                if (split != null && split.Length == 2 && split[0] == "Bearer" && split[1] == "token")
                {
                    return base.OnConnectedAsync();
                }
            }

            Context.Abort();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
