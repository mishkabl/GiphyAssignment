using Lib.Interfaces;
using Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class GiphySearchService : IGiphySearchService
    {
        private static IGiphySearchEngine _infGiphySearch;

        public GiphySearchService(IGiphySearchEngine infGiphySearch)
        {
            _infGiphySearch = infGiphySearch;
        }

        public async Task<GiphySearchModel> SearchByCritirea(string searchCriterion)
        {
            return await _infGiphySearch.FetchByCritirea(searchCriterion);
        }

        public async Task<GiphySearchModel> SearchByTrending()
        {
            return await _infGiphySearch.FetchByTrending();
        }
    }
}
