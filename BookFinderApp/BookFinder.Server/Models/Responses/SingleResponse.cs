namespace BookFinder.Server.Models.Responses
{
    public class SingleResponse<T> where T : class 
    {
        public SingleResponse(T? entity)
        {
            if (entity != null)
            {
                this.Entity = entity;
            }

            this.IsSuccessful = true;
        }

        public SingleResponse(ErrorResponse? error, int errorCode)
        {
            if (error != null)
            {
                this.Error = error;
            }

            this.ErrorCode = errorCode;
            this.IsSuccessful = false;
        }

        public T? Entity { get; set; } 

        public bool IsSuccessful { get; set; }

        public ErrorResponse? Error { get; set; }

        public int ErrorCode { get; set; }
    }
}
