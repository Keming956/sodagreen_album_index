namespace SodagreenSongs;


public class HelpCommand : Command
{
    public override void Execute(SongManager manager)
    {
        Console.WriteLine(manager.Translate("Available commands:", "可用的命令："));
        Console.WriteLine(manager.Translate("- help: Display this help message.", "- 帮助: 显示此帮助信息。"));
        Console.WriteLine(manager.Translate("- loadjson: Load songs from a JSON file.", "- 加载JSON: 从JSON文件加载歌曲。"));
        Console.WriteLine(manager.Translate("- savejson: Save current songs to a JSON file.", "- 保存JSON: 将当前歌曲保存到JSON文件。"));
        Console.WriteLine(manager.Translate("- loadcsv: Load songs from a CSV file.", "- 加载CSV: 从CSV文件加载歌曲。"));
        Console.WriteLine(manager.Translate("- savecsv: Save current songs to a CSV file.", "- 保存CSV: 将当前歌曲保存到CSV文件。"));
        Console.WriteLine(manager.Translate("- list: List all songs.", "- 列出: 列出所有歌曲。"));
        Console.WriteLine(manager.Translate("- search: Search songs by criteria.", "- 搜索: 按条件搜索歌曲。"));
        Console.WriteLine(manager.Translate("- webscrape: Scrape songs from web.", "- 网页抓取: 从网页抓取歌曲。"));
        Console.WriteLine(manager.Translate("- exit: Exit the program.", "- 退出: 退出程序。"));
    }
}