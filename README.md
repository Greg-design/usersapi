# UsersApi - API de Gerenciamento de Usuários

Esta é uma API RESTful desenvolvida em ASP.NET Core para gerenciamento de usuários, oferecendo operações CRUD (Create, Read, Update, Delete) com autenticação segura e validação de dados.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQLite
- BCrypt.NET (para hash de senhas)
- Swagger/OpenAPI

## 📋 Requisitos

- .NET 6.0 ou superior
- Um editor de código (recomendado: Visual Studio 2022 ou VS Code)

## 🛠️ Configuração do Projeto

1. Clone o repositório
2. Abra a solução no Visual Studio ou VS Code
3. Restaure os pacotes NuGet
4. Execute as migrações do banco de dados:
   ```
   dotnet ef database update
   ```
5. Execute o projeto:
   ```
   dotnet run
   ```

## 📌 Endpoints da API

### Usuários

- **GET /api/users**

  - Lista todos os usuários cadastrados
  - Não requer parâmetros

- **GET /api/users/{id}**

  - Retorna um usuário específico
  - Parâmetro: id (Guid)

- **POST /api/users**

  - Cria um novo usuário
  - Corpo da requisição:
    ```json
    {
      "nome": "string",
      "login": "email@exemplo.com",
      "password": "string",
      "funcao": "string"
    }
    ```

- **PUT /api/users/{id}**

  - Atualiza um usuário existente
  - Parâmetro: id (Guid)
  - Corpo da requisição: mesmo formato do POST

- **DELETE /api/users/{id}**
  - Remove um usuário
  - Parâmetro: id (Guid)

## 🔒 Segurança

- Senhas são armazenadas com hash usando BCrypt
- Validação de dados nos modelos
- CORS configurado para permitir requisições do frontend (http://localhost:3000)

## 📝 Validações

O modelo de usuário inclui as seguintes validações:

- Nome: 3 a 200 caracteres
- Login: Deve ser um e-mail válido (máx. 100 caracteres)
- Senha: Mínimo 6 caracteres
- Função: 3 a 20 caracteres

## 🗄️ Banco de Dados

O projeto utiliza SQLite como banco de dados, com o arquivo `meubanco.db` localizado na raiz do projeto.

## 🌐 CORS

A API está configurada para aceitar requisições de:

- http://localhost:3000 (para desenvolvimento com React)

## 📚 Documentação da API

A documentação completa da API está disponível através do Swagger UI:

- Em desenvolvimento: https://localhost:7214/swagger
