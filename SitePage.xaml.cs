using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Interaction logic for SitePage.xaml
    /// </summary>
    public partial class SitePage : Page
    {
        public SitePage(string url)
        {
            InitializeComponent();

            InitializeWebView(url);
        }

        private async void InitializeWebView(string url)
        {
            await webView.EnsureCoreWebView2Async();
            webView.CoreWebView2.Navigate(url);
        }
    }
}
