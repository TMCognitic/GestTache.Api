using Cqs.Abstractions.Queries;
using GestTache.Api.Domain.Entities;

namespace GestTache.Api.Domain.Queries
{
    public record GetTachesQuery() : IQueryDefinition<IEnumerable<Tache>>
    {
        public int UtilisateurId => 1;
    }
}
