using System.Windows;

namespace Cyprom.MarvelCinematicUniverse.Windows
{
    public partial class BuiltinBrowser : Window
    {
        private string _url;
        public string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                ReloadPage();
            }
        }

        public BuiltinBrowser(string url)
        {
            InitializeComponent();
            this.Title = url;
            this.URL = url;
            ReloadPage();
        }

        public void ReloadPage()
        {
            brwContent.Navigate(URL);
        }
    }
}
