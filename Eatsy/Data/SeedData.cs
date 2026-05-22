using Eatsy.Models;
using Microsoft.EntityFrameworkCore;

namespace Eatsy.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        // Check if tables are already seeded
        if (await context.Units.AnyAsync()) return; // DB has been seeded

        // Seed Units
        var unitGramme = new Unit { Name = "Gramme", Abbreviation = "g" };
        var unitMl = new Unit { Name = "Millilitre", Abbreviation = "ml" };
        var unitPcs = new Unit { Name = "Pièce", Abbreviation = "pcs" };
        var unitCas = new Unit { Name = "Cuillère à soupe", Abbreviation = "c.à.s" };
        var unitCac = new Unit { Name = "Cuillère à café", Abbreviation = "c.à.c" };
        
        context.Units.AddRange(unitGramme, unitMl, unitPcs, unitCas, unitCac);
        await context.SaveChangesAsync();

        // Seed Categories
        var catPetitDej = new Category { Name = "Petit-déjeuner" };
        var catDejeuner = new Category { Name = "Déjeuner" };
        var catDiner = new Category { Name = "Dîner" };
        var catDessert = new Category { Name = "Dessert" };
        var catCollation = new Category { Name = "Collation" };

        context.Categories.AddRange(catPetitDej, catDejeuner, catDiner, catDessert, catCollation);
        await context.SaveChangesAsync();

        // Seed Cuisine Types
        var cuitTunisienne = new CuisineType { Name = "Tunisienne" };
        var cuitFrancaise = new CuisineType { Name = "Française" };
        var cuitItalienne = new CuisineType { Name = "Italienne" };
        var cuitMed = new CuisineType { Name = "Méditerranéenne" };
        var cuitOrientale = new CuisineType { Name = "Orientale" };

        context.CuisineTypes.AddRange(cuitTunisienne, cuitFrancaise, cuitItalienne, cuitMed, cuitOrientale);
        await context.SaveChangesAsync();

        // Seed Ingredients
        var ingRiz = new Ingredient { Name = "Riz basmati", CaloriesPerUnit = 350, Proteins = 7, Carbs = 77, Fats = 0.5, UnitId = unitGramme.Id };
        var ingLentilles = new Ingredient { Name = "Lentilles rouges", CaloriesPerUnit = 116, Proteins = 9, Carbs = 20, Fats = 0.4, UnitId = unitGramme.Id };
        var ingPoulet = new Ingredient { Name = "Poulet (cuisse)", CaloriesPerUnit = 209, Proteins = 26, Carbs = 0, Fats = 11, UnitId = unitGramme.Id };
        var ingBoeuf = new Ingredient { Name = "Boeuf haché", CaloriesPerUnit = 254, Proteins = 17, Carbs = 0, Fats = 20, UnitId = unitGramme.Id };
        var ingTomate = new Ingredient { Name = "Tomate", CaloriesPerUnit = 18, Proteins = 0.9, Carbs = 3.9, Fats = 0.2, UnitId = unitGramme.Id };
        var ingOignon = new Ingredient { Name = "Oignon", CaloriesPerUnit = 40, Proteins = 1.1, Carbs = 9.3, Fats = 0.1, UnitId = unitGramme.Id };
        var ingAil = new Ingredient { Name = "Ail", CaloriesPerUnit = 149, Proteins = 6.4, Carbs = 33, Fats = 0.5, UnitId = unitGramme.Id };
        var ingHuile = new Ingredient { Name = "Huile d'olive", CaloriesPerUnit = 884, Proteins = 0, Carbs = 0, Fats = 100, UnitId = unitMl.Id };
        var ingCouscous = new Ingredient { Name = "Couscous", CaloriesPerUnit = 376, Proteins = 13, Carbs = 77, Fats = 0.6, UnitId = unitGramme.Id };
        var ingFarine = new Ingredient { Name = "Farine de blé", CaloriesPerUnit = 364, Proteins = 10, Carbs = 76, Fats = 1, UnitId = unitGramme.Id };
        var ingOeuf = new Ingredient { Name = "Oeuf", CaloriesPerUnit = 155, Proteins = 13, Carbs = 1.1, Fats = 11, UnitId = unitPcs.Id };
        var ingLait = new Ingredient { Name = "Lait", CaloriesPerUnit = 42, Proteins = 3.4, Carbs = 5, Fats = 1, UnitId = unitMl.Id };
        var ingBeurre = new Ingredient { Name = "Beurre", CaloriesPerUnit = 717, Proteins = 0.9, Carbs = 0.1, Fats = 81, UnitId = unitGramme.Id };
        var ingSucre = new Ingredient { Name = "Sucre", CaloriesPerUnit = 387, Proteins = 0, Carbs = 100, Fats = 0, UnitId = unitGramme.Id };
        var ingSel = new Ingredient { Name = "Sel", CaloriesPerUnit = 0, Proteins = 0, Carbs = 0, Fats = 0, UnitId = unitGramme.Id };
        var ingCumin = new Ingredient { Name = "Cumin", CaloriesPerUnit = 375, Proteins = 18, Carbs = 44, Fats = 22, UnitId = unitGramme.Id };
        var ingHarissa = new Ingredient { Name = "Harissa", CaloriesPerUnit = 50, Proteins = 1.9, Carbs = 8, Fats = 1.5, UnitId = unitGramme.Id };
        var ingBrick = new Ingredient { Name = "Feuille de brick", CaloriesPerUnit = 270, Proteins = 8, Carbs = 52, Fats = 3, UnitId = unitPcs.Id };
        var ingFromage = new Ingredient { Name = "Fromage râpé", CaloriesPerUnit = 402, Proteins = 25, Carbs = 1.3, Fats = 33, UnitId = unitGramme.Id };
        var ingPates = new Ingredient { Name = "Pâtes (spaghetti)", CaloriesPerUnit = 371, Proteins = 13, Carbs = 74, Fats = 1.5, UnitId = unitGramme.Id };
        var ingPommeTerre = new Ingredient { Name = "Pomme de terre", CaloriesPerUnit = 77, Proteins = 2, Carbs = 17, Fats = 0.1, UnitId = unitGramme.Id };
        var ingPoivron = new Ingredient { Name = "Poivron rouge", CaloriesPerUnit = 31, Proteins = 1, Carbs = 6, Fats = 0.3, UnitId = unitGramme.Id };
        var ingPersil = new Ingredient { Name = "Persil", CaloriesPerUnit = 36, Proteins = 3, Carbs = 6, Fats = 0.8, UnitId = unitGramme.Id };
        var ingCannelle = new Ingredient { Name = "Cannelle", CaloriesPerUnit = 247, Proteins = 4, Carbs = 81, Fats = 1.2, UnitId = unitGramme.Id };
        var ingMiel = new Ingredient { Name = "Miel", CaloriesPerUnit = 304, Proteins = 0.3, Carbs = 82, Fats = 0, UnitId = unitGramme.Id };

        context.Ingredients.AddRange(ingRiz, ingLentilles, ingPoulet, ingBoeuf, ingTomate, ingOignon, ingAil, ingHuile, ingCouscous, ingFarine, ingOeuf, ingLait, ingBeurre, ingSucre, ingSel, ingCumin, ingHarissa, ingBrick, ingFromage, ingPates, ingPommeTerre, ingPoivron, ingPersil, ingCannelle, ingMiel);
        await context.SaveChangesAsync();

        // Seed Recipes
        var recTajine = new Recipe
        {
            Name = "Tajine de poulet aux olives", CategoryId = catDejeuner.Id, CuisineTypeId = cuitMed.Id, NumberOfPersons = 4, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Faire dorer les cuisses de poulet dans l'huile d'olive. Ajouter oignon, ail, tomates et épices. Laisser mijoter 45 minutes à feu doux. Ajouter les olives en fin de cuisson et servir chaud.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingPoulet.Id, Quantity = 800 },
                new RecipeIngredient { IngredientId = ingOignon.Id, Quantity = 150 },
                new RecipeIngredient { IngredientId = ingAil.Id, Quantity = 15 },
                new RecipeIngredient { IngredientId = ingTomate.Id, Quantity = 200 },
                new RecipeIngredient { IngredientId = ingHuile.Id, Quantity = 40 },
                new RecipeIngredient { IngredientId = ingSel.Id, Quantity = 5 },
                new RecipeIngredient { IngredientId = ingCumin.Id, Quantity = 5 }
            }
        };

        var recCouscous = new Recipe
        {
            Name = "Couscous au boeuf", CategoryId = catDejeuner.Id, CuisineTypeId = cuitTunisienne.Id, NumberOfPersons = 6, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Préparer le bouillon avec le boeuf, oignons et épices. Cuire les légumes dans le bouillon. Cuire le couscous à la vapeur en 3 passages. Dresser et arroser de bouillon. Servir avec harissa.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingCouscous.Id, Quantity = 600 },
                new RecipeIngredient { IngredientId = ingBoeuf.Id, Quantity = 400 },
                new RecipeIngredient { IngredientId = ingOignon.Id, Quantity = 200 },
                new RecipeIngredient { IngredientId = ingTomate.Id, Quantity = 300 },
                new RecipeIngredient { IngredientId = ingHuile.Id, Quantity = 50 },
                new RecipeIngredient { IngredientId = ingSel.Id, Quantity = 8 },
                new RecipeIngredient { IngredientId = ingCumin.Id, Quantity = 8 },
                new RecipeIngredient { IngredientId = ingHarissa.Id, Quantity = 30 }
            }
        };

        var recBrik = new Recipe
        {
            Name = "Brik au thon et oeuf", CategoryId = catDiner.Id, CuisineTypeId = cuitTunisienne.Id, NumberOfPersons = 2, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Déposer sur chaque feuille de brick: un oeuf, du thon émietté et de l'harissa. Replier en triangle et frire dans l'huile bien chaude 3 minutes de chaque côté.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingBrick.Id, Quantity = 4 },
                new RecipeIngredient { IngredientId = ingOeuf.Id, Quantity = 4 },
                new RecipeIngredient { IngredientId = ingHarissa.Id, Quantity = 15 },
                new RecipeIngredient { IngredientId = ingHuile.Id, Quantity = 60 },
                new RecipeIngredient { IngredientId = ingSel.Id, Quantity = 2 }
            }
        };

        var recSpaghetti = new Recipe
        {
            Name = "Spaghetti bolognaise", CategoryId = catDiner.Id, CuisineTypeId = cuitItalienne.Id, NumberOfPersons = 4, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Faire revenir le boeuf haché avec l'oignon et l'ail. Ajouter les tomates concassées et laisser mijoter 20 minutes. Cuire les pâtes al dente et mélanger avec la sauce. Parsemer de fromage râpé avant de servir.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingPates.Id, Quantity = 400 },
                new RecipeIngredient { IngredientId = ingBoeuf.Id, Quantity = 300 },
                new RecipeIngredient { IngredientId = ingTomate.Id, Quantity = 400 },
                new RecipeIngredient { IngredientId = ingOignon.Id, Quantity = 100 },
                new RecipeIngredient { IngredientId = ingAil.Id, Quantity = 10 },
                new RecipeIngredient { IngredientId = ingHuile.Id, Quantity = 30 },
                new RecipeIngredient { IngredientId = ingSel.Id, Quantity = 5 },
                new RecipeIngredient { IngredientId = ingFromage.Id, Quantity = 50 }
            }
        };

        var recRizLait = new Recipe
        {
            Name = "Riz au lait à la cannelle", CategoryId = catDessert.Id, CuisineTypeId = cuitOrientale.Id, NumberOfPersons = 4, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Porter le lait à ébullition avec le sucre. Verser le riz et cuire à feu doux 25 minutes en remuant. Verser dans des ramequins, saupoudrer de cannelle et laisser refroidir avant de servir.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingRiz.Id, Quantity = 200 },
                new RecipeIngredient { IngredientId = ingLait.Id, Quantity = 800 },
                new RecipeIngredient { IngredientId = ingSucre.Id, Quantity = 80 },
                new RecipeIngredient { IngredientId = ingCannelle.Id, Quantity = 5 },
                new RecipeIngredient { IngredientId = ingBeurre.Id, Quantity = 20 }
            }
        };

        var recShakshuka = new Recipe
        {
            Name = "Shakshuka (oeufs en sauce tomate)", CategoryId = catPetitDej.Id, CuisineTypeId = cuitTunisienne.Id, NumberOfPersons = 2, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Faire revenir oignon, ail et poivron dans l'huile. Ajouter les tomates concassées, sel, cumin et harissa. Laisser mijoter 10 min. Casser les oeufs dans la sauce, couvrir et cuire 5 minutes. Parsemer de persil frais.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingOeuf.Id, Quantity = 4 },
                new RecipeIngredient { IngredientId = ingTomate.Id, Quantity = 400 },
                new RecipeIngredient { IngredientId = ingOignon.Id, Quantity = 100 },
                new RecipeIngredient { IngredientId = ingAil.Id, Quantity = 10 },
                new RecipeIngredient { IngredientId = ingPoivron.Id, Quantity = 150 },
                new RecipeIngredient { IngredientId = ingHuile.Id, Quantity = 30 },
                new RecipeIngredient { IngredientId = ingSel.Id, Quantity = 4 },
                new RecipeIngredient { IngredientId = ingCumin.Id, Quantity = 4 },
                new RecipeIngredient { IngredientId = ingHarissa.Id, Quantity = 20 },
                new RecipeIngredient { IngredientId = ingPersil.Id, Quantity = 10 }
            }
        };

        var recSoupe = new Recipe
        {
            Name = "Soupe de lentilles", CategoryId = catDiner.Id, CuisineTypeId = cuitOrientale.Id, NumberOfPersons = 4, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Faire revenir l'oignon et l'ail dans l'huile d'olive. Ajouter les lentilles, tomates et épices. Couvrir d'eau et cuire 30 minutes. Mixer partiellement et ajuster l'assaisonnement. Servir avec du persil.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingLentilles.Id, Quantity = 300 },
                new RecipeIngredient { IngredientId = ingOignon.Id, Quantity = 150 },
                new RecipeIngredient { IngredientId = ingAil.Id, Quantity = 15 },
                new RecipeIngredient { IngredientId = ingTomate.Id, Quantity = 200 },
                new RecipeIngredient { IngredientId = ingHuile.Id, Quantity = 30 },
                new RecipeIngredient { IngredientId = ingSel.Id, Quantity = 5 },
                new RecipeIngredient { IngredientId = ingCumin.Id, Quantity = 6 },
                new RecipeIngredient { IngredientId = ingPersil.Id, Quantity = 10 }
            }
        };

        var recCrepes = new Recipe
        {
            Name = "Crêpes au miel", CategoryId = catPetitDej.Id, CuisineTypeId = cuitFrancaise.Id, NumberOfPersons = 4, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Mélanger farine, oeufs, lait et une pincée de sel jusqu'à obtenir une pâte lisse. Laisser reposer 30 min. Cuire dans une poêle beurrée, 2 min de chaque côté. Servir avec du miel.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingFarine.Id, Quantity = 250 },
                new RecipeIngredient { IngredientId = ingOeuf.Id, Quantity = 3 },
                new RecipeIngredient { IngredientId = ingLait.Id, Quantity = 500 },
                new RecipeIngredient { IngredientId = ingBeurre.Id, Quantity = 30 },
                new RecipeIngredient { IngredientId = ingSel.Id, Quantity = 2 },
                new RecipeIngredient { IngredientId = ingMiel.Id, Quantity = 60 }
            }
        };

        var recPommes = new Recipe
        {
            Name = "Pommes de terre à la tunisienne", CategoryId = catCollation.Id, CuisineTypeId = cuitTunisienne.Id, NumberOfPersons = 3, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Couper les pommes de terre en cubes. Mélanger avec huile d'olive, harissa, ail et sel. Rôtir au four à 200°C pendant 35 minutes jusqu'à dorure. Parsemer de persil et servir chaud.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingPommeTerre.Id, Quantity = 700 },
                new RecipeIngredient { IngredientId = ingHuile.Id, Quantity = 40 },
                new RecipeIngredient { IngredientId = ingHarissa.Id, Quantity = 25 },
                new RecipeIngredient { IngredientId = ingAil.Id, Quantity = 10 },
                new RecipeIngredient { IngredientId = ingSel.Id, Quantity = 5 },
                new RecipeIngredient { IngredientId = ingPersil.Id, Quantity = 10 }
            }
        };

        var recGratin = new Recipe
        {
            Name = "Gratin de pâtes au fromage", CategoryId = catDiner.Id, CuisineTypeId = cuitFrancaise.Id, NumberOfPersons = 4, ImageUrl = "/images/recipes/default.jpg",
            CookingMethod = "Cuire les pâtes al dente. Préparer une béchamel avec beurre, farine et lait. Mélanger pâtes et béchamel, verser dans un plat. Couvrir de fromage râpé. Gratiner au four à 200°C pendant 20 minutes.",
            RecipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient { IngredientId = ingPates.Id, Quantity = 400 },
                new RecipeIngredient { IngredientId = ingFromage.Id, Quantity = 150 },
                new RecipeIngredient { IngredientId = ingBeurre.Id, Quantity = 40 },
                new RecipeIngredient { IngredientId = ingFarine.Id, Quantity = 40 },
                new RecipeIngredient { IngredientId = ingLait.Id, Quantity = 400 },
                new RecipeIngredient { IngredientId = ingSel.Id, Quantity = 4 }
            }
        };

        context.Recipes.AddRange(recTajine, recCouscous, recBrik, recSpaghetti, recRizLait, recShakshuka, recSoupe, recCrepes, recPommes, recGratin);
        await context.SaveChangesAsync();
    }
}
