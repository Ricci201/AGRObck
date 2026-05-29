using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using AGROfuturo.IntegrationTests.Infrastructure;

namespace AGROfuturo.IntegrationTests;

public class ApiEndpointsTests(AgroFuturoApiFactory factory) : IClassFixture<AgroFuturoApiFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Theory]
    [InlineData("/api/Planos")]
    [InlineData("/api/Empresas")]
    [InlineData("/api/Fazendas")]
    [InlineData("/api/Culturas")]
    [InlineData("/api/Talhoes")]
    [InlineData("/api/Pulverizadoras")]
    [InlineData("/api/ModelosSensor")]
    [InlineData("/api/Sensores")]
    [InlineData("/api/leituras-sensor")]
    [InlineData("/api/Pulverizacoes")]
    [InlineData("/api/Pragas")]
    [InlineData("/api/deteccoes-praga")]
    [InlineData("/api/Insumos")]
    [InlineData("/api/consumos-insumo")]
    [InlineData("/api/Clientes")]
    [InlineData("/api/Vendas")]
    public async Task MainGetEndpoints_ShouldReturnSuccessAndSeededData(string endpoint)
    {
        var response = await _client.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        Assert.False(string.IsNullOrWhiteSpace(body));
        Assert.NotEqual("[]", body.Trim());
    }

    [Fact]
    public async Task AuthCadastroAndLogin_ShouldWork()
    {
        var email = $"teste.{Guid.NewGuid():N}@agrofuturo.com";

        var cadastroPayload = new
        {
            nomeCompleto = "Usuario Teste Integracao",
            empresa = "Empresa Teste Integracao",
            email,
            telefone = "11999998888",
            senha = "123456",
            confirmarSenha = "123456",
            plano = "Basico"
        };

        var cadastroResponse = await _client.PostAsJsonAsync("/api/Auth/cadastro", cadastroPayload);
        Assert.Equal(HttpStatusCode.Created, cadastroResponse.StatusCode);

        var loginPayload = new
        {
            email,
            senha = "123456"
        };

        var loginResponse = await _client.PostAsJsonAsync("/api/Auth/login", loginPayload);
        Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);

        var loginBody = await loginResponse.Content.ReadAsStringAsync();
        Assert.Contains(email, loginBody, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task CreateEmpresa_ShouldPersistAndBeListed()
    {
        var nomeEmpresa = $"Empresa Nova {Guid.NewGuid():N}";

        var payload = new
        {
            nome = nomeEmpresa,
            cnpjCpf = "56789012000194",
            cidade = "Uberlandia",
            estado = "MG"
        };

        var postResponse = await _client.PostAsJsonAsync("/api/Empresas", payload);
        Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);

        var listResponse = await _client.GetAsync("/api/Empresas");
        listResponse.EnsureSuccessStatusCode();

        var listBody = await listResponse.Content.ReadAsStringAsync();
        Assert.Contains(nomeEmpresa, listBody, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task ConfiguracaoGet_ShouldReturnSeededConfiguration()
    {
        var response = await _client.GetAsync("/api/configuracoes/1");
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("intervalo", body, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task CreateVenda_ShouldWorkWithDependencies()
    {
        var clientesResponse = await _client.GetAsync("/api/Clientes");
        clientesResponse.EnsureSuccessStatusCode();
        var clientesJson = await clientesResponse.Content.ReadAsStringAsync();

        var modelosResponse = await _client.GetAsync("/api/ModelosSensor");
        modelosResponse.EnsureSuccessStatusCode();
        var modelosJson = await modelosResponse.Content.ReadAsStringAsync();

        var clienteId = ReadFirstId(clientesJson);
        var modeloId = ReadFirstId(modelosJson);

        var vendaPayload = new
        {
            dataVenda = DateTime.UtcNow,
            quantidadeSensores = 1,
            valorTotal = 4700.0m,
            desconto = 0.0m,
            status = "Confirmada",
            observacoes = "Venda criada em teste de integracao",
            clienteId,
            itens = new[]
            {
                new
                {
                    quantidade = 1,
                    precoUnitario = 4700.0m,
                    modeloSensorId = modeloId
                }
            }
        };

        var response = await _client.PostAsJsonAsync("/api/Vendas", vendaPayload);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("clienteId", body, StringComparison.OrdinalIgnoreCase);
    }

    private static int ReadFirstId(string jsonArray)
    {
        using var doc = JsonDocument.Parse(jsonArray);
        var first = doc.RootElement.EnumerateArray().First();

        if (first.TryGetProperty("id", out var idCamel))
        {
            return idCamel.GetInt32();
        }

        if (first.TryGetProperty("Id", out var idPascal))
        {
            return idPascal.GetInt32();
        }

        throw new InvalidOperationException("Nenhuma propriedade Id encontrada no payload.");
    }
}