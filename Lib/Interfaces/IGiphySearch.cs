using Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces
{
    public interface IGiphySearchEngine
    {
        Task<GiphySearchModel> FetchByCritirea(string searchCriterion);
        Task<GiphySearchModel> FetchByTrending();
    }
}
