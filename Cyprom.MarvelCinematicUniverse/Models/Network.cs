using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class Network
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Webpage { get; set; }

        public Network(string name, string logo, string webpage)
        {
            Name = name;
            Logo = logo;
            Webpage = webpage;
        }
    }
}
