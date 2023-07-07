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
                TextBlock linkTextBlockURL = new TextBlock();
                TextBlock linkTextBlockTitle = new TextBlock();
                TextBlock linkTextBlockDescription = new TextBlock();
                linkTextBlockURL.Tag = link.Url;
                linkTextBlockTitle.Tag = link.Url;
                linkTextBlockURL.FontSize = 16;

                linkTextBlockTitle.FontSize = 28;

                linkTextBlockDescription.FontSize = 18;

                linkTextBlockURL.Text = $"{link.Url}";
                linkTextBlockTitle.Text = $"{link.Title}";
                linkTextBlockDescription.Text = $"{link.Description}\n";

                linkTextBlockURL.MouseLeftButtonDown += LinkTextBlock_MouseLeftButtonDown;
                linkTextBlockTitle.MouseLeftButtonDown += LinkTextBlock_MouseLeftButtonDown;

                stackPanel.Children.Add(linkTextBlockURL);
                stackPanel.Children.Add(linkTextBlockTitle);
                stackPanel.Children.Add(linkTextBlockDescription);
            }

            return searchPage;
        }

        private void LinkTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock clickedTextBlock = (TextBlock)sender;
            string url = clickedTextBlock.Tag.ToString();

            contentFrame.Navigate(new SitePage(url));
        }
    }
}
