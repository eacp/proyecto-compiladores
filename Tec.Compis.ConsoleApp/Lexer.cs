namespace Tec.Compis.ConsoleApp;

// 
internal class Lexer
{
    internal HashSet<string> Terminals = new(128);
    internal HashSet<string> NonTerminals = new(128);

    private Dictionary<string, Definition[]> ruleTable;

    /// <summary>
    /// Gets if we reached a recursive state.
    /// </summary>
    internal bool ReachedRecursive { get; private set; }

    internal Lexer(IEnumerable<Definition> defs)
    {

        ruleTable = makeRuleTable(defs);
    }

    /// <summary>
    /// Creates a lexer that is defined by a file or a text.
    /// </summary>
    /// <param name="input">An input that can be a file or the console.</param>
    internal Lexer(TextReader input)
    {
        // The grammar
        Grammar g = new();

        // Append all the lines
        // Read the first one
        int lines = int.Parse(input.ReadLine() ?? "");

        for(int i = 0; i  < lines; i++)
        {
            string line = input.ReadLine() ?? "";
            g.Add(line);
        }

        // Save the rule table made from a list of definitions
        ruleTable =  makeRuleTable(g);
    }

    private Dictionary<string, Definition[]> makeRuleTable(IEnumerable<Definition> defs)
    {
        // Add terminals and non terminals
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

        return defs
            .GroupBy(def => def.Name)
            .ToDictionary(x => x.Key, x => x.ToArray());
    }

    bool isTerminal(string token) => token == "epsilon" || Terminals.Contains(token);

    internal List<string> FirstOf(string nt)
    {
        var list = new List<string>(128);

        Stack<string> stack = new Stack<string>(128);

        // Push the first one
        stack.Push(nt);

        int iterations = 0;

        // Use stack-based recursion
        while(stack.Count > 0)
        {
            string symbol = stack.Pop();
            if (isTerminal(symbol))
            {
                list.Add(symbol);
                continue;
            }

            // Otherwise append all the tokens to the stack
            Definition[] defs = ruleTable[symbol];
            foreach (Definition def in defs) 
                stack.Push(def.FirstOrDefault("epsilon"));

            iterations++;
            if (iterations >= 1000000)
            {
                // Register we detected recursion.
                ReachedRecursive = true;
                return list;
            }

        }

        return list;
    }
}
