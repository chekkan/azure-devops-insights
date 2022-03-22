using Microsoft.Extensions.Logging;

namespace Chekkan.AzureDevOpsInsights;

public class TestRunCommandHandler
{
    private readonly ILogger<TestRunCommandHandler> logger;

    public TestRunCommandHandler(ILogger<TestRunCommandHandler> logger)
        => this.logger = logger;

    public async Task Handle(TestRunCommand command)
    {
        try
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"https://dev.azure.com/{command.Organization}/{command.Project}/_apis/");
            var response = await httpClient.GetAsync($"test/Runs/{command.TestRunId}/results?api-version=6.0");

            logger.LogInformation($"Got response: {response.StatusCode}");
        }
        catch (System.Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }
}

public class TestRunCommand
{
    public string Organization { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public int TestRunId { get; set; }
}