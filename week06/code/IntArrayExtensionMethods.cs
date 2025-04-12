using System.Collections;
using System.Linq;

public static class IntArrayExtensionMethods
{
    // Método de extensión para convertir IEnumerable<int> a una cadena de texto
    public static string AsString(this IEnumerable<int> array)
    {
        return "<IEnumerable>{" + string.Join(", ", array) + "}";
    }
}
