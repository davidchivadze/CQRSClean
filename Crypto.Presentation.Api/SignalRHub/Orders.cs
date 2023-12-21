namespace Crypto.Presentation.Api.SignalRHub
{
    using global::Crypto.Application.CQRS.Query;
    using Microsoft.AspNetCore.SignalR;
    using SignalRSwaggerGen.Attributes;
    using System;
    using System.Threading.Tasks;

    namespace Crypto.Application.CQRS.Handlers.Query
    {
        /// <summary>
        /// Represents a SignalR hub for handling order-related operations.
        /// </summary>
        [SignalRHub("/orders")]
        public class Orders : Hub
        {
            //private CancellationTokenSource _cancellationTokenSource;

            //public override async Task OnConnectedAsync()
            //{
            //    _cancellationTokenSource = new CancellationTokenSource();

            //    await SendGuidsToClients(null,_cancellationTokenSource.Token);
            //    await base.OnConnectedAsync();
            //}

            //public override Task OnDisconnectedAsync(Exception exception)
            //{
            //    _cancellationTokenSource?.Cancel();
            //    return base.OnDisconnectedAsync(exception);
            //}
            /// <summary>
            /// Sends a new order notification to connected clients.
            /// </summary>
            /// <param name="orderId">The ID of the new order.</param>
            public async Task SendGuidsToClients(GetOrderQuery query, CancellationToken token)
            {
                if (query != null)
                {
                    await Clients.All.SendAsync("ReceiveOrderUpdate", query);
                }
            }

        }
    }

}
