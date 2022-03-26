namespace Tec.Compis.ConsoleApp;

/// <summary>
/// Static class with util methods
/// </summary>
public static class Util
{
    public static string Contents<T>(IEnumerable<T> c) => $"{{{String.Join(',', c)}}}";
}
