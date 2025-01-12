using System.Text.Json;

namespace SodagreenSongs;
public class LoadJsonCommand : Command
{
    public override void Execute(SongManager manager)
    {
        Console.WriteLine(manager.Translate("Enter the JSON filename:", "输入JSON文件名："));
        string filename = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(filename))
        {
            PrintError(manager.Translate("Filename cannot be empty.", "文件名不能为空。"));
            return;
        }

        if (!File.Exists(filename))
        {
            PrintError(manager.Translate("File not found.", "文件未找到。"));
            return;
        }

        try
        {
            var json = File.ReadAllText(filename);
            var songs = JsonSerializer.Deserialize<List<Song>>(json) ?? new List<Song>();
            manager.Songs.AddRange(songs);
            Console.WriteLine(manager.Translate($"Loaded {songs.Count} songs from {filename}.",
                $"从{filename}加载了{songs.Count}首歌曲。"));
        }
        catch (JsonException)
        {
            PrintError(manager.Translate("Invalid JSON format.", "无效的JSON格式。"));
        }
        catch (Exception ex)
        {
            PrintError($"Error loading JSON file: {ex.Message}");
        }
    }
}