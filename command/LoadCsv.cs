namespace SodagreenSongs;

public class LoadCsvCommand : Command
{
    public override void Execute(SongManager manager)
    {
        Console.WriteLine(manager.Translate("Enter the CSV filename:", "输入CSV文件名："));
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
            var lines = File.ReadAllLines(filename);
            var newSongs = new List<Song>();

            foreach (var line in lines.Skip(1)) // Skip header line
            {
                var parts = line.Split(',');
                if (parts.Length < 6)
                {
                    throw new InvalidFileFormatException(manager.Translate($"Invalid line format: {line}",
                     "格式错误：{line}"));
                }

                newSongs.Add(new Song
                {
                    Album_title = parts[0].Trim(),
                    Order_in_album = int.TryParse(parts[1], out var order) ? order : 0,
                    Title = parts[2].Trim(),
                    Duration = parts[3].Trim(),
                    Lyricist = parts.Length > 4 ? parts[4].Trim() : string.Empty,
                    Composer = parts.Length > 5 ? parts[5].Trim() : string.Empty
                });
            }

            manager.Songs.AddRange(newSongs);
            Console.WriteLine(manager.Translate($"Loaded {newSongs.Count} songs from {filename}.",
             "从{filename}加载了{newSongs.Count}首歌曲。"));
        }
        catch (InvalidFileFormatException ex)
        {
            PrintError(manager.Translate($"Error: {ex.Message}", "错误：{ex.Message}"));
        }
        catch (Exception ex)
        {
            PrintError(manager.Translate($"Error loading CSV file: {ex.Message}",
             "加载CSV文件时出错：{ex.Message}"));
        }
    }
}