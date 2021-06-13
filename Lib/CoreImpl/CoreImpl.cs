using System;
using System.Net.Http;
using System.Threading.Tasks;
using Giphy.Libs.Models;
using Lib.Interfaces;
using Lib.Models;
using System.Text.Json;

namespace Lib.CoreImpl
{
    public class GiphySearchImpl : IGiphySearchEngine
    {
        IGiphySearchSetup _searchSetup;

        public GiphySearchImpl(IGiphySearchSetup searchSetup)
        {
            _searchSetup = searchSetup;
        }

        public async Task<GiphySearchModel> FetchByCritirea(string searchCriterion)
        {
            using var client = new HttpClient();

            var url = new Uri($"{_searchSetup.GiphyApiUrl}/gifs/search?api_key={_searchSetup.ApiKey}&q={searchCriterion}&rating={_searchSetup.Rating}&limit={_searchSetup.SearchResultsLimit}");

            string respJson;
            var response = await client.GetAsync(url);
            using (var content = response.Content)
            {
                respJson = await content.ReadAsStringAsync();
            }

            return JsonSerializer.Deserialize<GiphySearchModel>(respJson);
        }

        public async Task<GiphySearchModel> FetchByTrending()
        {
            using var client = new HttpClient();
            var url = new Uri($"{_searchSetup.GiphyApiUrl}/gifs/trending?api_key={_searchSetup.ApiKey}&rating={_searchSetup.Rating}&limit={_searchSetup.SearchResultsLimit}");

            string respJson;
            var response = await client.GetAsync(url);
            using (var content = response.Content)
            {
                respJson = await content.ReadAsStringAsync();
            }

            return JsonSerializer.Deserialize<GiphySearchModel>(respJson);
        }
    }
}