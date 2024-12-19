# RamandipTaxCalculator

The **RamandipTaxCalculator** application calculates tax based on predefined tax bands. It consists of two parts:
1. **Backend**: Developed using ASP.NET Core for tax calculation logic and RESTful APIs.
2. **Frontend**: Built with Angular to provide a responsive UI for user interaction.
   ![image](https://github.com/user-attachments/assets/2601054c-8dcb-49ce-afcb-c51dd5da692b)


---

## Backend: RamandipTaxCalculatorBackend

The backend handles tax calculations and exposes RESTful APIs for the frontend.

### Technologies Used
- **ASP.NET Core 9.0**: Backend framework  
- **Entity Framework Core**: ORM for database interaction  
- **SQL Server**: Relational database  
- **C#**: Programming language  
- **xUnit**: Unit testing framework  
- **FluentAssertions**: Assertion library for readable and expressive tests  
- **Moq**: Mocking library for unit testing  

### Third-Party Tools & Frameworks
1. **Entity Framework Core**: For database access and relationships.  
2. **Swagger**: For API documentation and testing.  
3. **xUnit & Moq**: For testing controllers, services, and repositories.  
4. **FluentAssertions**: For expressive and readable test assertions.  

### How to Run the Backend

#### Prerequisites
1. **.NET SDK 9.0 or above**: Download and install from [Microsoft's .NET page](https://dotnet.microsoft.com/).  
2. **SQL Server**: Ensure SQL Server is installed and running.  

#### Steps to Run
1. **Clone the Repository**: Open the solution `RamandipTaxCalculatorBackend.sln` in Visual Studio 2022.  
2. **Setup the Database**:  
   - Modify the `ConnectionStrings.DefaultConnection` in `appsettings.json` to match your SQL Server configuration:  
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=.\\SQLEXPRESS;Database=TaxCalculatorDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"
     }
     ```  
   - Create and populate the database:  
     - Open SQL Server Management Studio (SSMS).  
     - Create a database named `TaxCalculatorDb`.  
     - Run the SQL script at `RamandipTaxCalculatorBackend/Database/TaxCalculatorDbCreateAndPopulateQuery.sql` to set up tables and seed data.  
3. **Run the Application**: Start the application in Visual Studio 2022. The backend will be accessible at `https://localhost:7284`.  
4. **API Documentation**: Access Swagger UI at `https://localhost:7284/swagger`.  

#### Running Unit Tests
Run the following command to verify backend functionality:  
```bash
dotnet test
```  
Tests include:  
- Correct retrieval of tax bands.  
- Accurate tax calculations.  
- Proper API request handling.

---

## Frontend: RamandipTaxCalculatorFrontend

The frontend provides a user interface for inputting gross annual salary, sends requests to the backend, and displays tax details (e.g., net salary, monthly breakdown).

### Technologies Used
- **Angular v18**: Standalone component-based framework  
- **TypeScript**  
- **HTML5** & **SCSS**: For responsive UI  
- **Angular HttpClient**: For backend communication  

### Third-Party Tools & Frameworks
1. **Angular CLI**: For project building.  
2. **Karma & Jasmine**: For testing Angular components and services.  
3. **Visual Studio Code (VS Code)**: Recommended IDE.  

### How to Run the Frontend

#### Prerequisites
1. **Node.js**: Download from [Node.js official site](https://nodejs.org/).  
2. **Angular CLI** (v18): Install globally using:  
   ```bash
   npm install -g @angular/cli
   ```  
3. Ensure the backend server is running and its URL is correctly configured in `environment.ts`.

#### Steps to Run
1. **Clone the Repository**.  
2. **Install Dependencies**: Run:  
   ```bash
   npm install
   ```  
3. **Start the Development Server**:  
   ```bash
   ng serve
   ```  
   The frontend will be accessible at `http://localhost:4200`.  
4. **Access the Application**: Open a browser and navigate to:  
   ```text
   http://localhost:4200
   ```

---

## Integration Notes

- Ensure the backend is running at `https://localhost:7284` before starting the frontend.  
- The backend URL should match the configuration in the Angular `environment.ts` file.

---

Feel free to reach out with questions or issues!

