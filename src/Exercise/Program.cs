Console.WriteLine("Welcome to File Reader");
Console.WriteLine("-----");
Console.WriteLine("Please enter the name of a text file you would like to read (leave empty to quit):");

string? fileName;
bool fileIsValid = false;

do {
    fileName = Console.ReadLine();

    try {
        testFileName(fileName);
        fileIsValid = true;
    } catch (ArgumentNullException) {
        // Provide an empty input for end user to stop application
        Console.WriteLine("Empty input detected - stopping application...");
        break;
    } catch (FormatException) {
        Console.WriteLine("\nPlease provide a file name of the '.txt' format (leave empty to quit):");
    } catch (FileNotFoundException) {
        Console.WriteLine("\nThe file name entered does not exist, please try again (leave empty to quit):");
    }
} while (!fileIsValid);

void testFileName(string? file) {
    if (String.IsNullOrEmpty(file)) {
        // Given input is empty
        throw new ArgumentNullException();
    }

    if (!file.EndsWith(".txt")) {
        // Given input is wrong file format
        throw new FormatException();
    }

    if (!File.Exists(file)) {
        // Given input does not exist on file system
        throw new FileNotFoundException();
    }
}