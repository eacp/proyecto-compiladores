using Tec.Compis.ConsoleApp;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Diseño de compiladores");
Console.WriteLine("Eduardo Andrés Castillo Perera - A01702948");
Console.WriteLine("Profesor: Dr. Pedro Oscar Pérez Murueta");
Console.WriteLine("El PWD es: " + Directory.GetCurrentDirectory());

// Get the input file
string filepath = args.Length > 0 ? 
    args[0] : 
    ask("Please provid the filepath for the grammar");

// Open the file
using var grammarFile = File.OpenText(filepath);


// The grammar
Grammar g = new();

// Append all the lines
// Read the first one
grammarFile.ReadLine();

while(!grammarFile.EndOfStream)
{
    var line = grammarFile.ReadLine();
    g.Add(line);
}

// A symbol is terminal if and only if it appears on the right.
// If it is at the right it is NT

HashSet<string> terminals = new();
HashSet<string> nonTerminals = new();

foreach (Definition def in g)
{
    // Add the name to the set of NT
    nonTerminals.Add(def.Name);

    // Attempt to remove it from the terminals if it is
    // somehow labeled as such
    if( terminals.Contains(def.Name) )
    {
        terminals.Remove(def.Name);
    }

    // Iterate thru all the symbols in a definition
    foreach (var token in def)
    {
        // Attempt to add it to the terminals if it is NOT
        // in the NT already
        if (!nonTerminals.Contains(token))
        {
            terminals.Add(token);
        }
    }
}

Console.WriteLine(terminals);
Console.WriteLine(nonTerminals);


/// <summary>
/// Prints a message to the console and reads a line
/// from the console.
/// </summary>
string ask(string message, string defaultAnswer="")
{
    Console.WriteLine("Please provide the path of the input file");
    return Console.ReadLine() ?? defaultAnswer;
}