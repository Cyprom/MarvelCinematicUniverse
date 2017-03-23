using System;
using System.IO;
using Cyprom.MarvelCinematicUniverse.Helpers;
using Cyprom.MarvelCinematicUniverse.Interfaces;

namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class Episode : ChildOf<Season>, IVideo
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Timeline { get; set; }
        public int ViewOrder { get; set; }
        public string IMDbLink { get; set; }
        public string Synopsis { get; set; }
        public bool Future { get; set; }
        public DateTime AirDate;

        public DateTime GetDate()
        {
            return AirDate;
        }

        public string GetHeader()
        {
            return Title;
        }

        public string GetTimelineHeader()
        {
            return string.Format("{0}. [Episode] {1} ({2} S{3}E{4})", ViewOrder, Title, Parent.Parent.Denominator, Parent.Number.ToString().PadLeft(2, '0'), Number.ToString().PadLeft(2, '0'));
        }

        public string GetDateRepresentation()
        {
            return string.Format("Air date: {0}", AirDate.ToString("dd/MM/yyyy"));
        }

        public string GetMediaPath()
        {
            return Path.Combine("Shows", MediaHelper.SanitizeMediaText(Parent.Parent.Denominator), string.Format("Season {0}", Parent.Number), Number.ToString());
        }
    }
}
