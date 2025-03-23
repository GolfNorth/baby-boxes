using System.Linq;
using Game.Enums;
using Game.Presentation.Events;
using Game.Presentation.Utils;
using Game.SDK.Infrastructure.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Game.Presentation.Components
{
    /// <summary>
    /// Компонент драга куба
    /// </summary>
    public class BoxDragHandler : BoxComponent, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField]
        private BoxState[] availableStates = { BoxState.Idle, BoxState.Placed };

        private RectTransform _rect;

        private Vector3 _deltaPosition;

        private IEventBus _eventBus;

        private BoxState State => DataContext != null ? DataContext.State.Value : BoxState.None;

        [Inject]
        public void Construct(IEventBus eventBus)
        {
            _rect = (RectTransform)transform;
            _eventBus = eventBus;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!availableStates.Contains(State) || !_rect.TryGetWorldPoint(eventData.position, out var rectPosition))
                return;

            _rect.position = rectPosition - _deltaPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!availableStates.Contains(State))
                return;

            _rect.TryGetWorldPoint(eventData.position, out _deltaPosition);

            _deltaPosition -= _rect.position;

            _eventBus.Publish(new BoxBeginDragEvent(View));
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!availableStates.Contains(State))
                return;

            _eventBus.Publish(new BoxEndDragEvent(View));
        }
    }
}