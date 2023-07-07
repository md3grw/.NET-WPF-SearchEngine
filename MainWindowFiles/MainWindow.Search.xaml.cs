using SearchEngine.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine;
using System.Windows.Controls;


namespace SearchEngine.MainWindowFiles
{
    public partial class MainWindow
    {
        private void HandleSearchInput(string searchText)
        {
            if (IsUrlValid(searchText))
            {
                contentFrame.Content = new SitePage(searchText);
            }
            else if (IsUrlValid("https://" + searchText))
            {
                contentFrame.Content = new SitePage("https://" + searchText);
            }
            else
            {
                contentFrame.Content = searchEngine.ExecuteSearch(URLSearchTextBox.Text);
            }
        }

        private bool IsUrlValid(string text)
        {
            return Uri.TryCreate(text, UriKind.Absolute, out _);
        }
    }
}
