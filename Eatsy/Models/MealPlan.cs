using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eatsy.Models
{
    public class MealPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string JourSemaine { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string RepasType { get; set; } = string.Empty;

        public int? RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe? Recipe { get; set; }
    }
}
