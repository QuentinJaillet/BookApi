# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Common Development Commands

### Build and Run
```bash
dotnet build                    # Build the solution
dotnet run                      # Run the API (starts on configured ports)
dotnet watch run               # Run with hot reload for development
```

### Database Operations
```bash
dotnet ef migrations add <MigrationName>    # Create new migration
dotnet ef database update                   # Apply migrations to database
dotnet ef migrations remove                 # Remove last migration (if not applied)
```

### Docker Operations
```bash
docker build -t bookapi .                  # Build Docker image
docker run -p 8080:8080 bookapi           # Run containerized API
```

## Architecture Overview

This is a **Clean Architecture** ASP.NET Core 9.0 Web API implementing **Domain-Driven Design** principles with **CQRS pattern** using MediatR.

### Layer Structure
- **Domain** (`/Domain/Models/`): Core business entities (Book, Author, BookAuthors)
- **Application** (`/Application/`): CQRS Commands/Queries and their Handlers
- **Infrastructure** (`/Infrastructure/`): Data access with EF Core and Repository pattern

### Key Patterns
- **CQRS with MediatR**: Separate commands (writes) and queries (reads)
- **Repository Pattern**: `IBookRepository` abstracts data access
- **Minimal APIs**: No controllers, routes defined in Program.cs
- **Async/Await**: All operations use `ConfigureAwait(false)` for performance

### Database Setup
- **SQLite** database (`books.db` file)
- **Entity Framework Core** 9.0.6 with migrations
- **Primary Key**: ISBN for Book entity
- **Fluent API**: Entity configuration in `BookDbContext.OnModelCreating()`

### API Endpoints
```
GET    /api/books           # Get all books
GET    /api/books/{isbn}    # Get book by ISBN  
POST   /api/books           # Add new book
DELETE /api/books/{isbn}    # Delete book by ISBN
```

### Service Registration
All services (DbContext, Repository, MediatR) are registered in Program.cs with proper scoping.

## Current Implementation Notes

### Namespace Issue
Domain models incorrectly use `BookApi.Models` namespace instead of `BookApi.Domain.Models`. Update imports when adding new features.

### Repository Interface Location
`IBookRepository` is in `BookApi.Infrastructure.Repositories.Interfaces` namespace, not Domain layer as would be ideal in pure DDD.

### Missing Features
- No validation on commands (consider FluentValidation)
- No global error handling middleware
- No logging implementation
- No unit tests

### Development Database
The SQLite database file (`books.db`) is created automatically on first run. Connection string fallback is "Data Source=books.db" if not configured.