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
        bool isTypedByUserURL;
        bool isTypedByUserSearch;
        API.SearchEngine searchEngine;

        public MainWindow()
        {
            InitializeComponent();

            searchEngine = new API.SearchEngine();
            isTypedByUserURL = false;
            isTypedByUserSearch = false;
        }

        private void ExecuteSearch(string query)
        {
            LinksStorage links = searchEngine.Search(query);

            this.Content = new SearchPage();

            SearchPage searchPage = this.Content as SearchPage;

            StackPanel stackPanel = searchPage.ResultsStackPannel;

            stackPanel.Children.Clear();

            foreach (LinkData link in links)
            {
                TextBlock linkTextBlock = new TextBlock();
                linkTextBlock.Text = $"Title: {link.Title}\nDescription: {link.Description}\nURL: {link.Url}";

                linkTextBlock.MouseLeftButtonUp += LinkTextBlock_MouseLeftButtonUp;

                stackPanel.Children.Add(linkTextBlock);
            }

        }

        private void LinkTextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock clickedTextBlock = sender as TextBlock;
            if (clickedTextBlock != null)
            {
                string linkInfo = clickedTextBlock.Text;

                this.Content = new SitePage(linkInfo);
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

        private void URLTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) ExecuteSearch(SearchTextBox.Text);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            const string labelText = "Text...";

            if (SearchTextBox.Text == labelText && !isTypedByUserSearch)
                SearchTextBox.Text = "";
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text.Length <= 0)
            {
                SearchTextBox.Text = "Text...";
                isTypedByUserSearch = false;
            }
        }

        private void URLTextBox_GotFocus(Object sender, RoutedEventArgs e)
        {
            const string labelText = "Text...";

            if (URLTextBox.Text == labelText && !isTypedByUserURL)
                URLTextBox.Text = "";
        }

        private void URLTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (URLTextBox.Text.Length <= 0)
            {
                URLTextBox.Text = "Text...";
                isTypedByUserURL = false;
            }
        }

        private void URLTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTypedByUserURL = true;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTypedByUserSearch = true;
        }
    }
}
