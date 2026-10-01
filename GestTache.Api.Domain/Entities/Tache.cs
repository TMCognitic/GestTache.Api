namespace GestTache.Api.Domain.Entities
{
    public record Tache(int Id, string Titre, DateTime DateCreation, bool Cloturee);
}
