using TorneSe.ServicoNotaAlunos.Data.Context;
using TorneSe.ServicoNotaAlunos.IOC;
using TorneSe.ServicoNotaAlunos.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.SetBasePath(hostContext.HostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json")
                .AddEnvironmentVariables();

        hostContext.Configuration = config.Build();
    })
    .ConfigureServices((hostContext,services) =>
    {
        services.ConfigurarInjecaoDependencia()
                .AddHostedService<ServicoNotaAlunoWorker>()
                .AddNpgsql<ServicoNotaAlunosContexto>(hostContext.Configuration.GetConnectionString("DefaultConnection"), 
                options => 
                {
                    options.CommandTimeout(20);
                });
                //.AddHostedService<WorkerExemplo>();
    })
    .Build();

await host.RunAsync();
