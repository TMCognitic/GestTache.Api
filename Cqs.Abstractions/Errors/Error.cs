namespace Cqs.Abstractions.Errors
{
    public record Error(string Code, string Message)
    {
        internal static Error None => new Error("", "");
        internal static Error Exception => new Error("Exception", "Une erreur est survenue (voir logs)");
        internal static Error Null => new Error("Error.Null", "Valeur NULL reçue");
    }
}
