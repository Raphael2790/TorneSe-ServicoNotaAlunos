using TorneSe.ServicoNotaAlunos.Data.Environment.Interface;

namespace TorneSe.ServicoNotaAlunos.Data.Environment;

public sealed class ProvedorVariaveisAmbiente : IProvedorVariaveisAmbiente
{
    public static readonly IProvedorVariaveisAmbiente Instancia = new ProvedorVariaveisAmbiente();

    public string AwsSecret => Get(VariaveisAmbienteConstants.AWS_SECRET);

    public string AWSSecretAccessKey => Get(VariaveisAmbienteConstants.AWS_SECRET_KEY);

    public int AwsLongPooling => int.TryParse(Get(VariaveisAmbienteConstants.SEGUNDOS_POLLING_AWS), 
                    out int segundos) ? segundos : 20;

    public string MongoDbUrl => Get(VariaveisAmbienteConstants.MONGO_DB_URL);

    public string ElasticSearchUrl => Get(VariaveisAmbienteConstants.ELASTIC_SEARCH_URL);

    public string DefaultConnection => Get(VariaveisAmbienteConstants.DEFAULT_CONNECTION);

    public string Get(string name)
     => System.Environment.GetEnvironmentVariable(name);
}
