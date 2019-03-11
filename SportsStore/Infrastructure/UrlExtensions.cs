﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Infrastructure
{
    public static class UrlExtensions
    {
        /// <summary>
        /// Generates a URL that the browser will be returned to after
        /// the cart has been updated, taking into account the query string if there is one.
        /// </summary>
        /// <param name="request">Uses Httprequest as parameter, being
        ///  a extension method.</param>
        /// <returns>
        /// Returns the URL after the cart being updated.
        /// </returns>
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
            ? $"{request.Path}{request.QueryString}"
            : request.Path.ToString();
    }
}
