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
using Microsoft.Toolkit.Uwp.UI.Animations;
using Windows.UI;

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

        private HashSet<string> existingEmailList = new HashSet<string>();
        private List<string> existingContactList = new List<string>();
        private List<string> used_redeem_codes = new List<string>();

        private bool emailDuplicate;
        private bool contactDuplicate;

        public Registration()
        {
            this.InitializeComponent();

            FetchExistingData();
        }

        
        private async void FetchExistingData()
        {
            List<string> existingEmailList_ = new List<string>();

                AppCommunicator.ReadLineFromFile("ExistingEmailList.txt", existingEmailList_);

            await System.Threading.Tasks.Task.Delay(500);

            AppCommunicator.ReadLineFromFile("ExistingContactList.txt", existingContactList);

            await System.Threading.Tasks.Task.Delay(500);

            AppCommunicator.ReadLineFromFile("used_redeem_codes.txt", used_redeem_codes);


            await System.Threading.Tasks.Task.Delay(500);

            for (int i = 0; i < existingEmailList_.Count; i++)
            {
                existingEmailList.Add(existingEmailList_[i]);
            }

            for (int i = 0; i < used_redeem_codes.Count; i++)
            {
                existingEmailList.Add(used_redeem_codes[i]);
            }

           
        }

        private void contactField_TextChanged(object sender, TextChangedEventArgs e)
        {
            Match c = Regex.Match(contactField.Text, @"^(01)[0-46-9]*[0-9]{7,8}$");
            if (c.Success)
            {
                contactValid = true;
            }
            else
            {
                contactValid = false;
            }

            if (c.Success)
            {
                contactValid = true;
            }
            else
            {
                contactValid = false;
            }

            contactDuplicate = ValidateDuplicate(existingContactList, contactField.Text);

            if (!contactValid || contactDuplicate)
            {
                ContactBorder.BorderThickness = new Thickness(3, 3, 3, 3);
                ContactBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 211, 25, 25));
            }
            else if(contactValid && !contactDuplicate)
            {
                ContactBorder.BorderThickness = new Thickness(3, 3, 3, 3);
                ContactBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 25, 211, 25));
            }

            ButtonHandler();
        }

        private void emailField_TextChanged(object sender, TextChangedEventArgs e)
        {
            Match em = Regex.Match(emailField.Text, @"^\w+@[a-zA-Z]+?\.[a-zA-Z]{2,3}$");
            if (em.Success)
            {
                emailValid = true;
            }
            else {
                emailValid = false;
            }

            emailDuplicate = ValidateDuplicate(existingEmailList.ToList(), emailField.Text);

            if (!emailValid || emailDuplicate)
            {
                EmailBorder.BorderThickness = new Thickness(3, 3, 3, 3);
                EmailBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 211, 25, 25));
            }
            else if(emailValid && !emailDuplicate)
            {
                EmailBorder.BorderThickness = new Thickness(3,3,3,3);
                EmailBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 25, 211, 25));
            }

            ButtonHandler();
        }

        private void nameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameField.Text))
            {
                nameValid = false;
                NameBorder.BorderThickness = new Thickness(3,3,3,3);
                NameBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 211, 25, 25)); 
            }
            else
            {
                nameValid = true;
                NameBorder.BorderThickness = new Thickness(3, 3, 3, 3);
                NameBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 25, 211, 25));
            }

            ButtonHandler();
        }

        private async void submitButton_Click(object sender, RoutedEventArgs e)
        {
            // if checkbox and field is validate
            if ((nameValid == true) && (emailValid == true) &&
                 (contactValid == true) && (checkboxValid == true) && !emailDuplicate && !contactDuplicate)
            {
                Click.Play();
                submitButton.IsEnabled = false;
                SubmitIMG.Scale(scaleX: 1.3f, scaleY: 1.3f, centerX: 0f, centerY: 0, duration: 200, delay: 0, easingType: EasingType.Default).Start();

                await System.Threading.Tasks.Task.Delay(200);

                SubmitIMG.Scale(scaleX: 1, scaleY: 1f, centerX: 0f, centerY: 0f, duration: 200, delay: 0, easingType: EasingType.Default).Start();

                AppCommunicator.WriteLinesToFile("PlayerData.txt",
                    new string[] { nameField.Text, emailField.Text, contactField.Text, "0", "0000-00-00" , "0", "Panel01", 
                        System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), "no"
            });
                // email , voucher_code, redeem_code, created_at, is_sync
                AppCommunicator.WriteLinesToFile("VoucherDistributionData.txt",
                    new string[] { emailField.Text, "PEDIASURE", emailField.Text, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), "no"
            });

                AppCommunicator.SaveData();

                await System.Threading.Tasks.Task.Delay(1600);

                Frame.Navigate(typeof(Pages.Webpage));
            }
            else
            {
                ShowWarning();
            }

        }

        private void ButtonHandler()
        {
            // submitButton.Visibility = Visibility.Collapsed;
            SubmitIMG.Opacity = 0.5f;

            if (nameValid == true)
                if (emailValid == true)
                    if (contactValid == true)
                        if (checkboxValid == true && !emailDuplicate && !contactDuplicate)
                        {  
                            SubmitIMG.Opacity = 1f;
                        }

        }

        private async void ShowWarning()
        {
            submitButton.IsEnabled = false;

            if (!checkboxValid) WarningMessage.Text = "Please accept policy agreement";
            // if contact duplicate
            if (contactDuplicate)
                WarningMessage.Text = "The mobile number you have entered is already registered,\nplease enter a different mobile number.";

            // if email duplicate
            if (emailDuplicate)
                WarningMessage.Text = "The email address you have entered is already registered,\nplease enter a different email address.";

            // if contact valid
            if (!contactValid)
                WarningMessage.Text = "Mobile number format entered is invalid\n Example : 0146734292";
            if (string.IsNullOrEmpty(contactField.Text))
                WarningMessage.Text = "Please fill in your mobile number\n example : 0146734292";

            // if email valid
            if (!emailValid)
                WarningMessage.Text = "The email address you have entered is invalid\n example : example@gmail.com";
            if (string.IsNullOrEmpty(emailField.Text))
                WarningMessage.Text = "Please fill in your email address\n example : example@gmail.com";

            // NAME is empty
            if (!nameValid)
            {
                WarningMessage.Text = "Please fill in your name";
            }

            WarningBox.Visibility = Visibility.Visible;

            await System.Threading.Tasks.Task.Delay(3000);
            WarningBox.Visibility = Visibility.Collapsed;
            submitButton.IsEnabled = true;
        }

        private void checkbox_Click(object sender, RoutedEventArgs e)
        {
            checkboxValid = !checkboxValid;

            if (checkboxValid == true)
            {
                checkboxBackground.Visibility = Visibility.Visible;
            }else
                checkboxBackground.Visibility = Visibility.Collapsed;

            ButtonHandler();
        }

        private bool ValidateDuplicate(List<string> source, string text_)
        {
            bool hasSame = false;

            string same = source.FirstOrDefault(t => t == text_);
            if (same != null) hasSame = true;

            return hasSame;
        }
    }
}
