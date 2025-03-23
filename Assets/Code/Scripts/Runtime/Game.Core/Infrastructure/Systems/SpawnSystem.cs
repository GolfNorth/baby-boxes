using Game.Enums;
using Game.Events;
using Game.Infrastructure.Interfaces;
using Game.Models;
using Game.SDK.Infrastructure.Interfaces;
using Game.Services.Interfaces;
using Game.ViewModels;
using UnityEngine;
using VContainer.Unity;

namespace Game.Infrastructure
{
    public class SpawnSystem : ISpawnSystem, IStartable
    {
        private readonly IBoxRepository _boxRepository;

        private readonly IEventBus _eventBus;

        private readonly TowerViewModel _towerViewModel;

        private readonly GameConfig _gameConfig;

        public SpawnSystem(IBoxRepository boxRepository, ITowerRepository towerRepository, IEventBus eventBus,
            IConfigService configService)
        {
            _boxRepository = boxRepository;
            _eventBus = eventBus;

            _towerViewModel = towerRepository.GetTower();
            _gameConfig = configService.GetConfig();

            _eventBus.Subscribe<BoxDroppedEvent>(OnBoxDropped);
        }

        public void Start()
        {
            SpawnTower();
            SpawnPalette();
        }

        private void OnBoxDropped(BoxDroppedEvent e)
        {
            var viewModel = _boxRepository.GetBoxById(e.Id);

            if (viewModel.State.Value == BoxState.Placed)
                return;

            SpawnBox(viewModel.Color.CurrentValue);
        }

        /// <summary>
        /// Создать кубы внутри башни
        /// </summary>
        private void SpawnTower()
        {
            foreach (var viewModel in _boxRepository.Boxes)
            {
                if (viewModel.State.Value != BoxState.Placed)
                    continue;

                _towerViewModel.AddBox(viewModel.Id.CurrentValue);
                _eventBus.Publish(new BoxCreatedEvent(viewModel.Id.CurrentValue));
            }
        }

        /// <summary>
        /// Создать палитру кубов
        /// </summary>
        private void SpawnPalette()
        {
            foreach (var color in _gameConfig.BoxColors)
            {
                SpawnBox(color);
            }
        }

        private void SpawnBox(Color color)
        {
            var viewModel = _boxRepository.AddBox(color);
            viewModel.State.Value = BoxState.Idle;

            _eventBus.Publish(new BoxCreatedEvent(viewModel.Id.CurrentValue));
        }
    }
}