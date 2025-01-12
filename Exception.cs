namespace SodagreenSongs;

public class InvalidCommandException : Exception
{
    public InvalidCommandException(string message) : base(message) { }
}

public class InvalidFileFormatException : Exception
{
    public InvalidFileFormatException(string message) : base(message) { }
}

public abstract class Command
{
    public abstract void Execute(SongManager manager);

    protected void PrintError(string message)
    {
        Console.WriteLine($"Error: {message}");
    }
}