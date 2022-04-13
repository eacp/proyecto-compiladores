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


// A symbol is terminal if and only if it appears on the right.
// If it is at the right it is NT

// Create a lexer from the grammar
Lexer lexer = new(File.OpenText(filepath));

// Write them to a file
using var outputFile = new StreamWriter(ask("Please write the path to the output file"));

Console.WriteLine($"Terminal: {String.Join(',', lexer.Terminals)}");
Console.WriteLine($"Non terminal: {String.Join(',', lexer.NonTerminals)}");

outputFile.WriteLine($"Terminal: {String.Join(',', lexer.Terminals)}");
outputFile.WriteLine($"Non terminal: {String.Join(',', lexer.NonTerminals)}");

// Now print the first table
foreach (string nt in lexer.NonTerminals)
{
    List<string> first = lexer.FirstOf(nt);

    if (lexer.ReachedRecursive)
    {
        Console.WriteLine("la gramática es RECURSIVA, por lo tanto NO es LL(1)");
        return;
    }

    Console.WriteLine($"First({nt}) = {Util.Contents(first.Distinct())}");
}

/// <summary>
/// Prints a message to the console and reads a line
/// from the console.
/// </summary>
string ask(string message, string defaultAnswer="")
{
    Console.WriteLine(message);
    return Console.ReadLine() ?? defaultAnswer;
}