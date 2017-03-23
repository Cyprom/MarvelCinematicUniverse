using Cyprom.MarvelCinematicUniverse.Helpers;

namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class Show : ChildOf<Collection>
    {
        public Show()
        {
            Seasons = new ParentChildCollection<Show, Season>(this);
        }

        public string Denominator;
        public bool Netflix;
        public string IMDbLink;
        public string Description;
        public bool Future { get; set; }
        public ParentChildCollection<Show, Season> Seasons;

        public string GetMediaPath()
        {
            return string.Format("Shows\\{0}\\{0}.jpg", MediaHelper.SanitizeMediaText(Denominator));
        }
    }
}
