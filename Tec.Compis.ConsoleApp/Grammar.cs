namespace Tec.Compis.ConsoleApp;

class Grammar
{
    // A grammar has one or more definitions
    private List<Definition> definitions = new(64);

    /// <summary>
    /// Add a definition to the grammar based on a line
    /// </summary>
    /// <param name="line"></param>
    internal void Add(string line)
    {
        definitions.Add(new Definition(line));
    }
}

class Definition
{
    /// <summary>
    /// Name is the "left" part of the definition.
    /// </summary>
    internal string Name { get; private set; }

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
}