using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using DiscordRest.Data;
using DiscordRest.Extensions;
using DiscordRest.Models;
using Microsoft.Extensions.Logging;

namespace DiscordRest
{
    public class DiscordHttp 
    {
        private bool _unauthorized = false;
        private bool _renewAttempted = false;

        private readonly ITokenStore _tokenStore;
        private readonly ILogger _logger;

        /// <summary>
        /// Utility for running the HTTP requests
        /// </summary>
        /// <param name="tokenStore"></param>
        /// <param name="logger"></param>
        public DiscordHttp(ITokenStore tokenStore, ILogger logger)
        {
            //TODO: Add injection for configuration for HttpClient
            _tokenStore = tokenStore;
            _logger = logger;
        }

        public T Run<T>(string url) where T : class, IDiscordDataObject
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));

            _logger.LogDebug($"Running request against {url}");

            throw new NotImplementedException();     
        }

        public T RunAsync<T>(string url) where T : class, IDiscordDataObject
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));

            _logger.LogDebug($"Running request against {url}");
            //_client.BaseAddress = new Uri);
            throw new NotImplementedException();
        }

        public ServiceResult Run(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));

            _logger.LogDebug($"Running request against {url}");
            throw new NotImplementedException();
        }

        public ServiceResult RunAsync(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));

            _logger.LogDebug($"Running request against {url}");
            throw new NotImplementedException();
        }
    }
}