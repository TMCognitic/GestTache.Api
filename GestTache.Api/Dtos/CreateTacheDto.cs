using System.ComponentModel.DataAnnotations;

namespace GestTache.Api.Dtos
{
    public class CreateTacheDto
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Titre { get; set; } = default!;
    }
}
