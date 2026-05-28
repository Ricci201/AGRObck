"# AgroFuturo API — .NET 10 + PostgreSQL

API REST para o sistema **AgroFuturo** (pulverização de precisão / agro).
Implementa CRUDs para todas as entidades das telas: Login, Cadastro, Dashboard, Sensores, Mapa do Campo, Pragas, Insumos, Vendas e Configurações.

---

## 📦 Stack

- **.NET 10.0** (ASP.NET Core Web API)
- **PostgreSQL** (via `Npgsql.EntityFrameworkCore.PostgreSQL`)
- **Entity Framework Core 10**
- **BCrypt.Net-Next** (hash de senhas)
- **Swashbuckle / Swagger** (documentação)

---

## 🗂️ Estrutura

```
dotnet-api/
├── AgroFuturo.Api.csproj
├── Program.cs
├── appsettings.json
├── Properties/launchSettings.json
├── Models/
│   ├── Enums/Enums.cs
│   ├── Plano.cs
│   ├── Empresa.cs
│   ├── Usuario.cs
│   ├── Cultura.cs
│   ├── Fazenda.cs
│   ├── Talhao.cs
│   ├── Pulverizadora.cs
│   ├── ModeloSensor.cs
│   ├── Sensor.cs
│   ├── LeituraSensor.cs
│   ├── Pulverizacao.cs
│   ├── Praga.cs
│   ├── DeteccaoPraga.cs
│   ├── Insumo.cs
│   ├── ConsumoInsumo.cs
│   ├── Cliente.cs
│   ├── Venda.cs
│   ├── ItemVenda.cs
│   └── ConfiguracaoSistema.cs
├── DTOs/Dtos.cs
├── Data/
│   ├── AppDbContext.cs
│   └── DbSeeder.cs
└── Controllers/
    ├── AuthController.cs
    ├── CrudControllerBase.cs
    └── CrudControllers.cs
```

Cada **model está em arquivo separado** dentro de `Models/` conforme solicitado.

---

## 🚀 Como rodar (VS Code)

### 1. Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL 14+](https://www.postgresql.org/download/) rodando local

### 2. Criar o banco

```sql
CREATE DATABASE agrofuturo;
```

### 3. Ajustar a connection string em `appsettings.json`

```json
\"DefaultConnection\": \"Host=localhost;Port=5432;Database=agrofuturo;Username=postgres;Password=SUA_SENHA\"
```

### 4. Restaurar pacotes e gerar a migração inicial

```bash
cd dotnet-api
dotnet restore
dotnet tool install --global dotnet-ef --version 10.0.0     # se ainda não tiver
dotnet ef migrations add InitialCreate
```

### 5. Rodar (o seed cria Planos, Culturas e ModelosSensor automaticamente)

```bash
dotnet run
```

Abra: **http://localhost:5050/swagger**

---

## 🔌 Endpoints principais

| Recurso             | Rota                             |
| ------------------- | -------------------------------- |
| Cadastro de usuário | `POST /api/Auth/cadastro`        |
| Login               | `POST /api/Auth/login`           |
| Planos              | `/api/Planos`                    |
| Empresas            | `/api/Empresas`                  |
| Fazendas            | `/api/Fazendas`                  |
| Culturas            | `/api/Culturas`                  |
| Talhões             | `/api/Talhoes`                   |
| Pulverizadoras      | `/api/Pulverizadoras`            |
| Modelos de sensor   | `/api/ModelosSensor`             |
| Sensores            | `/api/Sensores`                  |
| Leituras de sensor  | `/api/leituras-sensor`           |
| Pulverizações       | `/api/Pulverizacoes`             |
| Pragas              | `/api/Pragas`                    |
| Detecções de praga  | `/api/deteccoes-praga`           |
| Insumos             | `/api/Insumos`                   |
| Consumos de insumo  | `/api/consumos-insumo`           |
| Clientes            | `/api/Clientes`                  |
| Vendas              | `/api/Vendas`                    |
| Configurações       | `/api/configuracoes/{usuarioId}` |

Todos os controllers herdam de `CrudControllerBase<T>` que já implementa **GET /**, **GET /{id}** e **DELETE /{id}**.
Cada controller específico implementa **POST** e **PUT** com o DTO correspondente.

---

## 🔐 Cadastro (tela \"Criar Conta\")

```http
POST /api/Auth/cadastro
Content-Type: application/json

{
  \"nomeCompleto\": \"Rayane F. dos Santos\",
  \"empresa\": \"Fazenda do Sul\",
  \"email\": \"rayane@email.com\",
  \"telefone\": \"+55 11 99999-9999\",
  \"senha\": \"123456\",
  \"confirmarSenha\": \"123456\",
  \"plano\": \"Basico\"
}
```

Plano aceita: `\"Basico\"`, `\"Pro\"`, `\"Enterprise\"` (string do enum).

---

## 🧪 Próximos passos sugeridos

- Adicionar **JWT** (a flag `AutenticacaoJwt` já existe em `ConfiguracaoSistema`) — basta plugar `Microsoft.AspNetCore.Authentication.JwtBearer`.
- Endpoints de **dashboard** agregados (totais por dia, eficiência, etc.).
- Histórico de leituras com **WebSocket / SignalR** para a tela \"Leitura ao Vivo\".
  "
