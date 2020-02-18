using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _200201_MY_YellowLead_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WebViewPage : Page
    {
        public WebViewPage()
        {
            this.InitializeComponent();
        }

        private void HeightPredictor_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("https://pediasure.com.my/watchMeGrow/height-predictor");
            PediasureWebview.Navigate(uri);
            WebViewExit.Visibility = Visibility.Visible;
            PediasureWebview.Visibility = Visibility.Visible;
        }

        private void WebViewExit_Click(object sender, RoutedEventArgs e)
        {
            PediasureWebview.Visibility = Visibility.Collapsed;
            WebViewExit.Visibility = Visibility.Collapsed;
        }
    }
}
