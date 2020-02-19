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

    public sealed partial class Questions : Page
    {
        private bool correct = false;

        public Questions()
        {
            this.InitializeComponent();
            FadeAnimations();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Question1Correct.Visibility = Visibility.Visible;
            GoToScreenSaver();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        { 

            Question2Correct.Visibility = Visibility.Visible;
            GoToScreenSaver();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Question3Correct.Visibility = Visibility.Visible;
            GoToScreenSaver();
        }

        private async void GoToScreenSaver()
        {
            if (correct) return;
            correct = true;

            await Task.Delay(2000);
            Frame.Navigate(typeof(ScreenSaver));
        }

        private async void FadeAnimations()
        {
            if (correct) return;

            await Task.Delay(5000);

            if (correct) return;

            Question1.Fade(value: 0f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();

            if (correct)
                return;

           Question2.Fade(value: 1f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();

            await Task.Delay(5000);

            if (correct) return;

            Question2.Fade(value: 0f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();

            if (correct) return;

            Question3.Fade(value: 1f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();

            await Task.Delay(5000);

            if (correct) return;

            Question3.Fade(value: 0f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();

            if (correct) return;

            Question1.Fade(value: 1f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();

            if (correct) return;

            FadeAnimations();

        }
    }
}
