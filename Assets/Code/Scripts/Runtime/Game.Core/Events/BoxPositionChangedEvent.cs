using UnityEngine;

namespace Game.Events
{
    /// <summary>
    /// Событие смены позиции коробки
    /// </summary>
    public class BoxPositionChangedEvent
    {
        /// <summary>
        /// Идентификатор коробки
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Новая позиция коробки
        /// </summary>
        public Vector2 Position { get; }
    }
}