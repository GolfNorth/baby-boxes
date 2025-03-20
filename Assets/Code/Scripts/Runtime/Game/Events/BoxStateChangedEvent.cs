using Game.Enums;

namespace Game.Events
{
    /// <summary>
    /// Событие смены состояния коробки
    /// </summary>
    public class BoxStateChangedEvent
    {
        /// <summary>
        /// Идентификатор коробки
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Прежнее состояние коробки
        /// </summary>
        public BoxState OldState { get; }

        /// <summary>
        /// Новое состояние коробки
        /// </summary>
        public BoxState NewState { get; }
    }
}