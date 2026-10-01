using BStorm.Tools.Database;
using Cqs.Abstractions.Results;
using GestTache.Api.Domain.Commands;
using GestTache.Api.Domain.Entities;
using GestTache.Api.Domain.Mappers;
using GestTache.Api.Domain.Queries;
using GestTache.Api.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace GestTache.Api.Domain.Services
{
    public class TacheService : ITacheRepository
    {
        private readonly DbConnection _dbConnection;
        private readonly ILogger _logger;

        public TacheService(DbConnection dbConnection, ILogger<TacheService> logger)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
            _logger = logger;
        }

        public Result<IEnumerable<Tache>> Execute(GetTachesQuery query)
        {
            return _dbConnection.ExecuteReader("SELECT Id, Titre, Cloturee, DateCreation, UtilisateurId FROM Tache WHERE UtilisateurId = @UtilisateurId;", dr => dr.ToTache(), parameters: query).ToList();
        }

        public async Task<Result<Tache>> ExecuteAsync(GetTacheByIdQuery query)
        {
            IAsyncEnumerable<Tache> result = _dbConnection.ExecuteReaderAsync("SELECT Id, Titre, Cloturee, DateCreation, UtilisateurId FROM Tache WHERE Id = @Id AND UtilisateurId = @UtilisateurId;", dr => dr.ToTache(), parameters: query);

            Tache? tache = await result.SingleOrDefaultAsync();

            if(tache is null)
            {
                return TacheErrors.NotFound;
            }

            return tache;
        }

        public async Task<Result<int>> ExecuteAsync(CreateTacheCommand command)
        {
            try
            {
                int? id = (int?)await _dbConnection.ExecuteScalarAsync("INSERT INTO Tache (Titre, UtilisateurId) OUTPUT inserted.Id VALUES (@Titre, @UtilisateurId);", parameters: command);

                if(!id.HasValue)
                    return TacheErrors.NotInserted;

                return id.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex;
            }
            
        }

        public Result Execute(UpdateTacheCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("UPDATE Tache SET Titre = @Titre, Cloturee = @Cloturee WHERE Id = @Id AND UtilisateurId = @UtilisateurId;", parameters: command);

                if (rows is 0)
                    return TacheErrors.NotFound;

                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex;
            }
        }

        public Result Execute(DeleteTacheCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("DELETE FROM Tache WHERE Id = @Id AND UtilisateurId = @UtilisateurId;", parameters: command);

                if (rows is 0)
                    return TacheErrors.NotFound;

                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex;
            }
        }

        public async Task<Result> ExecuteAsync(ClotureTacheCommand command)
        {
            try
            {
                Result<Tache> result = await ExecuteAsync(new GetTacheByIdQuery(command.Id));

                if(result.IsFailure)
                {
                    return result.Error;
                }

                if (result.Data.Cloturee)
                {
                    return TacheErrors.AlreadyCloture;
                }

                int rows = _dbConnection.ExecuteNonQuery("UPDATE Tache SET Cloturee = 1 WHERE Id = @Id AND UtilisateurId = @UtilisateurId;", parameters: command);                
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex;
            }
        }
    }
}
