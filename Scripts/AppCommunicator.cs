using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace _200201_MY_YellowLead_UWP
{
    public class AppCommunicator
    {

        public static void LaunchAutoSyncApp()
        {
            WriteTextToFile("AppLaunchNumber.txt", "0");

            LaunchCommunicatorApp();
        }

        public static void LaunchStockUIApp()
        {
            WriteTextToFile("AppLaunchNumber.txt", "1");

            LaunchCommunicatorApp();
        }

        public static void SaveData()
        {
            WriteTextToFile("AppLaunchNumber.txt", "2");

            LaunchCommunicatorApp();
        }

        public static void LaunchDropApp()
        {
            WriteTextToFile("AppLaunchNumber.txt", "3");

            LaunchCommunicatorApp();

        }

        public static void ExitAllApp()
        {
            WriteTextToFile("AppLaunchNumber.txt", "4");

            LaunchCommunicatorApp();

        }

        public static async void WriteLinesToFile(string fileName, string[] fileLines)
        {
            StorageFolder folder = await KnownFolders.DocumentsLibrary.GetFolderAsync("200201-MY-YellowLead");
            StorageFile file = await folder.GetFileAsync(fileName);
            await FileIO.WriteLinesAsync(file, fileLines);
        }

        public static async void WriteTextToFile(string fileName, string text)
        {
            StorageFolder folder = await KnownFolders.DocumentsLibrary.GetFolderAsync("200201-MY-YellowLead");
            StorageFile file = await folder.GetFileAsync(fileName);
            await FileIO.WriteTextAsync(file, text);
        }

        public static async void ReadLineFromFile(string fileName, List<string> stringList)
        {
            StorageFolder folder = await KnownFolders.DocumentsLibrary.GetFolderAsync("200201-MY-YellowLead");
            StorageFile file = await folder.GetFileAsync(fileName);
           IList<string> istring = await FileIO.ReadLinesAsync(file);
           stringList.AddRange(istring.ToList<string>());
        }

        private static async void LaunchCommunicatorApp()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
                await Windows.ApplicationModel.FullTrustProcessLauncher.
                    LaunchFullTrustProcessForCurrentAppAsync();
        }

        
    }
}
