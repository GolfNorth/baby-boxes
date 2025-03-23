using Game.ViewModels;
using R3;
using UnityEngine;

namespace Game.Presentation.Views
{
    /// <summary>
    /// Вьюшка куба
    /// </summary>
    public class BoxView : MonoBehaviour
    {
        private readonly ReactiveProperty<BoxViewModel> _dataContext = new();

        public ReadOnlyReactiveProperty<BoxViewModel> DataContext => _dataContext;

        public RectTransform Rect { get; private set; }

        public int Id => DataContext != null ? DataContext.CurrentValue.Id.CurrentValue : -1;

        public Color Color => DataContext != null ? DataContext.CurrentValue.Color.CurrentValue : Color.white;

        private void Awake()
        {
            Rect = (RectTransform)transform;
        }

        public void Init(BoxViewModel dataContext)
        {
            gameObject.name = $"Box Id:{dataContext.Id.CurrentValue}";
            _dataContext.Value = dataContext;
        }
    }
}