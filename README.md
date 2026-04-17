# MinhaLojaAPI

Um backend simples de e-commerce desenvolvido com **C# .NET 10**, criado como material prático para aprendizado e como base de integração com qualquer frontend.

## Propósito

Este projeto foi desenvolvido para servir como:
- Material de estudo - implementação clean de APIs RESTful
- Base de integração - estrutura pronta para conectar com frontends
- Referência prática - boas práticas em desenvolvimento backend com .NET

## Tecnologias

- .NET 10
- C# 14.0
- Entity Framework Core - ORM para banco de dados
- SQLite - banco de dados leve e portável
- JWT - autenticação e autorização
- Dependency Injection - padrão nativo do .NET

## Funcionalidades

- Autenticação JWT - login seguro com tokens
- Gerenciamento de Usuários - registro e autenticação
- Categorias - CRUD completo de categorias
- Produtos - CRUD de produtos com categorias
- Autorização - controle por bearer token

## Arquitetura

```
MinhaLojaAPI/
├── Controllers/          # Endpoints da API
│   ├── AuthController.cs
│   ├── CategoriesController.cs
│   ├── ProductsController.cs
│   └── MainController.cs
├── Services/             # Lógica de negócio
│   ├── AuthService.cs
│   ├── CategoryService.cs
│   ├── TokenService.cs
│   └── Interfaces
├── Repositories/         # Acesso aos dados
├── Models/               # Entidades do domínio
│   ├── User.cs
│   ├── Category.cs
│   ├── Product.cs
│   └── Role.cs
├── DTOs/                 # Objetos de transferência
├── Data/                 # DbContext
│   └── AppDbContext.cs
├── appsettings.json      # Configurações
└── Program.cs            # Setup da aplicação
```

## Como Usar

### 1. Pré-requisitos
- .NET 10 SDK
- Visual Studio 2026 ou VS Code

### 2. Clonar o repositório
```
git clone https://github.com/caioalvesdev/MinhaLojaAPI.git
cd MinhaLojaAPI
```

### 3. Restaurar pacotes
```
dotnet restore
```

### 4. Executar migrations
```
dotnet ef database update
```

### 5. Iniciar a API
```
dotnet run
```

A API estará em `https://localhost:5001`

## Endpoints

### Autenticação
| Método | Rota | Auth |
|--------|------|------|
| POST | `/auth/login` | Nao |
| POST | `/auth/register` | Nao |

### Categorias
| Método | Rota | Auth |
|--------|------|------|
| GET | `/categories` | Nao |
| POST | `/categories` | Sim |
| PUT | `/categories/{id}` | Sim |
| DELETE | `/categories/{id}` | Sim |

### Produtos
| Método | Rota | Auth |
|--------|------|------|
| GET | `/products` | Nao |
| POST | `/products` | Sim |
| PUT | `/products/{id}` | Sim |
| DELETE | `/products/{id}` | Sim |

## Autenticação

### Login
```
POST /auth/login
Content-Type: application/json

{
  "email": "usuario@example.com",
  "password": "senha123"
}
```

**Resposta:**
```json
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiresAt": "2026-04-18T10:30:00Z",
  "user": {
    "id": "550e8400-e29b-41d4-a716-446655440000",
    "username": "joao_silva",
    "email": "usuario@example.com"
  }
}
```

### Usar o token
```
Authorization: Bearer {accessToken}
```

## Padrões Utilizados

- Clean Architecture
- Repository Pattern
- Dependency Injection
- DTOs (Data Transfer Objects)
- Async/Await
- JWT Authentication
- Exception Handling

## Testando a API

Use **Postman**, **Insomnia** ou **curl**:

```powershell
# Login
$response = Invoke-WebRequest -Uri "https://localhost:5001/auth/login" `
  -Method POST `
  -ContentType "application/json" `
  -Body '{"email":"user@example.com","password":"password123"}'

# Listar categorias
Invoke-WebRequest -Uri "https://localhost:5001/categories" -Method GET
```

## Contribuindo

Sinta-se livre para:
- Estudar o código
- Fazer fork e adaptar
- Abrir issues
- Criar pull requests

## Licença

MIT License - Use para fins educacionais e comerciais

---

Desenvolvido com dedicação para aprendizado prático de .NET backend