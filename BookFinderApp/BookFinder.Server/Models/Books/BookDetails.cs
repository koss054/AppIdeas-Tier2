namespace BookFinder.Server.Models.Books
{
    public class BookDetails
    {
        public string? Id { get; set; }
        public string? Etag { get; set; }
        public string? SelfLink { get; set; }
        public VolumeInfo VolumeInfo { get; set; } = new();
        public SearchInfo SearchInfo { get; set; } = new();
    }
}
