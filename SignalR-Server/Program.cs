using Microsoft.AspNetCore.SignalR;
using SignalR_Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("brodcast", async (string message, IHubContext<NotificationHub, INotificationClient> hubContext) =>
    {
        await hubContext.Clients.All.ReceiveMessageFromServer($"broadcast:{message}");
        return Results.NoContent();
    });

app.UseHttpsRedirection();

//app.UseEndpoints(ep =>
//    ep.MapHub<NotificationHub>("/hubs-notify")
//);

app.MapHub<NotificationHub>("/hubs/notify");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}