# Escola com Docker

Esta solução pode ser executada localmente com a API .NET 9 e o PostgreSQL via Docker Compose.

## Serviços

- API ASP.NET Core: `http://localhost:8080`
- Swagger UI: `http://localhost:8080/swagger`
- PostgreSQL: `localhost:5432`

## Subir o ambiente

Na raiz da solução:

```bash
docker compose up --build
```

O serviço da API aguarda o PostgreSQL ficar saudável e aplica automaticamente as migrations existentes na inicialização.

## Parar o ambiente

```bash
docker compose down
```

## Remover também os dados do banco

```bash
docker compose down -v
```

## Configuração relevante

- A API expõe a porta `8080` no contêiner e na máquina local.
- A connection string do contêiner usa `Host=postgres`, que é o nome do serviço no Compose.
- As credenciais do banco no ambiente local Docker são:
  - Usuário: `postgres`
  - Senha: `toor`
  - Banco: `Escola`

## Observações

- O arquivo `Escola.API/appsettings.json` continua válido para execução fora do Docker.
- Em ambiente Docker de desenvolvimento, os valores mais sensíveis são sobrescritos por variáveis de ambiente no `compose.yaml`.
