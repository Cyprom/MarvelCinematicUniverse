using System.Windows;
using System.Diagnostics;
using Cyprom.MarvelCinematicUniverse.Windows;

namespace Cyprom.MarvelCinematicUniverse.Helpers
{
    public static class InternetHelper
    {
        public static void ShowWebpage(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Page is not available.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (Properties.Settings.Default.UseDefaultBrowser)
                {
                    Process.Start(url);
                }
                else
                {
                    var browser = new BuiltinBrowser(url);
                    browser.Show();
                }
            }
        }
    }
}
