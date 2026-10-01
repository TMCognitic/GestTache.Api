using Cqs.Abstractions.Commands;
using Cqs.Abstractions.Queries;
using GestTache.Api.Domain.Commands;
using GestTache.Api.Domain.Entities;
using GestTache.Api.Domain.Queries;

namespace GestTache.Api.Domain.Repositories
{
    public interface ITacheRepository :
        IQueryHandler<GetTachesQuery, IEnumerable<Tache>>,
        IQueryAsyncHandler<GetTacheByIdQuery, Tache>,
        ICommandAsyncHandler<CreateTacheCommand, int>,
        ICommandHandler<UpdateTacheCommand>,
        ICommandHandler<DeleteTacheCommand>,
        ICommandAsyncHandler<ClotureTacheCommand>
    {
    }
}
