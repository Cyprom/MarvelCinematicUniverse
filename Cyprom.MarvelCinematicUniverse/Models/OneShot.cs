using System;
using System.IO;
using Cyprom.MarvelCinematicUniverse.Helpers;
using Cyprom.MarvelCinematicUniverse.Interfaces;

namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class OneShot : ChildOf<Collection>, IVideo
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Timeline { get; set; }
        public int ViewOrder { get; set; }
        public string IMDbLink { get; set; }
        public string Synopsis { get; set; }
        public bool Future { get; set; }
        public DateTime Date;

        public DateTime GetDate()
        {
            return Date;
        }

        public string GetHeader()
        {
            return Title;
        }

        public string GetTimelineHeader()
        {
            return string.Format("{0}. [One-Shot] {1}", ViewOrder, Title);
        }

        public string GetDateRepresentation()
        {
            return string.Format("Date: {0}", Date.ToString("dd/MM/yyyy"));
        }

        public string GetMediaPath()
        {
            return Path.Combine("OneShots", Number.ToString());
        }
    }
}
