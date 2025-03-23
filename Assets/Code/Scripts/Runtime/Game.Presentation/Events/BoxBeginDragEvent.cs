using Game.Presentation.Views;

namespace Game.Presentation.Events
{
    /// <summary>
    /// Событие начала драга куба
    /// </summary>
    public class BoxBeginDragEvent
    {
        public BoxView View { get; }

        public BoxBeginDragEvent(BoxView view)
        {
            View = view;
        }
    }
}