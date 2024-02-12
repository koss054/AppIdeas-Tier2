using BookFinder.Server.Consts;
using BookFinder.Server.Contracts;
using BookFinder.Server.Models;
using BookFinder.Server.Models.Books;
using BookFinder.Server.Models.Responses;
using Newtonsoft.Json;

namespace BookFinder.Server.Services
{
    public class BookService : IBookService
    {
        public async Task<SingleResponse<BookDetails>> GetByIdAsync(HttpClient httpClient, string apiKey, string volumeId)
        {
            var apiUrl = $"{BookServiceConsts.GoogleBooksApiUrl}volumes/{volumeId}";
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var bookDetails = await response.Content.ReadFromJsonAsync<BookDetails>();
                return new SingleResponse<BookDetails>(bookDetails);
            }
            else
            {
                var errorDetails = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                return new SingleResponse<BookDetails>(errorDetails, (int)response.StatusCode);
            }
        }

        public async Task<SingleResponse<BookList>> GetByQueryAsync(HttpClient httpClient, string apiKey, string queryValue)
        {
            var apiUrl = $"{BookServiceConsts.GoogleBooksApiUrl}volumes?q={queryValue}";
            var response = await httpClient.GetStringAsync(apiUrl);
            var bookDetails = JsonConvert.DeserializeObject<BookList>(response);

            return new SingleResponse<BookList>(bookDetails);
        }
    }
}
