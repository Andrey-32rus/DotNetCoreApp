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
            var headers = Context.GetHttpContext().Request.Headers;
            bool isTokenPresent = headers.TryGetValue("Authorization", out StringValues token);

            if (isTokenPresent == false || token.Count != 1 || token[0] != "token")
            {
                Context.Abort();
            }
            
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
