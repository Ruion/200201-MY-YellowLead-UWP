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
    public sealed partial class ScreenSaver3 : Page
    {
        public ScreenSaver3()
        {
            this.InitializeComponent();
            AnimateButton();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            NextButton.IsEnabled = false;
            Click.Play();

            NextButton.Scale(scaleX: 1.3f, scaleY: 1.3f, centerX: 0, centerY: 0, duration: 200, delay: 0, easingType: EasingType.Default).Start();

            await System.Threading.Tasks.Task.Delay(200);

            NextButton.Scale(scaleX: 1, scaleY: 1f, centerX: 0, centerY: 0, duration: 200, delay: 0, easingType: EasingType.Default).Start();

            await System.Threading.Tasks.Task.Delay(1600);

            Frame.Navigate(typeof(Registration));

        }

        private async void AnimateButton()
        {
            if (!NextButton.IsEnabled) return;

            NextButton.Scale(scaleX: 1.2f, scaleY: 1.2f, centerX: 0, centerY: 0, duration: 500, delay: 0, easingType: EasingType.Default).Start();

            if (!NextButton.IsEnabled) return;

            await Task.Delay(500);

            if (!NextButton.IsEnabled) return;

            NextButton.Scale(scaleX: 1, scaleY: 1, centerX: 0, centerY: 0, duration: 500, delay: 0, easingType: EasingType.Default).Start();

            if (!NextButton.IsEnabled) return;

            await Task.Delay(500);

            AnimateButton();
        }

    }
}
