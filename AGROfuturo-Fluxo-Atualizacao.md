# AGROfuturo - Fluxo de Atualizacao

Data: 29/05/2026

## Objetivo

Deixar a API pronta para uso com SQL Server, migration aplicada, banco populado, testes de integracao isolados e validacao manual dos endpoints principais.

## O que foi ajustado

- A aplicacao passou a usar SQL Server com a connection string solicitada.
- O `AppDbContext` foi configurado com relacionamentos explicitos e `DeleteBehavior.Restrict` nos caminhos criticos para evitar conflitos de cascade no SQL Server.
- O seeder deixou de apagar o banco e passou a usar `MigrateAsync` no banco real.
- O projeto principal ganhou Swagger para documentacao local.
- Foi criado um projeto separado de testes de integracao usando SQLite in-memory.
- Foi criado seed completo com dados de validacao em ordem de dependencia.
- Os controladores singulares duplicados foram removidos, mantendo apenas as rotas consolidadas.
- Os warnings de compilacao do projeto principal foram eliminados.

## Passo a passo executado

1. Revisei `Program.cs`, `AppDbContext`, `appsettings.json`, controllers, DTOs e modelos.
2. Substitui o provider de banco para SQL Server.
3. Atualizei a connection string em `appsettings.json` e `appsettings.Development.json`.
4. Ajustei o mapeamento do EF Core para as entidades e relacoes principais.
5. Refatorei o seeder para nao destruir o banco e para inserir dados de validacao.
6. Gerei a migration inicial `InitialSqlServer`.
7. Apliquei a migration no banco real `AGROfuturo`.
8. Criei o projeto de testes `tests/AGROfuturo.IntegrationTests`.
9. Configurei os testes para usar SQLite in-memory, sem misturar com o banco real.
10. Executei a suite de testes de integracao.
11. Subi a API localmente e validei manualmente alguns GETs.
12. Removi controladores singulares redundantes e limpei os warnings de compilacao.

## Resultado da migration

- Banco criado/atualizado com sucesso no SQL Server.
- Tabelas e indices criados.
- Seed aplicado com:
  - planos
  - empresas
  - usuarios
  - culturas
  - fazendas
  - talhoes
  - pulverizadoras
  - modelos de sensor
  - sensores
  - leituras de sensor
  - pragas
  - detecoes de praga
  - insumos
  - consumos de insumo
  - clientes
  - vendas
  - configuracoes do sistema

## Testes executados

- Build da API: sucesso.
- `dotnet ef migrations add InitialSqlServer`: sucesso.
- `dotnet ef database update`: sucesso.
- `dotnet test tests/AGROfuturo.IntegrationTests/AGROfuturo.IntegrationTests.csproj`: sucesso.

## Validacao manual

Endpoints validados com GET localmente:

- `/api/Planos`
- `/api/Empresas`
- `/api/Sensores`
- `/api/Vendas`

Os retornos confirmaram que os dados estavam gravados e sendo expostos pela API.

## Observacoes importantes

- O banco real ficou isolado dos testes.
- A suite de testes usa SQLite in-memory e nao toca o SQL Server real.
- O build do projeto principal ficou sem warnings.

## Arquivos principais

- `Program.cs`
- `Data/AppDbContext.cs`
- `Data/DbSeeder.cs`
- `Data/Migrations/20260529114119_InitialSqlServer.cs`
- `tests/AGROfuturo.IntegrationTests/Infrastructure/AgroFuturoApiFactory.cs`
- `tests/AGROfuturo.IntegrationTests/ApiEndpointsTests.cs`

## Proximo passo sugerido

Se quiser, o proximo passo natural e revisar se ainda vale refinar os contratos de entrada e saida dos endpoints de venda e configuracao para ficar mais previsivel para o front-end.
