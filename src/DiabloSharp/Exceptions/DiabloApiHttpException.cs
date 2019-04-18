namespace DiabloSharp.Exceptions
{
    public class DiabloApiHttpException : DiabloApiException
    {
        public int StatusCode { get; internal set; }

        public string Content { get; internal set; }

        public DiabloApiHttpException(string message) : base(message)
        {
        }
    }
}
