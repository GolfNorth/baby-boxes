using System.Collections.Generic;
using Game.SDK.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI.Components
{
    /// <summary>
    /// Компонент для распределения перемещения объектов
    /// </summary>
    public class DragRouter : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IBeginDragHandler
    {
        #region Fields

        [SerializeField, Tooltip("Осевой множитель. Чем больше, тем проще начать перемещение")]
        private Vector2 axialMultiplier = Vector2.one;

        [TypeRestriction(typeof(IDragHandler))]
        [SerializeField, Tooltip("Объект перемещения по оси X")]
        private Component passDragXTo;

        [TypeRestriction(typeof(IDragHandler))]
        [SerializeField, Tooltip("Объект перемещения по оси Y")]
        private Component passDragYTo;

        /// <summary>
        /// Данные для рейкаста компонентов
        /// </summary>
        private readonly PointerEventData _raycastEventData = new PointerEventData(EventSystem.current);

        /// <summary>
        /// Компонент <see cref="ScrollRect"/>
        /// </summary>
        private ScrollRect _scrollRect;

        /// <summary>
        /// Объекты исключения
        /// </summary>
        private HashSet<GameObject> _exceptionObjects;

        /// <summary>
        /// Целевой объект для перемещения
        /// </summary>
        private IDragHandler _dragHandler;

        /// <summary>
        /// Флаг наличия целевого объекта
        /// </summary>
        private bool _hasDragHandler;

        /// <summary>
        /// Объект перемещения по оси X
        /// </summary>
        private IDragHandler _dragHandlerX;

        /// <summary>
        /// Объект перемещения по оси Y
        /// </summary>
        private IDragHandler _dragHandlerY;

        #endregion

        #region Init

        private void Awake()
        {
            _exceptionObjects = new HashSet<GameObject>(3) { gameObject };

            ProcessedComponent(passDragXTo, ref _dragHandlerX);
            ProcessedComponent(passDragYTo, ref _dragHandlerY);
        }

        /// <summary>
        /// Выполнить действия над компонентом перемещения
        /// </summary>
        private void ProcessedComponent(Component component, ref IDragHandler _dragHandler2)
        {
            if (component == null)
                return;

            _dragHandler2 = (IDragHandler)component;
            _exceptionObjects.Add(component.gameObject);

            if (_dragHandler2 is ScrollRect sr)
            {
                _scrollRect = sr;
            }
        }

        #endregion

        #region Dragging

        /// <summary>
        /// Обработка нажатия на компонент
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            _raycastEventData.position = eventData.position;

            if (_scrollRect != null)
            {
                _scrollRect.StopMovement();
            }
        }

        /// <summary>
        /// Обработка начала перемещения
        /// </summary>
        public void OnBeginDrag(PointerEventData eventData)
        {
            _hasDragHandler = TryGetDragHandler(eventData, ref _dragHandler);

            if (_hasDragHandler && _dragHandler is IBeginDragHandler beginDragHandler)
            {
                beginDragHandler.OnBeginDrag(eventData);
            }
        }

        /// <summary>
        /// Обработка перемещения
        /// </summary>
        public void OnDrag(PointerEventData eventData)
        {
            if (!_hasDragHandler)
                return;

            _dragHandler.OnDrag(eventData);
        }

        /// <summary>
        /// Обработка завершения перемещения
        /// </summary>
        public void OnEndDrag(PointerEventData eventData)
        {
            if (!_hasDragHandler)
                return;

            if (_dragHandler is IEndDragHandler endDragHandler)
            {
                endDragHandler.OnEndDrag(eventData);
            }

            _hasDragHandler = false;
            _dragHandler = null;
        }

        /// <summary>
        /// Возвращает компонент типа <see cref="IDragHandler"/>
        /// </summary>
        private bool TryGetDragHandler(PointerEventData eventData, ref IDragHandler result)
        {
            var offset = GetDragOffset(eventData);

            if (offset.x > 0 && passDragXTo != null)
            {
                result = _dragHandlerX;
                return true;
            }

            if (offset.y > 0 && passDragYTo != null)
            {
                result = _dragHandlerY;
                return true;
            }

            return TryRaycastDragHandler(_raycastEventData, ref result);
        }

        #endregion

        #region Calculations

        /// <summary>
        /// Находит компонент типа <see cref="IDragHandler"/>
        /// </summary>
        private bool TryRaycastDragHandler(PointerEventData eventData, ref IDragHandler result)
        {
            var raycastResults = new List<RaycastResult>();

            EventSystem.current.RaycastAll(eventData, raycastResults);

            foreach (var raycast in raycastResults)
            {
                if (_exceptionObjects.Contains(raycast.gameObject))
                    continue;

                if (raycast.gameObject.TryGetComponent<IDragHandler>(out result))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Возвращает вектор перемещения курсора
        /// </summary>
        private Vector2 GetDragOffset(PointerEventData eventData)
        {
            var offsetX = Mathf.Abs(eventData.pressPosition.x - eventData.position.x) * axialMultiplier.x;
            var offsetY = Mathf.Abs(eventData.pressPosition.y - eventData.position.y) * axialMultiplier.y;

            return offsetX > offsetY ? new Vector2(offsetX, 0) : new Vector2(0, offsetY);
        }

        #endregion
    }
}