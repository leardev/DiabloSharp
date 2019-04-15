using System;
using RestSharp;

namespace DiabloSharp.Extensions
{
    internal static class RestResponseExtensions
    {
        public static void EnsureSuccess(this IRestResponse response)
        {
            if (response.IsSuccessful)
                return;

            if (!string.IsNullOrEmpty(response.ErrorMessage))
                throw new Exception(response.ErrorMessage);
            if (!string.IsNullOrEmpty(response.StatusDescription))
                throw new Exception(response.StatusDescription);
        }
    }
}