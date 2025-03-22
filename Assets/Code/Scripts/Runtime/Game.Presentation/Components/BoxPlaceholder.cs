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
            boxView.transform.SetParent(transform);
            boxView.transform.localScale = Vector3.one;
            boxView.transform.localPosition = Vector3.zero;
        }
    }
}