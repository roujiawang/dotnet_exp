using System;
using System.IO;
using NoteLibrary;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Taking Notes!");

        // initialize a new note with default values specified in the Note class
        Note note = new Note();

        Console.Write($"Please enter note title (default: {note.Title}): ");
        string title = Console.ReadLine() ?? string.Empty;  // avoid assigning null to title
        if (!string.IsNullOrEmpty(title))
        {
            note.Title = title;
        }

        Console.Write($"Please enter note tag (default: {note.Tag}): ");
        string tag = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrEmpty(tag))
        {
            note.Tag = tag;
        }

        Console.Write($"Please enter relevant link (optional, default: {note.Link}): ");
        string link = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrEmpty(link))
        {
            note.Link = link;
        }

        Console.WriteLine("Enter bullet points (type 'exit' or nothing on a new line to finish):");

        string input;

        while (true)
        {
            input = Console.ReadLine() ?? string.Empty;

            // stop recording bullet points if the user types "exit" or hits Enter without inputting anything
            if (input == string.Empty || input.ToLower() == "exit")
            {
                break;
            }

            note.BulletPoints.Add(input);
        }

        string outputDir = "output";
        Directory.CreateDirectory(outputDir);  // create the output folder if not exist

        // save note as formatted text
        string fileName = Path.Combine(outputDir, $"{note.Title.Replace(" ", "_")}.txt");
        File.WriteAllText(fileName, note.GetFormattedContent());
        Console.WriteLine($"Note saved to {fileName}");

        // save note as JSON
        string jsonFileName = Path.Combine(outputDir, $"{note.Title.Replace(" ", "_")}.json");
        File.WriteAllText(jsonFileName, note.GetJsonContent());
        Console.WriteLine($"Note saved as JSON to {jsonFileName}");
    }
}
