using System.Collections;

namespace Tec.Compis.ConsoleApp;

class Grammar : IReadOnlyList<Definition>
{
    private const string epsilon = "EPSILON";

    // A grammar has one or more definitions
    private List<Definition> definitions = new(64);

    public int Count => definitions.Count;

    public Definition this[int index] => definitions[index];

    /// <summary>
    /// Add a definition to the grammar based on a line
    /// </summary>
    /// <param name="line"></param>
    internal void Add(string line) => definitions.Add(new Definition(line));

    /// <inheritdoc/>
    public override string ToString() => Util.Contents(definitions);

    /// <inheritdoc/>
    public IEnumerator<Definition> GetEnumerator() => definitions.GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => definitions.GetEnumerator();
}

class Definition : IReadOnlyList<string>
{
    /// <summary>
    /// Name is the "left" part of the definition.
    /// </summary>
    internal string Name { get; private set; }

    public int Count => tokens.Length;

    public string this[int index] => tokens[index];

    /// <summary>
    /// The part on the right
    /// </summary>
    private string[] tokens;

    /// <summary>
    /// Creates a new definition based on a line
    /// </summary>
    /// <param name="line">
    /// The text that makes this definition.
    /// Example: 'id -> a b c'
    /// </param>
    public Definition(string line)
    {
        string[] elements = line.Replace('\'', ' ')
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Get the ID and the sub array
        Name = elements[0];
        tokens = elements.Skip(2).ToArray();
    }

    /// <inheritdoc/>
    public override string ToString() => $"{Name} -> {Util.Contents(tokens)}";

    /// <inheritdoc/>
    public IEnumerator<string> GetEnumerator()
    {
        foreach (string token in tokens) yield return token;
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => tokens.GetEnumerator();

    /// <summary>
    /// Determines if this definition is recursive.
    /// </summary>
    /// <remarks>
    /// A recursive definition is one like
    /// 
    /// E -> E X Y Z
    /// </remarks>
    internal bool IsRecursive => Name == tokens[0];
}