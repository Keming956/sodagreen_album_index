namespace SodagreenSongs;

public class ListCommand : Command
{
    public override void Execute(SongManager manager)
    {
        if (!manager.Songs.Any())
        {
            Console.WriteLine(manager.Translate("No songs available.", "没有歌曲。"));
            return;
        }

        foreach (var song in manager.Songs)
        {
            Console.WriteLine(manager.Translate($"Song: {song.DisplayName}, Duration: {song.DurationInMinutes:F2} minutes",
             $"歌曲：{song.DisplayName}，时长：{song.DurationInMinutes:F2}分钟"));
        }
    }
}