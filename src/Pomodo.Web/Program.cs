using MediatR;
using Microsoft.OpenApi.Models;
using Pomodo.Bootstrap.Configuration;
using Pomodo.Common.Constants;
using Pomodo.Infrastructure.Helpers;
using Pomodo.Infrastructure.Queries;
using Pomodo.Web.Configuration;

const string applicationName = ApplicationInfo.ApiName;
var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddMediatRWithAssemblyScanning();
services.AddSwashbuckle(new OpenApiInfo
{
    Title = applicationName,
    Version = SwashbuckleConfiguration.DefaultVersion
});

services.AddHelpers();

var app = builder.Build();
app.Services.GetRequiredService<IAboutInfoHelper>();
app.MapGet("/api/v1/about", (IMediator mediator) => mediator.Send(new GetAboutInfo.Query()));
app.UseSwashbuckle(applicationName);

app.Run();