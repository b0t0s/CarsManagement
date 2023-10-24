# CarsManagement

## Description

This project is a .NET solution utilizing Blazor for the client-side, hosted on ASP.NET for management of parkings with role and account model.

The server-side API is documented with Swagger and includes authentication. Data can be stored in-memory or in a SQL database.

## Getting Started

### Dependencies

- .NET 5.0 or later
- SQL Server (optional)

### Installing

1. Clone the repository:
   ```bash
   git clone https://github.com/b0t0s/CarsManagement.git
    ```

2.  Navigate to the project directory:
    
    bash
    
    ```bash
    cd CarsManagement/
    ```
    
3.  Restore packages and run in Visual Studio:
    
Usage
-----

### UI

Set project CarsManagement.Server.Presentation as startup, and just run.
If no browser window will appear, open your defined browser and go to `https://localhost:7206/` page

### Swagger UI

Access the Swagger UI at `https://localhost:7206/Swagger/index.html` to explore and test the API endpoints.

### Authentication

Authentication process here is controlled by personal accounts. 
System have capabilities to login and register.

### Database Configuration

Explain how to switch between in-memory and SQL database configurations, and any necessary setup for the SQL database.

Contributing
------------

Just process for submitting pull requests.

License
-------

This project is licensed under the MIT License - see the `LICENSE.md` file for details.