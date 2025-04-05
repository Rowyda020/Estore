
using Estore.Services;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();  // Keep for compatibility if needed

// Add gRPC services
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
// Register gRPC clients as services
builder.Services.AddSingleton(services =>
{
    return GrpcChannel.ForAddress("https://localhost:7188"); // Inventory Service Channel
});

builder.Services.AddSingleton(services =>
{
    return GrpcChannel.ForAddress("https://localhost:7108"); // Payment Service Channel
});

// Register gRPC services with channels
builder.Services.AddSingleton<InventorygRPC>(provider =>
{
    var inventoryChannel = provider.GetRequiredService<GrpcChannel>();
    return new InventorygRPC(inventoryChannel); // Inject InventorygRPC with its channel
});

builder.Services.AddSingleton<PaymentgRPC>(provider =>
{
    var paymentChannel = provider.GetRequiredService<GrpcChannel>();
    return new PaymentgRPC(paymentChannel); // Inject PaymentgRPC with its channel
});

builder.Services.AddSingleton<OrderServiceImplementation>();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(7160, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});
var app = builder.Build();

app.UseRouting();

app.MapControllers();
app.MapGrpcService<OrderServiceImplementation>();  

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. For REST API, use the /api endpoints.");

app.Run();
