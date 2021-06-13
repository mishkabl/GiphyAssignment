using Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces
{
    public interface IGiphySearchService
    {
        Task<GiphySearchModel> SearchByCritirea(string searchCriterion);
        Task<GiphySearchModel> SearchByTrending();
    }
}
