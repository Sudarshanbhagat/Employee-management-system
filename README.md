# Enterprise Management System

A comprehensive, production-ready enterprise management platform built with ASP.NET Core, PostgreSQL, and modern web technologies. Designed to streamline employee management, project tracking, leave management, and organizational analytics.

**Live Demo:** [yourdomain.com](https://yourdomain.com)  
**Documentation:** [Full Project Documentation](./DOCUMENTATION.md)  
**Author:** Sudarshan Bhagat  
**Status:** Production Ready v2.1.0

---

## Table of Contents

- [Overview](#overview)
- [Key Features](#key-features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Quick Start](#quick-start)
- [Installation](#installation)
- [Configuration](#configuration)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [API Documentation](#api-documentation)
- [Features in Detail](#features-in-detail)
- [Testing](#testing)
- [Deployment](#deployment)
- [Screenshots](#screenshots)
- [Troubleshooting](#troubleshooting)
- [Performance](#performance)
- [Security](#security)
- [Contributing](#contributing)
- [License](#license)

---

## Overview

The Enterprise Management System (EMS) is a centralized platform that consolidates employee data, project management, leave tracking, and organizational insights into a single, secure application. I built this system to solve real problems I encountered during my internship—scattered data, manual processes, and lack of real-time visibility.

### What This System Does

- **Centralized Employee Management**: Store and manage all employee information in one secure location
- **Project Tracking**: Assign team members, monitor progress, and manage budgets
- **Leave Management**: Apply for leaves, track approvals, and maintain leave balances automatically
- **Attendance Tracking**: Daily attendance records and automated reporting
- **Financial Management**: Track expenses, manage budgets, and process payments
- **Real-time Dashboards**: Get instant insights into employee data, project status, and team metrics
- **Secure Access**: Role-based access control ensures users only see what they're allowed to

### Why I Built This

During my internship, I noticed our company was using Excel spreadsheets for everything. Employee information was scattered across multiple files, leave approvals were done via email, and there was no way to get quick insights into team performance. This system was my solution to that problem, and it's now used by multiple organizations.

---

## Key Features

### 1. Employee Management
- Add, edit, and manage employee profiles
- Store documents, certifications, and qualifications
- Track employment history and salary information
- Department and role assignment
- Employee directory with search and filtering

### 2. Project Management
- Create and manage projects with detailed information
- Assign team members and track allocations
- Monitor project progress and milestones
- Budget tracking and expense management
- Project status tracking (Planning, In Progress, Completed, On Hold)

### 3. Leave Management
- Apply for various types of leaves (Sick, Personal, Vacation, etc.)
- Automatic leave balance calculation
- Multi-level approval workflows
- Conflict detection to prevent double-booking
- Leave balance reports and history

### 4. Attendance Management
- Daily attendance tracking
- Automatic late/early detection
- Attendance reports by department
- Leave impact on attendance calculations
- Attendance analytics

### 5. Dashboard & Analytics
- Overview cards showing key metrics
- Employee growth trends
- Department distribution charts
- Project status overview
- Pending approvals at a glance
- Custom report generation

### 6. Security & Compliance
- JWT-based authentication
- Role-based access control (Admin, HR, Manager, Employee)
- Audit logging for all important operations
- Password encryption and validation
- CORS protection and HTTPS enforcement
- Data privacy controls

---

## Tech Stack

### Backend
- **Framework**: ASP.NET Core 6.0
- **Language**: C#
- **ORM**: Entity Framework Core
- **Authentication**: JWT (JSON Web Tokens)
- **Logging**: Serilog
- **Background Jobs**: Hangfire
- **Email**: SMTP
- **Testing**: NUnit, Moq

### Frontend
- **HTML**: HTML5
- **CSS**: Bootstrap 5
- **JavaScript**: Vanilla JS with AJAX
- **Charts**: Chart.js
- **Form Validation**: HTML5 + Custom Validators
- **Responsive Design**: Mobile-first approach

### Database
- **DBMS**: PostgreSQL 13+
- **Migrations**: Entity Framework Core migrations
- **Backup**: pg_dump for automated backups

### DevOps & Deployment
- **Web Server**: IIS (Internet Information Services)
- **Version Control**: Git/GitHub
- **CI/CD**: GitHub Actions (optional)
- **Monitoring**: Application Insights
- **Deployment**: Manual via PowerShell scripts or automated CI/CD

---

## Project Structure

```
EnterpriseManagementSystem/
│
├── src/
│   ├── EMS.API/                          # ASP.NET Core API
│   │   ├── Controllers/
│   │   │   ├── AuthenticationController.cs
│   │   │   ├── EmployeeController.cs
│   │   │   ├── ProjectController.cs
│   │   │   ├── LeaveController.cs
│   │   │   ├── DashboardController.cs
│   │   │   └── AttendanceController.cs
│   │   ├── Middleware/
│   │   │   ├── ExceptionHandlingMiddleware.cs
│   │   │   └── AuthenticationMiddleware.cs
│   │   ├── wwwroot/
│   │   │   ├── css/
│   │   │   │   └── site.css
│   │   │   ├── js/
│   │   │   │   ├── site.js
│   │   │   │   ├── employees.js
│   │   │   │   ├── leaves.js
│   │   │   │   └── dashboard.js
│   │   │   └── lib/
│   │   ├── Views/
│   │   │   ├── Shared/
│   │   │   │   └── _Layout.cshtml
│   │   │   ├── Dashboard/
│   │   │   ├── Employee/
│   │   │   ├── Project/
│   │   │   └── Leave/
│   │   ├── appsettings.json
│   │   ├── appsettings.Production.json
│   │   ├── Startup.cs
│   │   └── Program.cs
│   │
│   ├── EMS.Services/                     # Business Logic Layer
│   │   ├── EmployeeService.cs
│   │   ├── ProjectService.cs
│   │   ├── LeaveService.cs
│   │   ├── AuthenticationService.cs
│   │   ├── EmailService.cs
│   │   ├── DashboardService.cs
│   │   └── Interfaces/
│   │       ├── IEmployeeService.cs
│   │       ├── IProjectService.cs
│   │       └── ...
│   │
│   ├── EMS.Data/                         # Data Access Layer
│   │   ├── EmsDbContext.cs
│   │   ├── Repositories/
│   │   │   ├── EmployeeRepository.cs
│   │   │   ├── ProjectRepository.cs
│   │   │   ├── LeaveRepository.cs
│   │   │   └── Interfaces/
│   │   ├── Models/
│   │   │   ├── Employee.cs
│   │   │   ├── Project.cs
│   │   │   ├── LeaveRequest.cs
│   │   │   ├── Department.cs
│   │   │   └── ...
│   │   ├── DTOs/
│   │   │   ├── CreateEmployeeDto.cs
│   │   │   ├── UpdateEmployeeDto.cs
│   │   │   └── ...
│   │   └── Migrations/
│   │
│   └── EMS.Common/                       # Utilities & Constants
│       ├── Constants/
│       ├── Exceptions/
│       ├── Extensions/
│       └── Utilities/
│
├── tests/
│   └── EMS.Tests/
│       ├── EmployeeServiceTests.cs
│       ├── LeaveServiceTests.cs
│       ├── AuthenticationServiceTests.cs
│       └── Fixtures/
│
├── docs/
│   ├── API.md
│   ├── ARCHITECTURE.md
│   ├── DATABASE.md
│   └── DEPLOYMENT.md
│
├── scripts/
│   ├── Deploy.ps1
│   ├── Rollback.ps1
│   └── DatabaseSetup.sql
│
├── .github/
│   └── workflows/
│       ├── ci.yml
│       └── deploy.yml
│
├── DOCUMENTATION.md                      # Complete project documentation
├── README.md                             # This file
└── .gitignore
```

---

## Quick Start

### Prerequisites
- .NET 6.0 SDK or later
- PostgreSQL 13 or later
- Visual Studio 2022 (or VS Code)
- Git

### 5-Minute Setup (Development)

```bash
# 1. Clone the repository
git clone https://github.com/yourusername/enterprise-management-system.git
cd enterprise-management-system

# 2. Create the development database
createdb ems_dev

# 3. Configure connection string
# Edit src/EMS.API/appsettings.json and update ConnectionStrings

# 4. Run migrations
cd src/EMS.API
dotnet ef database update

# 5. Run the application
dotnet run

# 6. Open browser
# Navigate to https://localhost:5001
# Default login: admin@company.com / password: Admin@123
```

---

## Installation

### Step 1: Clone Repository

```bash
git clone https://github.com/yourusername/enterprise-management-system.git
cd enterprise-management-system
```

### Step 2: Install Dependencies

```bash
# Restore NuGet packages
dotnet restore

# Install Node packages (if using any npm modules)
npm install
```

### Step 3: Set Up Environment Variables

Create a `.env` file in the root directory:

```env
# Database
DB_HOST=localhost
DB_PORT=5432
DB_NAME=ems_dev
DB_USER=postgres
DB_PASSWORD=your_password

# JWT
JWT_SECRET=your-super-secret-key-at-least-32-characters-long
JWT_EXPIRATION=86400

# Email (for notifications)
SMTP_HOST=smtp.gmail.com
SMTP_PORT=587
SMTP_USER=your-email@gmail.com
SMTP_PASSWORD=your-app-password

# Application
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_URLS=https://localhost:5001
```

### Step 4: Configure Connection String

Edit `src/EMS.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;Database=ems_dev;User Id=postgres;Password=your_password;SSL Mode=Prefer;"
  },
  "Jwt": {
    "Secret": "your-super-secret-key-at-least-32-characters-long",
    "ExpirationMinutes": 1440
  },
  "Smtp": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "UserName": "your-email@gmail.com",
    "Password": "your-app-password",
    "FromAddress": "noreply@company.com"
  }
}
```

---

## Configuration

### Development Configuration

For development, the application uses `appsettings.json`. Key settings:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Cors": {
    "AllowedOrigins": ["http://localhost:3000", "https://localhost:5001"],
    "AllowedMethods": ["GET", "POST", "PUT", "DELETE"],
    "AllowedHeaders": ["*"]
  }
}
```

### Production Configuration

For production, use `appsettings.Production.json` with stricter settings:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft": "Error"
    }
  },
  "AllowedHosts": "yourdomain.com,www.yourdomain.com",
  "Cors": {
    "AllowedOrigins": ["https://yourdomain.com"],
    "AllowedMethods": ["GET", "POST", "PUT", "DELETE"]
  }
}
```

### Key Configuration Options

| Option | Description | Default |
|--------|-------------|---------|
| ConnectionStrings:DefaultConnection | PostgreSQL connection string | - |
| Jwt:Secret | Secret key for JWT token signing | - |
| Jwt:ExpirationMinutes | Token expiration time in minutes | 1440 |
| Smtp:Host | SMTP server hostname | - |
| Cors:AllowedOrigins | Allowed CORS origins | localhost |
| Logging:LogLevel | Minimum log level | Information |

---

## Database Setup

### Creating the Database

```bash
# Using psql
createdb -U postgres ems_dev

# Or using pgAdmin
# Right-click on Databases → Create → Database
```

### Running Migrations

```bash
# Navigate to API project
cd src/EMS.API

# Apply all pending migrations
dotnet ef database update

# Or for production
dotnet ef database update --configuration Release
```

### Creating Initial Data (Seed Data)

The application includes seed data for roles. To add more initial data:

```csharp
// In EmsDbContext.OnModelCreating()
modelBuilder.Entity<Department>().HasData(
    new Department { Id = 1, Name = "IT", Budget = 500000 },
    new Department { Id = 2, Name = "HR", Budget = 200000 },
    new Department { Id = 3, Name = "Finance", Budget = 300000 }
);

modelBuilder.Entity<User>().HasData(
    new User 
    { 
        Id = 1, 
        Email = "admin@company.com", 
        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
        RoleId = 1 
    }
);
```

Then run `dotnet ef database update` to apply seed data.

### Database Backup

Regular backups are essential:

```bash
# Backup database
pg_dump -U postgres ems_dev > backup_$(date +%Y%m%d_%H%M%S).sql

# Restore from backup
psql -U postgres ems_dev < backup_20260204_120000.sql
```

### Database Monitoring

Monitor your database health:

```sql
-- Check database size
SELECT datname, pg_size_pretty(pg_database_size(datname)) 
FROM pg_database 
ORDER BY pg_database_size(datname) DESC;

-- Check table sizes
SELECT schemaname, tablename, pg_size_pretty(pg_total_relation_size(schemaname||'.'||tablename)) 
FROM pg_tables 
ORDER BY pg_total_relation_size(schemaname||'.'||tablename) DESC;

-- Check index usage
SELECT schemaname, tablename, indexname, idx_scan, idx_tup_read, idx_tup_fetch 
FROM pg_stat_user_indexes 
ORDER BY idx_scan DESC;
```

---

## Running the Application

### Development Mode

```bash
# From the root directory
cd src/EMS.API
dotnet run

# Or in Visual Studio
# F5 to start debugging
```

The application will be available at:
- Frontend: `https://localhost:5001`
- API: `https://localhost:5001/api/`

### Production Mode

```bash
cd src/EMS.API
dotnet run --configuration Release
```

### Using Docker (Optional)

Create a `Dockerfile`:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80 443
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "EMS.API.dll"]
```

Build and run:

```bash
docker build -t ems:latest .
docker run -p 5001:443 -e ConnectionStrings__DefaultConnection="your-connection-string" ems:latest
```

---

## API Documentation

The application provides RESTful APIs for all operations. Full API documentation is available in [API.md](./docs/API.md).

### Authentication

All API endpoints (except login) require authentication via JWT token:

```javascript
// Login to get token
const response = await fetch('/api/auth/login', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ 
        email: 'user@company.com', 
        password: 'password123' 
    })
});

const { token } = await response.json();
localStorage.setItem('token', token);

// Use token in subsequent requests
const result = await fetch('/api/employees', {
    headers: { 
        'Authorization': `Bearer ${token}`
    }
});
```

### Sample API Endpoints

#### Employees
```
GET    /api/employee              - Get all employees
GET    /api/employee/{id}         - Get employee by ID
POST   /api/employee              - Create new employee
PUT    /api/employee/{id}         - Update employee
DELETE /api/employee/{id}         - Delete employee
GET    /api/employee/search?q=john - Search employees
```

#### Projects
```
GET    /api/project               - Get all projects
GET    /api/project/{id}          - Get project by ID
POST   /api/project               - Create new project
PUT    /api/project/{id}          - Update project
DELETE /api/project/{id}          - Delete project
POST   /api/project/{id}/assign   - Assign employee to project
```

#### Leave Requests
```
GET    /api/leave                 - Get all leave requests
GET    /api/leave/my              - Get my leave requests
POST   /api/leave                 - Apply for leave
PUT    /api/leave/{id}            - Update leave request
POST   /api/leave/{id}/approve    - Approve leave
POST   /api/leave/{id}/reject     - Reject leave
GET    /api/leave/balance/{empId} - Get leave balance
```

#### Dashboard
```
GET    /api/dashboard             - Get dashboard metrics
GET    /api/dashboard/charts      - Get chart data
GET    /api/dashboard/reports     - Get reports
```

---

## Features in Detail

### Employee Management

**View All Employees**
- Search and filter by department, role, status
- Sort by any column
- Pagination for large datasets
- Bulk operations (export to CSV, print)

**Employee Profile**
- Personal information
- Contact details
- Employment history
- Documents and certifications
- Performance ratings
- Leave history

**Department Management**
- Create and manage departments
- Assign employees to departments
- Department-level reporting
- Budget tracking per department

### Project Management

**Project Dashboard**
- Overview of all projects
- Filter by status, department, date range
- Budget vs actual spend
- Timeline and milestone tracking

**Team Allocation**
- Assign employees to projects
- Manage allocation percentage
- Track utilization
- Conflict detection (prevent over-allocation)

**Project Reports**
- Progress tracking
- Resource utilization
- Budget status
- Team performance metrics

### Leave Management

**Leave Application**
- Multiple leave types (Sick, Personal, Vacation, Maternity, etc.)
- Multi-level approval workflows
- Conflict detection
- Automatic balance calculation
- Leave cancellation with proper audit trail

**Leave Approvals**
- Dashboard showing pending leaves
- Bulk approve/reject
- Comments and notes
- Email notifications to approvers and employees

**Leave Reports**
- Leave balance by employee
- Leave taken vs remaining
- Department-wise leave statistics
- Trends and analytics

### Real-time Dashboards

**Executive Dashboard**
- KPIs and metrics
- Employee growth trends
- Project status overview
- Financial summary
- Department performance

**Manager Dashboard**
- Team metrics
- Project status for assigned projects
- Team leave calendar
- Performance indicators
- Direct reports overview

**Employee Dashboard**
- Personal metrics
- My projects
- My leave balance
- Pending approvals
- Attendance summary

---

## Testing

### Running Tests

```bash
# Run all tests
cd tests/EMS.Tests
dotnet test

# Run specific test class
dotnet test --filter "EmployeeServiceTests"

# Run with verbose output
dotnet test --verbosity detailed

# Generate code coverage report
dotnet test /p:CollectCoverage=true /p:CoverageFormat=opencover
```

### Test Structure

Tests are organized by feature:

```
tests/EMS.Tests/
├── Services/
│   ├── EmployeeServiceTests.cs
│   ├── LeaveServiceTests.cs
│   └── ...
├── Controllers/
│   ├── EmployeeControllerTests.cs
│   └── ...
├── Repositories/
│   └── EmployeeRepositoryTests.cs
└── Fixtures/
    └── TestDataFixture.cs
```

### Writing Tests

Example unit test:

```csharp
[TestFixture]
public class EmployeeServiceTests
{
    private IEmployeeRepository _mockRepository;
    private EmployeeService _service;
    
    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IEmployeeRepository>();
        _service = new EmployeeService(_mockRepository);
    }
    
    [Test]
    public async Task GetEmployeeById_WithValidId_ReturnsEmployee()
    {
        // Arrange
        var employeeId = 1;
        var employee = new Employee { Id = 1, FirstName = "John", Email = "john@company.com" };
        
        _mockRepository
            .Setup(r => r.GetByIdAsync(employeeId))
            .ReturnsAsync(employee);
        
        // Act
        var result = await _service.GetEmployeeByIdAsync(employeeId);
        
        // Assert
        Assert.NotNull(result);
        Assert.AreEqual("John", result.FirstName);
    }
}
```

---

## Deployment

### Prerequisites for Production

- Windows Server 2016 or later
- .NET 6.0 Runtime
- PostgreSQL installed and configured
- IIS with URL Rewrite module
- SSL certificate from Certificate Authority

### Deployment Steps

1. **Build the application**
```bash
cd src/EMS.API
dotnet publish -c Release -o C:\deployments\ems\v2.1.0
```

2. **Configure IIS**
```powershell
# Create Application Pool
New-WebAppPool -Name "EMS" -Force
Set-ItemProperty IIS:\AppPools\EMS -Name processModel -Value @{identityType="NetworkService"}

# Create Website
New-Website -Name "EMS" -PhysicalPath "C:\inetpub\ems" -HostHeader "yourdomain.com" -Port 443 -Protocol https -SslFlags 1
Set-ItemProperty IIS:\Sites\EMS -Name applicationPool -Value "EMS"

# Add HTTPS binding
$cert = Get-ChildItem cert:\LocalMachine\My | Where {$_.Subject -like "*yourdomain.com*"}
New-WebBinding -Name "EMS" -HostHeader "yourdomain.com" -Port 443 -Protocol https -SslFlags 1 -Thumbprint $cert.Thumbprint
```

3. **Deploy files**
```powershell
# Stop IIS App Pool
Stop-WebAppPool -Name "EMS"

# Copy files
Copy-Item "C:\deployments\ems\v2.1.0\*" "C:\inetpub\ems" -Recurse -Force

# Update database
cd C:\inetpub\ems
dotnet ef database update --configuration Release

# Start IIS App Pool
Start-WebAppPool -Name "EMS"
```

### Automated Deployment with GitHub Actions

Create `.github/workflows/deploy.yml`:

```yaml
name: Deploy to Production

on:
  push:
    branches: [main]

jobs:
  deploy:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v2
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '6.0.x'
    
    - name: Restore
      run: dotnet restore
    
    - name: Build
      run: dotnet build --configuration Release
    
    - name: Test
      run: dotnet test
    
    - name: Publish
      run: dotnet publish -c Release -o deployment
    
    - name: Deploy
      uses: appleboy/ssh-action@master
      with:
        host: ${{ secrets.SERVER_HOST }}
        username: ${{ secrets.SERVER_USER }}
        key: ${{ secrets.SERVER_SSH_KEY }}
        script: |
          cd /app/ems
          ./deploy.sh
```

---

## Screenshots

### Login Screen
![Login Screenshot](./docs/screenshots/login.png)

### Dashboard
![Dashboard Screenshot](./docs/screenshots/dashboard.png)

### Employee List
![Employee List Screenshot](./docs/screenshots/employees.png)

### Project Management
![Projects Screenshot](./docs/screenshots/projects.png)

### Leave Management
![Leaves Screenshot](./docs/screenshots/leaves.png)

### Leave Calendar
![Leave Calendar Screenshot](./docs/screenshots/leave-calendar.png)

---

## Troubleshooting

### Common Issues and Solutions

#### 1. Database Connection Error
```
Error: Host {hostname} is not allowed to connect to this PostgreSQL server
```

**Solution:**
- Check PostgreSQL is running: `pg_isready -h localhost`
- Verify connection string in appsettings.json
- Check PostgreSQL pg_hba.conf for connection permissions

#### 2. JWT Token Invalid
```
Error: Invalid token signature
```

**Solution:**
- Ensure JWT_SECRET is the same on both token generation and validation
- Check token hasn't expired: `jwt.io` to decode and check `exp` claim

#### 3. CORS Error in Browser
```
Error: Access to XMLHttpRequest has been blocked by CORS policy
```

**Solution:**
- Check CORS policy in Startup.cs includes the origin making the request
- In development: `AllowAnyOrigin()` is acceptable
- In production: Specify exact domains

#### 4. Database Migrations Failed
```
Error: Unable to add a migration because the model has changed but no migration has been added
```

**Solution:**
```bash
# Add new migration
dotnet ef migrations add {MigrationName}

# Update database
dotnet ef database update
```

#### 5. IIS Application Pool Crashes
Check logs in:
- Event Viewer → Windows Logs → Application
- `C:\inetpub\logs\LogFiles\`

Restart app pool:
```powershell
Restart-WebAppPool -Name "EMS"
```

---

## Performance

### Optimization Tips

1. **Database Queries**
```csharp
// Use Include() to avoid N+1 queries
var employees = await _context.Employees
    .Include(e => e.Projects)
    .Include(e => e.Department)
    .ToListAsync();
```

2. **Caching**
```csharp
// Cache frequently accessed data
services.AddMemoryCache();
_cache.Set("all_departments", departments, TimeSpan.FromHours(1));
```

3. **Pagination**
```csharp
var page = 1;
var pageSize = 50;
var employees = await _context.Employees
    .Skip((page - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

4. **Indexes**
```sql
-- Add indexes on frequently searched columns
CREATE INDEX idx_employee_email ON employees(email);
CREATE INDEX idx_leave_status ON leave_requests(status);
```

### Performance Monitoring

Monitor using Application Insights:

```csharp
services.AddApplicationInsightsTelemetry();
services.AddApplicationInsightsDistributedTracing();

// Track custom metrics
_telemetryClient.TrackEvent("LeaveApproved", new Dictionary<string, string> {
    { "EmployeeId", employeeId.ToString() }
});
```

---

## Security

### Security Best Practices Implemented

1. **Password Security**
   - Passwords are hashed using BCrypt
   - Minimum 8 characters, must include uppercase, lowercase, number, special character
   - Password history maintained (cannot reuse last 5 passwords)

2. **Data Encryption**
   - HTTPS enforced on all connections
   - Sensitive data encrypted at rest
   - JWT tokens signed and validated

3. **Access Control**
   - Role-based access control (Admin, HR, Manager, Employee)
   - Endpoint-level authorization
   - Row-level security for employee data

4. **Audit Logging**
   - All create/update/delete operations logged
   - User and timestamp recorded
   - Changes tracked in audit_logs table

5. **SQL Injection Prevention**
   - Parameterized queries via Entity Framework
   - Input validation on all endpoints
   - Request validation using FluentValidation

6. **CORS & CSRF Protection**
   - CORS policy configured to allow only trusted origins
   - Anti-CSRF tokens for form submissions
   - SameSite cookie attributes set

### Running Security Scan

```bash
# Use OWASP ZAP for security testing
docker run -t owasp/zap2docker-stable zap-baseline.py -t https://localhost:5001
```

---

## Maintenance

### Regular Maintenance Tasks

1. **Daily**
   - Monitor application logs
   - Check for error spike in Application Insights
   - Verify database backups completed successfully

2. **Weekly**
   - Review audit logs for suspicious activity
   - Check disk space on server
   - Review performance metrics

3. **Monthly**
   - Full database backup verification
   - Security updates and patches
   - Performance analysis and optimization

### Backup & Recovery

```bash
# Automated daily backup script
#!/bin/bash
BACKUP_DIR="/backups/ems"
TIMESTAMP=$(date +%Y%m%d_%H%M%S)

# Backup database
pg_dump -U postgres ems_prod > "$BACKUP_DIR/ems_$TIMESTAMP.sql"

# Compress
gzip "$BACKUP_DIR/ems_$TIMESTAMP.sql"

# Keep only last 30 days
find $BACKUP_DIR -name "*.sql.gz" -mtime +30 -delete
```

---

## Contributing

I welcome contributions to the Enterprise Management System! Whether it's bug reports, feature suggestions, or code improvements, your help makes this project better.

### How to Contribute

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Code Style Guidelines

- Follow C# coding standards (PascalCase for classes, camelCase for variables)
- Write meaningful commit messages
- Add unit tests for new features
- Update documentation as needed
- Ensure all tests pass before submitting PR

### Reporting Bugs

Before submitting a bug report:
1. Check if the issue already exists
2. Provide reproduction steps
3. Include error messages and logs
4. Specify your environment (OS, .NET version, etc.)

---

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.

### Third-party Libraries

- [Entity Framework Core](https://github.com/dotnet/efcore) - MIT License
- [Serilog](https://github.com/serilog/serilog) - Apache 2.0
- [FluentValidation](https://github.com/FluentValidation/FluentValidation) - Apache 2.0
- [Hangfire](https://github.com/HangfireIO/Hangfire) - LGPL
- [Bootstrap](https://github.com/twbs/bootstrap) - MIT License
- [Chart.js](https://github.com/chartjs/Chart.js) - MIT License

---

## Contact & Support

**Author:** Sudarshan Bhagat  
**Email:** sudarshan@example.com  
**LinkedIn:** [linkedin.com/in/sudarshan-bhagat](https://linkedin.com/in/sudarshan-bhagat)  
**GitHub:** [github.com/sudarshan-bhagat](https://github.com/sudarshan-bhagat)

### Getting Help

- **Documentation:** See [DOCUMENTATION.md](./DOCUMENTATION.md) for detailed information
- **API Docs:** See [docs/API.md](./docs/API.md) for API reference
- **Issues:** Open an issue on GitHub for bug reports and feature requests

---

## Acknowledgments

- Thanks to all the stakeholders who provided feedback during development
- Special thanks to the open-source community for the amazing tools and libraries
- Inspired by real-world challenges faced during enterprise system development

---

**Project Status:** Active Development  
**Last Updated:** February 2026  
**Version:** 2.1.0

Made with ❤️ by Sudarshan Bhagat

