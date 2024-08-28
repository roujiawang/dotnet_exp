using System;
using System.Collections.Generic;  // to use List<T>
using System.Text.Json;  // for notes output in JSON format

namespace NoteLibrary
{
    public class Note
    {
        public string Title { get; set; } = "Note";
        public string Tag { get; set; } = "Tech";
        public string Link { get; set; } = "N/A";
        public string Author { get; set; } = "Jack Wang";  // Default author name
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public List<string> BulletPoints { get; set; } = new List<string>();

        public string GetFormattedContent()
        {
            string result = "Title : " + Title + "\n" +
                    "Tag   : " + Tag + "\n" +
                    "Link  : " + Link + "\n" +
                    "Author: " + Author + "\n" +
                    "Date  : " + DateCreated.ToShortDateString() + "\n" +
                    "Notes :\n" +
                    string.Join("\n", BulletPoints.Select(item => "- " + item));
                    
            return result;
        }

        public string GetJsonContent()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
