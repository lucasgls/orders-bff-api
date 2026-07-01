# 📦 Cancel Orders BFF API

> ⚠️ **Em desenvolvimento**

API REST desenvolvida em .NET 10 com ASP.NET Core para gerenciamento e cancelamento de pedidos. Permite listar pedidos, buscar por ID, cancelar e avançar o status de pedidos com validações de regras de negócio.

---

## ✅ Funcionalidades

- Criação de pedido  
- Listagem de todos os pedidos
- Busca de pedido por ID
- Cancelamento de pedido com validação de status
- Avanço de status do pedido com validação de regras de negócio
- Tratamento global de erros via middleware

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

---

## 📋 Endpoints

### `POST /api/orders`
Cria um novo pedido.

**Request Body:**
```json
{
  "customerName": "Lucas Gabriel",
  "totalAmount": 350.00
}
```

**Response `201 Created`:**
```json
{
  "id": "03d7c953-166b-4005-aebd-9b7452f7895c",
  "orderNumber": "PED-0006",
  "customerName": "Lucas Gabriel",
  "totalAmount": 350.00,
  "status": 0,
  "createdAt": "2026-05-01T14:00:00Z",
  "updatedAt": "2026-05-01T14:00:00Z"
}
```

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

### `PATCH /api/orders/{id}/advance-status`
Avança o status do pedido para o próximo na sequência. Retorna erro se o pedido estiver cancelado ou já faturado.

**Response `200 OK`:**
```json
{
    "orderId": "22222222-2222-2222-2222-222222222222",
    "orderNumber": "PED-0002",
    "currentStatus": 1,
    "updatedAt": "2026-06-25T14:00:00Z"
}
```

**Response `404 Not Found`** — pedido não existe:
```json
{
  "erro": "Pedido não encontrado",
  "status": 404,
  "timestamp": "2026-06-29T14:00:00Z"
}
```

**Response `422 Unprocessable Entity`** — pedido cancelado ou faturado:
```json
{
  "erro": "Pedido faturado não pode ser avançado",
  "status": 422,
  "timestamp": "2026-06-29T14:00:00Z"
}
```

---

## 🔢 Status dos Pedidos

| Valor | Nome               | Descrição                        |
|-------|--------------------|----------------------------------|
| `0`   | `OrderPlaced`      | Pedido realizado                 |
| `1`   | `PaymentPending`   | Aguardando pagamento             |
| `2`   | `PaymentApproved`  | Pagamento aprovado               |
| `3`   | `ReadyForHandling` | Pronto para separação            |
| `4`   | `Handling`         | Em separação                     |
| `5`   | `Invoiced`         | Faturado — não pode ser cancelado |
| `6`   | `Canceled`         | Cancelado                        |

---

## 🗄️ Dados de Seed

O banco é populado automaticamente com 5 pedidos de exemplo:

| Pedido   | Cliente         | Valor      | Status           |
|----------|-----------------|------------|------------------|
| PED-0001 | Ana Silva       | R$ 250,00  | OrderPlaced      |
| PED-0002 | Carlos Souza    | R$ 1340,00 | PaymentApproved  |
| PED-0003 | Fernanda Lima   | R$ 89,90   | Handling         |
| PED-0004 | Ricardo Mendes  | R$ 499,00  | Invoiced         |
| PED-0005 | Juliana Costa   | R$ 720,50  | Canceled         |

---
## ⚠️ Regras de Negócio

- Pedidos com status `Canceled` **não podem** ser cancelados novamente → `422`
- Pedidos com status `Invoiced` **não podem** ser cancelados → `422`
- Pedidos com status `Canceled` ou `Invoiced` **não podem** ter o status avançado → `422`
- Todos os demais status **podem** ser cancelados ou avançados normalmente