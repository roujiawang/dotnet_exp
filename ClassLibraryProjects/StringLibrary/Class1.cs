namespace UtilityLibraries;

public static class StringLibrary
{
    // extension method for the string class;
    // checks if a string starts with an uppercase letter
    public static bool StartsWithUpper(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return false;
        
        char ch = str[0];
        return char.IsUpper(ch);
    }
}
