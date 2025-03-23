namespace Game.Events
{
    /// <summary>
    /// Событие уничтожения куба с поля
    /// </summary>
    public class BoxDestroyedEvent
    {
        public int Id { get; }

        public BoxDestroyedEvent(int id)
        {
            Id = id;
        }
    }
}