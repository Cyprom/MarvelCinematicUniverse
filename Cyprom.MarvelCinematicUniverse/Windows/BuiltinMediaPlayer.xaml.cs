using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Media.Animation;
using Cyprom.MarvelCinematicUniverse.Helpers;
using Cyprom.MarvelCinematicUniverse.Interfaces;

namespace Cyprom.MarvelCinematicUniverse.Windows
{
    public partial class BuiltinMediaPlayer : Window
    {
        public BuiltinMediaPlayer(IVideo video)
        {
            InitializeComponent();
            DataContext = this;
            Title = video.Title;
            var timeline = new MediaTimeline(new Uri(MediaHelper.GetVideoPath(video), UriKind.Absolute));
            medPlayer.Clock = (MediaClock)timeline.CreateClock(true);
        }
        
        private void Play(object sender, RoutedEventArgs e)
        {
            medPlayer.Clock.Controller.Resume();
            btnPlay.Visibility = Visibility.Collapsed;
            btnPause.Visibility = Visibility.Visible;
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            medPlayer.Clock.Controller.Pause();
            btnPause.Visibility = Visibility.Collapsed;
            btnPlay.Visibility = Visibility.Visible;
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            medPlayer.Clock.Controller.Pause();
            sldTimeslider.Value = 0;
            medPlayer.Clock.Controller.Seek(TimeSpan.FromSeconds(sldTimeslider.Value), TimeSeekOrigin.BeginTime);
            medPlayer.Clock.Controller.Pause();
            btnPause.Visibility = Visibility.Collapsed;
            btnPlay.Visibility = Visibility.Visible;
        }

        private void GoFullScreen(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            btnFullScreen.Visibility = Visibility.Collapsed;
            btnRevertToWindow.Visibility = Visibility.Visible;
        }

        private void RevertToWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
            WindowStyle = WindowStyle.SingleBorderWindow;
            btnRevertToWindow.Visibility = Visibility.Collapsed;
            btnFullScreen.Visibility = Visibility.Visible;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            medPlayer.Clock.Controller.Stop();
            medPlayer.Stop();
            medPlayer.Close();
        }

        private void PlayerClicked(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount >= 2)
            {
                if (btnFullScreen.IsVisible)
                {
                    GoFullScreen(sender, null);
                }
                else
                {
                    RevertToWindow(sender, null);
                }
            }
        }

        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            sldTimeslider.Maximum = medPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            medPlayer.Play();
            medPlayer.Clock.Controller.Resume();
        }

        private void TimeChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            medPlayer.Clock.Controller.Pause();
            medPlayer.Clock.Controller.Seek(TimeSpan.FromSeconds(sldTimeslider.Value), TimeSeekOrigin.BeginTime);
            medPlayer.Clock.Controller.Resume();
        }
    }
}
