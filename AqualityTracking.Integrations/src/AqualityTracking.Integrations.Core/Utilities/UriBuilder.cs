using System;
using System.Collections.Specialized;
using System.Web;

namespace AqualityTracking.Integrations.Core.Utilities
{
    public class UriBuilder
    {
        private System.UriBuilder builder;
        private NameValueCollection queryParams;

        public UriBuilder(string host)
        {
            builder = new System.UriBuilder(host);
            queryParams = HttpUtility.ParseQueryString(builder.Query);
        }

        public Uri Uri
        {
            get
            {
                builder.Query = queryParams.ToString();
                return builder.Uri;
            }
        }

        public UriBuilder SetPath(string value)
        {
            builder.Path = value;
            return this;
        }

        public UriBuilder AddParam<TValue>(string name, TValue value)
        {
            queryParams[name] = value.ToString();
            return this;
        }
    }
}
