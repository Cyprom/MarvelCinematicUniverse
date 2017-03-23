using System;
using System.Windows;
using System.Windows.Controls;
using Cyprom.MarvelCinematicUniverse.Models;
using Cyprom.MarvelCinematicUniverse.Windows;

namespace Cyprom.MarvelCinematicUniverse.Controls
{
    public partial class SearchResultControl : UserControl
    {
        private CustomExpander _control;

        public SearchResultControl(SearchResult result)
        {
            InitializeComponent();
            txtType.Text = result.Type;
            txtCompact.Text = result.Compact;
            txtFull.Text = result.Full;
            _control = result.Control;
        }

        private void ToOverview(object sender, RoutedEventArgs e)
        {
            _control.Activate();
        }
    }
}
