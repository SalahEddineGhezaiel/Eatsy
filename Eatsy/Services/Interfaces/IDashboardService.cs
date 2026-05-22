namespace Eatsy.Services
{
    public class DashboardStats
    {
        public int TotalRecipes { get; set; }
        public int TotalIngredients { get; set; }
        public double AverageCaloriesPerRecipe { get; set; }
        public string MostPopularCuisineType { get; set; } = string.Empty;
    }

    public interface IDashboardService
    {
        Task<Dictionary<string, int>> GetRecettesParCategorieAsync();
        Task<Dictionary<string, int>> GetRecettesParCuisineAsync();
        Task<Dictionary<string, double>> GetCaloriesParRecetteAsync();
        Task<DashboardStats> GetStatistiquesGeneralesAsync();
    }
}
