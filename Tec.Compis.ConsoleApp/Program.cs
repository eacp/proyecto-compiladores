using Tec.Compis.ConsoleApp;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Diseño de compiladores");
Console.WriteLine("Eduardo Andrés Castillo Perera - A01702948");
Console.WriteLine("Profesor: Dr. Pedro Oscar Pérez Murueta");

/*
Three options:
	1. There are no params in the command line. 
	Use standard input and standard output

	2. There is a file path for the input, but no file path
	for the output. Use the file and standard output.

	3. There is a file input and a file output. Use these instead.
*/

if (args.Length == 0)
{
	// Case 1: Ask for the file in the command line
	Console.WriteLine("Por favor ingrese la ruta del archivo de entrada");
	string path = Console.ReadLine() ?? "";

	// Check the file exists
	if(!File.Exists(path)) {
		notFoundError(path);
		return;
	}

	using StreamReader inFile = File.OpenText(path);

	// Call the program but with the file as the input
	lexerApp(inFile, Console.Out);
} else if (args.Length == 1) {
	// Case 2: Use a file as input but keep stdout.

	// Open the input file

	// Check the file exists
	if(!File.Exists(args[0])) {
		notFoundError(args[0]);
		return;
	}

	using StreamReader inFile = File.OpenText(args[0]);

	// Call the program but with the file as the input
	lexerApp(inFile, Console.Out);

} else if (args.Length == 2){
	// Case 3: Use files as stdin and stdout.

	// Check the INPUT file exists
	if(!File.Exists(args[0])) {
		notFoundError(args[0]);
		return;
	}

	// The output file does NOT need to exist, because it can be created

	// Open the IO files
	using StreamReader inFile = File.OpenText(args[0]);
	using StreamWriter outFile = new StreamWriter(args[1]);

	// Use the "main2" but with the files.
	lexerApp(inFile, outFile);
}


// The "real" main
void lexerApp(TextReader input, TextWriter output) {
	string line1 = input.ReadLine() ?? "";
	if (line1 == "") {
		return;
	}

	int numLines = int.Parse(line1);

	Grammar grammar = new();

	// Iterate each line
	for (int i = 0; i < numLines; i++)
	{
		// Get the tokens, ignoring the ' symbol
		string[] tokens = tokenize(rl(input).Replace('\'', ' '));
		grammar.AddProd(tokens);
		
	}

}

void notFoundError(string path) 
	=> Console.Error.WriteLine($"Error: file '{path}' does not exists");

string rl(TextReader r) => r.ReadLine() ?? "";

// Separate into tokens
string[] tokenize(string line) => line.Split(' ', StringSplitOptions.RemoveEmptyEntries);