using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Cyprom.MarvelCinematicUniverse.Helpers;
using Cyprom.MarvelCinematicUniverse.Windows;
using Cyprom.MarvelCinematicUniverse.Interfaces;
using System.Windows.Media;

namespace Cyprom.MarvelCinematicUniverse.Controls
{
    public partial class VideoControl : CustomExpander
    {
        private bool _inTimeline;

        private IVideo _video;
        public IVideo Video
        {
            get
            {
                return _video;
            }
            set
            {
                _video = value;
                Refresh();
            }
        }

        public VideoControl(object parent, IVideo video, bool inTimeline = false) : base(parent)
        {
            InitializeComponent();
            this._inTimeline = inTimeline;
            this.Video = video;
            if (CustomParent != null)
            {
                SearchHelper.RegisterSearchable(this);
            }
            if (inTimeline)
            {
                EventHelper.TimelineFilterChanged += UpdateTypeVisibility;
            }
        }

        public void Refresh()
        {
            if (_video != null)
            {
                Header = _inTimeline ? _video.GetTimelineHeader() : _video.GetHeader();
                txtSynopsis.Text = _video.Synopsis;
                txtDate.Text = _video.GetDateRepresentation();
                if (_video.GetDate() > DateTime.Now)
                {
                    txtDate.Foreground = Brushes.Red;
                    txtDate.ToolTip = "This product is not available yet...";
                }
                try
                {
                    imgCover.Source = new BitmapImage(new Uri(string.Format("{0}.jpg", Path.Combine(Properties.Settings.Default.MediaDirectory, _video.GetMediaPath(), MediaHelper.SanitizeMediaText(_video.Title))), UriKind.Absolute));
                }
                catch (FileNotFoundException fnfe)
                {
                    imgCover.ToolTip = fnfe.Message;
                }
            }
        }

        private void PlayVideo(object sender, RoutedEventArgs e)
        {
            MediaHelper.PlayMedia(_video);
        }

        private void ShowImdb(object sender, RoutedEventArgs e)
        {
            InternetHelper.ShowWebpage(_video.IMDbLink);
        }

        protected override bool CheckFuture()
        {
            return Video.Future;
        }

        private void UpdateTypeVisibility(object sender, TimelineFilterEventArgs e)
        {
            switch (_video.GetType().Name)
            {
                case "Movie":
                    Visibility = e.MoviesEnabled ? Visibility.Visible : Visibility.Collapsed;
                    break;
                case "OneShot":
                    Visibility = e.OneShotsEnabled ? Visibility.Visible : Visibility.Collapsed;
                    break;
                case "Episode":
                    Visibility = e.ShowsEnabled ? Visibility.Visible : Visibility.Collapsed;
                    break;
            }
        }
    }
}
