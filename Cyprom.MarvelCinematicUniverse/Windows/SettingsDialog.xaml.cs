using System.Windows;
using System.Windows.Forms;

namespace Cyprom.MarvelCinematicUniverse.Windows
{
    public partial class SettingsDialog : Window
    {
        public SettingsDialog()
        {
            InitializeComponent();
            txtBrowse.Text = Properties.Settings.Default.MediaDirectory;
            chkBrowser.IsChecked = Properties.Settings.Default.UseDefaultBrowser;
            chkMediaPlayer.IsChecked = Properties.Settings.Default.UseDefaultMediaPlayer;
            chkFuture.IsChecked = Properties.Settings.Default.IncludeFuture;
        }

        private void Browse(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBrowse.Text = dialog.SelectedPath;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.MediaDirectory = txtBrowse.Text;
            Properties.Settings.Default.UseDefaultBrowser = chkBrowser.IsChecked.GetValueOrDefault();
            Properties.Settings.Default.UseDefaultMediaPlayer = chkMediaPlayer.IsChecked.GetValueOrDefault();
            Properties.Settings.Default.IncludeFuture = chkFuture.IsChecked.GetValueOrDefault();
            DialogResult = true;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
