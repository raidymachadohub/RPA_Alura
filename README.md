# RPA.ALURA- .NET 6 MVC API

## Contexto Primário

```
Para rodar os migrations abrir terminal no projeto ##RPA.Alura.Infrastrucure e executar o migration
```

```sh
dotnet ef --startup-project ../RPA.Alura.Application migrations add  <NomeDaMigration> --output-dir Migrations/Entities
```

Frameworks usado para o projeto.
- WebDriverChrome - O teste tem que ser efetuado no Google Chrome.
- Entity Framework - Para persistencia de dados.
- AutoMapper - Para mapeamento de campos entre o dominio e os DTOs
- Selenium - Para coleta dos dados
- SQL Lite - Para armazenamento de dados
- Swagger - Para documentação de API
- XUnit - Para teste unitário

## O projejo já consta o SqliteDB. 
- Diretorio /RPA.Alura.Infrastructure/LocalDb


## Arquitetura

- DDD
- Result Patterns - Foi usado o padrão de resultado para melhor visualização e tratamento de errros - https://github.com/victorDivino/operationResult
- Facade Patterns - Para consulta de um subsistema. https://refactoring.guru/design-patterns/facade
- Di - Injeção de dependencia.

## Usando o Swagger.

No endpoint /routine.

{
  "id": 0,
  "titleSearch": "string", <- Incluir o nome do curso que deseja ser processado.
  "active": true
}

No endpoint /Selenium/ExecutarRotina você consegue rodar a automação todas as Routine com a flag:true.

No endpoint /course você consegue visualizar todas as informações do curso coletado.
