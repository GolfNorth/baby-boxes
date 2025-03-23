using Game.Presentation.Views;
using UnityEngine;

namespace Game.Presentation.Components
{
    /// <summary>
    /// Враппер для кубов
    /// </summary>
    public class BoxPlaceholder : MonoBehaviour
    {
        public void Place(BoxView boxView)
        {
            PlaceAndResetScale(boxView);
        }

        public void Place(BoxView boxView, Vector2 position)
        {
            PlaceAndResetScale(boxView);

            var boxRect = (RectTransform)boxView.transform;

            boxRect.anchoredPosition = position;
        }

        private void PlaceAndResetScale(BoxView boxView)
        {
            boxView.transform.SetParent(transform, true);
            boxView.transform.localScale = Vector3.one;
        }
    }
}