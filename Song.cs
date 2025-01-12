namespace SodagreenSongs;

public class Song
{
    public string Album_title { get; set; } = string.Empty;
    public int Order_in_album { get; set; } = 0;
    public string Title { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Lyricist { get; set; } = string.Empty;
    public string Composer { get; set; } = string.Empty;
    // readonly property
    public string DisplayName
    {
        get { return $"{Title} ({Album_title})"; }
    }
    public double DurationInMinutes // calculated property
    {
        get
        {
            if (TimeSpan.TryParseExact(Duration, @"m\:ss", null, out TimeSpan time))
            {
                return time.TotalMinutes;
            }
            return 0;
        }
    }
}