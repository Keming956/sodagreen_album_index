using HtmlAgilityPack;

namespace SodagreenSongs;

public class WebScrapCommand : Command
{
    public override void Execute(SongManager manager)
    {
        Console.WriteLine(manager.Translate(
            "Scraping song information from web...",
            "正在从网页抓取歌曲信息..."
        ));

        try
        {
            var web = new HtmlWeb();
            var doc = web.Load("https://zh.wikipedia.org/zh-cn/蘇打綠_(專輯)");

            // 修改选择器以匹配新表格结构
            var songNodes = doc.DocumentNode.SelectNodes("//table[@class='tracklist']//tr[position()>1 and not(contains(@class, 'tracklist-total-length'))]");
            
            if (songNodes != null)
            {
                string currentAlbum = "苏打绿"; // 默认专辑名称
                
                foreach (var node in songNodes)
                {
                    var columns = node.SelectNodes("td");
                    if (columns?.Count >= 3)
                    {
                        var orderText = columns[0].InnerText.Trim().TrimEnd('.');
                        var titleText = columns[1].InnerText.Trim();
                        var durationText = columns[2].InnerText.Trim();
                        
                        // 处理可能包含作者信息的标题
                        string title = titleText;
                        string lyricist = "";
                        string composer = "";
                        
                        if (titleText.Contains("（词曲："))
                        {
                            var parts = titleText.Split(new[] { "（词曲：" }, StringSplitOptions.None);
                            title = parts[0].Trim();
                            if (parts.Length > 1)
                            {
                                lyricist = composer = parts[1].TrimEnd('）').Trim();
                            }
                        }

                        var song = new Song
                        {
                            Album_title = currentAlbum,
                            Order_in_album = int.TryParse(orderText, out var order) ? order : 0,
                            Title = title,
                            Duration = durationText,
                            Lyricist = lyricist,
                            Composer = composer
                        };
                        
                        manager.Songs.Add(song);
                    }
                }
                
                Console.WriteLine(manager.Translate(
                    $"Successfully scraped {manager.Songs.Count} songs.",
                    $"成功抓取了 {manager.Songs.Count} 首歌曲。"
                ));
            }
        }
        catch (Exception ex)
        {
            PrintError(manager.Translate(
                $"Error scraping web: {ex.Message}",
                $"网页抓取出错：{ex.Message}"
            ));
        }
    }
}