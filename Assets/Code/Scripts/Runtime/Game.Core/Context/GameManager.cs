using Game.SDK.Infrastructure.Interfaces;
using Game.Controllers;
using Game.Events;
using Game.Infrastructure.Interfaces;
using Game.Models;
using Game.Services.Interfaces;
using Game.Systems.Interfaces;
using VContainer.Unity;

namespace Game.Context
{
    /// <summary>
    /// Игровая точка входа
    /// </summary>
    public sealed class GameManager : IStartable
    {
        private readonly IBoxRepository _boxRepository;

        private readonly ITowerRepository _towerRepository;

        private readonly IEventBus _eventBus;

        private readonly ISaveService _saveService;

        private readonly IConfigService _configService;

        private TowerViewModel _towerViewModel;

        private GameConfig _gameConfig;

        public GameManager(IBoxRepository boxRepository, ITowerRepository towerRepository,
            IEventBus eventBus, ISaveService saveService, IConfigService configService)
        {
            _boxRepository = boxRepository;
            _towerRepository = towerRepository;
            _eventBus = eventBus;
            _saveService = saveService;
            _configService = configService;
        }

        public void Start()
        {
            _towerViewModel = _towerRepository.GetTower();
            _gameConfig = _configService.GetConfig();

            SpawnBoxes();

            // TODO Загрузка сейва, 
        }

        private void SpawnBoxes()
        {
            foreach (var color in _gameConfig.BoxColors)
            {
                var viewModel = _boxRepository.CreateBox(color);

                _eventBus.Publish(new BoxCreatedEvent(viewModel.Id.CurrentValue));
            }
        }
    }
}