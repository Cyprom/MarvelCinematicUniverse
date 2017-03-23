using System.Linq;
using System.Windows.Controls;
using Cyprom.MarvelCinematicUniverse.Models;

namespace Cyprom.MarvelCinematicUniverse.Controls
{
    public partial class TimelineControl : Expander
    {
        private Timeline _timeline;
        public Timeline Timeline
        {
            get
            {
                return _timeline;
            }
            set
            {
                _timeline = value;
                Refresh();
            }
        }

        public TimelineControl(Timeline timeline)
        {
            InitializeComponent();
            this.Timeline = timeline;
        }

        public void Refresh()
        {
            if (_timeline != null)
            {
                Header = _timeline.Name;
                foreach (var video in _timeline.Videos.OrderBy(v => v.ViewOrder))
                {
                    pnlVideos.Children.Add(new VideoControl(null, video, true));
                }
            }
        }
    }
}
