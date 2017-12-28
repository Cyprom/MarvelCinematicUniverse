using System;
using System.IO;
using System.Windows;
using System.Reflection;
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

        private Network _network;
        public Network Network
        {
            get
            {
                return _network;
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
                _network = NetworkHelper.GetNetwork(_show.Network);

                if (_network != null)
                {
                    btnNetwork.ToolTip = _network.Name;
                    imgNetwork.Source = new BitmapImage(new Uri("pack://application:,,,/Cyprom.MarvelCinematicUniverse;component/Images/Logos/" + _network.Logo));
                    btnNetwork.Visibility = Visibility.Visible;
                }
                else
                {
                    btnNetwork.ToolTip = string.Empty;
                    imgNetwork.Source = null;
                    btnNetwork.Visibility = Visibility.Collapsed;
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

        private void ShowNetwork(object sender, RoutedEventArgs e)
        {
            if (_network != null)
            {
                InternetHelper.ShowWebpage(_network.Webpage);
            }
        }

        protected override bool CheckFuture()
        {
            return Show.Future;
        }
    }
}
