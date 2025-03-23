using System;
using UnityEngine;

namespace Game.Presentation.Utils
{
    /// <summary>
    /// Методы расширения для компонента <see cref="RectTransform"/>
    /// </summary>
    public static class RectTransformExtensions
    {
        /// <summary>
        /// Возвращает прямоугольник относительно <see cref="Canvas"/>
        /// </summary>
        /// <param name="rect">Заданный трансформ</param>
        public static Rect GetWorldRect(this RectTransform rect)
        {
            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            var corners = new Vector3[4];
            rect.GetWorldCorners(corners);

            var bottomLeft = corners[0];
            var topRight = corners[2];
            var size = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

            return new Rect(bottomLeft, size);
        }

        /// <summary>
        /// Содержит ли полностью заданный трансформ другой
        /// </summary>
        /// <param name="rectA">Заданный трансформ</param>
        /// <param name="rectB">Другой трансформ</param>
        public static bool Contains(this RectTransform rectA, RectTransform rectB)
        {
            var worldRectA = rectA.GetWorldRect();
            var worldRectB = rectB.GetWorldRect();

            return worldRectA.xMin <= worldRectB.xMin && worldRectA.xMax >= worldRectB.xMax &&
                   worldRectA.yMin <= worldRectB.yMin && worldRectA.yMax >= worldRectB.yMax;
        }

        /// <summary>
        /// Возвращает состояние пересечения двух трансформов
        /// </summary>
        /// <param name="rect">Заданный трансформ</param>
        /// <param name="other">Другой трансформ</param>
        public static bool Overlaps(this RectTransform rect, RectTransform other)
        {
            return rect.GetWorldRect().Overlaps(other.GetWorldRect());
        }

        /// <summary>
        /// Возвращает относительную позицию трансформа
        /// </summary>
        /// <param name="from">Трансформ цели</param>
        /// <param name="to">Трансформ отсчета</param>
        public static Vector2 GetRelativePosition(this RectTransform from, RectTransform to)
        {
            var screenPoint = RectTransformUtility.WorldToScreenPoint(null, from.position);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(to, screenPoint, null, out var localPoint);
            return localPoint;
        }

        /// <summary> 
        /// Упрощенный доступ к методу ScreenPointToWorldPointInRectangle
        /// </summary>
        public static bool TryGetWorldPoint(this RectTransform rect, Vector2 screenPosition, out Vector3 worldPoint)
        {
            return RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, screenPosition,
                Camera.main, out worldPoint);
        }

        /// <summary>
        /// Проверяет полную видимость трансформа
        /// </summary>
        /// <param name="_rectTransform">Заданный трансформ</param>
        public static bool IsFullyVisible(this RectTransform _rectTransform)
        {
            return CountCornersVisibleFrom(_rectTransform) == 4;
        }

        /// <summary>
        /// Проверяет видимость трансформа
        /// </summary>
        /// <param name="_rectTransform">Заданный трансформ</param>
        public static bool IsVisible(this RectTransform _rectTransform)
        {
            return CountCornersVisibleFrom(_rectTransform) > 0;
        }

        /// <summary>
        /// Возвращает количество видимых углов трансформа
        /// </summary>
        /// <param name="_rectTransform">Заданный трансформ</param>
        private static int CountCornersVisibleFrom(this RectTransform _rectTransform)
        {
            if (!_rectTransform.gameObject.activeInHierarchy)
                return 0;

            var screenBounds = new Rect(0f, 0f, Screen.width, Screen.height);
            var objectCorners = new Vector3[4];
            var result = 0;

            _rectTransform.GetWorldCorners(objectCorners);

            for (var i = 0; i < objectCorners.Length; i++)
            {
                var screenSpaceCorner = Camera.main.WorldToScreenPoint(objectCorners[i]);

                if (screenBounds.Contains(screenSpaceCorner))
                {
                    result++;
                }
            }

            return result;
        }
    }
}