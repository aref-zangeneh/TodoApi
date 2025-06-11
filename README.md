- **ASP.NET Core 9 / C# 13**
- Clean Architecture applied
- modular folder structure
- Persistence with **Entity Framework Core 9** and **SQL Server**
- Auto‑generated **Swagger** documentation
- Auto database and table creation is active(you should just setup the connection string, the database would be created itself when you run the project)
- Minimal Bootstrap  web UI

# 1 – Clone
$ git clone https://github.com/aref-zangeneh/TodoApi.git
$ cd TodoApp

# 2 – Restore & build
$ dotnet restore
$ dotnet build

# 3 – Configure the database connection in TodoApp.Api => appsettings.json

# 4 - In **Visual Studio/Rider/VS Code**:
1. Right‑click the *solution* → **Configure Startup Projects…**
2. Choose **Multiple startup projects**
3. Set **TodoApp.Api** and **TodoApp.Web** to **Start**
4. **Apply**

# 5 – Check ports

Ensure the ports defined in each project's `Properties/launchSettings.json` are free.

| Project | Default Port |
|---------|--------------|
| TodoApp.Api | `8001` |
| TodoApp.Web | `7064` |

Change them if they collide with other services.

# 6 Run the project

# Explore

| Endpoint | URL |
|----------|-----|
| **Swagger UI** | <https://localhost:8001> |
| **Web UI** | <https://localhost:7064> | (simple UI available for API interaction simulation)

