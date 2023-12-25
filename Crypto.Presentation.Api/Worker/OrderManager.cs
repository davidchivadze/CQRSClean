using AutoMapper;
using Crypto.Application.CQRS.Command.Order;
using Crypto.Application.CQRS.Query.Order;
using MediatR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Crypto.Presentation.Api.Worker
{
    public class OrderManager : BackgroundService
    {
        private readonly HubConnection _hubConnection;
        private bool _isNewMessageReceived = false;
        private List<GetOrderQuery> _orders = new List<GetOrderQuery>();
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;
        public OrderManager(IMapper mapper, IServiceScopeFactory serviceProvider)
        {
            _scopeFactory = serviceProvider;
            _mapper = mapper;
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:7641/orders/GetOrder") // Adjust the hub URL
                .Build();

            _hubConnection.On<GetOrderQuery>("SendOrderUpdate", (message) =>
            {

                _orders.Add(message);

                Console.WriteLine($"Received order update: {message.GetType()}");
                _isNewMessageReceived = true;
            });
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await _hubConnection.StartAsync(stoppingToken);

                while (!stoppingToken.IsCancellationRequested)
                {
                    // Check if a new message has arrived
                    if (_isNewMessageReceived)
                    {
                        if (_orders.Count > 0)
                        {
                            foreach (var order in _orders)
                            {
                                try
                                {
                                    using (var scope = _scopeFactory.CreateScope())
                                    {
                                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                                        await mediator.Send(_mapper.Map<ProcessOrderCommand>(order));
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        Console.WriteLine("New message received. Initiating action...");

                        // Reset the flag
                        _isNewMessageReceived = false;
                        _orders = new List<GetOrderQuery>();
                    }

                    // Perform any other background service logic here

                    await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken); // Adjust the delay as needed
                }
            }
            catch (Exception ex)
            {
                // Handle connection-related exceptions
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                await _hubConnection.StopAsync();
            }
        }
    }
}
