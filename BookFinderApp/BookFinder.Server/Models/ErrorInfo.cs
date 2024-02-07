namespace BookFinder.Server.Models
{
    public class ErrorInfo
    {
        public int Code { get; set; }
        public required string Message { get; set; }
    }
}
