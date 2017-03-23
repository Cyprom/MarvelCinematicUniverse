namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class Season : ChildOf<Show>
    {
        public Season()
        {
            Episodes = new ParentChildCollection<Season, Episode>(this);
        }

        public int Number;
        public int Year;
        public string IMDbLink;
        public bool Future { get; set; }
        public ParentChildCollection<Season, Episode> Episodes;
    }
}
