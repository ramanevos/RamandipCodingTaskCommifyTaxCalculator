# RamandipTaxCalculatorBackend

This is the **backend** of the Tax Calculator application, developed using ASP.NET Core. The application calculates tax based on predefined tax bands and provides RESTful API endpoints to handle tax calculations.

---

## Technologies Used

- **ASP.NET Core 9.0**: Backend framework
- **Entity Framework Core**: ORM for database interaction
- **SQL Server**: Relational database
- **C#**: Programming language
- **xUnit**: Unit testing framework
- **FluentAssertions**: Assertion library for readable and expressive tests
- **Moq**: Mocking library for unit testing

---

## Third-Party Tools & Frameworks

1. **Entity Framework Core**: ORM for managing database access and relationships.
2. **Swagger**: For API documentation and testing in development environments.
3. **xUnit & Moq**: Used for unit tests of controllers, services, and repositories.
4. **FluentAssertions**: For clean and expressive test assertions.

---

## How to Run the Backend

Follow these steps to get the backend application running locally.

### Prerequisites

1. **.NET SDK 9.0 or above**: Download and install it from [Microsoft's .NET page](https://dotnet.microsoft.com/).
2. **SQL Server**: Ensure you have SQL Server installed and running locally or remotely.

### Steps to Run

1. Clone the Repository and then run the RamandipTaxCalculatorBackend.sln in VS 2022
   

2. Setup the Database:
   - Open the `appsettings.json` file and modify the `ConnectionStrings.DefaultConnection` to match your SQL Server configuration:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=.\\SQLEXPRESS;Database=TaxCalculatorDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"
     }
     ```

3. Create and Populate the Database:
   - Open SQL Server Management Studio (SSMS).
   - Create a new database named `TaxCalculatorDb` using Windows Authentication and SQL Express.
   - Run the SQL script located at `RamandipTaxCalculatorBackend/Database/TaxCalculatorDbCreateAndPopulateQuery.sql` to create and populate the necessary tables.

4. Run the Application:
   Start the application using Vs 2022:
  
   The application will be accessible at `https://localhost:7284`.

5. Access the API Documentation:
   Open Swagger UI in your browser by navigating to:
   https://localhost:7284/swagger

   and test the api
   

---

## Running Unit Tests

To verify the functionality of the backend components, run the unit tests using the following command:

```bash
dotnet test
```

The tests include validations for:
- Correct retrieval of tax bands.
- Accurate tax calculation based on salary and bands.
- Proper handling of API requests in the controller.

---

Feel free to ask if you have any questions or require additional details!

