using System.Windows;
using System.Windows.Controls;
using Cyprom.MarvelCinematicUniverse.Models;
using Cyprom.MarvelCinematicUniverse.Helpers;

namespace Cyprom.MarvelCinematicUniverse.Controls
{
    public partial class SeasonControl : CustomExpander
    {
        private Season _season;
        public Season Season
        {
            get
            {
                return _season;
            }
            set
            {
                _season = value;
                Refresh();
            }
        }

        public SeasonControl(object parent, Season season) : base(parent)
        {
            InitializeComponent();
            this.Season = season;
        }

        public void Refresh()
        {
            if (_season != null)
            {
                Header = string.Format("Season {0}", _season.Number);
                txtDate.Text = string.Format("Year: {0}", _season.Year);
                foreach (var episode in _season.Episodes)
                {
                    pnlEpisodes.Children.Add(new VideoControl(this, episode));
                }
            }
        }

        private void ShowImdb(object sender, RoutedEventArgs e)
        {
            InternetHelper.ShowWebpage(_season.IMDbLink);
        }

        protected override bool CheckFuture()
        {
            return Season.Future;
        }
    }
}
