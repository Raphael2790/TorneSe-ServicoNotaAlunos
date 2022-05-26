using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TorneSe.ServicoNotaAlunos.Data.Environment;
using TorneSe.ServicoNotaAlunos.IOC.Providers;

namespace TorneSe.ServicoNotaAlunos.IOC.Extensions;

public static class HealthChecksExtensions
{
    public static IServiceCollection ConfigurarHealthChecks(this IServiceCollection services, 
                                                            IConfiguration configuration)
    {
        var provedorVariaveis = ProvedorVariaveisAmbiente.Instancia;
        services
            .AddHealthChecks()
            .AddNpgSql(provedorVariaveis.DefaultConnection, name: "Postgres",
            tags : new string[] {"db", "data"})
            .AddMongoDb(provedorVariaveis.MongoDbUrl, name: "MongoLogs",
            tags: new string[] {"logs", "data"})
            .AddElasticsearch(provedorVariaveis.ElasticSearchUrl, name: "ElasticLogs", tags: new string[] {"logs", "observabilidade"})
            .AddCheck<AwsSqsHealthCheck>("AwsSQS", tags: new string[] {"fila", "mensageria"});

        return services;
    }
}
