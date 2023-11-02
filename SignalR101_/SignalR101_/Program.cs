
using SignalR101_.Bussiness;
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
    services.AddTransient<MyBusiness>();
    services.AddSignalR();
    services.AddControllers();
   
});

var app = builder.Build();

app.UseCors();

//https://localhost:7066/myhub
app.MapHub<Myhub>("/myhub");
app.MapHub<MessageHub>("/messagehub");
app.MapControllers();

app.Run();
