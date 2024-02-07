namespace BookFinder.Server.Models
{
    public class VolumeInfo
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public List<string> Authors { get; set; } = [];
    }
}
