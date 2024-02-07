using BookFinder.Server.Models;
using BookFinder.Server.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BookFinder.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Adding the custom created class that will pass down our API key.
        // It has been populated in Program.cs by configuring it.
        // The API key value is in appsettings.json - a file that has been added to .gitignore.
        private readonly GoogleBookApiSettings _googleBooksApi;
        private readonly HttpClient _httpClient;

        // TODO: Read about the details below in multiple places. It's good to confirm the validity of what you've read ;)

        // We use IOptions in order to assure separation of concerns.
        // Achieved by keeping configuration details in a dedicated class (GoogleBookApiSettings in this case).
        // Has reload support - allows us to reload our configuration data without restarting the app.

        // We use IHttpClientFactory in order to manage the HttpClient lifecycle more efficiently.
        // It reuses and manages a pool of HttpClient instances.
        // It allows us to configure and customize HttpClient instances (important when using external APIs).
        // Supports named clients, allowing us to easily switch between HttpClient instances with different settings
        public BooksController(IOptions<GoogleBookApiSettings> googleBooksApi, IHttpClientFactory httpClientFactory)
        {
            _googleBooksApi = googleBooksApi.Value;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("{volumeId}")]
        public async Task<IActionResult> GetBookDetails(string volumeId)
        {
            try
            {
                string apiKey = _googleBooksApi.ApiKey;
                string apiUrl = $"https://www.googleapis.com/books/v1/volumes/{volumeId}?key={apiKey}";

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var bookDetails = await response.Content.ReadFromJsonAsync<BookDetails>();
                    return Ok(bookDetails);
                }
                else
                {
                    var errorDetails = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    return StatusCode((int)response.StatusCode, errorDetails);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error", Error = ex.Message });
            }
        }
    }
}
