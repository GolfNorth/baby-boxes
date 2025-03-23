using Game.Enums;

namespace Game.Events
{
    /// <summary>
    /// Событие достижения лимита
    /// </summary>
    public class BoxPlacementErrorEvent
    {
        public int Id { get; }

        public PlacementError Error { get; }

        public BoxPlacementErrorEvent(int id, PlacementError error)
        {
            Id = id;
            Error = error;
        }
    }
}