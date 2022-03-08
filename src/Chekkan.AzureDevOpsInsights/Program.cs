using CommandLine;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed<Options>(o =>
    {
        Console.WriteLine($"Current Arguments: --organization {o.Organization} " +
        $"--project {o.Project} --test-run-id {o.TestRunId}");
    });

public class Options
{
    [Option("organization", Required = true, HelpText = "azure devops org name")]
    public string Organization { get; set; } = string.Empty;

    [Option("project", Required = true, HelpText = "azure devops project name")]
    public string Project { get; set; } = string.Empty;

    [Option("test-run-id", Required = true, HelpText = "azure devops test run ID")]
    public int TestRunId { get; set; }
}