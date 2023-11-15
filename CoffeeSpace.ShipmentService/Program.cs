using CoffeeSpace.Core.Extensions;
using CoffeeSpace.Core.Settings;
using CoffeeSpace.ShipmentService.Consumers;
using MassTransit;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureKeyVault();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
        .AddDatadogLogging("Shipment Service"));

builder.Services.AddOptions<AwsMessagingSettings>()
     .Bind(builder.Configuration.GetRequiredSection(AwsMessagingSettings.SectionName))
     .ValidateOnStart();

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.AddConsumer<RequestOrderShipmentConsumer>();
    
    x.UsingAmazonSqs((context, config) =>
    {
        var awsSettings = context.GetRequiredService<IOptions<AwsMessagingSettings>>().Value;
        config.Host(awsSettings.Region, hostConfig =>
        {
            hostConfig.AccessKey(awsSettings.AccessKey);
            hostConfig.SecretKey(awsSettings.SecretKey);
        });   
        config.UseNewtonsoftJsonSerializer();
        config.UseNewtonsoftJsonDeserializer();

        config.ConfigureEndpoints(context);
    });
});

builder.Services.AddHealthChecks();
var app = builder.Build();

app.UseHealthChecks("/_health");

app.Run();