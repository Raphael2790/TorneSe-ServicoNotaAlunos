using TorneSe.ServicoNotaAlunos.IOC;
using TorneSe.ServicoNotaAlunos.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.AddEnvironmentVariables();
    })
    .ConfigureServices(services =>
    {
        services.ConfigurarInjecaoDependencia()
                .AddHostedService<ServicoNotaAlunoWorker>();
                //.AddHostedService<WorkerExemplo>();
    })
    .Build();

await host.RunAsync();
