using Cqs.Abstractions.Commands;

namespace GestTache.Api.Domain.Commands;

public record CreateTacheCommand(string Titre) : ICommandDefinition<int>
{
    public int UtilisateurId => 1;
}
