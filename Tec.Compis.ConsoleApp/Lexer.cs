namespace Tec.Compis.ConsoleApp;

// Representation of a basic grammar
class Grammar{
	Dictionary<string, List<string[]>> symbols;

    public Grammar()
    {
		// Init the data
		symbols = new(128);
    }

    // Add a production to another symbol
    public void AddProd(string key, string[] production) {
		// Create the symbol if it does not exists
		if (!symbols.ContainsKey(key))
		{
			symbols[key] = new(32);
		}

		symbols[key].Add(production);
	}

	public void AddProd(string[] tokens) {
		// Get the other productions
		List<string> right = new(tokens.Length);
		for(int i = 2; i < tokens.Length; i++) right.Add(tokens[i]);

		AddProd(tokens[0], right.ToArray());
	}

	
}