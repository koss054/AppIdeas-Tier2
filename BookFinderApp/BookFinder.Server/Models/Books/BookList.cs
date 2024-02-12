namespace BookFinder.Server.Models.Books
{
    public class BookList
    {
        public string Kind { get; set; }

        public int TotalItems { get; set; }

        public List<BookDetails> Items { get; set; }
    }
}
