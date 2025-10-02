# TechChallenge GameStore

A PI REST para gerenciamento de usuários e funcionalidades básicas de uma loja de jogos, desenvolvida como parte do Tech Challenge da FIAP. A aplicação foca em boas práticas, arquitetura em camadas e uso do Entity Framework Core com PostgreSQL.

## Sobre o Projeto

O objetivo é criar uma API REST em .NET 8 que permita gerenciar usuários e seus jogos, garantindo persistência de dados, qualidade de software e boas práticas de desenvolvimento. O projeto foi estruturado como um monolito, facilitando o desenvolvimento ágil deste MVP.

### Arquitetura

A aplicação segue o padrão **Clean Architecture**, adotando o estilo _Layered_ (em camadas) com foco em baixo acoplamento e alta coesão.

- `Api`: camada de entrada responsável por expor a API REST e receber as requisições externas.
- `Application`: orquestra a execução dos casos de uso, coordenando interações entre Domain e Infrastructure.
- `Domain`: núcleo da aplicação, contendo as entidades de negócio e regras de domínio.
- `Infrastructure`: provê implementação de repositórios, persistência e integrações externas.

#### Pré-requisitos

| Requisito        | Link para Download   |
| ---------------- |----------------------|
| `.NET SDK 8.0`   | [Baixar aqui](https://dotnet.microsoft.com/en-us/download)   |
| `PostgreSQL 14+` | [Baixar aqui](https://www.postgresql.org/download/)   |
| `Docker`         | [Baixar aqui](https://www.docker.com/products/docker-desktop/)   |
| `Docker Compose` | [Baixar aqui](https://docs.docker.com/compose/install/)   |

## 🚀 Passo a Passo para Executar a API

<details><summary>1. Clone o projeto</summary>

- Execute o comando:
    ```bash
    git clone https://github.com/seu-usuario/fiap-tech-challenge.git
    cd fiap-tech-challenge
    ```
</details>

<details><summary>2. Suba o banco de dados com Docker Compose</summary>

- Defina um usuário e senha no arquivo `docker-compose.yml`, disponível na camada **WebApi**.
- Navegue até a pasta `TechChallenge.GameStore.WebApi` no terminal da sua IDE e execute o comando:

```bash
docker-compose up -d
```
</details>

<details><summary>3. Configure a string de conexão</summary>

- No arquivo `appsettings.Development.json` da camada WebApi, configure a string de conexão com os dados definidos no `docker-compose.yml`. Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=gamestoredb;Username=admin;Password=admin"
  }
}
```
</details>

<details><summary>4. Aplique a migration no banco de dados</summary>

- Execute o comando abaixo a partir da raiz do projeto para aplicar as migrations:
    ```bash
    dotnet ef database update \
      --project src/TechChallenge.GameStore.Infrastructure \
      --startup-project src/TechChallenge.GameStore.WebApi
    ```
</details>


<details><summary>5. Execute a API</summary>

- Execute o seguinte comando para aplicar as migrations:
    ```bash
    dotnet run --project src/TechChallenge.GameStore.WebApi
    ```
- Acesse no navegador:
    ```bash
    https://localhost:5209/swagger
    ```
</details>

## Tecnologias Utilizadas

| Tecnologia                | Documentação                                                                      |
|---------------------------| --------------------------------------------------------------------------------- |
| **.NET 8**                | [Documentação Oficial](https://learn.microsoft.com/en-us/dotnet/)                 |
| **Entity Framework Core** | [Documentação Oficial](https://learn.microsoft.com/en-us/ef/core/)                |
| **PostgreSQL**            | [Documentação Oficial](https://www.postgresql.org/docs/)                          |
| **Swashbuckle (Swagger)** | [Documentação Oficial](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) |
| **MediatR**               | [Documentação Oficial](https://github.com/jbogard/MediatR)                        |
| **NUnit**                 | [Documentação Oficial](https://nunit.org/)                                        |
| **MailDev**               | [Documentação Oficial](https://github.com/maildev/maildev)                          |

## Variáveis de Ambiente

| Variável                               | Descrição                                                     | Obrigatório | Valor Padrão                                                        |
| -------------------------------------- | ------------------------------------------------------------- | ----------- | ------------------------------------------------------------------- |
| `ConnectionStrings__DefaultConnection` | String de conexão com o banco de dados PostgreSQL             | Sim         | `Host=localhost;Port=5432;Database=gamestoredb;Username=;Password=` |
| `Email__Remetente`                     | Endereço de e-mail usado como remetente nas notificações      | Sim         | `no-reply@gamestore.fiap`                                           |
| `Email__Smtp__Host`                    | Endereço do servidor SMTP                                     | Sim         | `localhost`                                                         |
| `Email__Smtp__Porta`                   | Porta do servidor SMTP                                        | Sim         | `1025`                                                              |
| `Email__Smtp__Usuario`                 | Nome de usuário do servidor SMTP (se necessário)              | Não         | `""`                                                                |
| `Email__Smtp__Senha`                   | Senha do servidor SMTP (se necessário)                        | Não         | `""`                                                                |
| `ENVIA_NOTIFICACAO_INTERVALO_MINUTOS`  | Intervalo, em minutos, para execução do envio de notificações | Sim         | `10`                                                                |
| `Jwt__Key`                             | Chave secreta usada para assinar e validar tokens JWT         | Sim         | `""`                                                                |
| `Jwt__Audience`                        | Público-alvo (audience) aceito nos tokens JWT                 | Sim         | `""`                                                                |
| `Jwt__Issuer`                          | Emissor (issuer) dos tokens JWT, utilizado para validação     | Sim         | `""`                                                                |

## Melhorias futuras

1. Incluir cache para tornar a aplicação mais eficiente;
2. (...)