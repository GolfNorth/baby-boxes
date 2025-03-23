using Game.Enums;
using Game.Events;
using Game.Infrastructure.Interfaces;
using Game.SDK.Infrastructure.Interfaces;
using Game.ViewModels;
using UnityEngine;
using VContainer.Unity;

namespace Game.Infrastructure
{
    public class PlacementSystem : IPlacementSystem, IStartable
    {
        private readonly IPlacementFactory _placementFactory;

        private readonly IBoxRepository _boxRepository;

        private readonly IEventBus _eventBus;

        private readonly TowerViewModel _towerViewModel;

        public PlacementSystem(IBoxRepository boxRepository, ITowerRepository towerRepository, IEventBus eventBus,
            IPlacementFactory placementFactory)
        {
            _boxRepository = boxRepository;
            _eventBus = eventBus;
            _placementFactory = placementFactory;
            _towerViewModel = towerRepository.GetTower();
        }

        public void Start()
        {
            _eventBus.Subscribe<BoxDroppedEvent>(OnBoxDropped);
        }

        private void OnBoxDropped(BoxDroppedEvent e)
        {
            var viewModel = _boxRepository.GetBoxById(e.Id);

            switch (e.Placement)
            {
                case BoxPlacement.Tower:
                    PlaceBox(viewModel, e.Position);
                    break;
                case BoxPlacement.Bin:
                    RemoveBox(viewModel);
                    break;
                default:
                    DestroyBox(viewModel);
                    break;
            }
        }

        private void PlaceBox(BoxViewModel viewModel, Vector2 position)
        {
            var strategy = _placementFactory.GetStrategy(_towerViewModel, viewModel);

            if (strategy.TryPlace(_towerViewModel, viewModel, position))
            {
                viewModel.State.Value = BoxState.Placed;
                _eventBus.Publish(new BoxPlacedEvent(viewModel.Id.CurrentValue, viewModel.Position.Value));
            }
            else
            {
                DestroyBox(viewModel);
            }
        }

        private void RemoveBox(BoxViewModel viewModel)
        {
            if (viewModel.State.Value == BoxState.Placed)
            {
                viewModel.State.Value = BoxState.Removed;
                _eventBus.Publish(new BoxRemovedEvent(viewModel.Id.CurrentValue));
            }
            else
            {
                DestroyBox(viewModel);
            }
        }

        private void DestroyBox(BoxViewModel viewModel)
        {
            viewModel.State.Value = BoxState.Destroyed;
            _eventBus.Publish(new BoxDestroyedEvent(viewModel.Id.CurrentValue));
        }
    }
}