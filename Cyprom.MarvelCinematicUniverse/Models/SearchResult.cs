using System;
using Cyprom.MarvelCinematicUniverse.Controls;

namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class SearchResult
    {
        public int Rank;
        public string Type;
        public string Compact;
        public string Full;
        public CustomExpander Control;

        public SearchResult(int rank, string type, string compact, string full, CustomExpander control)
        {
            this.Rank = rank;
            this.Type = type;
            this.Compact = compact;
            this.Full = full;
            this.Control = control;
        }
    }
}
