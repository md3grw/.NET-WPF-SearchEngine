using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SearchEngine.API
{
    class LinksStorage : IEnumerable<LinkData>
    {
        private List<LinkData> links;
        
        public LinksStorage(List<LinkData> links)
        {
            this.links = links;
        }

        public LinksStorage() 
        {
            links = new List<LinkData>();
        }

        public void Add(LinkData link)
        {
            links.Add(link);
        }

        public IEnumerator<LinkData> GetEnumerator()
        {
            return links.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    class LinkData
    {
        private string title;
        private string description;
        private string url;

        public string Title {get; set; }
        public string Description {get; set; }
        public string Url { get; set; }
    }
}
