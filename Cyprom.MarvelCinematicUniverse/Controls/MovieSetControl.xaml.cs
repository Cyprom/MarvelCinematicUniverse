using System.Windows.Controls;
using Cyprom.MarvelCinematicUniverse.Models;

namespace Cyprom.MarvelCinematicUniverse.Controls
{
    public partial class MovieSetControl : CustomExpander
    {
        private MovieSet _movieSet;
        public MovieSet MovieSet
        {
            get
            {
                return _movieSet;
            }
            set
            {
                _movieSet = value;
                Refresh();
            }
        }

        public MovieSetControl(object parent, MovieSet movieSet) : base(parent)
        {
            InitializeComponent();
            this.MovieSet = movieSet;
        }

        public void Refresh()
        {
            if (_movieSet != null)
            {
                Header = _movieSet.Denominator;
                foreach (var movie in _movieSet.Movies)
                {
                    pnlMovies.Children.Add(new VideoControl(this, movie));
                }
            }
        }

        protected override bool CheckFuture()
        {
            return MovieSet.Future;
        }
    }
}
