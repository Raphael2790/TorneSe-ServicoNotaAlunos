namespace TorneSe.ServicoNotaAlunos.Data.Environment.Interface;

public interface IProvedorVariaveisAmbiente
{
    string AwsSecret { get; }
    string AWSSecretAccessKey { get;}
    int AwsLongPooling { get; }
    string MongoDbUrl { get; }
    string ElasticSearchUrl { get;}
    string PrdElasticSearchUrl { get;}
    string DefaultConnection { get; }
    string ElasticCloudId { get; }
    string ElasticUser { get; }
    string ElasticPassword { get; }
    string Get(string name);
}
