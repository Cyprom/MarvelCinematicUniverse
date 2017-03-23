namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class Collection
    {
        public Collection()
        {
            MovieSets = new ParentChildCollection<Collection, MovieSet>(this);
            OneShots = new ParentChildCollection<Collection, OneShot>(this);
            Shows = new ParentChildCollection<Collection, Show>(this);
        }

        public ParentChildCollection<Collection, MovieSet> MovieSets;
        public ParentChildCollection<Collection, OneShot> OneShots;
        public ParentChildCollection<Collection, Show> Shows;
    }
}
