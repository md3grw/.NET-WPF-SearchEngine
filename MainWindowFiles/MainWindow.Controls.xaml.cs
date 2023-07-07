using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace SearchEngine.MainWindowFiles
{
    public partial class MainWindow
    {
        private void URLSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) HandleSearchInput(URLSearchTextBox.Text);
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
            HandleSearchInput("https://github.com/md3grw");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            HandleSearchInput(URLSearchTextBox.Text);
        }
    }
}
