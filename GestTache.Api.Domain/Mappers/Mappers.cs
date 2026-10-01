using GestTache.Api.Domain.Entities;
using System.Data;

namespace GestTache.Api.Domain.Mappers
{
    internal static class Mappers
    {
        extension(IDataRecord record)
        {
            public Tache ToTache()
            {
                return new Tache(
                    (int)record["Id"],
                    (string)record["Titre"],
                    (DateTime)record["DateCreation"],
                    (bool)record["Cloturee"]);
            }
        }
    }
}
