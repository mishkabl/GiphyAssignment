using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Interfaces
{
    public interface IGiphySearchSetup
    {
        string GiphyApiUrl { get; }
        string ApiKey { get; }
        string Rating { get; }
        int SearchResultsLimit { get; }
    }
}
