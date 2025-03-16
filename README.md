DemoAPI(Handling Multiple Databases Dynamically in an Application)
==================================================================
In applications requiring multiple databases, dynamic connection management can be implemented based on the incoming request. This approach allows the application to switch databases efficiently without hardcoding connections.

Overview:-
  This repository demonstrates how to dynamically switch databases based on the bankCode received in the HTTP request header. The default database is used only for Identity authentication, while customer-related data is stored in bank-specific databases.

Technologies Used:-
  * ASP.NET Core 9
  * EF Core
  * SQLite

Database Configuration (appSettings.json):-
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db",
    "1664": "Data Source=Bank1664DB.sqlite",
    "27": "Data Source=Bank27DB.sqlite"
  }
}

Migration commands:-
  1. dotnet ef migrations add CreateIdentityTables -c AppDbContext
  2. dotnet ef database upadate -c AppDbContext

  3. dotnet ef migrations add CreateCustomerTable -c BankDbContext
  4. dotnet ef database update -c BankDbContext --connection "Data Source=Bank1664DB.sqlite"
  5. dotnet ef database update -c BankDbContext --connection "Data Source=Bank27DB.sqlite"

Installation & Setup:-
  1. Clone the repository git clone https://github.com/navimahendran50/DemoAPI.git
  2. cd DemoAPI
  3. dotnet build
  4. dotnet run

Testing Endpoint:-
Request
GET /api/customers
Headers:
  bankCode: 1850

Conclusion:-
  This implementation ensures dynamic database selection per request while maintaining a separate default database for Identity authentication.

  



  
