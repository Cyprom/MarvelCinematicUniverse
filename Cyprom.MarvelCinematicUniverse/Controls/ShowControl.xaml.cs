using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Cyprom.MarvelCinematicUniverse.Models;
using Cyprom.MarvelCinematicUniverse.Helpers;

namespace Cyprom.MarvelCinematicUniverse.Controls
{
    public partial class ShowControl : CustomExpander
    {
        private Show _show;
        public Show Show
        {
            get
            {
                return _show;
            }
            set
            {
                _show = value;
                Refresh();
            }
        }

        public ShowControl(object parent, Show show) : base(parent)
        {
            InitializeComponent();
            this.Show = show;
            SearchHelper.RegisterSearchable(this);
        }

        public void Refresh()
        {
            if (_show != null)
            {
                Header = _show.Denominator;
                txtDescription.Text = _show.Description;
                if (_show.Netflix)
                {
                    btnNetflix.Visibility = Visibility.Visible;
                }
                foreach (var season in _show.Seasons)
                {
                    pnlSeasons.Children.Add(new SeasonControl(this, season));
                }
                try
                {
                    imgCover.Source = new BitmapImage(new Uri(Path.Combine(Properties.Settings.Default.MediaDirectory, Show.GetMediaPath())));
                }
                catch (FileNotFoundException fnfe)
                {
                    imgCover.ToolTip = fnfe.Message;
                }
            }
        }

        private void ShowImdb(object sender, RoutedEventArgs e)
        {
            InternetHelper.ShowWebpage(_show.IMDbLink);
        }

        private void ShowNetflix(object sender, RoutedEventArgs e)
        {
            InternetHelper.ShowWebpage("http://www.netflix.com");
        }

        protected override bool CheckFuture()
        {
            return Show.Future;
        }
    }
}
