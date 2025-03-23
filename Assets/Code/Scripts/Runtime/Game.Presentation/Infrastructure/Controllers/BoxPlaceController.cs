using System;
using Game.Enums;
using Game.Events;
using Game.Presentation.Components;
using Game.Presentation.Events;
using Game.Presentation.Views;
using Game.SDK.Infrastructure.Interfaces;
using UnityEngine;
using VContainer;

namespace Game.Presentation.Infractructure
{
    public class BoxPlaceController : MonoBehaviour
    {
        [SerializeField]
        private BoxPlaceholder towerPlaceholder;

        [SerializeField]
        private BoxPlaceholder binPlaceholder;

        private IEventBus _eventBus;

        private Func<int, BoxView> _viewFactory;

        [Inject]
        public void Construct(Func<int, BoxView> viewFactory, IEventBus eventBus)
        {
            _eventBus = eventBus;
            _viewFactory = viewFactory;

            eventBus.Subscribe<BoxRemovedEvent>(OnBoxRemoved);
            eventBus.Subscribe<BoxPlacedEvent>(OnBoxPlaced);
            eventBus.Subscribe<BoxReturnedEvent>(OnBoxReturned);
            eventBus.Subscribe<BoxDestroyedEvent>(OnBoxDestroyed);
        }

        private void OnBoxPlaced(BoxPlacedEvent e)
        {
            var view = _viewFactory.Invoke(e.Id);

            towerPlaceholder.Place(view);

            _eventBus.Publish(new BoxPlacementChangedEvent(view, BoxPlacement.Tower));
        }

        private void OnBoxReturned(BoxReturnedEvent e)
        {
            var view = _viewFactory.Invoke(e.Id);

            towerPlaceholder.Place(view);

            _eventBus.Publish(new BoxPlacementChangedEvent(view, BoxPlacement.Tower));
        }

        private void OnBoxRemoved(BoxRemovedEvent e)
        {
            var view = _viewFactory.Invoke(e.Id);

            binPlaceholder.Place(view);

            _eventBus.Publish(new BoxPlacementChangedEvent(view, BoxPlacement.Bin));
        }

        private void OnBoxDestroyed(BoxDestroyedEvent e)
        {
            var view = _viewFactory.Invoke(e.Id);

            _eventBus.Publish(new BoxPlacementChangedEvent(view, BoxPlacement.None));
        }
    }
}