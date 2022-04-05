namespace Tec.Compis.ConsoleApp;

// 
internal class Lexer
{
    internal HashSet<string> Terminals = new(128);
    internal HashSet<string> NonTerminals = new(128);

    internal Lexer(IEnumerable<Definition> defs)
    {
        foreach (Definition def in defs)
        {
            // Add the name to the set of NT
            NonTerminals.Add(def.Name);

            // Attempt to remove it from the terminals if it is
            // somehow labeled as such
            if (Terminals.Contains(def.Name))
            {
                Terminals.Remove(def.Name);
            }

            // Iterate thru all the symbols in a definition
            foreach (var token in def)
            {
                // Attempt to add it to the terminals if it is NOT
                // in the NT already
                if (!NonTerminals.Contains(token))
                {
                    Terminals.Add(token);
                }
            }
        }
    }
}
