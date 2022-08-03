using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace NST.Simple.Api;

public class BackJob : BackgroundService
{
    private readonly SuperService superService;

    public BackJob(SuperService superService)
    {
        this.superService = superService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        superService.DoubleSavedValue();
    }
}