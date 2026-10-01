using Cqs.Abstractions.Errors;

namespace GestTache.Api.Domain.Services
{
    public static class TacheErrors
    {
        public static Error NotFound => new Error("Tache.Errors", "Tache non trouvée");
        public static Error AlreadyCloture => new Error("Tache.Errors", "Tache déjà cloturée");
        public static Error NotInserted => new Error("Tache.Errors", "Aucune tache insérée");

    }
}
