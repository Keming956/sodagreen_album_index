namespace SodagreenSongs;

public class AddSongCommand : Command
{
    public override void Execute(SongManager manager)
    {
        Console.WriteLine(manager.Translate("Enter Album Title:", "输入专辑名："));
        string albumTitle = Console.ReadLine() ?? string.Empty;

        Console.WriteLine(manager.Translate("Enter Order in Album:", "输入曲序："));
        if (!int.TryParse(Console.ReadLine(), out var order))
        {
            Console.WriteLine(manager.Translate("Invalid order. Using 0 as default.", "曲序无效。默认使用0。"));
            order = 0;
        }

        Console.WriteLine(manager.Translate("Enter Title:", "输入歌曲名："));
        string title = Console.ReadLine() ?? string.Empty;

        Console.WriteLine(manager.Translate("Enter Duration (format mm:ss):", "输入时长 (格式 mm:ss)："));
        string duration = Console.ReadLine() ?? string.Empty;
        if (!TimeSpan.TryParseExact(duration, @"m\:ss", null, out _))
        {
            Console.WriteLine(manager.Translate("Invalid duration format. Please use mm:ss.",
            "时长格式无效。请使用 mm:ss。"));
            return;
        }


        Console.WriteLine(manager.Translate("Enter Lyricist:", "输入作词人："));
        string lyricist = Console.ReadLine() ?? string.Empty;

        Console.WriteLine(manager.Translate("Enter Composer:", "输入作曲人："));
        string composer = Console.ReadLine() ?? string.Empty;

        var newSong = new Song
        {
            Album_title = albumTitle,
            Order_in_album = order,
            Title = title,
            Duration = duration,
            Lyricist = lyricist,
            Composer = composer
        };

        manager.Songs.Add(newSong);
        Console.WriteLine(manager.Translate("Song added successfully.", "歌曲已成功添加。"));
    }
}