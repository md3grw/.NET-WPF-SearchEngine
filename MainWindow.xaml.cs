using SearchEngine.API;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SearchEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isTypedByUser;
        API.SearchEngine searchEngine;

        public MainWindow()
        {
            InitializeComponent();
            
            AddMainLogo();

            searchEngine = new API.SearchEngine(contentFrame);
            isTypedByUser = false;
        }

        private void AddMainLogo()
        {
            Grid grid = new Grid();

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            Label label = new Label();
            label.FontSize = 85;
            label.FontFamily = new FontFamily("Bernard MT Condensed");
            label.Content = "Search Engine";
            label.VerticalAlignment = VerticalAlignment.Center;
            label.HorizontalAlignment = HorizontalAlignment.Center;

            grid.Children.Add(label);

            Grid.SetColumn(label, 1);

            contentFrame.Content = grid;
        }

        private void URLSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) contentFrame.Content = searchEngine.ExecuteSearch(URLSearchTextBox.Text);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void URLSearchTextBox_GotFocus(Object sender, RoutedEventArgs e)
        {
            const string labelText = "Text...";

            if (URLSearchTextBox.Text == labelText && !isTypedByUser)
                URLSearchTextBox.Text = "";
        }

        private void URLSearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (URLSearchTextBox.Text.Length <= 0)
            {
                URLSearchTextBox.Text = "Text...";
                isTypedByUser = false;
            }
        }

        private void URLSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTypedByUser = true;
        }

        private void GitButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Content = new SitePage("https://github.com/md3grw");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Content = searchEngine.ExecuteSearch(URLSearchTextBox.Text);
        }
    }
}
