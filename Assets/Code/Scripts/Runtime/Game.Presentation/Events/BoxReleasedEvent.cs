namespace Game.Presentation.Events
{
    /// <summary>
    /// Событие освобождения куба
    /// </summary>
    public class BoxReleasedEvent
    {
        public int Id { get; }

        public BoxReleasedEvent(int id)
        {
            Id = id;
        }
    }
}