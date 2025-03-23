using UnityEngine;

namespace Game.Events
{
    /// <summary>
    /// Событие размещения куба в башне
    /// </summary>
    public class BoxPlacedEvent
    {
        public int Id { get; }

        public Vector2 Position { get; }

        public BoxPlacedEvent(int id, Vector2 position)
        {
            Id = id;
            Position = position;
        }
    }
}