namespace TorneSe.ServicoNotaAlunos.IOC.Extensions;

public static class ServiceProviderExtensions
{
    public static List<object> GetServices(this IServiceProvider provider,Type[] tiposImplementacao)
    {
        var services = new List<object>(tiposImplementacao.Count());

        foreach(var tipo in tiposImplementacao)
            services.Add(provider.GetService(tipo));

        return services;
    }
}
