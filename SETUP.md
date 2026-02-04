# Getting Started with Enterprise Management System

## Prerequisites

Before you begin, ensure you have the following installed:

1. **.NET 6.0 SDK** - Download from [dot.net](https://dot.net)
2. **PostgreSQL 13+** - Download from [postgresql.org](https://www.postgresql.org)
3. **Git** - Download from [git-scm.com](https://git-scm.com)
4. **Visual Studio 2022** or **VS Code** (optional but recommended)

## Setup Steps

### 1. Database Setup

First, create the PostgreSQL database:

```bash
# Open PostgreSQL command line
psql -U postgres

# Create the database
CREATE DATABASE ems_dev;

# Exit
\q
```

### 2. Install Dependencies

Navigate to the project root and restore NuGet packages:

```bash
cd "e:\Enterprise Management System"
dotnet restore
```

### 3. Update Connection String

Edit `src/EMS.API/appsettings.json` and update the connection string:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;Database=ems_dev;User Id=postgres;Password=YOUR_PASSWORD;SSL Mode=Prefer;"
}
```

Replace `YOUR_PASSWORD` with your PostgreSQL password.

### 4. Update JWT Secret

In the same appsettings.json file, update the JWT secret (must be at least 32 characters):

```json
"Jwt": {
    "Secret": "your-super-secret-key-at-least-32-characters-long-for-jwt-signing",
    "ExpirationMinutes": 1440
}
```

### 5. Run Database Migrations

```bash
cd src/EMS.API
dotnet ef database update
```

This will create all the necessary tables and seed initial data.

### 6. Run the Application

```bash
dotnet run
```

The application will start at `https://localhost:5001`

### 7. Default Login Credentials

**Email:** `admin@company.com`  
**Password:** `Admin@123`

(You'll need to create this user first, or modify the seed data)

## Project Structure

```
EnterpriseManagementSystem/
├── src/
│   ├── EMS.API/           - ASP.NET Core API & Views
│   ├── EMS.Services/      - Business Logic
│   ├── EMS.Data/          - Data Models & Repositories
│   └── EMS.Common/        - Shared Utilities
├── tests/
│   └── EMS.Tests/         - Unit Tests
└── README.md
```

## Available Endpoints

### Authentication
- `POST /api/auth/login` - Login
- `POST /api/auth/register` - Register

### Employees
- `GET /api/employee` - Get all employees
- `GET /api/employee/{id}` - Get employee by ID
- `POST /api/employee` - Create employee
- `PUT /api/employee/{id}` - Update employee
- `DELETE /api/employee/{id}` - Delete employee

### Projects
- `GET /api/project` - Get all projects
- `GET /api/project/{id}` - Get project by ID
- `POST /api/project` - Create project
- `PUT /api/project/{id}` - Update project
- `DELETE /api/project/{id}` - Delete project

### Leaves
- `GET /leave/employee/{employeeId}` - Get employee leaves
- `GET /leave/pending` - Get pending leaves
- `POST /leave/apply` - Apply for leave
- `POST /leave/{id}/approve` - Approve leave
- `POST /leave/{id}/reject` - Reject leave

## Running Tests

```bash
cd tests/EMS.Tests
dotnet test
```

## Troubleshooting

### Database Connection Error
- Verify PostgreSQL is running
- Check connection string in appsettings.json
- Ensure database user has correct permissions

### Port Already in Use
- Change the port in launchSettings.json
- Or kill the process: `netstat -ano | findstr :5001`

### Migration Issues
```bash
# Reset database
dotnet ef database drop
dotnet ef database update
```

## Common Commands

```bash
# Build solution
dotnet build

# Run tests
dotnet test

# Create new migration
dotnet ef migrations add YourMigrationName

# Update database
dotnet ef database update

# View database
# Use pgAdmin or psql to view tables and data
```

## Next Steps

1. Create additional employees with different roles
2. Create projects and assign employees
3. Apply for leaves and test the approval workflow
4. Customize the UI with your branding
5. Add more features as needed

## Support

For issues or questions, refer to the main [README.md](./README.md) or [DOCUMENTATION.md](./DOCUMENTATION.md).

## License

MIT License - See LICENSE file for details.
