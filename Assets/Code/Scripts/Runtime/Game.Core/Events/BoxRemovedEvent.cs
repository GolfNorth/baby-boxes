namespace Game.Events
{
    /// <summary>
    /// Событие удаления куба с поля
    /// </summary>
    public class BoxRemovedEvent
    {
        public int Id { get; }

        public BoxRemovedEvent(int id)
        {
            Id = id;
        }
    }
}