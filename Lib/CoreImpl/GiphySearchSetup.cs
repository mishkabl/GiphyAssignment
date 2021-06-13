using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.CoreImpl
{
    public class GiphySearchSetup : IGiphySearchSetup
    {
        readonly string _giphyApiUrl;
        readonly int _searchResultsLimit;
        readonly string _apiKey;
        readonly string _rating;

        public GiphySearchSetup(string apiUrl, string apiKey, string limit, string rating)
        {
            _giphyApiUrl = apiUrl;
            _apiKey = apiKey;
            _rating = rating;
            if (!int.TryParse(limit, out _searchResultsLimit))
                _searchResultsLimit = 100;
        }

        string IGiphySearchSetup.GiphyApiUrl => _giphyApiUrl;

        int IGiphySearchSetup.SearchResultsLimit => _searchResultsLimit;
        string IGiphySearchSetup.Rating => _rating;

        string IGiphySearchSetup.ApiKey => _apiKey;
    }
}
