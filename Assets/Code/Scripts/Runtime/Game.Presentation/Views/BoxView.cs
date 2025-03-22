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

        public static IObjectPool<BoxView> ObjectPool;

        public ReactiveProperty<int> Id { get; } = new();

        public ReactiveProperty<Color> Color { get; } = new();

        private void Awake()
        {
            _rect = (RectTransform)transform;
        }

        public void Init(int id, Color color)
        {
            Id.Value = id;
            Color.Value = color;
        }

        public void Release()
        {
            ObjectPool.Release(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("?");
            
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