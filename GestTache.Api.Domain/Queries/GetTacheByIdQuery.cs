using Cqs.Abstractions.Queries;
using GestTache.Api.Domain.Entities;

namespace GestTache.Api.Domain.Queries
{
    public record GetTacheByIdQuery(int Id) : IQueryDefinition<Tache>
    {
        public int UtilisateurId => 1;
    }
}
