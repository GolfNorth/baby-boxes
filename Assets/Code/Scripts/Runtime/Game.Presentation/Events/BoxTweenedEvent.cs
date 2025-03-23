using Game.Presentation.Views;

namespace Game.Presentation.Events
{
    /// <summary>
    /// Событие завершения анимации куба
    /// </summary>
    public class BoxTweenedEvent
    {
        public BoxView View { get; }

        public BoxTweenedEvent(BoxView view)
        {
            View = view;
        }
    }
}