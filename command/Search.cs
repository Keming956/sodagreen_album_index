namespace SodagreenSongs;


public enum SearchCriteria
{
    Title,
    Album,
    Lyricist,
    Composer
}

public class SearchCommand : Command
{
    private SearchCriteria ParseSearchCriteria(string input, SongManager manager)
    {
        string loweredInput = input.ToLower();
        switch (loweredInput)
        {
            case "title":
            case "歌曲名":
                return SearchCriteria.Title;

            case "album":
            case "专辑名":
                return SearchCriteria.Album;

            case "lyricist":
            case "作词人":
                return SearchCriteria.Lyricist;

            case "composer":
            case "作曲人":
                return SearchCriteria.Composer;

            default:
                throw new InvalidCommandException(manager.Translate("Invalid search criteria",
                 "无效的搜索条件"));
        }
    }

    public override void Execute(SongManager manager)
    {
        Console.WriteLine(manager.Translate(
            "Choose a search criteria (title, album, lyricist, composer):",
            "选择搜索条件 (歌曲名，专辑名，作词人，作曲人):"
        ));

        string userInput = Console.ReadLine()?.ToLower() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(userInput))
        {
            PrintError(manager.Translate(
                "Search criteria cannot be empty.",
                "搜索条件不能为空。"
            ));
            return;
        }

        SearchCriteria criteria;
        try
        {
            criteria = ParseSearchCriteria(userInput, manager);
        }
        catch (InvalidCommandException)
        {
            PrintError(manager.Translate(
                "Invalid criteria. Choose from title, album, lyricist, or composer.",
                "条件无效，请选择歌曲名，专辑名，作词人或作曲人。"
            ));
            return;
        }

        Console.WriteLine(manager.Translate("Enter the search value:", "输入搜索内容："));
        string value = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(value))
        {
            PrintError(manager.Translate(
                "Search value cannot be empty.",
                "搜索内容不能为空。"
            ));
            return;
        }
        
        List<Song> results = new List<Song>();

        switch (criteria)
        {
            case SearchCriteria.Title:
                results = manager.Songs
                    .Where(s => s.Title.Contains(value, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                break;

            case SearchCriteria.Album:
                results = manager.Songs
                    .Where(s => s.Album_title.Contains(value, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                break;

            case SearchCriteria.Lyricist:
                results = manager.Songs
                    .Where(s => s.Lyricist.Contains(value, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                break;

            case SearchCriteria.Composer:
                results = manager.Songs
                    .Where(s => s.Composer.Contains(value, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                break;

            default:
                results = new List<Song>();
                break;
        }

        if (!results.Any())
        {
            Console.WriteLine(manager.Translate(
                "No results found for your search.",
                "未找到符合条件的结果。"
            ));
            return;
        }

        foreach (var song in results)
        {
            Console.WriteLine(manager.Translate(
                $"Title: {song.Title}, Album: {song.Album_title}, Order: {song.Order_in_album}, Duration: {song.Duration}, Lyricist: {song.Lyricist}, Composer: {song.Composer}",
                $"歌曲名：{song.Title}，专辑：{song.Album_title}，曲序：{song.Order_in_album}，时长：{song.Duration}，作词人：{song.Lyricist}，作曲人：{song.Composer}"
            ));
        }
    }
}