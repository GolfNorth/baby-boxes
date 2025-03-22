using Game.Controllers;
using Game.UI.Utils;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

namespace Game.Presentation.Views
{
    /// <summary>
    /// Вьюшка куба
    /// </summary>
    public class BoxView : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private RectTransform _rect;

        private Vector3 _deltaPosition;

        private BoxViewModel _viewModel;

        public ReactiveProperty<int> Id { get; } = new();

        public ReactiveProperty<Color> Color { get; } = new();

        private void Awake()
        {
            _rect = (RectTransform)transform;
        }

        public void Init(BoxViewModel viewModel)
        {
            Id.Value = viewModel.Id.CurrentValue;
            Color.Value = viewModel.Color.CurrentValue;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_rect.TryGetWorldPoint(eventData.position, out var rectPosition))
            {
                _rect.position = rectPosition - _deltaPosition;
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _rect.TryGetWorldPoint(eventData.position, out _deltaPosition);

            _deltaPosition -= _rect.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // TODO
        }
    }
}