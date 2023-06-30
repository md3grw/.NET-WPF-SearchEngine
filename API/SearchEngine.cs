using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Navigation;

namespace SearchEngine.API
{
    internal class SearchEngine
    {
        private Frame contentFrame;
        private DataAPI dataAPI;

        public SearchEngine(Frame contentFrame)
        {
            dataAPI = new DataAPI();

            this.contentFrame = contentFrame;
        }

        public LinksStorage Search(string query)
        {
            try { return dataAPI.getDataFromAPI(query); }
            catch { return new LinksStorage(); }
        }

        public SearchPage ExecuteSearch(string query)
        {
            LinksStorage links = Search(query);

            SearchPage searchPage = new SearchPage();

            ScrollViewer scrollViewer = new ScrollViewer();
            StackPanel stackPanel = new StackPanel();

            scrollViewer.Content = stackPanel;
            searchPage.Content = scrollViewer;

            foreach (LinkData link in links)
            {
                TextBlock linkTextBlock = new TextBlock();
                linkTextBlock.Tag = link.Url;
                linkTextBlock.FontSize = 24;
                
                linkTextBlock.Text = $"{link.Url}\n{link.Title}\n{link.Description}\n";

                linkTextBlock.MouseLeftButtonDown += LinkTextBlock_MouseLeftButtonDown;

                stackPanel.Children.Add(linkTextBlock);
            }

            return searchPage;
        }

        private void LinkTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock clickedTextBlock = (TextBlock)sender;
            string url = clickedTextBlock.Tag.ToString();

            WebBrowser webBrowser = new WebBrowser();
            webBrowser.LoadCompleted += this.WebBrowser_LoadCompleted;

            webBrowser.Navigate(url);

            contentFrame.Navigate(webBrowser);
        }

        public void WebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            dynamic activeX = webBrowser.GetType().InvokeMember("ActiveXInstance",
                BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, webBrowser, new object[] { });

            activeX.Silent = true;
        }

    }
}
