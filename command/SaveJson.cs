using System.Text.Json;

namespace SodagreenSongs;
public class SaveJsonCommand : Command
{
    public override void Execute(SongManager manager)
    {
        Console.WriteLine(manager.Translate("Enter the JSON filename:", "输入JSON文件保存路径："));
        string filename = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(filename))
        {
            PrintError(manager.Translate("Filename cannot be empty.", "文件名不能为空。"));
            return;
        }

        try
        {
            var json = JsonSerializer.Serialize(manager.Songs, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
            });
            File.WriteAllText(filename, json);
            Console.WriteLine(manager.Translate($"Saved {manager.Songs.Count} songs to {filename}.",
                $"已保存{manager.Songs.Count}首歌曲到{filename}。"));
        }
        catch (Exception ex)
        {
            PrintError(manager.Translate($"Error saving JSON file: {ex.Message}",
                "保存JSON文件时出错：{ex.Message}"));
        }
    }
}