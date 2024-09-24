using System;
using System.IO;
using NoteLibrary;

class Program
{
    static Note note = new Note();
    static string outputDir = "output";

    static void Main(string[] args)
    {
        // Setup signal handling for accidental CTRL+C
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true; // Prevent immediate termination
            SaveNote();
            Environment.Exit(0); // Exit after saving
        };

        AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
        {
            SaveNote();
        };

        Console.WriteLine("Taking Notes!");

        // Initialize a new note with default values specified in the Note class
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

        while (true) // Continuous input until the user exits
        {
            input = Console.ReadLine() ?? string.Empty;

            // Stop recording bullet points if the user types "exit" or hits Enter without inputting anything
            if (input == string.Empty || input.ToLower() == "exit")
            {
                break;
            }

            note.BulletPoints.Add(input);
        }

        // Save note as formatted text and JSON at the end of input
        SaveNoteToFile(note.GetFormattedContent(), $"{note.Title.Replace(" ", "_")}.txt");
        SaveNoteToFile(note.GetJsonContent(), $"{note.Title.Replace(" ", "_")}.json");
    }

    static void SaveNote()
    {
        if (!string.IsNullOrEmpty(note.Title) || 
            !string.IsNullOrEmpty(note.Tag) || 
            !string.IsNullOrEmpty(note.Link) || 
            note.BulletPoints.Count > 0)
        {
            Console.WriteLine("Auto-saving your note...");
            SaveNoteToFile(note.GetFormattedContent(), $"{note.Title.Replace(" ", "_")}.txt");
            SaveNoteToFile(note.GetJsonContent(), $"{note.Title.Replace(" ", "_")}.json");
            Console.WriteLine("Note saved.");
        }
        else
        {
            Console.WriteLine("No note content to save.");
        }
    }

    static void SaveNoteToFile(string content, string fileName)
    {
        Directory.CreateDirectory(outputDir);  // Create the output folder if it doesn't exist
        string filePath = Path.Combine(outputDir, fileName);
        File.WriteAllText(filePath, content);
        Console.WriteLine($"Note saved to {filePath}");
    }
}
