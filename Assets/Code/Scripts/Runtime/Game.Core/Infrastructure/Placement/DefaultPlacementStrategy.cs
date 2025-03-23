using System.Collections.Generic;
using System.Linq;
using Game.Infrastructure.Interfaces;
using Game.Services.Interfaces;
using Game.ViewModels;
using UnityEngine;

namespace Game.Infrastructure
{
    public class DefaultPlacementStrategy : IPlacementStrategy
    {
        private readonly IBoxRepository _boxRepository;

        private readonly Vector2 _boxSize;

        public DefaultPlacementStrategy(IBoxRepository boxRepository, IConfigService configService)
        {
            _boxSize = configService.GetConfig().BoxSize;
            _boxRepository = boxRepository;
        }

        public bool TryPlace(TowerViewModel towerViewModel, BoxViewModel boxViewModel, Vector2 boxPosition)
        {
            boxViewModel.Position.Value = boxPosition;

            return true;
        }

        private IList<BoxViewModel> GetSortedBoxes(TowerViewModel towerViewModel)
        {
            return towerViewModel.BoxIds
                .Select(x => _boxRepository.GetBoxById(x))
                .OrderBy(x => x.Position.Value.y)
                .ToList();
        }
    }
}