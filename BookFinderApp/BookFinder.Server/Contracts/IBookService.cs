using BookFinder.Server.Models.Responses;
using BookFinder.Server.Models.Books;

namespace BookFinder.Server.Contracts
{
    public interface IBookService
    {
        Task<SingleResponse<BookDetails>> GetByIdAsync(HttpClient httpClient, string apiKey, string volumeId);
        Task<SingleResponse<BookList>> GetByQueryAsync(HttpClient httpClient, string apiKey, string queryValue);
    }
}
