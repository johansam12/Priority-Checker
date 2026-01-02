# Priority Checker 
A high-performance .NET 8 Minimal API designed to evaluate task urgency and persist data using Entity Framework Core. It prioritizes the tasks and labels the priority. Feel free to check it out!


## Features
* **Minimal API Architecture**: Built using the latest .NET 8 standards for lightweight, efficient routing.
* **Data Persistence**: Utilizes **Entity Framework Core** with a **SQLite** provider to save tasks locally.
* **Automated Priority Logic**: Custom logic that categorizes tasks based on description length and specific keywords.
* **Interactive Documentation**: Integrated **Swagger UI** for real-time API testing and exploration.

## Tech Implemented
* **Framework**: .NET 8.0.11
* **ORM**: Entity Framework Core
* **Database**: SQLite
* **API Documentation**: Swashbuckle/Swagger

## How to run?
1. **Clone the repository**: `git clone <your-repo-url>`
2. **Restore dependencies**: `dotnet restore`
3. **Initialize the database**:
   - Run `dotnet ef database update` to apply migrations(database name) and create the `tasks.db` file.
4. **Run the application**: `dotnet run`
5. **Access the UI**: Navigate to `http://localhost:<port_num>/swagger` in your browser.

## Project Structure
* `Program.cs` -  This contains the API endpoints and service configuration.
* `Migrations/` - Directory containing the database schema blueprints.
* `Priority Checker.csproj` -  The project version .NET 8.0 is configured and executed.
