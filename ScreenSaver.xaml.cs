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

namespace _200201_MY_YellowLead_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScreenSaver : Page
    {
        public ScreenSaver()
        {
            this.InitializeComponent();
            FadeAnimations();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WebViewPage));
        }

        private async void FadeAnimations()
        {
            await Task.Delay(4000);

            H1.Fade(value: 0f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();
            H2.Fade(value: 1f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();

            await Task.Delay(4000);

            H2.Fade(value: 0f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();
            H3.Fade(value: 1f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();

            await Task.Delay(4000);

            H3.Fade(value: 0f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();
            H1.Fade(value: 1f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();

            FadeAnimations();
        }
    }
}
