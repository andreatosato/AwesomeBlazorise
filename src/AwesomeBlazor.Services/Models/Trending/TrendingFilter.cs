namespace AwesomeBlazor.Services.Models.Trending
{
    public class TrendingFilter
    {
        public string Type { get; set; }
        public string TimeWindow { get; set; }

        public string[] Types { get; set; } = { "all", "movie", "tv", "person" };
        public string[] TimesWindow { get; set; } = { "day", "week" };
    }
}
