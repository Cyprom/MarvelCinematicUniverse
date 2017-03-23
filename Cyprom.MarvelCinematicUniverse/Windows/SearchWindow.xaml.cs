using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using Cyprom.MarvelCinematicUniverse.Helpers;
using Cyprom.MarvelCinematicUniverse.Controls;

namespace Cyprom.MarvelCinematicUniverse.Windows
{
    public partial class SearchWindow : Window
    {
        private Overview _overview;

        public SearchWindow(Overview overview)
        {
            InitializeComponent();
            _overview = overview;
            txtRequest.Focus();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            txtRequest.Text = string.Empty;
            txtRequest.Focus();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            PerformSearch();
        }

        private void KeyHit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                PerformSearch();
            }
        }

        private void PerformSearch()
        {
            pnlResults.Children.Clear();
            if (!string.IsNullOrWhiteSpace(txtRequest.Text))
            {
                var results = SearchHelper.Search(txtRequest.Text);
                if (results != null && results.Any())
                {
                    results = results.OrderByDescending(r => r.Rank).ToList();
                    foreach (var result in results)
                    {
                        pnlResults.Children.Add(new SearchResultControl(result));
                    }
                    txtResults.Text = string.Format("Found {0} results:", results.Count);
                }
                else
                {
                    txtResults.Text = "No results found...";
                }
            }
        }

        private void SearchWindow_Closing(object sender, CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
