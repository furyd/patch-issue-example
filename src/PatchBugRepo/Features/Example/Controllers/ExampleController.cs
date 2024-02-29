using MassTransit;
using PatchBugRepo.Features.Example.Models;
using SystemTextJsonPatch;

namespace PatchBugRepo.Features.Example.Controllers;

public static class ExampleController
{
    public static IResult Update(
        IBus bus,
        Guid id,
        JsonPatchDocument<UserModel> model)
    {
        bus.Publish(new PatchMessageModel<UserModel>(id, model));

        return Results.Ok();
    }
}
