Blog API

A RESTful API built with .NET 8, using Clean Architecture principles and Separation of Concerns. This project is structured for educational purposes and created by Lucas Sodré.

✨ Features

CRUD operations for blog posts and comments

Repository pattern for data access

FluentValidation for DTO validation

Error handling with Serilog

Swagger for interactive API documentation

Unit testing with xUnit

.NET 8

Entity Framework Core

📚 Usabilaty

Postagens (/api/posts)

GET / → List all Posts

GET /{id} → List Post By ID

POST / → Create new Post

POST /{id} → Create new Comment for Posts

📁 Project Structure

BlogApi
├── BlogApi.Presentation       → API project (controllers, DI config, Swagger)
├── BlogApi.Application        → Application layer (services, DTOs, validation)
├── BlogApi.Domain             → Domain entities and interfaces
├── BlogApi.Infrastructure     → Data layer (EF Core, repositories)
├── BlogApi.Tests              → Unit tests

🔧 Setup Instructions

Clone the repository

git clone https://github.com/yourusername/BlogApi.git
cd BlogApi

Set the connection string

Edit appsettings.json in BlogApi.Presentation:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BlogDb;User Id=sa;Password=your_password;TrustServerCertificate=True;"
}

Run migrations

dotnet ef migrations add InitialCreate --project BlogApi.Infrastructure --startup-project BlogApi.Presentation
dotnet ef database update --project BlogApi.Infrastructure --startup-project BlogApi.Presentation

Run the API

dotnet run --project BlogApi.Presentation

🔍 Swagger Usage

After starting the app in Development mode, navigate to:

https://localhost:{port}/swagger

You will see the interactive documentation where you can test endpoints.

The Swagger config is customized with:

Title: Blog API

Version: v1

Description: Educational Blog API for clean architecture practice

Author: Lucas Sodré

✅ Running Tests

dotnet test

📬 Author

Lucas Sodré

📝 Future Improvements

If I had more time, I would:

Implement PATCH and PUT methods for blog posts

Create GetAll and GetById endpoints for comments

Add soft delete functionality for posts and comments

Introduce active/inactive status handling for UI usage

Improove unitTests