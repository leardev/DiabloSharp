using System;
using System.Net;
using System.Text;

namespace DiabloSharp.Exceptions
{
    public class DiabloApiHttpException : DiabloApiException
    {
        public DiabloApiHttpException(string requestUri, HttpStatusCode statusCode, string content)
            : base(GetExceptionMessage(requestUri, statusCode, content))
        {
        }

        private static string GetExceptionMessage(string requestUri, HttpStatusCode statusCode, string content)
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.Append($"An HTTP error occured while requesting on {requestUri}.");
            messageBuilder.Append($"{Environment.NewLine}HTTP Status Code: {statusCode}");
            if (!string.IsNullOrEmpty(content))
                messageBuilder.Append($"{Environment.NewLine}Response content: {content}");

            return messageBuilder.ToString();
        }
    }
}