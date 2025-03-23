using Game.Enums;
using UnityEngine;

namespace Game.Events
{
    /// <summary>
    /// Событие попытки размещения куба в заданном направлении
    /// </summary>
    public class BoxDroppedEvent
    {
        public int Id { get; }
        
        public Vector2 Position { get; }

        public BoxPlacement Placement { get; }

        public BoxDroppedEvent(int id, Vector2 position, BoxPlacement placement)
        {
            Id = id;
            Position = position;
            Placement = placement;
        }
    }
}