using Eatsy.Models;
using Microsoft.EntityFrameworkCore;

namespace Eatsy.Services
{
    public class MealPlannerService : IMealPlannerService
    {
        private readonly AppDbContext _context;

        public MealPlannerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MealPlan>> GetPlanSemaineAsync()
        {
            var plan = await _context.MealPlans
                .Include(m => m.Recipe)
                .ToListAsync();

            // S'assurer que tous les jours et repas existent
            var jours = new[] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            var repasTypes = new[] { "Petit-déjeuner", "Déjeuner", "Dîner" };

            var hasChanges = false;
            foreach (var jour in jours)
            {
                foreach (var repasType in repasTypes)
                {
                    if (!plan.Any(m => m.JourSemaine == jour && m.RepasType == repasType))
                    {
                        var newMeal = new MealPlan { JourSemaine = jour, RepasType = repasType };
                        _context.MealPlans.Add(newMeal);
                        plan.Add(newMeal);
                        hasChanges = true;
                    }
                }
            }

            if (hasChanges)
            {
                await _context.SaveChangesAsync();
            }

            return plan;
        }

        public async Task AssignerRecetteAsync(string jour, string repasType, int? recipeId)
        {
            var meal = await _context.MealPlans
                .FirstOrDefaultAsync(m => m.JourSemaine == jour && m.RepasType == repasType);

            if (meal != null)
            {
                meal.RecipeId = recipeId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<double> GetCaloriesTotalesSemaineAsync()
        {
            var plan = await _context.MealPlans
                .Include(m => m.Recipe)
                    .ThenInclude(r => r!.RecipeIngredients!)
                        .ThenInclude(ri => ri.Ingredient)
                .ToListAsync();

            double totalCalories = 0;

            foreach (var meal in plan)
            {
                if (meal.Recipe != null && meal.Recipe.RecipeIngredients != null)
                {
                    var mealTotalCalories = meal.Recipe.RecipeIngredients.Sum(ri =>
                        (ri.Ingredient?.CaloriesPerUnit ?? 0) / 100.0 * ri.Quantity);
                    totalCalories += mealTotalCalories / meal.Recipe.NumberOfPersons;
                }
            }

            return totalCalories;
        }
    }
}
