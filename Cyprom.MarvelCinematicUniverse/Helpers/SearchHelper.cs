using System;
using System.Collections.Generic;
using Cyprom.MarvelCinematicUniverse.Models;
using Cyprom.MarvelCinematicUniverse.Controls;
using Cyprom.MarvelCinematicUniverse.Interfaces;

namespace Cyprom.MarvelCinematicUniverse.Helpers
{
    public static class SearchHelper
    {

        private static List<VideoControl> _videos = new List<VideoControl>();
        private static List<ShowControl> _shows = new List<ShowControl>();

        public static void RegisterSearchable(VideoControl control)
        {
            _videos.Add(control);
        }

        public static void RegisterSearchable(ShowControl control)
        {
            _shows.Add(control);
        }

        public static List<SearchResult> Search(string request)
        {
            var includeFuture = Properties.Settings.Default.IncludeFuture;
            var lowered = request.ToLowerInvariant();
            var results = new List<SearchResult>();
            foreach (var control in _videos)
            {
                var video = control.Video;
                if (includeFuture || !video.Future)
                {
                    if (video.Title.ToLowerInvariant().Contains(lowered))
                    {
                        results.Add(new SearchResult(40, video.GetType().Name, video.Title, video.Synopsis, control));
                    }
                    else if (video.Synopsis.ToLowerInvariant().Contains(lowered))
                    {
                        results.Add(new SearchResult(20, video.GetType().Name, video.Title, video.Synopsis, control));
                    }
                }                
            }
            foreach (var control in _shows)
            {
                var show = control.Show;
                if (includeFuture || !show.Future)
                {
                    if (show.Denominator.ToLowerInvariant().Contains(lowered))
                    {
                        results.Add(new SearchResult(30, show.GetType().Name, show.Denominator, show.Description, control));
                    }
                    else if (show.Description.ToLowerInvariant().Contains(lowered))
                    {
                        results.Add(new SearchResult(10, show.GetType().Name, show.Denominator, show.Description, control));
                    }
                }
            }
            return results;
        }
    }
}
