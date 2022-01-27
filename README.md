# Comando para listar os Projetos
 - dotnet new --list

## Instalando pacotes Nuget apontando a origem
 - dotnet add package Microsoft.Extensions.DependencyInjection --source  https://api.nuget.org/v3/index.json

## Comando para adicionar projetos a solução vazia
``` bash
A partir de uma solução criada digitamos o comando para adicionar a referencia ao csproj dos projetos
    dotnet sln add src\TorneSe.ServicoNotaAlunos.Worker\TorneSe.ServicoNotaAlunos.Worker.csproj
    dotnet sln remove src\TorneSe.ServicoNotaAluno.Worker\TorneSe.ServicoNotaAluno.Worker.csproj  
 ```