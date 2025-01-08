using MassTransit;
using Parser123.Components;
using Parser123.Data;
using Parser123.Messaging.Consumers;
using Parser123.Services;
using System.Diagnostics;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddMassTransit(options =>
{
    options.SetKebabCaseEndpointNameFormatter();

    options.AddConsumer<FetchProductPriceConsumer>();

    options.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("price-fetching", e =>
        {
            e.ConfigureConsumer<FetchProductPriceConsumer>(context);
        });
    });
});

builder.Services.AddHttpClient();

builder.Services.AddScoped<PriceFetcher>();

var app = builder.Build();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
Process.Start(new ProcessStartInfo("http://localhost:5184") { UseShellExecute = true });
app.Run();