# Bug Tracking System - Setup Instructions

## Backend Implementation Complete ✅

### What's Included

#### 1. Models
- **Bug.cs** - Bug tracking with Title, Description, Severity, Status, Comment
- **User.cs** - User authentication with Username, Password (hashed), Role
- **LoginViewModel.cs** - Login form validation

#### 2. Database (Entity Framework Core)
- **AppDbContext.cs** - Database context with Bugs and Users tables
- **Connection String** - SQL Server LocalDB configured
- **Seed Data** - Pre-populated test users and sample bug

#### 3. Controllers
- **BugController.cs** - Full CRUD operations (Create, Read, Update)
- **AccountController.cs** - Login/Logout with session management
- **HomeController.cs** - Home and Privacy pages

#### 4. Authentication & Security
- **Session-based authentication** - User login state management
- **Password hashing** - BCrypt for secure password storage
- **Authorization filter** - Protects Bug pages (requires login)
- **Anti-forgery tokens** - CSRF protection on forms

#### 5. Views (Updated)
- **Login.cshtml** - Connected to backend with validation
- **Bug/Index.cshtml** - Dynamic bug list from database
- **Bug/Create.cshtml** - Form with model binding
- **Bug/Edit.cshtml** - Update bug status with validation
- **_Layout.cshtml** - Navigation with user info and logout

---

## Setup Steps in Visual Studio 2022

### Step 1: Restore NuGet Packages
```bash
dotnet restore
```

### Step 2: Create Database
Open **Package Manager Console** (Tools → NuGet Package Manager → Package Manager Console)

Run these commands:
```powershell
Add-Migration InitialCreate
Update-Database
```

### Step 3: Run the Application
Press **F5** or click the green play button

---

## Test Credentials

The system comes with 2 pre-configured users:

### Admin User
- **Username:** admin
- **Password:** admin123
- **Role:** Admin

### Member User
- **Username:** member
- **Password:** member123
- **Role:** Member

---

## Features to Test

1. **Login** - Use test credentials above
2. **View Bugs** - See the bug list (includes 1 sample bug)
3. **Create Bug** - Add new bugs with title, description, severity
4. **Edit Bug** - Update bug status and add comments
5. **Logout** - Clear session and return to login

---

## Project Structure

```
BugTrackingSystem/
├── Controllers/
│   ├── AccountController.cs    (Login/Logout)
│   ├── BugController.cs         (Bug CRUD)
│   └── HomeController.cs
├── Models/
│   ├── Bug.cs
│   ├── User.cs
│   ├── LoginViewModel.cs
│   └── ErrorViewModel.cs
├── Data/
│   └── AppDbContext.cs          (Database context)
├── Filters/
│   └── SessionAuthFilter.cs     (Authorization)
├── Views/
│   ├── Account/
│   │   └── Login.cshtml
│   ├── Bug/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   └── Edit.cshtml
│   └── Shared/
│       └── _Layout.cshtml
└── appsettings.json             (Connection string)
```

---

## Database Schema

### Users Table
- UserId (PK)
- Username
- Password (hashed)
- FullName
- Email
- Role
- CreatedDate

### Bugs Table
- BugId (PK)
- Title
- Description
- Severity (Low, Medium, High, Critical)
- Status (Open, In Progress, Fixed, Closed)
- Comment
- CreatedDate
- UpdatedDate

---

## Next Steps

### Push to GitHub
```bash
git add .
git commit -m "Complete backend implementation with authentication"
git push origin backend-member
```

### Create Pull Request
1. Go to your GitHub repository
2. Click "Compare & pull request"
3. Review changes
4. Merge to main branch

---

## Troubleshooting

### If migration fails:
```powershell
Remove-Migration
Add-Migration InitialCreate
Update-Database
```

### If database connection fails:
Check `appsettings.json` connection string matches your SQL Server instance

### If login doesn't work:
Make sure you ran `Update-Database` to seed the test users

---

## Technologies Used
- ASP.NET Core 10.0 MVC
- Entity Framework Core 9.0
- SQL Server LocalDB
- BCrypt.Net (Password hashing)
- Bootstrap 5.3
- Session-based authentication
