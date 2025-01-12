namespace SodagreenSongs;

public class SongManager
{

    public List<Song> Songs { get; set; } = new List<Song>();
    public string Language { get; set; } = "en"; // Default language is English

    public void ChangeLanguage()
    {
        Console.WriteLine(Language == "zh" ? "请输入语言 (en 或 zh):" : "Enter language (en or zh):");
        string lang = Console.ReadLine()?.ToLower() ?? string.Empty;
        if (lang == "en" || lang == "zh")
        {
            Language = lang;
            Console.WriteLine(Language == "zh" ? "语言已切换到中文" : "Language switched to English");
        }
        else
        {
            Console.WriteLine(Language == "zh" ? "无效的语言选择" : "Invalid language selection");
        }
    }

    public string Translate(string enMessage, string zhMessage)
    {
        return Language == "zh" ? zhMessage : enMessage;
    }



    public bool HandleCommand()
    {
        Console.WriteLine(Translate("Choose a command (help, 切换语言, addsong, loadjson, savejson, loadcsv, savetxt, list, search, webscrape, exit):",
                                     "选择命令 (帮助, changelang, 添加歌曲, 加载JSON, 保存JSON, 加载CSV, 保存TXT, 列出歌曲, 搜索, 网页抓取, 退出):"));
        string mainCommand = Console.ReadLine()?.ToLower() ?? string.Empty;

        if (mainCommand == "exit" || mainCommand == "退出")
        {
            Console.WriteLine(Translate("Exiting program.", "程序已退出。"));
            return false;
        }

        if (mainCommand == "changelang" || mainCommand == "切换语言")
        {
            ChangeLanguage();
            return true;
        }

        Command cmd;
        switch (mainCommand)
        {
            case "help":
            case "帮助":
                cmd = new HelpCommand();
                break;

            case "loadjson":
            case "加载json":
                cmd = new LoadJsonCommand();
                break;

            case "savejson":
            case "保存json":
                cmd = new SaveJsonCommand();
                break;

            case "list":
            case "列出歌曲":
                cmd = new ListCommand();
                break;

            case "search":
            case "搜索":
                cmd = new SearchCommand();
                break;

            case "loadcsv":
            case "加载csv":
                cmd = new LoadCsvCommand();
                break;

            case "addsong":
            case "添加歌曲":
                cmd = new AddSongCommand();
                break;

            case "savetxt":
            case "保存txt":
                cmd = new SaveTxtCommand();
                break;

            case "webscrape":
            case "网页抓取":
                cmd = new WebScrapCommand();
                break;

            default:
                throw new InvalidCommandException(
                    Translate($"'{mainCommand}' is not a valid command. Type 'help' for the list of commands.",
                             $"'{mainCommand}' 不是有效的命令。输入 '帮助' 查看命令列表。"));
        }

        try
        {
            cmd.Execute(this);
        }
        catch (Exception ex)
        {
            Console.WriteLine(Translate($"An error occurred: {ex.Message}", $"发生错误：{ex.Message}"));
        }
        return true;
    }

}