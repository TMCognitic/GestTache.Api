using Cqs.Abstractions.Commands;

namespace GestTache.Api.Domain.Commands;

public record UpdateTacheCommand(int Id, string Titre, bool Cloturee) : ICommandDefinition
{
    public int UtilisateurId => 1;
}
