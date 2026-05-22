using Eatsy.Models;
using Microsoft.EntityFrameworkCore;

namespace Eatsy.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, int>> GetRecettesParCategorieAsync()
        {
            return await _context.Recipes
                .Include(r => r.Category)
                .Where(r => r.Category != null)
                .GroupBy(r => r.Category.Name)
                .Select(g => new { Categorie = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Categorie, x => x.Count);
        }

        public async Task<Dictionary<string, int>> GetRecettesParCuisineAsync()
        {
            return await _context.Recipes
                .Include(r => r.CuisineType)
                .Where(r => r.CuisineType != null)
                .GroupBy(r => r.CuisineType.Name)
                .Select(g => new { Cuisine = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Cuisine, x => x.Count);
        }

        public async Task<Dictionary<string, double>> GetCaloriesParRecetteAsync()
        {
            var recipes = await _context.Recipes
                .Include(r => r.RecipeIngredients!)
                .ThenInclude(ri => ri.Ingredient)
                .ToListAsync();

            var result = recipes.Select(r => new
            {
                RecipeName = r.Name,
                TotalCalories = Math.Round((r.RecipeIngredients?.Sum(ri => (ri.Ingredient?.CaloriesPerUnit ?? 0) / 100.0 * ri.Quantity) ?? 0) / (r.NumberOfPersons > 0 ? r.NumberOfPersons : 1), 0)
            })
            .OrderByDescending(r => r.TotalCalories)
            .Take(8)
            .ToDictionary(r => r.RecipeName, r => r.TotalCalories);

            return result;
        }

        public async Task<DashboardStats> GetStatistiquesGeneralesAsync()
        {
            var recipes = await _context.Recipes
                .Include(r => r.RecipeIngredients!)
                .ThenInclude(ri => ri.Ingredient)
                .ToListAsync();

            var totalRecipes = recipes.Count;
            var totalIngredients = await _context.Ingredients.CountAsync();

            double totalCaloriesAll = recipes.Sum(r => r.RecipeIngredients?.Sum(ri => (ri.Ingredient?.CaloriesPerUnit ?? 0) / 100.0 * ri.Quantity) ?? 0);
            double avgCalories = totalRecipes > 0 ? totalCaloriesAll / totalRecipes : 0;

            var mostPopularCuisine = await _context.Recipes
                .Include(r => r.CuisineType)
                .Where(r => r.CuisineType != null)
                .GroupBy(r => r.CuisineType.Name)
                .Select(g => new { Cuisine = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefaultAsync();

            return new DashboardStats
            {
                TotalRecipes = totalRecipes,
                TotalIngredients = totalIngredients,
                AverageCaloriesPerRecipe = avgCalories,
                MostPopularCuisineType = mostPopularCuisine?.Cuisine ?? "N/A"
            };
        }
    }
}
