using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _200201_MY_YellowLead_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Webpage : Page
    {
        public Webpage()
        {
            this.InitializeComponent();
            Uri uri = new Uri("https://pediasure.com.my/watchMeGrow/height-predictor");
            PediasureWebsite.Navigate(uri);

            AnimateButton();
        }

        private async void FreeSampleButton_Click(object sender, RoutedEventArgs e)
        {
            
            Click.Play();

            FreeSampleButton.IsEnabled = false;
            FreeSampleIMG.Scale(scaleX: 1.3f, scaleY: 1.3f, centerX: 0, centerY: 0, duration: 200, delay: 0, easingType: EasingType.Default).Start();

            await System.Threading.Tasks.Task.Delay(200);

            FreeSampleIMG.Scale(scaleX: 1, scaleY: 1f, centerX: 0, centerY: 0, duration: 200, delay: 0, easingType: EasingType.Default).Start();

            await System.Threading.Tasks.Task.Delay(1600);

            Frame.Navigate(typeof(CollectSample));
        }

        private async void AnimateButton()
        {
            if (!FreeSampleButton.IsEnabled) return;

            FreeSampleIMG.Scale(scaleX: 1.05f, scaleY: 1.05f, centerX: 0.5f, centerY: 0.5f, duration: 500, delay: 0, easingType: EasingType.Default).Start();

            if (!FreeSampleButton.IsEnabled) return;

            await Task.Delay(500);

            if (!FreeSampleButton.IsEnabled) return;

            FreeSampleIMG.Scale(scaleX: 1, scaleY: 1, centerX: 0.5f, centerY: 0.5f, duration: 500, delay: 0, easingType: EasingType.Default).Start();

            if (!FreeSampleButton.IsEnabled) return;

            await Task.Delay(500);

            AnimateButton();
        }
    }
}
