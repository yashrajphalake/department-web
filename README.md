
# YCIS College Alumni Management System

This project is a modular web application for the YCIS College Alumni Management System, built with a .NET backend and a MySQL database.

## Setup

To set up the MySQL connection string in your .NET application, follow these steps:

1.  **Open `appsettings.json`:** In your .NET project, locate and open the `appsettings.json` file.
2.  **Add Connection String:** Add a new entry for your connection string under the `ConnectionStrings` section. Replace the placeholder values with your actual database credentials.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User=your_user;Password=your_password;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Now you can inject `IConfiguration` into your `DbContext` or repository to access the connection string.
