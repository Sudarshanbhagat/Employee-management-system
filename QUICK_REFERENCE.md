# Quick Reference Guide

## Project Overview

**Name:** Enterprise Management System (EMS)  
**Type:** Full-Stack ASP.NET Core Web Application  
**Status:** Complete & Ready to Use  
**Build Date:** February 4, 2026  

## File Organization

### Backend Structure
```
src/EMS.API/              → API Controllers, Views, Startup
src/EMS.Services/         → Business Logic Layer
src/EMS.Data/             → Database Models, DbContext, Repositories
src/EMS.Common/           → Shared Utilities, Constants, Exceptions
```

### Key Locations

| What | Where |
|------|-------|
| Controllers | `src/EMS.API/Controllers/` |
| Services | `src/EMS.Services/` |
| Database Models | `src/EMS.Data/Models/` |
| Repositories | `src/EMS.Data/Repositories/` |
| Database Context | `src/EMS.Data/EmsDbContext.cs` |
| Views | `src/EMS.API/Views/` |
| JavaScript | `src/EMS.API/wwwroot/js/` |
| CSS | `src/EMS.API/wwwroot/css/` |
| Configuration | `src/EMS.API/appsettings.json` |

## Quick Commands

```bash
# Restore packages
dotnet restore

# Build project
dotnet build

# Run application
dotnet run

# Run tests
dotnet test

# Create migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update

# Drop database
dotnet ef database drop

# View EF help
dotnet ef --help
```

## API Endpoints Cheat Sheet

### Authentication
```
POST   /api/auth/login           - Login user
POST   /api/auth/register        - Register new user
```

### Employees
```
GET    /api/employee             - Get all employees
GET    /api/employee/{id}        - Get specific employee
POST   /api/employee             - Create employee
PUT    /api/employee/{id}        - Update employee
DELETE /api/employee/{id}        - Delete employee
GET    /api/employee/department/{deptId}  - Get dept employees
```

### Projects
```
GET    /api/project              - Get all projects
GET    /api/project/{id}         - Get specific project
POST   /api/project              - Create project
PUT    /api/project/{id}         - Update project
DELETE /api/project/{id}         - Delete project
```

### Leaves
```
GET    /api/leave/{id}           - Get specific leave
GET    /api/leave/employee/{empId}  - Get employee leaves
GET    /api/leave/pending        - Get pending leaves
POST   /api/leave/apply          - Apply for leave
POST   /api/leave/{id}/approve   - Approve leave
POST   /api/leave/{id}/reject    - Reject leave
```

## Database Models

| Model | Purpose |
|-------|---------|
| Employee | Store employee information |
| Department | Organize employees into departments |
| Role | Define user roles (Admin, HR, Manager, Employee) |
| User | Authentication and login |
| Project | Track company projects |
| LeaveRequest | Leave applications |
| LeaveType | Types of leaves (Sick, Vacation, etc.) |
| AuditLog | Track all important changes |

## Configuration Keys

In `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;..."  // PostgreSQL
  },
  "Jwt": {
    "Secret": "...",                              // 32+ chars
    "ExpirationMinutes": 1440                     // 24 hours
  },
  "Cors": {
    "AllowedOrigins": ["http://localhost:3000"]
  }
}
```

## User Roles

| Role | Permissions |
|------|-------------|
| Admin | Full system access, create/delete/modify everything |
| HR | Manage employees, approve leaves |
| Manager | Manage projects, approve leaves, view team |
| Employee | View own data, apply for leaves |

## Database Tables

- `Employees` - 13 fields
- `Departments` - 5 fields
- `Roles` - 4 fields  
- `Projects` - 9 fields
- `LeaveRequests` - 10 fields
- `LeaveTypes` - 5 fields
- `Users` - 8 fields
- `AuditLogs` - 7 fields

## Common Tasks

### Create New API Endpoint
1. Create method in Controller (`src/EMS.API/Controllers/`)
2. Create Service method (`src/EMS.Services/`)
3. Create Repository method if needed (`src/EMS.Data/Repositories/`)
4. Test with Postman or Swagger

### Add New Database Column
1. Add property to Model (`src/EMS.Data/Models/`)
2. Create migration: `dotnet ef migrations add AddFieldName`
3. Update database: `dotnet ef database update`
4. Update DTO if needed (`src/EMS.Data/DTOs/`)

### Fix Database Issues
```bash
# Reset database
dotnet ef database drop --force
dotnet ef database update

# View migrations
dotnet ef migrations list

# Remove last migration
dotnet ef migrations remove
```

### Debug API Calls
Use browser DevTools → Network tab or Postman:
1. Get JWT token from login
2. Add header: `Authorization: Bearer {token}`
3. Test endpoint

## Views Location Map

| Page | File |
|------|------|
| Login | `Views/Auth/Login.cshtml` |
| Dashboard | `Views/Dashboard/Index.cshtml` |
| Employees | `Views/Employee/Index.cshtml` |
| Projects | `Views/Project/Index.cshtml` |
| Leaves | `Views/Leave/Index.cshtml` |
| Layout | `Views/Shared/_Layout.cshtml` |

## JavaScript Files Map

| Script | Purpose |
|--------|---------|
| `site.js` | Global API calls and utilities |
| `dashboard.js` | Dashboard page logic |
| `employees.js` | Employee CRUD operations |
| `projects.js` | Project CRUD operations |
| `leaves.js` | Leave request workflow |

## Troubleshooting Checklist

- [ ] PostgreSQL running? `pg_isready -h localhost`
- [ ] Connection string correct? Check appsettings.json
- [ ] Migrations applied? `dotnet ef database update`
- [ ] Packages restored? `dotnet restore`
- [ ] JWT Secret set? 32+ characters in appsettings.json
- [ ] Port available? Check port 5001
- [ ] Firewall allowing connection? Check Windows Firewall

## Default Seed Data

**Roles:**
- Admin
- HR
- Manager
- Employee

**Leave Types:**
- Sick Leave (10 days)
- Vacation (20 days)
- Personal Leave (5 days)
- Maternity Leave (180 days)

**Departments:**
- IT
- HR
- Finance

## Important Files to Know

| File | Purpose |
|------|---------|
| `Program.cs` | Application startup configuration |
| `EmsDbContext.cs` | Database context and seed data |
| `appsettings.json` | Configuration settings |
| `EnterpriseManagementSystem.sln` | Solution file |
| `SETUP.md` | Setup instructions |
| `DOCUMENTATION.md` | Full documentation |

## Next: Get Started

1. Read [SETUP.md](./SETUP.md)
2. Set up PostgreSQL database
3. Update appsettings.json
4. Run `dotnet ef database update`
5. Run `dotnet run`
6. Open `https://localhost:5001`

---

**Questions?** Check [DOCUMENTATION.md](./DOCUMENTATION.md) or [README.md](./README.md)

**Ready to Code!** 🚀
