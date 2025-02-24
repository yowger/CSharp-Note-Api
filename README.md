# 📒 CRUD Note API

A simple CRUD API for managing notes, built with C# and ASP.NET Core using best practices.

## 🛠️ Technologies Used

- **C#** - Primary programming language  
- **ASP.NET Core** - Backend framework  
- **Entity Framework Core (EF Core)** - ORM for database interactions  
- **SQL Server** - Database  
- **Scalar.AspNetCore** - API for Scalar event sourcing  
- **Docker** (Optional) - Containerization  

## Getting Started  

### **Clone the Repository**
```sh
git clone https://github.com/yowger/CSharp-Note-Api.git
cd crud-note-api
```

### Run Project

#### Without Docker:
```sh
dotnet run
```
This will start the API on `http://localhost:5127`.

### Scalar Service
Run Scalar:
```sh
http://localhost:5127/scalar/v1
```
