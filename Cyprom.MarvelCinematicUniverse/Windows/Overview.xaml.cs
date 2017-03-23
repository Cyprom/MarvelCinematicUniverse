using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using Cyprom.MarvelCinematicUniverse.Models;
using Cyprom.MarvelCinematicUniverse.Helpers;
using Cyprom.MarvelCinematicUniverse.Controls;
using Cyprom.MarvelCinematicUniverse.Interfaces;
using System.Windows.Controls;

namespace Cyprom.MarvelCinematicUniverse.Windows
{
    public partial class Overview : Window
    {
        private SearchWindow _searchWindow;

        public Overview()
        {
            InitializeComponent();

            // Read collection
            var collection = XmlHelper.ReadXml();

            // Load movie sets
            foreach (var movieSet in collection.MovieSets)
            {
                stkMovieSets.Children.Add(new MovieSetControl(tabMovies, movieSet));
            }

            // Load one shots
            foreach (var oneShot in collection.OneShots)
            {
                stkOneShots.Children.Add(new VideoControl(tabOneShots, oneShot));
            }

            // Load shows
            foreach (var show in collection.Shows)
            {
                stkShows.Children.Add(new ShowControl(tabShows, show));
            }

            // Load timeline
            var videos = new List<IVideo>();
            videos.AddRange(collection.MovieSets.SelectMany(ms => ms.Movies));
            videos.AddRange(collection.OneShots.ToList());
            videos.AddRange(collection.Shows.SelectMany(sh => sh.Seasons.SelectMany(se => se.Episodes)));
            foreach (var group in videos.GroupBy(v => v.Timeline))
            {
                stkTimeline.Children.Add(new TimelineControl(new Timeline(group.Key, group.OrderBy(v => v.ViewOrder).ToList())));
            }

            // Apply settings
            EventHelper.RaiseSettingsChangedEvent(this);
        }

        private void AdjustSettings(object sender, RoutedEventArgs e)
        {
            var dialog = new SettingsDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                EventHelper.RaiseSettingsChangedEvent(this);
            }
        }

        private void OpenSearch(object sender, RoutedEventArgs e)
        {
            if (_searchWindow == null)
            {
                _searchWindow = new SearchWindow(this);
            }
            _searchWindow.Show();
            _searchWindow.Focus();
        }

        private void ShowHelp(object sender, RoutedEventArgs e)
        {
            InternetHelper.ShowWebpage(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "help.html"));
        }

        private void Overview_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
