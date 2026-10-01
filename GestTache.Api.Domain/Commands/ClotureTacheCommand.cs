using BStorm.Tools.Database;
using Cqs.Abstractions.Commands;
using Cqs.Abstractions.Errors;
using Cqs.Abstractions.Results;
using GestTache.Api.Domain.Entities;
using GestTache.Api.Domain.Queries;
using GestTache.Api.Domain.Services;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace GestTache.Api.Domain.Commands
{
    public record ClotureTacheCommand(int Id) : ICommandDefinition
    {
        public int UtilisateurId => 1;
    }
}
