# 🚗 DVLD - Driving & Vehicle License Department

A desktop application for managing people, users, drivers, driving licenses, applications, tests, and license-related services.

The project was developed using **C# Windows Forms** and **SQL Server**, following a **3-Tier Architecture** to separate the Presentation, Business Logic, and Data Access layers.

---

## 📌 Project Overview

Login:
  UserName: user
  Password: 1234

The **DVLD (Driving & Vehicle License Department)** system simulates a complete driving license management system.

It provides functionality for managing:

- People
- Users
- Drivers
- Driving Licenses
- Local Driving License Applications
- International Driving Licenses
- Tests and Test Appointments
- License Detention and Release
- Application Types
- Test Types
- User Accounts

---

## 🏗️ Architecture

The project follows a **3-Tier Architecture**:

┌─────────────────────────────────┐
│     Presentation Layer          │
│        Windows Forms            │
└───────────────┬─────────────────┘
                │
                ▼
┌─────────────────────────────────┐
│      Business Logic Layer       │
│        Business Classes         │
└───────────────┬─────────────────┘
                │
                ▼
┌─────────────────────────────────┐
│       Data Access Layer         │
│       SQL Server / ADO.NET      │
└─────────────────────────────────┘
1. Presentation Layer

Responsible for the application's UI and user interaction.

Technologies and components include:

C#
Windows Forms
User Controls
DataGridView
MenuStrip
Custom Forms
2. Business Logic Layer

Contains the application's business rules and domain classes, such as:

clsPerson
clsUser
clsDriver
clsLicense
clsLocalDrivingLicenseApplication
clsInternationalLicense
clsTest
clsTestAppointment
clsApplication
clsApplicationType
clsLicenseClass
clsCountry
clsDetainedLicense
3. Data Access Layer

Responsible for communication with SQL Server and performing database operations.

The project uses ADO.NET for database access.

🔐 Authentication & Security

The application implements several authentication and security-related features.

Password Hashing

User passwords are hashed before being stored in the database instead of storing them as plain text.

User Password
      │
      ▼
   Hashing
      │
      ▼
Password Hash
      │
      ▼
   Database

The application uses password hashing to protect stored credentials.

Password hashing is different from encryption. Hashing is designed to be one-way, while encryption is reversible using a key.

🔑 Remember Me

The application provides a Remember Me functionality.

When the user enables Remember Me, the application stores the login information in the Windows Registry.

The password is stored as a hash, rather than plain text.

Username + Password
        │
        ▼
    Hash Password
        │
        ▼
 Windows Registry

This allows the application to restore the user's login information when the application starts again.

📝 Login Tracking

The application records login activities in a text file.

The login log contains information such as:

Username
Login result
Date
Time

Example:

mohab888#/True#/4/19/2026 8:04:22 PM
user4#/True#/4/19/2026 8:05:11 PM

This provides a simple mechanism for tracking login activity and authentication attempts.

⚠️ Error Logging

Application errors are recorded using the Windows Event Viewer.

This allows errors to be logged at the operating-system level and provides useful information for troubleshooting and debugging.

Application Error
       │
       ▼
Windows Event Log
       │
       ▼
Event Viewer
👥 User Management

The system provides a complete User Management module.

Administrators can:

View users
Search and filter users
Add new users
Edit users
Delete users
View user details
Change passwords
Activate/deactivate users
Send email
Make phone calls

The system separates Person Information from Login Information.

🧑 People Management

The application manages people's personal information, including:

Person ID
Full Name
National Number
Date of Birth
Gender
Phone
Email
Country
Address
Personal Image

People can be searched and their information can be updated.

🚘 Drivers Management

The system provides driver-related functionality and connects drivers with their license records and license history.

Users can access:

Driver information
Driver licenses
License history
Related applications
🪪 Local Driving License Applications

The system supports Local Driving License Applications.

Users can:

Create applications
View applications
Edit applications
Delete applications
Cancel applications
Schedule tests
View application details
Issue driving licenses
View license information
View a person's license history

The application tracks the status of each application.

Example statuses include:

New
Completed
Cancelled
Local License Workflow
Create Application
        │
        ▼
Schedule Tests
        │
        ▼
Vision Test
        │
        ▼
Written Test
        │
        ▼
Street Test
        │
        ▼
Complete Application
        │
        ▼
Issue Driving License
🌍 International Driving Licenses

The system also supports International Driving Licenses.

It provides functionality for:

Creating international license applications
Viewing international licenses
Showing license details
Showing person details
Viewing license history
Tracking issue dates
Tracking expiration dates
Managing active/inactive licenses
🧪 Tests & Test Appointments

The system contains a complete test management workflow.

Supported test types include:

👁️ Vision Test
📝 Written Test
🚗 Street Test

