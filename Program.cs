using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
logger.Info(scrubbedFile);
MovieFile movieFile = new MovieFile(scrubbedFile);

Console.ForegroundColor = ConsoleColor.Green;
System.Console.WriteLine("Enter 1 to add a movie");
System.Console.WriteLine("Enter 2 to display movies");
System.Console.WriteLine("Enter 3 to search movies");
string readLine = Console.ReadLine();
if(readLine == "1" || readLine == "2")
    {System.Console.WriteLine("This feature has been removed for my convenience.");}
else if(readLine == "3"){
    System.Console.WriteLine("Enter search term:");
    readLine = Console.ReadLine();
    var term = movieFile.Movies.Where(m => m.title.Contains(readLine)).Select(m => m.title);
    foreach(string t in term)
    {
        Console.WriteLine($"{t} matches retrieved.");
    }
    System.Console.WriteLine($"   {term.Count()}");
}

Console.ForegroundColor = ConsoleColor.White;
logger.Info("Program ended");
