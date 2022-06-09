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

 ## Postgres DataTypes
- https://www.postgresql.org/docs/8.3/datatype.html

## GUId Generator
- https://www.guidgenerator.com/online-guid-generator.aspx

## Modelo Mensagem Entrada SQS
```
    {
    "AlunoId": 1234,
    "ProfessorId": 1282727,
    "AtividadeId": 2,
    "CorrelationId": "fbaa64f1-8e4d-4ff4-b5ff-749dc652c4e7",
    "ValorNota": 8.0,
    "NotaSubstitutiva": true
    }
```

## Documentação do Serilog
 - https://serilog.net/

## Documentação Serilog Postgres
 - https://github.com/serilog-contrib/Serilog.Sinks.Postgresql.Alternative/blob/master/HowToUse.md

## Comparativo Atributos, Asserts de frameworks de testes
 - https://xunit.net/docs/comparisons

## Instalação local Windows Service
- https://docs.microsoft.com/pt-br/dotnet/core/extensions/windows-service

## Passo a passo instalação local
- dotnet publish --no-self-contained -o C:\Users\raphael.silvestre\source\repos\publicacao -p:PublishProfile=FolderProfile
- sc.exe create "Servico Integracao Notas" binpath="C:\Users\raphael.silvestre\source\repos\publicacao\TorneSe.ServicoNotaAluno.Worker.exe"
- sc.exe failure "Servico Integracao Notas" reset=0 actions=restart/60000/restart/60000/run/1000
- sc.exe start "Servico Integracao Notas"
- sc.exe stop "Servico Integracao Notas"
- sc.exe delete "Servico Integracao Notas"

## Criar imagem docker aplicação
- docker build -t tornese/servico-notas:latest .
- docker run -d --name servico-notas tornese/servico-notas

## Criar conta no Atlas
https://account.mongodb.com/account/login?n=%2Fv2%2F5e8c9673dce91c238d9046bc%23clusters

## Exemplo conexão cluster mongo
mongodb://<user>:<password>@ac-2fgps34-shard-00-00.1tdhbqq.mongodb.net:27017,ac-2fgps34-shard-00-01.1tdhbqq.mongodb.net:27017,ac-2fgps34-shard-00-02.1tdhbqq.mongodb.net:27017/<database_name>?ssl=true&replicaSet=atlas-6bk87u-shard-0&authSource=admin&retryWrites=true&w=majority