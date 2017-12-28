using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cyprom.MarvelCinematicUniverse.Models;

namespace Cyprom.MarvelCinematicUniverse.Helpers
{
    public static class NetworkHelper
    {
        private static Dictionary<string, Network> _networks;

        static NetworkHelper()
        {
            _networks = new Dictionary<string, Network>();
            _networks.Add("abc", new Network("ABC", "abc.png", "http://abc.go.com/"));
            _networks.Add("netflix", new Network("Netflix", "netflix.png", "https://www.netflix.com/"));
            _networks.Add("hulu", new Network("Hulu", "hulu.png", "https://www.hulu.com/"));
            _networks.Add("freeform", new Network("Freeform", "freeform.png", "https://freeform.go.com/"));
            _networks.Add("youtube", new Network("YouTube", "youtube.png", "https://www.youtube.com/"));
        }

        public static Network GetNetwork(string name)
        {
            if (!string.IsNullOrEmpty(name) && _networks.ContainsKey(name.ToLowerInvariant()))
            {
                return _networks[name.ToLowerInvariant()];
            }
            return null;
        }

    }
}
