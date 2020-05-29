using System;
using System.Net.Http;

namespace AqualityTracking.Integrations.Core
{
    public interface IHttpClient
    {
        /// <summary>
        /// Sends GET request to specified uri.
        /// </summary>
        /// <typeparam name="TResponse">Type of the response data.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <returns>Response data.</returns>
        TResponse SendGET<TResponse>(Uri requestUri);

        /// <summary>
        /// Sends POST request to specified uri.
        /// </summary>
        /// <typeparam name="TModel">Type of the response/request body data.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="body">Request body which converts to string.</param>
        /// <returns>Response data.</returns>
        TModel SendPOST<TModel>(Uri requestUri, TModel body);

        /// <summary>
        /// Sends POST request to specified uri.
        /// </summary>
        /// <typeparam name="TResponse">Type of the response data.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Request entity.</param>
        /// <returns>Response data.</returns>
        TResponse SendPOST<TResponse>(Uri requestUri, HttpContent content);
    }
}
