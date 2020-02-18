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
using Microsoft.Toolkit.Uwp.UI.Extensions;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _200201_MY_YellowLead_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registration : Page
    {

        private bool nameValid;
        private bool emailValid;
        private bool contactValid;
        private bool checkboxValid;

        public Registration()
        {
            this.InitializeComponent();
        }

        private void contactField_TextChanged(object sender, TextChangedEventArgs e)
        {
           Match c = Regex.Match(contactField.Text, @"^(01)[0-46-9]*[0-9]{7,8}$");
            if (c.Success) contactValid = true;
            else contactValid = false;

            ButtonHandler();
        }

        private void emailField_TextChanged(object sender, TextChangedEventArgs e)
        {
            Match em = Regex.Match(emailField.Text, @"^\w+@[a-zA-Z]+?\.[a-zA-Z]{2,3}$");
            if (em.Success) emailValid = true;
            else emailValid = false;

            ButtonHandler();
        }

        private void nameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameField.Text))
                nameValid = false;
            else nameValid = true;

            ButtonHandler();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            // if checkbox and field is validate
            if (nameValid == true && emailValid == true &&
                contactValid == true && checkboxValid == true) 
            {
                Frame.Navigate(typeof(SampleDrop));
            }

        }

        private void ButtonHandler()
        {
            if (nameValid == true && emailValid == true &&
                contactValid == true && checkboxValid == true)
            {
                submitButton.Background.Opacity = 100;
            }
            else
            {
                submitButton.Background.Opacity = 50;
            }
        }

        private void checkbox_Click(object sender, RoutedEventArgs e)
        {
            checkboxValid = !checkboxValid;

            if (checkboxValid)
            {
                checkboxBackground.Visibility = Visibility.Visible;
            }else
                checkboxBackground.Visibility = Visibility.Collapsed;

        }
    }
}
