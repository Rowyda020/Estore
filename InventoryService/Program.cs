using InventoryService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddCors(opt => opt.AddPolicy("AllowAll", p =>
               p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
               .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding")
           ));
var app = builder.Build();
//builder.Services.AddGrpcReflection();
// Configure the HTTP request pipeline.
app.MapGrpcService<InventService>().RequireCors("AllowAll");
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

app.UseCors();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
