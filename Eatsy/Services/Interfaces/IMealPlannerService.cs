using Eatsy.Models;

namespace Eatsy.Services
{
    public interface IMealPlannerService
    {
        Task<List<MealPlan>> GetPlanSemaineAsync();
        Task AssignerRecetteAsync(string jour, string repasType, int? recipeId);
        Task<double> GetCaloriesTotalesSemaineAsync();
    }
}
