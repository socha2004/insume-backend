# Insume Back-end

Este repositório apresenta a aplicação back-end do projeto Insume, um sistema que organiza seu estoque doméstico.

Atualmente, a aplicação possui as seguintes funcionalidades:

- Cadastro de usuário e login
- Dashboard inicial com resumo do estoque e categorias
- Cadastro de insumos
- Cadastro de categorias

## Stack Usada

<p align="center">
  <a href="https://skillicons.dev">
    <img src="https://skillicons.dev/icons?i=dotnet,cs,visualstudio,postgres" />
  </a>
</p>

A stack utilizada foi a seguinte:

- **ASP.NET** - Framework
- **C#** - Linguagem de programação
- **Visual Studio** - IDE para desenvolvimento
- **PostgreSQL** - Banco de Dados

## Estrutura do projeto

A organização do projeto pretendi me aproximar do modelo Clean Architecture, separando os componentes da seguinte maneira :

```text
insume-backend
|
|──api/
|  └──Controllers/
|
|──Application/
|  |──DTOs/
|  |──Interfaces/
|  └──Services/
|
|──Domain/
|  └──Entities/
|
|──Infraestructure/
|  └──Data/
|
└──Migrations/
```

## Fluxo da Aplicação
```mermaid
flowchart TD
    U[Usuário]

    F[React + Vite<br/>Frontend]

    API[ASP.NET Web API<br/><br/>Autenticação<br/>Lógica de Negócio<br/>Entity Framework]

    DB[(PostgreSQL<br/><br/>Usuários<br/>Insumos<br/>Categorias<br/>)]

    U -->|HTTPS| F
    F -->|HTTP / REST| API
    API --> DB
```

## Executando

Para executar o projeto localmente, você precisa dos seguintes itens:

* [.NET SDK 8.0 ou superior](https://dotnet.microsoft.com/download)
* Um banco de dados PostgreSQL
* Git

### Instalando e Executando

1. Clone o repositório e acesse a pasta do projeto

```bash
git clone https://github.com/socha2004/insume-backend.git
cd insume-backend
```

2. Configure as variáveis sensíveis utilizando o **.NET User Secrets**

As informações sensíveis utilizadas pela aplicação não ficam armazenadas diretamente no repositório. Para executar o projeto localmente, configure o arquivo `secrets.json` através do sistema de User Secrets do .NET.

Inicialize o User Secrets no projeto:

```bash
dotnet user-secrets init
```

> [!NOTE]
> Você pode se basear no `secrets.example.json` também:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "postgresql://USUARIO:SENHA@HOST/BANCO"
  },
  "Jwt": {
    "Key": "SUBSTITUA_POR_UMA_CHAVE_SECRETA",
    "Issuer": "InsumeAPI",
    "Audience": "InsumeFrontend",
    "ExpiresInMinutes": 60
  }

}
```

Em seguida, configure os valores necessários para a aplicação.

> Consulte o arquivo `appsettings.json` para identificar quais configurações são esperadas pelo projeto.

3. Restaure as dependências do projeto

```bash
dotnet restore
```

4. Execute as migrations do Entity Framework

```bash
dotnet ef database update
```

> Caso o comando `dotnet ef` não esteja disponível, instale a ferramenta do Entity Framework Core:

```bash
dotnet tool install --global dotnet-ef
```

5. Inicie a API

```bash
dotnet run
```

A API estará disponível na URL informada pelo terminal após a inicialização do projeto.

### Desenvolvimento

Para executar a aplicação utilizando o ambiente de desenvolvimento:

```bash
dotnet watch run
```

## Privacidade e Segurança

O projeto adota boas práticas de proteção de dados, incluindo armazenamento seguro de senhas por hash, comunicação via HTTPS e coleta apenas dos dados necessários para autenticação e utilização da aplicação.

## 🚀 Próximos passos

Passos implementados e funcionalidades futuras que pretendo adicionar ao decorrer do tempo.

- [x] Cadastro e autenticação de usuários
- [x] Cadastro de insumos
- [x] Gerenciamento de categorias
- [x] Dashboard de estoque
- [ ] Recuperação de senha por e-mail
- [ ] Exportação de dados para Excel e PDF
- [ ] Cadastro de lista de compras
- [ ] Notificações de estoque baixo
- [ ] Exibir mercados próximos
- [ ] Registro de idas ao mercado

> [!NOTE]
> Este projeto está em desenvolvimento contínuo. A versão atual contempla as funcionalidades principais, enquanto novas funcionalidades estão planejadas para versões futuras.


**Se você tiver alguma sugestão ou dica por favor não hesite em me contatar!**
