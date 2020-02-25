using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

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

            DisableAllButton();
            FadeAnimations();

           

            Q1_A.Click += Q1_A_Click;
            Q1_B.Click += Q1_B_Click;

            Q2_A.Click += Q2_A_Click;
            Q2_B.Click += Q2_B_Click;

            Q3_A.Click += Q3_A_Click;
            Q3_B.Click += Q3_B_Click;

            Q1_A.IsEnabled = true;
            Q1_B.IsEnabled = true;

        }

        

        private void Q1_A_Click(object sender, RoutedEventArgs e)
        {
            Scripts.GlobalAnimator.ScaleImage(Q1BIMG, .5f);
        }

        private void Q1_B_Click(object sender, RoutedEventArgs e)
        {
            Scripts.GlobalAnimator.ScaleImage(Q1BIMG, .5f);
        }

        private void Q2_A_Click(object sender, RoutedEventArgs e)
        {

            Scripts.GlobalAnimator.ScaleImage(Q2BIMG, 0.55f);
        }

        private void Q2_B_Click(object sender, RoutedEventArgs e)
        {
            Scripts.GlobalAnimator.ScaleImage(Q2BIMG, 0.55f);
        }

        private void Q3_A_Click(object sender, RoutedEventArgs e)
        {
            Scripts.GlobalAnimator.ScaleImage(Q3BIMG);
        }

        private void Q3_B_Click(object sender, RoutedEventArgs e)
        {
            Scripts.GlobalAnimator.ScaleImage(Q3BIMG);
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Question1Correct.Visibility = Visibility.Visible;
            GoToScreenSaver();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Question2Correct.Visibility = Visibility.Visible;
            GoToScreenSaver2();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Question3Correct.Visibility = Visibility.Visible;
            GoToScreenSaver3();
        }

        private async void GoToScreenSaver()
        {
            
            if (correct) return;
            DisableAllButton();
            Correct.Play();

            correct = true;

            await Task.Delay(2000);
            Frame.Navigate(typeof(ScreenSaver));
        }

        private async void GoToScreenSaver2()
        {

            if (correct) return;
            DisableAllButton();
            Correct.Play();

            correct = true;

            await Task.Delay(2000);
            Frame.Navigate(typeof(Pages.ScreenSaver2));
        }

        private async void GoToScreenSaver3()
        {

            if (correct) return;
            DisableAllButton();
            Correct.Play();

            correct = true;

            await Task.Delay(2000);
            Frame.Navigate(typeof(Pages.ScreenSaver3));
        }

        private async void FadeAnimations()
        {
            if (correct) return;

            ToggleButtonSet1(true); 

            await Task.Delay(5000);

            if (correct) return;

            Question1.Fade(value: 0f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();
            ToggleButtonSet1(false);

            if (correct)
                return;

           Question2.Fade(value: 1f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();
            ToggleButtonSet2(true);

            await Task.Delay(5000);

            if (correct) return;

            Question2.Fade(value: 0f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();
            ToggleButtonSet2(false);
            if (correct) return;

            Question3.Fade(value: 1f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();
            ToggleButtonSet3(true);
            await Task.Delay(5000);

            if (correct) return;

            Question3.Fade(value: 0f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();
            ToggleButtonSet3(false);
            if (correct) return;

            Question1.Fade(value: 1f, duration: 1100, delay: 0, easingType: EasingType.Default).Start();
            if (correct) return;

            FadeAnimations();

        }

        private void DisableAllButton()
        {
            Q1_A.IsEnabled = false;
            Q2_A.IsEnabled = false;
            Q3_A.IsEnabled = false;

            Q1_B.IsEnabled = false;
            Q2_B.IsEnabled = false;
            Q3_B.IsEnabled = false;

            Q1_A.Visibility = Visibility.Collapsed;
            Q1_B.Visibility = Visibility.Collapsed;
            Q2_A.Visibility = Visibility.Collapsed;
            Q2_B.Visibility = Visibility.Collapsed;
            Q3_A.Visibility = Visibility.Collapsed;
            Q3_B.Visibility = Visibility.Collapsed;
        }

        private void ToggleButtonSet1(bool enable)
        {
            Q1_A.IsEnabled = enable;
            Q1_B.IsEnabled = enable;


            if (enable)
            {
                Q1_A.Visibility = Visibility.Visible;
                Q1_B.Visibility = Visibility.Visible;
            }

            else {
                Q1_A.Visibility = Visibility.Collapsed;
                Q1_B.Visibility = Visibility.Collapsed; 
            }
        }

        private void ToggleButtonSet2(bool enable)
        {
            Q2_A.IsEnabled = enable;
            Q2_B.IsEnabled = enable;

            if (enable)
            {
                Q2_A.Visibility = Visibility.Visible;
                Q2_B.Visibility = Visibility.Visible;
            }

            else
            {
                Q2_A.Visibility = Visibility.Collapsed;
                Q2_B.Visibility = Visibility.Collapsed;
            }
        }

        private void ToggleButtonSet3(bool enable)
        {
            Q3_A.IsEnabled = enable;
            Q3_B.IsEnabled = enable;

            if (enable)
            {
                Q3_A.Visibility = Visibility.Visible;
                Q3_B.Visibility = Visibility.Visible;
            }

            else
            {
                Q3_A.Visibility = Visibility.Collapsed;
                Q3_B.Visibility = Visibility.Collapsed;
            }
        }

    }



}
