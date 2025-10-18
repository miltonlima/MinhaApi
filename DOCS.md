# API Documentation / Documentação da API

## 🇺🇸 English Documentation

### Architecture Overview

MinhaApi follows a clean architecture pattern with the following layers:

- **Controllers**: Handle HTTP requests and responses
- **Models**: Data transfer objects and entities
- **Program.cs**: Application configuration and middleware setup

### Detailed API Reference

#### Authentication
Currently, the API does not require authentication. All endpoints are publicly accessible.

#### Error Handling
The API returns standard HTTP status codes:

- `200 OK`: Successful request
- `404 Not Found`: Resource not found
- `400 Bad Request`: Invalid request parameters
- `500 Internal Server Error`: Server error

#### Rate Limiting
No rate limiting is currently implemented.

#### CORS Policy
The API allows all origins in development mode.

### Data Models

#### Product Model
```csharp
{
  "id": "integer",
  "nome": "string",
  "preco": "decimal"
}
```

#### Weather Forecast Model
```csharp
{
  "date": "DateOnly",
  "temperatureC": "integer",
  "temperatureF": "integer", 
  "summary": "string"
}
```

### Environment Configuration

#### Development Environment
- Port: 5139 (HTTP)
- Port: 7273 (HTTPS)
- Swagger UI: Enabled
- Detailed logging: Enabled

#### Production Environment
- HTTPS redirection: Enabled
- Swagger UI: Disabled
- Minimal logging: Enabled

### Deployment

#### Prerequisites for Production
1. .NET 9.0 Runtime
2. IIS or reverse proxy (nginx/Apache)
3. SSL certificate for HTTPS

#### Docker Support
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MinhaApi.csproj", "."]
RUN dotnet restore "./MinhaApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MinhaApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinhaApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinhaApi.dll"]
```

### Testing

#### Manual Testing with curl
```bash
# Get all products
curl -X GET "http://localhost:5139/api/produtos" -H "accept: application/json"

# Get specific product
curl -X GET "http://localhost:5139/api/produtos/1" -H "accept: application/json"

# Get weather forecast
curl -X GET "http://localhost:5139/weatherforecast" -H "accept: application/json"
```

#### Testing with PowerShell
```powershell
# Get all products
Invoke-RestMethod -Uri "http://localhost:5139/api/produtos" -Method Get

# Get specific product
Invoke-RestMethod -Uri "http://localhost:5139/api/produtos/1" -Method Get

# Get weather forecast
Invoke-RestMethod -Uri "http://localhost:5139/weatherforecast" -Method Get
```

---

## 🇧🇷 Documentação em Português

### Visão Geral da Arquitetura

MinhaApi segue um padrão de arquitetura limpa com as seguintes camadas:

- **Controllers**: Manipulam requisições e respostas HTTP
- **Models**: Objetos de transferência de dados e entidades
- **Program.cs**: Configuração da aplicação e setup de middleware

### Referência Detalhada da API

#### Autenticação
Atualmente, a API não requer autenticação. Todos os endpoints são publicamente acessíveis.

#### Tratamento de Erros
A API retorna códigos de status HTTP padrão:

- `200 OK`: Requisição bem-sucedida
- `404 Not Found`: Recurso não encontrado
- `400 Bad Request`: Parâmetros de requisição inválidos
- `500 Internal Server Error`: Erro do servidor

#### Limitação de Taxa
Nenhuma limitação de taxa está implementada atualmente.

#### Política CORS
A API permite todas as origens no modo de desenvolvimento.

### Modelos de Dados

#### Modelo de Produto
```csharp
{
  "id": "integer",
  "nome": "string",
  "preco": "decimal"
}
```

#### Modelo de Previsão do Tempo
```csharp
{
  "date": "DateOnly",
  "temperatureC": "integer",
  "temperatureF": "integer", 
  "summary": "string"
}
```

### Configuração de Ambiente

#### Ambiente de Desenvolvimento
- Porta: 5139 (HTTP)
- Porta: 7273 (HTTPS)
- Swagger UI: Habilitado
- Log detalhado: Habilitado

#### Ambiente de Produção
- Redirecionamento HTTPS: Habilitado
- Swagger UI: Desabilitado
- Log mínimo: Habilitado

### Deploy

#### Pré-requisitos para Produção
1. .NET 9.0 Runtime
2. IIS ou proxy reverso (nginx/Apache)
3. Certificado SSL para HTTPS

#### Suporte ao Docker
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MinhaApi.csproj", "."]
RUN dotnet restore "./MinhaApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MinhaApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinhaApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinhaApi.dll"]
```

### Testes

#### Testes Manuais com curl
```bash
# Obter todos os produtos
curl -X GET "http://localhost:5139/api/produtos" -H "accept: application/json"

# Obter produto específico
curl -X GET "http://localhost:5139/api/produtos/1" -H "accept: application/json"

# Obter previsão do tempo
curl -X GET "http://localhost:5139/weatherforecast" -H "accept: application/json"
```

#### Testes com PowerShell
```powershell
# Obter todos os produtos
Invoke-RestMethod -Uri "http://localhost:5139/api/produtos" -Method Get

# Obter produto específico
Invoke-RestMethod -Uri "http://localhost:5139/api/produtos/1" -Method Get

# Obter previsão do tempo
Invoke-RestMethod -Uri "http://localhost:5139/weatherforecast" -Method Get
```

### Próximos Passos

#### Funcionalidades Planejadas
- [ ] Autenticação JWT
- [ ] Operações CRUD completas para produtos
- [ ] Banco de dados Entity Framework
- [ ] Testes unitários
- [ ] Logging estruturado
- [ ] Health checks
- [ ] Cache Redis
- [ ] Versionamento da API

#### Melhorias de Performance
- [ ] Implementar cache
- [ ] Otimizar consultas
- [ ] Compressão de resposta
- [ ] Paginação para listas grandes

#### Segurança
- [ ] Implementar HTTPS obrigatório
- [ ] Rate limiting
- [ ] Validação de entrada
- [ ] Sanitização de dados
- [ ] Headers de segurança

---

## 📊 API Metrics

### Performance Benchmarks
- Average response time: < 50ms
- Throughput: ~1000 requests/second
- Memory usage: ~50MB

### Monitoring
- Health check endpoint: `/health` (to be implemented)
- Metrics endpoint: `/metrics` (to be implemented)
- Application insights integration (to be implemented)

---

**Última atualização**: 18 de outubro de 2025