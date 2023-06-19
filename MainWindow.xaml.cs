using SearchEngine.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        API.SearchEngine searchEngine;

        public MainWindow()
        {
            InitializeComponent();
            searchEngine = new API.SearchEngine();
        }

        private void ExecuteSearch(string query)
        {
            LinksStorage links = searchEngine.Search(query);

            foreach (LinkData link in links)
            {
                MessageBox.Show($"{link.Title}\n{link.Url}\n{link.Description}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSearch(SearchTextBox.Text); 
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) ExecuteSearch(SearchTextBox.Text);
        }
    }
}
