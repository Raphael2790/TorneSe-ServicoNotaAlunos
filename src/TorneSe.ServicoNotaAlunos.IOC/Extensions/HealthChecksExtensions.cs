using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.ServicoNotaAlunos.Data.Environment;
using TorneSe.ServicoNotaAlunos.IOC.Providers;

namespace TorneSe.ServicoNotaAlunos.IOC.Extensions;

public static class HealthChecksExtensions
{
    public static IServiceCollection ConfigurarHealthChecks(this IServiceCollection services, 
                                                            IConfiguration configuration,
                                                            IHostEnvironment hostEnvironment)
    {
        var provedorVariaveis = ProvedorVariaveisAmbiente.Instancia;
        var healthCheckBuilder = services
                                .AddHealthChecks();

        healthCheckBuilder.AddNpgSql(provedorVariaveis.DefaultConnection, name: "Postgres",
        tags : new string[] {"db", "data"})
        .AddMongoDb(provedorVariaveis.MongoDbUrl, name: "MongoLogs",
        tags: new string[] {"logs", "data"})
        .AddCheck<AwsSqsHealthCheck>("AwsSQS", tags: new string[] {"fila", "mensageria"});
        
        if(hostEnvironment.IsProduction())
            // healthCheckBuilder.AddElasticsearch(options => 
            // {
            //     options.UseServer(provedorVariaveis.PrdElasticSearchUrl);
            //     options.UseBasicAuthentication(provedorVariaveis.ElasticUser, provedorVariaveis.ElasticPassword);
            // }, name: "Elastic"
            // , tags: new string[] { "logs", "logs data" });
             healthCheckBuilder.AddElasticsearch(provedorVariaveis.PrdElasticSearchUrl, name: "Elastic"
            , tags: new string[] { "logs", "logs data" });
        else
             healthCheckBuilder.AddElasticsearch(provedorVariaveis.ElasticSearchUrl, name: "Elastic"
            , tags: new string[] { "logs", "logs data" });


        return services;
    }
}
