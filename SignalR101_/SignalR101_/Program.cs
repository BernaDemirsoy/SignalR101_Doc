
using SignalR101_.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureServices((services) =>
{
    services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        policy.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed(origin=>true)
        );
    });
    services.AddSignalR();
});

var app = builder.Build();

app.UseCors();

//https://localhost:7066/myhub
app.MapHub<Myhub>("/myhub");

app.Run();
