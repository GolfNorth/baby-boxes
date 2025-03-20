namespace Game.Events
{
    /// <summary>
    /// События создания нового куба
    /// </summary>
    public class BoxCreatedEvent
    {
        public int Id { get; }

        public BoxCreatedEvent(int id)
        {
            Id = id;
        }
    }
}