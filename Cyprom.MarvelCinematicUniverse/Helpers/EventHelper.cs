using System;

namespace Cyprom.MarvelCinematicUniverse.Helpers
{
    public static class EventHelper
    {
        public delegate void SettingsChangedHandler(object sender, EventArgs e);

        public static event SettingsChangedHandler SettingsChanged;

        public static void RaiseSettingsChangedEvent(object sender)
        {
            SettingsChanged(sender, null);
        }
    }
}
