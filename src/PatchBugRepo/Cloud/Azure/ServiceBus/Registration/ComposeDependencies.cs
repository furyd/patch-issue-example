using MassTransit;
using Microsoft.Extensions.Options;
using PatchBugRepo.Cloud.Azure.ServiceBus.Settings;
using PatchBugRepo.Features.Example.Registration;

namespace PatchBugRepo.Cloud.Azure.ServiceBus.Registration;

public static class ComposeDependencies
{
    public static void RegisterServiceBus(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(RegisterServiceBus);
        builder.Services.Configure<ServiceBusSettings>(builder.Configuration.GetSection(nameof(ServiceBusSettings)));
    }

    private static void RegisterServiceBus(IBusRegistrationConfigurator registrationConfiguration)
    {
        registrationConfiguration.UsingAzureServiceBus((context, factoryConfiguration) =>
        {
            var serviceBusSettings = context.GetRequiredService<IOptions<ServiceBusSettings>>().Value;

            factoryConfiguration.UseNewtonsoftJsonSerializer();

            factoryConfiguration.AddExampleFeature(serviceBusSettings);

            factoryConfiguration.Host(serviceBusSettings.ConnectionString);
            factoryConfiguration.ConfigureEndpoints(context);
        });
    }
}
