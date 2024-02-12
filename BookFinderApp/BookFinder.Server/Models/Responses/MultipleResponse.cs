namespace BookFinder.Server.Models.Responses
{
    public class MultipleResponse<T> where T : class 
    {
        public MultipleResponse()
        {
        }

        public MultipleResponse(IEnumerable<T> entities)
        {
            this.Entities = entities;
            this.IsSuccessful = true;
        }

        public MultipleResponse(ErrorResponse? error, int errorCode)
        {
            if (error != null)
            {
                this.Error = error;
            }

            this.ErrorCode = errorCode;
            this.IsSuccessful = false;
        }

        public IEnumerable<T>? Entities { get; set; }

        public bool IsSuccessful { get; set; }

        public ErrorResponse? Error { get; set; }

        public int ErrorCode { get; set; }
    }
}
