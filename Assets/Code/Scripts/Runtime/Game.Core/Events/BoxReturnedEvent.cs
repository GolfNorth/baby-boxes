namespace Game.Events
{
    /// <summary>
    /// Событие возвращения куба в башню
    /// </summary>
    public class BoxReturnedEvent
    {
        public int Id { get; }

        public BoxReturnedEvent(int id)
        {
            Id = id;
        }
    }
}