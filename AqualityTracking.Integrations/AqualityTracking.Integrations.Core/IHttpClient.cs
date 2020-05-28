using System;
using System.Net.Http;

namespace AqualityTracking.Integrations.Core
{
    public interface IHttpClient
    {
        TResponse SendGET<TResponse>(Uri requestUri);

        TModel SendPOST<TModel>(Uri requestUri, TModel body);

        TResponse SendPOST<TResponse>(Uri requestUri, HttpContent content);
    }
}
