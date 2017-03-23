using System;
using System.IO;
using Cyprom.MarvelCinematicUniverse.Helpers;
using Cyprom.MarvelCinematicUniverse.Interfaces;

namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class Movie : ChildOf<MovieSet>, IVideo
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Timeline { get; set; }
        public int ViewOrder { get; set; }
        public string IMDbLink { get; set; }
        public string Synopsis { get; set; }
        public bool Future { get; set; }
        public DateTime ReleaseDate;

        public DateTime GetDate()
        {
            return ReleaseDate;
        }

        public string GetHeader()
        {
            return Title;
        }

        public string GetTimelineHeader()
        {
            return string.Format("{0}. [Movie] {1}", ViewOrder, Title);
        }

        public string GetDateRepresentation()
        {
            return string.Format("Release date: {0}", ReleaseDate.ToString("dd/MM/yyyy"));
        }

        public string GetMediaPath()
        {
            return Path.Combine("MovieSets", MediaHelper.SanitizeMediaText(Parent.Denominator), Number.ToString());
        }
    }
}
