using Game.Enums;
using Game.Presentation.Events;
using Game.Presentation.Views;
using Game.SDK.Infrastructure.Interfaces;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;

namespace Game.Presentation.Infractructure
{
    /// <summary>
    /// Контроллер освобождения визуализатора куба обратно в пул
    /// </summary>
    public class BoxReleaseController : MonoBehaviour
    {
        private IEventBus _eventBus;

        private IObjectPool<BoxView> _boxPool;

        [Inject]
        public void Construct(IObjectPool<BoxView> boxPool, IEventBus eventBus)
        {
            _eventBus = eventBus;
            _boxPool = boxPool;

            _eventBus.Subscribe<BoxTweenedEvent>(OnBoxTweened);
        }

        private void OnBoxTweened(BoxTweenedEvent e)
        {
            var state = e.View.DataContext.CurrentValue.State.Value;

            if (state == BoxState.Destroyed || state == BoxState.Removed)
            {
                _eventBus.Publish(new BoxReleasedEvent(e.View.Id));
                _boxPool.Release(e.View);
            }
        }
    }
}