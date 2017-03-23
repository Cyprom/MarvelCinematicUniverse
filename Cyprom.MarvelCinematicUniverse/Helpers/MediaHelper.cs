using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using Cyprom.MarvelCinematicUniverse.Windows;
using Cyprom.MarvelCinematicUniverse.Interfaces;

namespace Cyprom.MarvelCinematicUniverse.Helpers
{
    public static class MediaHelper
    {
        private static string[] VIDEO_FORMATS = { "mkv", "mp4", "avi", "mpg", "mpeg", "mov", "wmv" };

        public static string SanitizeMediaText(string text)
        {
            return text
                .Replace("/", string.Empty)
                .Replace("\\", string.Empty)
                .Replace(":", string.Empty)
                .Replace("*", string.Empty)
                .Replace("?", string.Empty)
                .Replace("\"", string.Empty)
                .Replace("<", string.Empty)
                .Replace(">", string.Empty)
                .Replace("|", string.Empty);
        }

        public static string GetVideoPath(IVideo video)
        {
            var dir = Path.Combine(Properties.Settings.Default.MediaDirectory, video.GetMediaPath());
            var title = Path.Combine(dir, SanitizeMediaText(video.Title));
            var possibleFiles = VIDEO_FORMATS.Select(f => string.Format("{0}.{1}", title, f)).ToList();
            var availableFiles = Directory.GetFiles(dir);
            return availableFiles.FirstOrDefault(f => possibleFiles.Contains(f));
        }

        public static void PlayMedia(IVideo video)
        {
            var videoPath = GetVideoPath(video);
            if (!string.IsNullOrEmpty(videoPath) && File.Exists(videoPath))
            {
                if (Properties.Settings.Default.UseDefaultMediaPlayer)
                {
                    Process.Start(videoPath);
                }
                else
                {
                    var player = new BuiltinMediaPlayer(video);
                    player.Show();
                }
            }
            else
            {
                MessageBox.Show(string.Format("Could not find a compatible video file in '{0}'.", Path.Combine(Properties.Settings.Default.MediaDirectory, video.GetMediaPath())), "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
