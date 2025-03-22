using System;
using UnityEngine;

namespace Game.UI.Utils
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
        /// Возвращает состояние пересечения двух трансформов
        /// </summary>
        /// <param name="rect">Заданный трансформ</param>
        /// <param name="other">Другой трансформ</param>
        public static bool Overlaps(this RectTransform rect, RectTransform other)
        {
            return rect.GetWorldRect().Overlaps(other.GetWorldRect());
        }

        /// <summary>
        /// Возвращает состояние пересечения точки трансформа
        /// </summary>
        /// <param name="rect">Заданный трансформ</param>
        /// <param name="screenPoint">Позиция на экране</param>
        public static bool Overlaps(this RectTransform rect, Vector2 screenPoint)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, Camera.main,
                out var localPosition);

            return rect.rect.Contains(localPosition);
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
        /// <param name="rect">Заданный трансформ</param>
        public static bool IsFullyVisible(this RectTransform rect)
        {
            return CountCornersVisibleFrom(rect) == 4;
        }

        /// <summary>
        /// Проверяет видимость трансформа
        /// </summary>
        /// <param name="rect">Заданный трансформ</param>
        public static bool IsVisible(this RectTransform rect)
        {
            return CountCornersVisibleFrom(rect) > 0;
        }

        /// <summary>
        /// Возвращает количество видимых углов трансформа
        /// </summary>
        /// <param name="rect">Заданный трансформ</param>
        private static int CountCornersVisibleFrom(this RectTransform rect)
        {
            if (!rect.gameObject.activeInHierarchy)
                return 0;

            var screenBounds = new Rect(0f, 0f, Screen.width, Screen.height);
            var objectCorners = new Vector3[4];
            var result = 0;

            rect.GetWorldCorners(objectCorners);

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