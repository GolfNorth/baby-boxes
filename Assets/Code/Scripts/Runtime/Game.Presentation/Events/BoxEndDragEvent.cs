using Game.Presentation.Views;

namespace Game.Presentation.Events
{
    /// <summary>
    /// Событие завершения драга
    /// </summary>
    public class BoxEndDragEvent
    {
        public BoxView View { get; }

        public BoxEndDragEvent(BoxView view)
        {
            View = view;
        }
    }
}