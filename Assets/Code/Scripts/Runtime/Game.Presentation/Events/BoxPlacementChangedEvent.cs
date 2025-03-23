using Game.Enums;
using Game.Presentation.Views;

namespace Game.Presentation.Events
{
    /// <summary>
    /// Событие смены родительского трансформа у куба
    /// </summary>
    public class BoxPlacementChangedEvent
    {
        public BoxView View { get; }
        
        public BoxPlacement Placement { get; }

        public BoxPlacementChangedEvent(BoxView view, BoxPlacement placement)
        {
            View = view;
            Placement = placement;
        }
    }
}