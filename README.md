# FCamara Estacionamento API

Este projeto é parte do teste técnico encontrado no GitHub da empresa FCamara, ainda não tive o prazer de participar do processo seletivo interno deles e aproveitei o desafio para aumentar meu conhecimento e enriquecer o portfólio.

### Tecnologias Utilizadas

- **.NET 8**: A aplicação foi desenvolvida usando .NET na versão 8, aproveitando as funcionalidades e melhorias dessa versão.
- **Entity Framework Core**: Utilizado para persistência de dados no banco, facilitando operações de CRUD e garantindo a integridade dos dados.
- **Swagger**: Implementado para documentar a API de forma interativa, permitindo testar os endpoints diretamente pelo navegador.
- **Docker**: Suporte a Docker para facilitar o deployment e execução da aplicação em diferentes ambientes.
- **SQLite**: Utilizado para execução local da aplicação, facilitando testes e desenvolvimento sem necessidade de configurações adicionais.
- **PostgreSQL**: Utilizado quando a aplicação é executada em containers Docker, oferecendo uma solução robusta para ambientes de produção.
- **xUnit**: Utilizado para implementar testes unitários, garantindo a qualidade e integridade do código.

### Executando a Aplicação Localmente

Para executar a aplicação localmente, utilizando SQLite:

1. Clone o repositório:

```bash
git clone https://github.com/mucasliranda/fcamara-test-dotnet.git
```

2. Navegue até o diretório do projeto da API:

```bash
cd fcamara-test-dotnet/src/fcamara-test-dotnet.Api
```

3. Execute a aplicação (garanta que você tenha o .NET SDK instalado):

```bash
dotnet run
```

A aplicação estará disponível em http://localhost:5126 ou na porta especificada no arquivo `appsettings.json`.

### Executando a Aplicação com Docker (PostgreSQL)

Para executar a aplicação com Docker, utilizando PostgreSQL:

1. Clone o repositório:

```bash
git clone https://github.com/mucasliranda/fcamara-test-dotnet.git
```

2. Navegue até o diretório do projeto:

```bash
cd fcamara-test-dotnet
```

3. Execute o container Docker:

```bash
docker compose up --build
```

A aplicação estará disponível em http://localhost:5126 ou na porta especificada no arquivo `docker-compose.yml`.

### Documentação da API

A documentação da API está disponível em http://localhost:5126/swagger/index.html.