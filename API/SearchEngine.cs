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
using System.Windows.Data;
using System.Windows.Media;
using SearchEngine.FileManagement;

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

        public ScrollViewer ExecuteSearch(string query)
        {
            LinksStorage links = Search(query);

            ScrollViewer scrollViewer = new ScrollViewer();
            ListView listView = new ListView();
            listView.FontSize = 16;

            scrollViewer.Content = listView;
            scrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;

            foreach (LinkData link in links)
            {
                TextBlock linkTextBlockURL = new TextBlock();
                linkTextBlockURL.Tag = link.Url;
                linkTextBlockURL.Text = $"{link.Url}";
                linkTextBlockURL.FontSize = 16;

                TextBlock linkTextBlockTitle = new TextBlock();
                linkTextBlockTitle.Tag = link.Url;
                linkTextBlockTitle.Text = $"{link.Title}";
                linkTextBlockTitle.FontSize = 28;

                TextBlock linkTextBlockDescription = new TextBlock();
                linkTextBlockDescription.Text = $"{link.Description}\n";
                linkTextBlockDescription.FontSize = 18;

                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(linkTextBlockURL);
                stackPanel.Children.Add(linkTextBlockTitle);
                stackPanel.Children.Add(linkTextBlockDescription);

                listView.Items.Add(stackPanel);
            }

            listView.MouseUp += ListView_MouseUp;

            return scrollViewer;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void ListView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;

            TextBlock clickedTextBlock = FindVisualChild<TextBlock>(dep);
            string url = clickedTextBlock.Tag.ToString();

            Logger.Log("User was redirected to " + url);
            contentFrame.Navigate(new SitePage(url));
        }

        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T visualChild)
                {
                    return visualChild;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }
    }
}
