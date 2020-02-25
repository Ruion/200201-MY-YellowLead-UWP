using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _200201_MY_YellowLead_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterPage : Page
    {
        public MasterPage()
        {
            this.InitializeComponent();
           mainFrame.Navigate(typeof(Questions));

            Setup();

        }

        private void Setup()
        {

            AppCommunicator.LaunchAutoSyncApp();

            CheckStock();
        }

        private async void RestartButton_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            RestartButton.IsEnabled = false;
            mainFrame.Navigate(typeof(Questions));

            await Task.Delay(2000);
            RestartButton.IsEnabled = true;
        }

        private async void ExitButton_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            AppCommunicator.ExitAllApp();
            ExitButton.IsEnabled = false;

            await Task.Delay(100);
            Application.Current.Exit();
        }

        private void StockUIButton_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            OpenStockUI();
        }

        private void ClosePromptButton_Click(object sender, RoutedEventArgs e)
        {
            Prompt.Visibility = Visibility.Collapsed;
            OpenStockUI();
        }

        private void RefillButton_Click(object sender, RoutedEventArgs e)
        {
            Prompt.Visibility = Visibility.Collapsed;
            OpenStockUI();
        }

        private async void CheckStock()
        {
            await Task.Delay(10000);

            StorageFolder folder = await KnownFolders.DocumentsLibrary.GetFolderAsync("200201-MY-YellowLead");
            StorageFile file = await folder.GetFileAsync("VendingMachineStockNumber.txt");
            IList<string> text = await FileIO.ReadLinesAsync(file);
            Console.WriteLine(text);

            if (Int32.Parse(text[0]) < 1)
            {
                // Prompt refill
                Prompt.Visibility = Visibility.Visible;
            }
            else
            {
                Prompt.Visibility = Visibility.Collapsed;
            }
        }

        private async void OpenStockUI()
        {
            var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
                ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.Auto;

                StockUIButton.IsEnabled = false;

                AppCommunicator.LaunchStockUIApp();

                await Task.Delay(1000);

                StockUIButton.IsEnabled = true;
            }
            else
            {
                StockUIButton.IsEnabled = false;

                if (view.TryEnterFullScreenMode())
                {
                    ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
                }
                await Task.Delay(1000);

                StockUIButton.IsEnabled = true;
            }
        }
    }

    

}
