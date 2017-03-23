namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class MovieSet : ChildOf<Collection>
    {
        public MovieSet()
        {
            Movies = new ParentChildCollection<MovieSet, Movie>(this);
        }

        public string Denominator;
        public bool Future { get; set; }
        public ParentChildCollection<MovieSet, Movie> Movies;
    }
}
