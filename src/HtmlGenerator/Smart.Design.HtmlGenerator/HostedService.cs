using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Smart.Design.HtmlGenerator;

public class HostApplicationLifetimeEventsHostedService : IHostedService
{
    private readonly string[] _args;

    public HostApplicationLifetimeEventsHostedService(string[] args)
    {
        _args = args;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        CommandLineParser commandLineParser = new(_args);
        var commandResponse = commandLineParser.Run();

        Console.WriteLine(commandResponse.GetResponseMessage());
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

}
