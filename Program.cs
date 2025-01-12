namespace SodagreenSongs;


public class Program
{
    public void Run()
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

    public static void Main(string[] args)
    {
        new Program().Run();
    }
}

