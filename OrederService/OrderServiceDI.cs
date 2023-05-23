using Grpc.Net.Client;
using OrederService.Protos;
using OrederService.Repositories;
using OrederService.Repositories.Intefaces;
using OrederService.Services;
using OrederService.Services.Interfeces;

namespace OrederService
{
    public static class OrderServiceDI
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<OrderInventory.OrderInventoryClient>(sp =>
            {
                var grpcServerUrl = configuration.GetValue<string>("InventoryManagmentServiceUrl");
                var channel = GrpcChannel.ForAddress(grpcServerUrl);
                return new OrderInventory.OrderInventoryClient(channel);
            });
            services.AddScoped<IOrderInventoryService, OrderInventoryService>();
        }
    }
}
