using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using static Google.Apis.Requests.BatchRequest;

namespace SearchEngine.API
{
    class DataAPI
    {
        readonly string apiKey;
        readonly string searchEngineId;

        public DataAPI()
        {
            Config config = new Config();

            apiKey = config.apiKey;
            searchEngineId = config.searchEngineID;
        }

        public LinksStorage getDataFromAPI(string query)
        {
            var customSearch = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            
            var customSearchList = customSearch.Cse.List();
            customSearchList.Q = query;

            customSearchList.Cx = searchEngineId;
            var searchResult = customSearchList.Execute();

            LinksStorage links = new LinksStorage();

            foreach ( var item in searchResult.Items ) 
            {
                LinkData linkData = new LinkData();
                linkData.Title = item.Title;
                linkData.Url = item.Link;
                linkData.Description = item.Snippet;

                links.Add( linkData );
            }

            return links;
        }

    }
}
