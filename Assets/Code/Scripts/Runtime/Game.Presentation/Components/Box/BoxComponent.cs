using Game.ViewModels;
using Game.Presentation.Views;
using R3;
using UnityEngine;

namespace Game.Presentation.Components
{
    /// <summary>
    /// Базовый класс для компонентов куба
    /// </summary>
    public abstract class BoxComponent : MonoBehaviour
    {
        [SerializeField]
        private BoxView view;

        protected BoxView View => view;

        protected BoxViewModel DataContext => view.DataContext.CurrentValue;

        protected virtual void Awake()
        {
            view.DataContext.Subscribe(OnDataContextChanged);
        }

        protected virtual void OnDataContextChanged(BoxViewModel dataContext)
        {
            if (dataContext == null)
                return;

            OnDataContextChanged();
        }

        protected virtual void OnDataContextChanged()
        {
        }
    }
}