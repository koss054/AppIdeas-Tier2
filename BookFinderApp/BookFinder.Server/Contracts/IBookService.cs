using BookFinder.Server.Models.Responses;
using BookFinder.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookFinder.Server.Contracts
{
    public interface IBookService
    {
        Task<SingleResponse<BookDetails>> GetByIdAsync(HttpClient httpClient, string apiKey, string volumeId);
        Task<IActionResult> GetByQueryAsync(HttpClient httpClient, string apiKey, string queryValue);
    }
}
