using System;

namespace Cyprom.MarvelCinematicUniverse.Interfaces
{
    public interface IVideo
    {
        int Number { get; set; }
        string Title { get; set; }
        string Timeline { get; set; }
        int ViewOrder { get; set; }
        string IMDbLink { get; set; }
        string Synopsis { get; set; }
        bool Future { get; set; }
        DateTime GetDate();
        string GetHeader();
        string GetTimelineHeader();
        string GetDateRepresentation();
        string GetMediaPath();
    }
}
