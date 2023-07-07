using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SearchEngine.MainWindowFiles
{
    public partial class MainWindow
    {
        private void AddMainLogo()
        {
            Grid grid = new Grid();

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            Label label = new Label();
            label.FontSize = 73;
            label.FontFamily = new FontFamily("Franklin Gothic Demi");
            label.Content = "Search Engine";
            label.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            label.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            grid.Children.Add(label);

            Grid.SetColumn(label, 1);

            contentFrame.Content = grid;
        }
    }
}
