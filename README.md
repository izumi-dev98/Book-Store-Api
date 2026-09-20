# BookStoreAPI

A RESTful Web API for managing a book store, built with **ASP.NET Core 8** and **Entity Framework Core** (SQL Server). It currently exposes full CRUD endpoints for authors, with the `Books` entity already modelled and migrated.

## Tech Stack

| Component | Version / Detail |
|---|---|
| Framework | .NET 8 (ASP.NET Core Web API) |
| ORM | Entity Framework Core 8.0.31 (SQL Server provider) |
| Mapping | AutoMapper 12.0.1 |
| API Docs | Swashbuckle / Swagger 6.6.2 |
| Database | SQL Server Express |

## Project Structure

```
BookStoreAPI/
├── Controllers/
│   └── AuthorsController.cs      # Author CRUD endpoints
├── Data/
│   └── AppDbContext.cs           # EF Core DbContext (Authors, Books)
├── Models/
│   ├── Domains/                  # Authors, Books entities
│   └── DTO/                      # AuthorsDTO, CreateAuthorDTO, UpdateAuthorDTO
├── Mapper/
│   └── AutoMapper.cs             # Domain <-> DTO profiles
├── Migrations/                   # EF Core migrations
├── Program.cs                    # App startup & DI configuration
└── appsettings.json              # Connection string & logging
```

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (LocalDB, Express, or full instance)
- EF Core CLI tools: `dotnet tool install --global dotnet-ef`

### Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/izumi-dev98/Book-Store-Api.git
   cd Book-Store-Api
   ```

2. **Configure the connection string**

   Update `DefaultConnections` in `BookStoreAPI/appsettings.json` to point at your SQL Server instance:

   ```json
   "ConnectionStrings": {
     "DefaultConnections": "Server=.\\SQLEXPRESS;Database=BookStore;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

3. **Apply the migrations**

   ```bash
   dotnet ef database update --project BookStoreAPI
   ```

4. **Run the API**

   ```bash
   dotnet run --project BookStoreAPI
   ```

Swagger UI opens automatically in Development at `https://localhost:7044/swagger` (HTTP: `http://localhost:5142/swagger`).

## API Endpoints

Base route: `/api/authors`

| Method | Endpoint | Description | Success | Failure |
|---|---|---|---|---|
| `GET` | `/api/authors` | Get all authors | `200 OK` | `404 Not Found` (empty list) |
| `GET` | `/api/authors/{id}` | Get a single author by ID | `200 OK` | `404 Not Found` |
| `POST` | `/api/authors` | Create a new author | `201 Created` | `400 Bad Request` |
| `PUT` | `/api/authors/{id}` | Update an existing author | `204 No Content` | `404 Not Found` |
| `DELETE` | `/api/authors/{id}` | Delete an author | `200 OK` | `404 Not Found` |

### Example — Create an author

**Request**

```http
POST /api/authors
Content-Type: application/json

{
  "name": "Haruki Murakami"
}
```

**Response** — `201 Created`

```json
{
  "name": "Haruki Murakami"
}
```

### Example — Update an author

```http
PUT /api/authors/1
Content-Type: application/json

{
  "name": "Kazuo Ishiguro"
}
```

`Name` is required on update and returns a validation error if omitted.

## Data Model

**Authors**

| Field | Type | Notes |
|---|---|---|
| `Id` | `int` | Primary key, identity |
| `Name` | `string` | Required |

**Books**

| Field | Type | Notes |
|---|---|---|
| `Id` | `int` | Primary key, identity |
| `Title` | `string` | Required |
| `Description` | `string` | Required |
| `ImageUrl` | `string` | Required |
| `Price` | `decimal(18,2)` | Required |
| `AuthorId` | `int` | Author reference |
| `Authors` | `Authors` | Navigation property |


