using Game.Enums;
using Game.Events;
using Game.Presentation.Components;
using Game.Presentation.Events;
using Game.Presentation.Utils;
using Game.SDK.Infrastructure.Interfaces;
using R3;
using UnityEngine;
using VContainer;

namespace Game.Presentation.Infractructure
{
    /// <summary>
    /// Трекер драга куба
    /// </summary>
    public class BoxDragController : MonoBehaviour
    {
        [Header("Drag")]
        [SerializeField]
        private BoxPlaceholder dragPlaceholder;

        [Header("Tower")]
        [SerializeField]
        private RectTransform towerRect;

        [SerializeField]
        private BoxPlaceholder towerPlaceholder;

        [Header("Bin")]
        [SerializeField]
        private RectTransform binRect;

        [SerializeField]
        private BoxPlaceholder binPlaceholder;

        private IEventBus _eventBus;

        [Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;

            eventBus.Subscribe<BoxBeginDragEvent>(OnBeginDrag).AddTo(this);
            eventBus.Subscribe<BoxEndDragEvent>(OnEndDrag).AddTo(this);
        }

        private void OnBeginDrag(BoxBeginDragEvent e)
        {
            dragPlaceholder.Place(e.View);
        }

        private void OnEndDrag(BoxEndDragEvent e)
        {
            var destination = towerRect.Contains(e.View.Rect)
                ? BoxPlacement.Tower
                : binRect.Overlaps(e.View.Rect)
                    ? BoxPlacement.Bin
                    : BoxPlacement.None;
            var position = destination == BoxPlacement.Tower
                ? e.View.Rect.GetRelativePosition((RectTransform)towerPlaceholder.transform)
                : Vector2.zero;

            _eventBus.Publish(new BoxDroppedEvent(e.View.Id, position, destination));
        }
    }
}