The system allows users to schedule tests for driving license applications and track passed tests.

Test Workflow
Driving License Application
            │
            ▼
     Schedule Vision Test
            │
            ▼
     Schedule Written Test
            │
            ▼
     Schedule Street Test
            │
            ▼
       Complete Tests
            │
            ▼
      Issue License
🚨 License Detention

The application supports License Detention.

Users can:

Search for a license
View driver information
View license information
Detain a license
Specify detention date
Specify fine fees
Record the user who created the detention
Detention Workflow
Active License
      │
      ▼
Detain License
      │
      ▼
Detained License
🔓 Release Detained License

Detained licenses can also be released.

The system provides:

License lookup
Driver information
License information
Detention information
Fine fees
Application fees
Total fees
Release date
Release Application ID
License history
Release Workflow
Detained License
       │
       ▼
Pay Required Fees
       │
       ▼
Release License
       │
       ▼
Released License
📋 Manage Detained Licenses

A dedicated module is provided for managing detained licenses.

It allows users to:

View all detained licenses
Filter detained licenses
Check release status
View fine fees
View release date
View person details
View license details
View license history
Release detained licenses
🧩 User Controls

The project uses Windows Forms User Controls to create reusable UI components.

User Controls help reduce duplicated UI logic and improve code organization and maintainability.

The project contains a dedicated:

User
└── Controls

structure for reusable controls.

🗄️ Database

The application uses Microsoft SQL Server as its database management system.

The database contains entities related to:

People
Users
Drivers
Applications
Application Types
License Classes
Licenses
International Licenses
Tests
Test Appointments
Local Driving License Applications
Detained Licenses
Payments / Fees
Countries

Relationships between these entities allow the system to maintain the complete lifecycle of applications and licenses.

🔄 Application Lifecycle

The system manages different processes through connected business workflows.

For example:

Person
  │
  ▼
Application
  │
  ▼
Tests
  │
  ▼
License
  │
  ├──────────────► International License
  │
  └──────────────► Detain License
                         │
                         ▼
                   Release License
🛠️ Technologies Used
Technology	Purpose
C#	Application development
.NET Framework	Desktop application framework
Windows Forms	Graphical User Interface
SQL Server	Database
T-SQL	Database queries and logic
ADO.NET	Database connectivity
3-Tier Architecture	Application architecture
Windows Registry	Remember Me functionality
Windows Event Viewer	Error logging
Password Hashing	Password protection
User Controls	Reusable UI components
Visual Studio	Development environment
✨ Main Features
✅ 3-Tier Architecture
✅ SQL Server Database
✅ ADO.NET
✅ Object-Oriented Programming
✅ User Management
✅ People Management
✅ Driver Management
✅ Local Driving License Management
✅ International Driving License Management
✅ Test Management
✅ Test Scheduling
✅ License Detention
✅ License Release
✅ Detained License Management
✅ License History
✅ Password Hashing
✅ Remember Me
✅ Windows Registry Integration
✅ Login Activity Tracking
✅ Text File Logging
✅ Windows Event Viewer Error Logging
✅ Windows Forms User Controls
✅ Search and Filtering
✅ Application Status Management
📂 Project Structure
DVLD
│
├── DVLD Business Layer
│   ├── clsApplication.cs
│   ├── clsApplicationType.cs
│   ├── clsCountry.cs
│   ├── clsDetainedLicense.cs
│   ├── clsDriver.cs
│   ├── clsInternationalLicense.cs
│   ├── clsLicense.cs
│   ├── clsLicenseClass.cs
│   ├── clsLocalDrivingLicenseApplication.cs
│   ├── clsPerson.cs
│   ├── clsTest.cs
│   ├── clsTestAppointment.cs
│   ├── clsTestType.cs
│   └── clsUser.cs
│
├── DVLD Data Access Layer
│
└── DVLD WinForms Presentation Layer
    ├── Applications
    ├── Drivers
    ├── Global Classes
    ├── Licenses
    ├── Login
    ├── People
    ├── Resources
    ├── Tests
    └── User
        └── Controls
🎯 Project Goal

The main goal of the project is to build a realistic Driving & Vehicle License Department Management System while applying software engineering concepts such as:

Object-Oriented Programming
3-Tier Architecture
Database Design
Data Access
Business Logic Separation
Reusable Components
Authentication
Password Security
Login Tracking
Error Logging
Windows OS Integration
Real-world Business Workflows
👨‍💻 Developer

Mohab Wael

C# / .NET Developer
Management Information Systems Student

⭐ Project Highlights

This project demonstrates practical experience in building a complete desktop business application with:

C# + WinForms + SQL Server + ADO.NET + 3-Tier Architecture + OOP + Authentication + Password Hashing + Windows Registry + Event Viewer + File Logging + User Controls + License Management Workflows
