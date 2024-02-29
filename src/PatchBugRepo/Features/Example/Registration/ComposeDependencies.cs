using MassTransit;
using PatchBugRepo.Cloud.Azure.ServiceBus.Settings;
using PatchBugRepo.Features.Example.Constants;
using PatchBugRepo.Features.Example.Controllers;
using PatchBugRepo.Features.Example.Models;

namespace PatchBugRepo.Features.Example.Registration;

public static class ComposeDependencies
{
    public static void AddExampleFeature(this IEndpointRouteBuilder builder)
    {
        builder.MapPatch(Routes.Root, ExampleController.Update);
    }

    public static void AddExampleFeature(this IServiceBusBusFactoryConfigurator builder, ServiceBusSettings settings)
    {
        builder.Message<PatchMessageModel<UserModel>>(topologyConfiguration =>
            {
                topologyConfiguration.SetEntityName(settings.TopicSettings.Example);
            });
    }
}
