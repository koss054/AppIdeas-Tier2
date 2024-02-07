using System.ComponentModel;

namespace BookFinder.Server.Models
{
    public class ErrorResponse
    {
        public required ErrorInfo Error { get; set; }
    }
}
