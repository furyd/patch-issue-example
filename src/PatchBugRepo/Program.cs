using PatchBugRepo.Cloud.Azure.ServiceBus.Registration;
using PatchBugRepo.Features.Example.Registration;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServiceBus();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseHttpsRedirection();

app.AddExampleFeature();

await app.RunAsync();
