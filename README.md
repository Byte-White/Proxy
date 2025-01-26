# Proxy

A real-time text clipboard and file-sharing web application built with ASP.NET Core and SignalR. This application allows multiple users on the same network to share text and files seamlessly.

![proxy](https://github.com/user-attachments/assets/c43686c9-2d5a-4158-9b8f-689f5b3281b6)


## Features

* File Uploads: Upload and share files with connected users.
* Real-Time Text Sharing: Instantly share text across all connected devices.
* Notes: Share notes accross all connected devices
* Local Network Access: Access the application from any device on the same network.
* QR Code Access: Easily connect mobile devices by scanning a QR code.


## Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/Byte-White/Proxy.git
   cd Proxy
   ```

2. **Navigate to the Project Directory**

   ```bash
   cd Proxy
   ```

3. **Restore Packages**

   ```bash
   dotnet restore
   ```

4. **Build the Application**

   ```bash
   dotnet build
   ```

## Configuration Files

To ensure the application functions correctly, the following configuration files are essential:

1. **appsettings.json**

   This file contains configuration settings, including database connection strings and logging configurations.

   ```json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\Local;Database=ProxyDB;Trusted_Connection=True;TrustServerCertificate=True;",
       "ProxyContext": "Server=(localdb)\\mssqllocaldb;Database=ProxyContext-edd63e76-56a7-4e53-a379-4978670a0fd5;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```
   Ensure that the connection strings are correctly configured to point to your database instances.


2. **launchSettings.json**

   Located in the `Properties` directory, this file contains settings that are used when running the application locally.

   ```json
   {
     "$schema": "http://json.schemastore.org/launchsettings.json",
     "iisSettings": {
       "windowsAuthentication": false,
       "anonymousAuthentication": true,
       "iisExpress": {
         "applicationUrl": "http://localhost:43792",
         "sslPort": 44317
       }
     },
     "profiles": {
       "http": {
         "commandName": "Project",
         "dotnetRunMessages": true,
         "launchBrowser": true,
         "applicationUrl": "http://0.0.0.0:5087",
         "environmentVariables": {
           "ASPNETCORE_ENVIRONMENT": "Development"
         }
       },
       "https": {
         "commandName": "Project",
         "dotnetRunMessages": true,
         "launchBrowser": true,
         "applicationUrl": "https://0.0.0.0:7006;http://0.0.0.0:5087",
         "environmentVariables": {
           "ASPNETCORE_ENVIRONMENT": "Development"
         }
       },
       "IIS Express": {
         "commandName": "IISExpress",
         "launchBrowser": true,
         "environmentVariables": {
           "ASPNETCORE_ENVIRONMENT": "Development"
         }
       }
     }
   }
   ```

   Ensure that the `applicationUrl` is set to the desired URL and port.
