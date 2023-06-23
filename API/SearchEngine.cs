using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.API
{
    internal class SearchEngine
    {
        private DataAPI dataAPI;

        public SearchEngine()
        {
            dataAPI = new DataAPI();
        }

        public LinksStorage Search(string query)
        {
            try { return dataAPI.getDataFromAPI(query); }
            catch { return new LinksStorage(); }
        }


    }
}
