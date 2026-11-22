# Eatsy

Recipe and meal-planning web app built with Blazor (.NET 10), Entity Framework Core (SQLite), ASP.NET Core Identity and Radzen components.

## Features
- Recipes, categories, cuisine types, ingredients and units management
- Weekly meal planner
- Dashboard with statistics
- User accounts and user management

## Run
Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
cd Eatsy
dotnet ef database update   # creates app.db (or let the app create it on first run)
dotnet run
```

The SQLite database (`app.db`) is created locally and is not committed.
