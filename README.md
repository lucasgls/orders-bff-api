# 📦 Cancel Orders BFF API

> ⚠️ **Em desenvolvimento**

API REST desenvolvida em .NET 10 com ASP.NET Core para gerenciamento de cancelamento de pedidos. Permite listar pedidos, buscar por ID e cancelar pedidos com validações de regras de negócio.

---

## ✅ Funcionalidades

- Listagem de todos os pedidos
- Busca de pedido por ID
- Cancelamento de pedido com validação de status
- Tratamento global de erros via middleware
- Seed de dados para ambiente de desenvolvimento

---

## 🛠️ Tecnologias

- C# / .NET 10
- ASP.NET Core
- Entity Framework Core 10
- PostgreSQL 18

---

## ▶️ Como executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL 18](https://www.postgresql.org/)

### 1. Clone o repositório

```bash
git clone https://github.com/lucasgls/orders-bff-api.git
cd orders-bff-api
```

### 2. Configure a connection string

No arquivo `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=orders_db;Username=postgres;Password=sua_senha"
  }
}
```

### 3. Aplique as migrations

```bash
dotnet ef database update --project OrderProcessingAPI
```

### 4. Execute o projeto

```bash
dotnet run --project OrderProcessingAPI
```

A API estará disponível em `https://localhost:7221` por padrão. 
(vale confirmar no launchSettings.json)

---

## 📋 Endpoints

### `GET /api/orders`
Retorna a lista de todos os pedidos cadastrados.

**Response `200 OK`:**
```json
[
  {
    "id": "11111111-1111-1111-1111-111111111111",
    "orderNumber": "PED-0001",
    "customerName": "Ana Silva",
    "totalAmount": 250.00,
    "status": 0,
    "createdAt": "2026-06-20T12:00:00Z",
    "updatedAt": "2026-06-20T12:00:00Z"
  }
]
```

---

### `GET /api/orders/{id}`
Retorna um pedido específico pelo ID.

**Response `200 OK`:**
```json
{
  "id": "11111111-1111-1111-1111-111111111111",
  "orderNumber": "PED-0001",
  "customerName": "Ana Silva",
  "totalAmount": 250.00,
  "status": 0,
  "createdAt": "2026-06-20T12:00:00Z",
  "updatedAt": "2026-06-20T12:00:00Z"
}
```

**Response `404 Not Found`:**
```json
{
  "erro": "Pedido não encontrado",
  "status": 404,
  "timestamp": "2026-06-25T14:00:00Z"
}
```

---

### `PATCH /api/orders/{id}/cancel`
Cancela um pedido pelo ID. Retorna erro se o pedido já estiver cancelado ou faturado.

**Response `200 OK`:**
```json
{
  "orderId": "11111111-1111-1111-1111-111111111111",
  "message": "Pedido cancelado com sucesso!",
  "orderNumber": "PED-0001",
  "canceledAt": "2026-06-25T14:00:00Z"
}
```

**Response `404 Not Found`** — pedido não existe:
```json
{
  "erro": "Pedido não encontrado",
  "status": 404,
  "timestamp": "2026-06-25T14:00:00Z"
}
```

**Response `422 Unprocessable Entity`** — pedido já cancelado ou faturado:
```json
{
  "erro": "Pedido já está cancelado",
  "status": 422,
  "timestamp": "2026-06-25T14:00:00Z"
}
```

---

## 🔢 Status dos Pedidos

| Valor | Nome               | Descrição                        |
|-------|--------------------|----------------------------------|
| `0`   | `ORDER_PLACED`     | Pedido realizado                 |
| `1`   | `PAYMENT_PENDING`  | Aguardando pagamento             |
| `2`   | `PAYMENT_APPROVED` | Pagamento aprovado               |
| `3`   | `READY_FOR_HANDLING` | Pronto para separação          |
| `4`   | `HANDLING`         | Em separação                     |
| `5`   | `INVOICED`         | Faturado — não pode ser cancelado |
| `6`   | `CANCELED`         | Cancelado                        |

---

## 🗄️ Dados de Seed

O banco é populado automaticamente com 5 pedidos de exemplo:

| Pedido   | Cliente         | Valor     | Status               |
|----------|-----------------|-----------|----------------------|
| PED-0001 | Ana Silva       | R$ 250,00 | ORDER_PLACED         |
| PED-0002 | Carlos Souza    | R$ 1340,00| PAYMENT_APPROVED     |
| PED-0003 | Fernanda Lima   | R$ 89,90  | HANDLING             |
| PED-0004 | Ricardo Mendes  | R$ 499,00 | INVOICED             |
| PED-0005 | Juliana Costa   | R$ 720,50 | CANCELED             |

---
## ⚠️ Regras de Negócio

- Pedidos com status `CANCELED` **não podem** ser cancelados novamente → `422`
- Pedidos com status `INVOICED` **não podem** ser cancelados → `422`
- Todos os demais status **podem** ser cancelados normalmente

---
