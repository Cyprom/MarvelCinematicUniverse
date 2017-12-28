using System;

namespace Cyprom.MarvelCinematicUniverse.Helpers
{
    public static class EventHelper
    {
        public delegate void SettingsChangedHandler(object sender, EventArgs e);
        public delegate void TimelineFilterChangedHandler(object sender, TimelineFilterEventArgs e);

        public static event SettingsChangedHandler SettingsChanged;
        public static event TimelineFilterChangedHandler TimelineFilterChanged;

        public static void RaiseSettingsChangedEvent(object sender)
        {
            try
            {
                SettingsChanged(sender, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void RaiseTimelineFilterChangedEvent(object sender, bool moviesEnabled, bool oneShotsEnabled, bool showsEnabled)
        {
            try
            {
                TimelineFilterChanged(sender, new TimelineFilterEventArgs(moviesEnabled, oneShotsEnabled, showsEnabled));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class TimelineFilterEventArgs : EventArgs
    {
        public bool MoviesEnabled { get; private set; }
        public bool OneShotsEnabled { get; private set; }
        public bool ShowsEnabled { get; private set; }

        public TimelineFilterEventArgs(bool moviesEnabled, bool oneShotsEnabled, bool showsEnabled)
        {
            MoviesEnabled = moviesEnabled;
            OneShotsEnabled = oneShotsEnabled;
            ShowsEnabled = showsEnabled;
        }
    }
}
