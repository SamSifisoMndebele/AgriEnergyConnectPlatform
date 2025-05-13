# Agri-Energy Connect Platform

## Overview
AgriEnergyConnect Platform is a web application built with ASP.NET Core that facilitates connections between the agriculture and energy sectors. It provides a secure user management system with role-based access control and a modern user interface.

## Development Environment Setup

### Prerequisites
1. **Required Software:**
   - .NET 9.0 SDK or later (download from [.NET Downloads](https://dotnet.microsoft.com/download))
   - Visual Studio 2022 or JetBrains Rider (recommended IDEs)
   - Git for version control
   - SQLite (included in project)

2. **System Requirements:**
   - Windows 10/11, macOS, or Linux
   - Minimum 8GB RAM (16GB recommended)
   - 10GB free disk space

### Installation Steps jnkm
1. **Clone the Repository:**
   ```bash
   git clone [repository-url]
   cd AgriEnergyConnectPlatform
   ```

2. **Setup Development Environment:**
   ```bash
   dotnet restore
   dotnet tool install --global dotnet-ef
   ```

3. **Database Setup:**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Configure Application Settings:**
   - Copy `appsettings.Example.json` to `appsettings.Development.json`
   - Update connection strings and any environment-specific settings

## Building and Running

### Local Development
1. **Build the Project:**
   ```bash
   dotnet build
   ```

2. **Run the Application:**
   ```bash
   dotnet run
   ```
   Access the application at:
   - HTTPS: `https://localhost:7132`
   - HTTP: `http://localhost:5297`

### Docker Deployment
1. **Build Docker Image:**
   ```bash
   docker build -t agrienergy-connect .
   ```

2. **Run Container:**
   ```bash
   docker run -p 5000:80 agrienergy-connect
   ```

## System Architecture and Features

### Core Components
1. **Authentication System**
   - User registration and login
   - Role-based access control
   - Secure password management
   - Email verification

2. **User Management**
   - Profile management
   - Role assignment
   - Contact information tracking

3. **Interface Components**
   - Responsive design
   - Mobile-friendly layout
   - Custom styling

### User Roles and Permissions

#### Administrator Role
- Full system access
- User management capabilities
- System configuration access
- Analytics and reporting

#### Farmer Role
- Profile management
- Resource access
- Communication features
- Personal data management

## Testing and Development

### Test Accounts
#### Administrator Account
- Email: admin@mail.com
- Password: Admin@123
- Role: Employee

#### Farmer Test Account
- Email: jane.doe@example.com
- Password: Password@123
- Role: Farmer

**Note:** These credentials are for development only. Change them in production.

### Technology Stack
- **Backend:** .NET 9.0, ASP.NET Core, Entity Framework Core
- **Database:** SQLite
- **Frontend:** Razor Pages, Bootstrap, Custom CSS, JavaScript
- **Security:** Cookie authentication, Claims-based authorization

## Troubleshooting

### Common Issues
1. **Database Connection:**
   - Verify connection string in appsettings.json
   - Ensure SQLite file exists and has proper permissions

2. **Build Errors:**
   - Run `dotnet restore` to refresh dependencies
   - Clear solution and rebuild
   - Verify .NET SDK version matches project requirements

### Support
For technical support:
- Create an issue in the repository
- Contact the development team
- Consult the documentation

## Contributing
1. Fork the repository
2. Create a feature branch
3. Commit changes
4. Submit pull request
5. Follow coding standards

## Security Considerations
- Regular security updates
- Secure password handling
- Data encryption
- Access control implementation
- Input validation

## License
[Add license information]

## Authors and Acknowledgments
[Add contributors and acknowledgments]

---
For detailed technical documentation, API references, and contribution guidelines, please refer to the project wiki.