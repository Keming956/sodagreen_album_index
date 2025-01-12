namespace SodagreenSongs;

public class Program
{
    public static void Main(string[] args)
    {
        var manager = new SongManager();
        Console.WriteLine("Welcome to SodaGreen Song Index.");
        bool continueRunning = true;
        while (continueRunning)
        {
            try
            {
                continueRunning = manager.HandleCommand();
            }
            catch (InvalidCommandException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

