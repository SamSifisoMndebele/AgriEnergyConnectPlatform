# Agri-Energy Connect Platform

## Overview
AgriEnergyConnect Platform is a web application built with ASP.NET Core that facilitates connections between the agriculture and energy sectors. It provides a secure user management system with role-based access control and a modern user interface.

## Features

### Authentication & Authorization
- User registration and login system
- Role-based access control (Farmers, Employees)
- Secure password handling
- Remember me functionality
- Email-based user identification

### User Management
- Comprehensive user profile management
- Multiple user roles support
- Address and contact information tracking
- Employee-specific features for managing farmer accounts

### User Interface
- Modern, responsive design
- Clean and intuitive forms
- Background styling with blur effects
- Mobile-friendly layout
- Custom styling for better user experience

## Technology Stack

### Backend
- .NET 9.0
- ASP.NET Core
- Entity Framework Core
- SQLite Database

### Frontend
- Razor Pages
- Bootstrap
- Custom CSS
- JavaScript

### Security
- Cookie-based authentication
- Claims-based authorization
- Form validation
- Password confirmation
- Terms acceptance requirement


## Setup and Installation

### Prerequisites
- .NET 9.0 SDK or later
- A text editor or IDE (recommended: Visual Studio or JetBrains Rider)
- SQLite (included in project)

### Local Development
1. Clone the repository: 
2. Navigate to the project directory: `AgriEnergyConnectPlatform`
3. Restore dependencies: 
4. Apply database migrations: ```run command: 
    dotnet ef migrations migration_name;
    dotnet ef database update   
       ```
5. Run the application:


The application will be available at `https://localhost:5001` or `http://localhost:5000`

### Docker Support
The project includes Docker support through the included Dockerfile.

## Configuration
- `appsettings.json` - Production configuration
- `appsettings.Development.json` - Development configuration

## Database Schema
The application uses SQLite with Entity Framework Core, featuring:
- User accounts with role-based access
- Secure password storage
- Contact and address information
- Unique email constraints

## Development Guidelines
- Follow C# coding conventions
- Use Razor Pages for views
- Implement proper validation
- Maintain responsive design
- Document new features

## Security Features
- Password confirmation on registration
- Email uniqueness validation
- Role-based access control
- Secure cookie authentication
- Form validation and sanitization

## Authors
[Add authors information]

---
For more information about specific features or development guidelines, please consult the project documentation or contact the development team.