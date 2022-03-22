using Chekkan.AzureDevOpsInsights;
using Cocona;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = Cocona.CoconaApp.CreateBuilder();
builder.Services.AddTransient<TestRunCommandHandler>();

var app = builder.Build();

await app.RunAsync(async (
    [Option(Description = "azure devops org name")] string organization,
    [Option(Description = "azure devops project name")] string project,
    [Option(Description = "azure devops test run ID")] int testRunId,
    ILogger<Program> logger,
    TestRunCommandHandler handler) =>
{
    logger.LogDebug($"Current Arguments: --organization {organization} " +
        $"--project {project} --test-run-id {testRunId}");

    await handler.Handle(new TestRunCommand
    {
        Organization = organization,
        Project = project,
        TestRunId = testRunId
    });
});
