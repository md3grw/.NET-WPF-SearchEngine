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
            label.FontSize = 72;
            label.Content = "Search Engine";
            label.VerticalAlignment = VerticalAlignment.Center;
            label.HorizontalAlignment = HorizontalAlignment.Center;

            Button button = new Button();
            button.Click += MainPageButton_Click;

            button.Height = 100;
            button.Width = 100;

            Image myImage = new Image();

            //ur path
            myImage.Source = new BitmapImage(new Uri("C:\\Users\\emosk\\Documents\\C#\\Search engine\\SearchEngine\\src\\github.png", UriKind.RelativeOrAbsolute));
            
            button.Content = myImage;

            button.HorizontalAlignment = HorizontalAlignment.Left;

            grid.Children.Add(label);
            grid.Children.Add(button);

            Grid.SetColumn(label, 1);
            Grid.SetColumn(button, 2);

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

        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.LoadCompleted += searchEngine.WebBrowser_LoadCompleted;
            
            webBrowser.Navigate("https://github.com/wonderxxfull");

            contentFrame.Content = webBrowser;
        }
    }
}
