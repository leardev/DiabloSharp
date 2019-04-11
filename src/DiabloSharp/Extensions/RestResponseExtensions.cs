using System;
using RestSharp;

namespace DiabloSharp.Extensions
{
    internal static class RestResponseExtensions
    {
        public static void EnsureSuccess(this IRestResponse response)
        {
            if (!response.IsSuccessful)
                throw new Exception(response.ErrorMessage);
        }
    }
}