using System.Collections.Generic;
using Cyprom.MarvelCinematicUniverse.Interfaces;

namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class Timeline
    {
        public Timeline(string name, List<IVideo> videos)
        {
            this.Name = name;
            this.Videos = videos;
        }

        public string Name;
        public List<IVideo> Videos;
    }
}
