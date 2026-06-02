# Online Complaint Management System (OCMS)

## Overview

The **Online Complaint Management System (OCMS)** is a web-based complaint handling platform developed using **ASP.NET MVC** and **Entity Framework Core 3.1.32** with **PostgreSQL** as the database backend.

The system enables citizens or users to submit complaints, track complaint progress, and communicate with administrators through a centralized complaint management workflow. It is designed to improve transparency, accountability, and response efficiency.

---

## Key Features

### Visitor Features

* User registration and account creation
* Complaint tracking using tracking IDs
* Public access to complaint status information

### User Features

* Submit complaints with category selection
* View complaint history
* Track complaint status in real-time
* Receive responses from administrators

### Administrator Features

* Manage complaints and complaint responses
* Update complaint status
* Manage complaint categories
* Manage users and roles
* Monitor complaint resolution workflow

---

## Architecture

The application follows a layered architecture with clear separation of concerns:

* ASP.NET MVC Presentation Layer
* Business Logic Layer
* Repository/Data Access Layer
* PostgreSQL Database Layer

### Design Principles

* Repository Pattern
* Separation of Concerns (SoC)
* Entity Framework Core ORM
* Role-Based Access Control (RBAC)

---

## Technology Stack

| Component      | Technology                               |
| -------------- | ---------------------------------------- |
| Framework      | ASP.NET MVC                              |
| Language       | C#                                       |
| ORM            | Entity Framework Core 3.1.32             |
| Database       | PostgreSQL                               |
| Frontend       | HTML5, CSS3, JavaScript, Bootstrap       |
| Authentication | ASP.NET Identity / Custom Authentication |
| IDE            | Visual Studio 2019 / 2022                |

---

## Database Entities

The system currently manages the following core entities:

```csharp
public DbSet<User> Users { get; set; }
public DbSet<UserCreadentials> UserCreadentials { get; set; }
public DbSet<Complaint> Complaints { get; set; }
public DbSet<ComplaintResponse> ComplaintResponses { get; set; }
public DbSet<Category> Categories { get; set; }
public DbSet<UserRole> UserRoles { get; set; }
```

### Entity Relationships

* A User can create multiple Complaints.
* A Complaint belongs to a Category.
* A Complaint can have multiple Complaint Responses.
* Users are assigned roles through User Roles.
* User Credentials manage authentication information.

---

## Project Structure

```text
OCMS
│
├── Controllers
├── Models
├── Views
├── Repositories
├── Services
├── Areas
│   ├── Visitor
│   ├── User
│   └── Admin
├── Data
├── Scripts
└── Content
```

---

## Getting Started

### Prerequisites

* Visual Studio 2019 or Visual Studio 2022
* .NET Framework / ASP.NET MVC Runtime
* PostgreSQL Server
* Entity Framework Core 3.1.32
* Git

---

## Installation

### 1. Clone Repository

```bash
git clone https://github.com/Asim-AKM/OCMS.git
cd OCMS
```

### 2. Restore NuGet Packages

Open the solution in Visual Studio and restore all NuGet packages.

```powershell
Update-Package -reinstall
```

---

### 3. Configure PostgreSQL Connection

Update your connection string inside:

```xml
Web.config
```

Example:

```xml
<connectionStrings>
  <add name="OCMSConnection"
       connectionString="Host=localhost;Port=5432;Database=OCMS_DB;Username=postgres;Password=your_password"
       providerName="Npgsql" />
</connectionStrings>
```

---

### 4. Apply Database Migrations

Using Package Manager Console:

```powershell
Update-Database
```

Or using .NET EF CLI:

```bash
dotnet ef database update
```

---

### 5. Run the Application

* Set the Web Project as Startup Project.
* Press **F5** or **Ctrl + F5**.
* Navigate to the application URL.

---

## Complaint Workflow

```text
Complaint Submitted
        ↓
Pending Review
        ↓
Under Investigation
        ↓
Response Added
        ↓
Resolved / Closed
```

---

## Security Features

* Role-Based Authorization
* Authentication Management
* Input Validation
* Server-Side Validation
* Secure Database Access through EF Core

---

## Future Enhancements

* Email Notifications
* SMS Notifications
* Complaint Analytics Dashboard
* File Attachments
* Audit Logging
* REST API Integration
* Mobile Application Support

---

## Contributing

Contributions are welcome.

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push the branch
5. Create a Pull Request

---

## License

This project is licensed under the MIT License.

---

## Author

**Muhammad Asim Khan**

Online Complaint Management System (OCMS)

GitHub: https://github.com/Asim-AKM
