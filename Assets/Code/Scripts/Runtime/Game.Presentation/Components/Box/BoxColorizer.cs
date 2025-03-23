using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation.Components
{
    /// <summary>
    /// Устанавливает цвет куба
    /// </summary>
    public class BoxColorizer : BoxComponent
    {
        [SerializeField]
        private Image image;

        protected override void OnDataContextChanged()
        {
            DataContext.Color.Subscribe(OnColorChanged).AddTo(this);
        }

        private void OnColorChanged(Color color)
        {
            image.color = color;
        }
    }
}