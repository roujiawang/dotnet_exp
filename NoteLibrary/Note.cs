using System;
using System.Collections.Generic;  // to use List<T>
using System.Text.Json;  // for notes output in JSON format
using System.Text.Json.Serialization;  // includes JSON converter
using System.Text.Encodings.Web;  // manages escape characters
using System.Text.Unicode;  // manages escape characters

namespace NoteLibrary
{
    public class NoteCustomizedConverter : JsonConverter<DateTime>
    {
        private readonly string _format = "yyyy-MM-dd";  // for JSON files, specify time up to day
        private readonly DateTime _defaultDate = new DateTime(1970, 1, 1);  // in case date is null

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? dateString = reader.GetString();
            if (string.IsNullOrEmpty(dateString))
            {
                return _defaultDate;
            }

            return DateTime.ParseExact(dateString, _format, null);
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // use default formatting
            writer.WriteStringValue(value.ToString(_format));
        }
    }

    public class Note
    {
        public string Title { get; set; } = "Note";
        public string Tag { get; set; } = "Tech";
        public string Link { get; set; } = "N/A";
        public string Author { get; set; } = "Jack Wang";  // Default author name

        [JsonConverter(typeof(NoteCustomizedConverter))]
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
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowCharacters('\u0027', '\u0022'); // allow single quotes and double quotes
            encoderSettings.AllowRange(UnicodeRanges.BasicLatin); // allow basic Latin characters

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
        }
    }
}
