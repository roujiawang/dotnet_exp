## NoteTakingApp README

### Overview
The **NoteTakingApp** is a simple console-based **C#** application that allows users to create, format, and save notes to a text file and a JSON file. The application prompts the user to enter a title, tag, relevant link, and optional author name for each note. Users can then input bullet points line by line until they type "exit" or hit `Enter` on an empty line to finish the note-taking session. The note is saved as a text file and a JSON file in the "output" folder under the current directory.

### Features
- **Note Creation**: Input a title, tag, and link to create a structured note.
- **Bullet Points**: Add multiple bullet points to the note.
- **Automatic File Saving Upon Completion**: The note is saved in a formatted text file upon completion.
- **Customizable Author and Date**: Each note automatically includes the default author's name and the creation date.

### Output Format
The note is saved as a `.txt` file in the following format:
```
Title: <TITLE>
Tag:   <TAG>
Link:  <LINK>
Author:<AUTHOR>
Date:  <DATE>
Notes:
- <ITEM>
- <ITEM>
```
A corresponding JSON file is also saved.

### Usage
1. Run the application from the console.
2. Enter the title, tag, link, and optionally author name when prompted.
3. Enter each bullet point for the note.
4. Type "exit" or press Enter on an empty line to finish.
5. The note is automatically saved in the "output" folder.

### Future Enhancements (TBD)
- **Auto-Save Feature**: Periodically save notes to prevent data loss in case of unexpected termination.
- **Signal Handling**: Capture `Ctrl+C` to save progress before exiting.

### Useful Linux commands:
```
dotnet new classlib -o <library>
```
```
dotnet new console -o <app>
dotnet add reference ../<library>/<library>.csproj
```
```
dotnet build
dotnet run
```
