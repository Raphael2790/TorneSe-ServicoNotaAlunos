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

 ## Sites para estudo
 - https://refactoring.guru/pt-br - Refactoring Guru


 ## Documentação docker Postgres
 - https://hub.docker.com/_/postgres/
 

 ## Subir container com Postgres
 - docker run -p 5432:5432 -v /c/Users/raphael.silvestre/Documents/database:/var/lib/postgresql/data -e POSTGRES_PASSWORD=1234 -e POSTGRES_USER=torneSe -e POSTGRES_DB=TorneSeDb -d postgres

 ## Site para encontrar formatos de connections strings
 - https://www.connectionstrings.com/