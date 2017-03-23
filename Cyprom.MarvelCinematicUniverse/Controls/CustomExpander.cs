using System;
using System.Windows;
using System.Windows.Controls;
using Cyprom.MarvelCinematicUniverse.Helpers;

namespace Cyprom.MarvelCinematicUniverse.Controls
{
    public abstract class CustomExpander : Expander
    {
        public object CustomParent;

        public CustomExpander(object parent)
        {
            this.CustomParent = parent;
            EventHelper.SettingsChanged += UpdateFutureVisibility;
        }

        private void UpdateFutureVisibility(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IncludeFuture)
            {
                this.Visibility = Visibility.Visible;
            }
            else
            {
                if (!CheckFuture())
                {
                    this.Visibility = Visibility.Visible;
                }
                else
                {
                    this.Visibility = Visibility.Collapsed;
                }
            }
        }

        public void Activate()
        {
            if (CustomParent != null)
            {
                if (CustomParent is CustomExpander)
                {
                    ((CustomExpander)(CustomParent)).Activate();
                }
                else if (CustomParent is TabItem)
                {
                    ((TabItem)(CustomParent)).IsSelected = true;
                }
            }
            IsExpanded = true;
            BringIntoView();
            Focus();
        }

        protected abstract bool CheckFuture();
    }
}
