using SearchEngine.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine;
using System.Windows.Controls;
using SearchEngine.FileManagement;

namespace SearchEngine.MainWindowFiles
{
    public partial class MainWindow
    {
        private void HandleSearchInput(string searchText)
        {
            if (IsUrlValid(searchText))
            {
                Logger.Log("User was redirected to " + searchText);
                contentFrame.Content = new SitePage(searchText);
            }
            else
            {
                Logger.Log("User was redirected to search page with " + searchText + " query");
                contentFrame.Content = searchEngine.ExecuteSearch(URLSearchTextBox.Text);
            }
        }

        private bool IsUrlValid(string text)
        {
            return Uri.TryCreate(text, UriKind.Absolute, out _);
        }
    }
}
