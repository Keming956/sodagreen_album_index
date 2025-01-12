namespace SodagreenSongs;

public class SaveTxtCommand : Command
{
    public override void Execute(SongManager manager)
    {
        Console.WriteLine(manager.Translate("Enter the TXT filename:", "输入TXT文件名："));
        string filename = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(filename))
        {
            PrintError(manager.Translate("Filename cannot be empty.", "文件名不能为空。"));
            return;
        }

        try
        {
            var lines = manager.Songs.Select(song =>
                manager.Translate($"Album: {song.Album_title}, Order: {song.Order_in_album}, Title: {song.Title}, Duration: {song.Duration}, Lyricist: {song.Lyricist}, Composer: {song.Composer}", $"专辑：{song.Album_title}，曲序：{song.Order_in_album}，歌曲名：{song.Title}，时长：{song.Duration}，作词人：{song.Lyricist}，作曲人：{song.Composer}"));
            File.WriteAllLines(filename, lines);
            Console.WriteLine(manager.Translate($"Saved {manager.Songs.Count} songs to {filename}.",
             $"已保存{manager.Songs.Count}首歌曲到{filename}。"));
        }

        catch (Exception ex)
        {
            PrintError(manager.Translate($"Error saving TXT file: {ex.Message}",
            $"保存TXT文件时出错：{ex.Message}"));
        }
    }
}