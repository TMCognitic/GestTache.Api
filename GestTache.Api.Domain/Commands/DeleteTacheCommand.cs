using Cqs.Abstractions.Commands;

namespace GestTache.Api.Domain.Commands;

public record DeleteTacheCommand(int Id) : ICommandDefinition
{
    public int UtilisateurId => 1;
}
