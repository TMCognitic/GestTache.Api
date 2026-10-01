using System.ComponentModel.DataAnnotations;

namespace GestTache.Api.Dtos
{
    public class UpdateTacheDto
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Titre { get; set; } = default!;
        public bool Cloturee { get; set; }
    }
}
